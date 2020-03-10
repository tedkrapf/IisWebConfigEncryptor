using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using Microsoft.Web.Administration;
using System.Web;
using System.Web.Configuration;
using System.IO;

namespace WebConfigEncryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class MySites
        {
            public long ID { get; set; }
            public string SiteName { get; set; }
            public string Path { get; set; }
            public string RunningState { get; set; }
            public string ConnectionStringState { get; set; }
            public string AppSettingsState { get; set; }
            public string Action { get; set; }

            public MySites(long id, string name, string path, string state)
            {
                ID = id;
                SiteName = name;
                Path = path;
                RunningState = state;
                ConnectionStringState = ConfigStatus(path, "connectionStrings");
                AppSettingsState = ConfigStatus(path, "appSettings"); ;
                Action = ConnectionStringState == "Protected" ? "decrypt me" : "encrypt me";
            }
        }

        private void btnGetSites_Click(object sender, EventArgs e)
        {
            MySiteGrid_Refresh();
        }

        public void MySiteGrid_Refresh()
        {
            List<MySites> mySites = new List<MySites>();
            ServerManager iis = new ServerManager();
            foreach(Site site in iis.Sites)
                mySites.Add(new MySites(site.Id, site.Name, site.Applications["/"].VirtualDirectories[0].PhysicalPath, site.State.ToString()));
            mySites = mySites.OrderBy(c => c.SiteName).ToList();

            gvSites.RowHeadersVisible = false;
            gvSites.DataSource = mySites;

            foreach(DataGridViewColumn c in gvSites.Columns)
            {
                int width = c.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
                c.Width = width;
            }
        }

        private void mySitesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gvSites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gvSites.CurrentCell.OwningColumn.Name;

            string path = gvSites.CurrentRow.Cells["Path"].Value.ToString();
            int siteID = Convert.ToInt32(gvSites.CurrentRow.Cells["ID"].Value.ToString());
            string action = gvSites.CurrentRow.Cells["Action"].Value.ToString();

            string connectionStringState = gvSites.CurrentRow.Cells["ConnectionStringState"].Value.ToString();
            string appSettingState = gvSites.CurrentRow.Cells["AppSettingsState"].Value.ToString();

            switch (colName)
            {
                case "Action":
                    if (action.ToLower() == "encrypt me")
                    {
                        if (connectionStringState != "not present") EncryptSite(siteID, path, section_ConnStr);
                        if (appSettingState != "not present")       EncryptSite(siteID, path, section_AppSettings);
                    }
                    else if (action.ToLower() == "decrypt me")
                    {
                        if (connectionStringState != "not present") DecryptSite(siteID, path, section_ConnStr);
                        if (appSettingState != "not present")       DecryptSite(siteID, path, section_AppSettings);
                    }
                    MySiteGrid_Refresh();
                    break;
            }
        }


        #region de/encrypt

        string provider = "RSAProtectedConfigurationProvider";
        string section_ConnStr = "connectionStrings";
        string section_AppSettings = "appSettings";

        public static string ConfigStatus(string path, string configType)
        {
            var config = OpenConfigFile(path + "\\web.config");
            var section = config.GetSection(configType);

            if (section == null)
            {
                return "unknown, configSection null";
            }
            else if (section != null && section.ElementInformation.IsPresent)
            {
                bool isProtected = section.SectionInformation.IsProtected;
                if (isProtected)
                    return "Protected";
                else
                    return "Unprotected";
            }
            else
                return "not present";
        }

        private void EncryptSite(int siteID, string path, string sectionType)
        {
            var config = OpenConfigFile(path + "\\web.config");
            var section = config.GetSection(sectionType);

            if (section != null)
            {
                bool isProtected = section.SectionInformation.IsProtected;
                if (isProtected)
                {
                    MessageBox.Show("This is already encrypted, you cannot do this.");
                    return;
                }
                section.SectionInformation.ProtectSection(provider);
                config.Save();
                MessageBox.Show("Config section ("+sectionType+") ENCRYPTED!");
            }
            else
            {
                MessageBox.Show("This config section is null, not encrypted.");
                return;
            }
        }
        private void DecryptSite(int siteID, string path, string sectionType)
        {
            var config = OpenConfigFile(path + "\\web.config");
            var section = config.GetSection(sectionType);

            if (section != null)
            {
                bool isProtected = section.SectionInformation.IsProtected;
                if (!isProtected)
                {
                    MessageBox.Show("This is already decrypted, you cannot do this.");
                    return;
                }
                section.SectionInformation.UnprotectSection();
                config.Save();
                MessageBox.Show("Config section (" + sectionType + ") DECRYPTED!");
            }
            else
            {
                MessageBox.Show("This config section is null, not encrypted.");
                return;
            }
        }


        public static System.Configuration.Configuration OpenConfigFile(string configPath)
        {
            var configFile = new FileInfo(configPath);
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            return System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
        }

        #endregion
    }
}
