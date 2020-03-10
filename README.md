# IisWebConfigEncryptor
IIS Web.config Encryptor

Yes, you can run the .NET CLI to encrypt the ConnectionStrings and AppSettings sections of your web.config files, but why not have an easy to use GUI for it.

This is a basic, C# WinForms app that retrieves the local IIS sites, and gives you a GUI to encrypt and decrypt the ConnectionStrings and AppSettings sections.

1.) compile & run
2.) click "Get Sites"
3.) view the IIS site IDs, site names, the physical site path, the site's running state, and the protected/unprotected (encrypted/unencrypted) status of each site.
4.) click the site row's "encrypt me" or "decrypt me" button to take that action and view the updated status


Note, the encryption uses the Microsoft RSA encryption provider.
