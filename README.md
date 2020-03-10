# IisWebConfigEncryptor
IIS Web.config Encryptor

Yes, you can run the .NET CLI to encrypt the ConnectionStrings and AppSettings sections of your web.config files, but why not have an easy to use GUI for it.

This is a basic, C# WinForms app that retrieves the local IIS sites, and gives you a GUI to encrypt and decrypt the ConnectionStrings and AppSettings sections.

1.) compile & run
2.) click "Get Sites"
3.) view the IIS site IDs, site names, the physical site path, the site's running state, and the protected/unprotected (encrypted/unencrypted) status of each site.
4.) click the site row's "encrypt me" or "decrypt me" button to take that action and view the updated status


Note 1: The encryption uses the Microsoft RSA encryption provider.
Note 2: The app requires Admin UAC elevation.  ClickOnce apps don't natively allow UAC elevation.  You either need to hack a solution into the app (https://stackoverflow.com/questions/5713825/run-as-administrator-requireadministrator-clickonce-emulating-system-time -- I'll try this when I have more time), or do the following:
a.) run the clickonce app per usual
b.) find it in task manager -> details, right click -> open location
c.) locate the (underlying) .exe in the location window, right click -> run as admin
d.) create a shortcut if it makes you feel better ;)

<img src="http://apps.tedkrapf.com/WebConfigEncryptor/sample.jpg" style="width:100%" />
