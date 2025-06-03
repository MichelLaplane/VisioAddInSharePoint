# VisioAddInSharePoint
   This solution is a VSTO Visio addin.
   It provides samples to access SharePoint Online.
## Installation
The solution comes with an installer that contains two files:
- "Installation.msi"
- "cab1.cab"
To install the app, simply launch "Installation.msi".

A dialog box appears:

-![InstallStart](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/InstallStart.png)

Click Install, the solution installs.
Click "Finish" to complete the installation wizard.

![InstallFinish](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/InstallFinish.png)

When you launch "Microsoft Visio", you will have a new tab.

![VisioAddInSharePointTab](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/VisioAddInSharePointTab.png)
## Setting SharePoint Online Application

Sign in on the admin center of the tenant supporting the SharePoint site

![TenantApp](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/TenantApp.png)

Select the identity admin center and the "App Registration" command

![Identity](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Identity.png)

![AppRegistration](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/AppRegistration.png)

The registration page is displayed.
Click on "New Registration" and enter:

- "VisioAddinSharePoint" for the name.
- Accounts in this Organization Directory only (YOURTENANT only - Single Tenant) for the type.
- Public/native client (mobile & desktop) for redirection
- "<https://locahost>" for the redirect URI.

Click on "Register".

![NewRegistration](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/NewRegistration.png)

![Register](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Register.png)

The application is registered. We now have to add the necessary authorisations.

![RegistrationOverview](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/RegistrationOverview.png)

Click on "API Permissions".

![ApiPermissions](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/ApiPermissions.png)

Click on "Add permission" and add the following permissions:

![AddPermissions](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/AddPermissions.png)

First Microsoft Graph permissions in "Microsoft Graph" 

![MicrosoftGraph](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/MicrosoftGraph.png)

Click "Delegated Permissions"

![DelegatedPermission](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/DelegatedPermission.png)

![Directory](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Directory.png)

![Group](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Group.png)

![User](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/User.png)

Click “Add permissions” 

![AddPermissionsButton](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/AddPermissionsButton.png)

Next in "SharePoint"

![SharePointPermissions](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/SharePointPermissions.png)

![AllSites](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/AllSites.png)

![Sites](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Sites.png)

All the authorisations are then present. Click on Grant admin consent.

![GrantAdmin](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/GrantAdmin.png)

All is then set right.

![SetOk](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/SetOk.png)

Now tou need to add the user that will be granted the use of the application.

![UsersAndGroup](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/UsersAndGroup.png)

Click on “Overview” to retrieve all needed information:
- Application (client) ID
- Directory (tenant) ID

![Overview](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/Overview.png)

 ### Warning
 Be sure that the user has also access to the SharePoint site and the document library you want to access.
 ## Using the Addin
 You will find the command available from the “VisioAddInSharePoint” tab.
   >### “CSOM” Command
   >When clicking on this command the Connection to SharePoint dialog is displayed
>
   ![CSOM](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/CSOM.png)
   
   Type the information to access the SharePoint site:
   >- Client Application ID (Grabbed from the VisioAddinSharePoint application registration).
>- SharePoint Tenant ID (Grabbed from the VisioAddinSharePoint application registration).
>- SharePoint Tenant Url (Url of your tenant “https://mycompany.sharepoint.com”)
>- SharePoint Site Url (Url of your site (sites/mySite)
>- Parent folder name (optional ‘MySharePointFolder”, needed only if you use the “Create folder” command)
>Click on the “SharePoint Folders” command to list the folders of your sites. The loggin window is displayed.

   ![LogginWindow](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/LogginWindow.png)
   
   >After logging on your site, the result is displayed.
 
 >### “Microsoft Graph” Command
>When clicking on this command the Connection to the Microsoft's PublicClientApplication dialog is displayed.
>
   ![LogginMsGraph](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/LogginMsGraph.png)
   
   >Click on “Call Microsoft Graph API”, an error message is displayed.
>
   ![MsGraphError](https://github.com/MichelLaplane/VisioAddInSharePoint/blob/master/VisioAddInSharePoint/Readme/MsGraphError.png)
   
   >This error did not occurs if the same code is executed in a window form application.


