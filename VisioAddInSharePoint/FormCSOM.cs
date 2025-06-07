using Microsoft.Identity.Client;
using Microsoft.Office.SharePoint.Tools;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using Microsoft.Win32;

//using PnP.Core.Model.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisioAddInSharePoint
  {
  public partial class FormCSOM : System.Windows.Forms.Form
    {
    RegistryKey regKey = null, regCompanyKey, regApplicationKey, regFieldKey;
    string strValue;
    public FormCSOM()
      {
      InitializeComponent();
      InitializeControl();
      }

    void InitializeControl()
      {
      regKey = Registry.CurrentUser;
      if ((regCompanyKey = regKey.CreateSubKey("Software\\ShareVisual")) != null)
        {
        if ((regApplicationKey = regCompanyKey.CreateSubKey("VisioAddInSharePoint")) != null)
          {
          if ((strValue = (String)regApplicationKey.GetValue("ClientApplicationId")) != null)
            {
            edClientApplicationID.Text = strValue;
            }
          if ((strValue = (String)regApplicationKey.GetValue("TenantId")) != null)
            {
            edSharePointTenantID.Text = strValue;
            }
          if ((strValue = (String)regApplicationKey.GetValue("TenantUrl")) != null)
            {
            edSharePointTenantUrl.Text = strValue;
            }
          if ((strValue = (String)regApplicationKey.GetValue("SiteUrl")) != null)
            {
            edSharePointSiteUrl.Text = strValue;
            }
          if ((strValue = (String)regApplicationKey.GetValue("RootFolder")) != null)
            {
            edRootFolder.Text = strValue;
            }
          if ((strValue = (String)regApplicationKey.GetValue("ParentFolder")) != null)
            {
            edParentFolderName.Text = strValue;
            }
          }
        }
      }


    private async void btnSharePointFolders_Click(object sender, EventArgs e)
      {
      edResponse.Text += "\r\btnSharePointFolders_Click enter";
      await ListLibraryFolder();
      edResponse.Text += "\r\btnSharePointFolders_Click leave";
      }

    public async Task ListLibraryFolder()
      {
      edResponse.Text += "\r\nAddFolderToLibrary enter";
      var redirectUri = "http://localhost";
      var siteUrl = edSharePointTenantUrl.Text + "/" + edSharePointSiteUrl.Text;

      // Create an instance of the AuthenticationManager type
      var authManager = PnP.Framework.AuthenticationManager.CreateWithInteractiveLogin(edClientApplicationID.Text,
                                                                                       redirectUri, 
                                                                                       edSharePointTenantID.Text);
      using (var clientContext = await authManager.GetContextAsync(siteUrl))
        {
        try
          {
          // Read web properties
          var web = clientContext.Web;
          clientContext.Load(web, w => w.Id, w => w.Title);
          await clientContext.ExecuteQueryAsync();
          edResponse.Text += $"\r\n{web.Id} - {web.Title}";
          // Read folders
          var folders = web.GetFolderByServerRelativeUrl(edRootFolder.Text);
          clientContext.Load(folders, d => d.Name);
          await clientContext.ExecuteQueryAsync();
          edResponse.Text += $"\r\nFolders : {folders.Name}";
          var files = folders.Files;
          clientContext.Load(files);
          await clientContext.ExecuteQueryAsync();
          edResponse.Text += $"\r\nFile count: {files.Count}";
          foreach (File file in files)
            {
            edResponse.Text += $"\r\nFile Title: {file.Name}";
            }
          }
        catch (Exception ex)
          {
          Debug.WriteLine("Error: " + ex.Message);
          edResponse.Text += $"\r\nError: {ex.Message}";
          }
        }
      edResponse.Text += "\r\nAddFolderToLibrary leave";
      }
    private void FormCSOM_FormClosing(object sender, FormClosingEventArgs e)
      {
      regKey = Registry.CurrentUser;
      if ((regCompanyKey = regKey.CreateSubKey("Software\\ShareVisual")) != null)
        {
        if ((regApplicationKey = regCompanyKey.CreateSubKey("VisioAddInSharePoint")) != null)
          {
          regApplicationKey.SetValue("ClientApplicationId", edClientApplicationID.Text);
          regApplicationKey.SetValue("TenantId", edSharePointTenantID.Text);
          regApplicationKey.SetValue("TenantUrl", edSharePointTenantUrl.Text);
          regApplicationKey.SetValue("SiteUrl", edSharePointSiteUrl.Text);
          regApplicationKey.SetValue("RootFolder", edRootFolder.Text);
          regApplicationKey.SetValue("ParentFolder", edParentFolderName.Text);
          }
        }
      }

    private void btnProcesses_Click(object sender, EventArgs e)
      {
      Process tempProcess = Process.GetCurrentProcess();
      foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
        {
        edResponse.Text += "\r\nModule: " + module.ModuleName + "\t" + module.FileName;
        }
      }

    private void FormCSOM_Load(object sender, EventArgs e)
      {
      edResponse.SelectionTabs = new int[] { 350 };
      }

    private async void btnCreateFolder_Click(object sender, EventArgs e)
      {
      var redirectUri = "http://localhost";
      var siteUrl = edSharePointTenantUrl.Text + "/" + edSharePointSiteUrl.Text;

      // Create an instance of the AuthenticationManager type
      var authManager = PnP.Framework.AuthenticationManager.CreateWithInteractiveLogin(edClientApplicationID.Text,
                                                                                       redirectUri,
                                                                                       edSharePointTenantID.Text);
      using (var clientContext = await authManager.GetContextAsync(siteUrl))
        {
        try
          {
          FolderCollection folderCollection = clientContext.Web.GetFolderByServerRelativeUrl(edRootFolder.Text + "/" + edParentFolderName.Text).Folders;
          clientContext.Load(folderCollection);
          await clientContext.ExecuteQueryAsync();
          bool bFounded = false;
          if (folderCollection.Count != 0)
            {
            foreach (Folder curFolder in folderCollection)
              {
              if (curFolder.Name == edFolderToCreate.Text)
                {
                bFounded = true;
                edResponse.Text += "\r\nError, Folder: " + edFolderToCreate.Text + " already exist";
                break;
                }
              }
            }
          if (bFounded == false)
            {
            folderCollection.Add(edFolderToCreate.Text);
            await clientContext.ExecuteQueryAsync();
            }
          }
        catch (Exception ex)
          {
          edResponse.Text += "\r\nError: " + ex.Message;
          }
        }
      }

    }
  }
