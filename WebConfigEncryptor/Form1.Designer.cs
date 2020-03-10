namespace WebConfigEncryptor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetSites = new System.Windows.Forms.Button();
            this.gvSites = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunningState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectionStringState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppSettingsState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvSites)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetSites
            // 
            this.btnGetSites.Location = new System.Drawing.Point(28, 12);
            this.btnGetSites.Name = "btnGetSites";
            this.btnGetSites.Size = new System.Drawing.Size(75, 23);
            this.btnGetSites.TabIndex = 1;
            this.btnGetSites.Text = "Get Sites";
            this.btnGetSites.UseVisualStyleBackColor = true;
            this.btnGetSites.Click += new System.EventHandler(this.btnGetSites_Click);
            // 
            // gvSites
            // 
            this.gvSites.AllowUserToAddRows = false;
            this.gvSites.AllowUserToDeleteRows = false;
            this.gvSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SiteName,
            this.Path,
            this.RunningState,
            this.ConnectionStringState,
            this.AppSettingsState,
            this.Action});
            this.gvSites.Location = new System.Drawing.Point(28, 67);
            this.gvSites.Name = "gvSites";
            this.gvSites.ReadOnly = true;
            this.gvSites.Size = new System.Drawing.Size(1233, 557);
            this.gvSites.TabIndex = 2;
            this.gvSites.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSites_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // SiteName
            // 
            this.SiteName.DataPropertyName = "SiteName";
            this.SiteName.HeaderText = "SiteName";
            this.SiteName.Name = "SiteName";
            this.SiteName.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.DataPropertyName = "Path";
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // RunningState
            // 
            this.RunningState.DataPropertyName = "RunningState";
            this.RunningState.HeaderText = "RunningState";
            this.RunningState.Name = "RunningState";
            this.RunningState.ReadOnly = true;
            // 
            // ConnectionStringState
            // 
            this.ConnectionStringState.DataPropertyName = "ConnectionStringState";
            this.ConnectionStringState.HeaderText = "ConnectionStringState";
            this.ConnectionStringState.Name = "ConnectionStringState";
            this.ConnectionStringState.ReadOnly = true;
            // 
            // AppSettingsState
            // 
            this.AppSettingsState.DataPropertyName = "AppSettingsState";
            this.AppSettingsState.HeaderText = "AppSettingsState";
            this.AppSettingsState.Name = "AppSettingsState";
            this.AppSettingsState.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.DataPropertyName = "Action";
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 658);
            this.Controls.Add(this.gvSites);
            this.Controls.Add(this.btnGetSites);
            this.Name = "Form1";
            this.Text = "IIS Web.Config Encryptor";
            ((System.ComponentModel.ISupportInitialize)(this.gvSites)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGetSites;
        private System.Windows.Forms.DataGridView gvSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunningState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionStringState;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppSettingsState;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}

