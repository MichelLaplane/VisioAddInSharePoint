using Microsoft.Identity.Client;
using Microsoft.Office.SharePoint.Tools;
using Microsoft.SharePoint.Client;
//using PnP.Core.Model.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisioAddInSharePoint
  {
  public partial class FormCSOM : System.Windows.Forms.Form
    {
    public FormCSOM()
      {
      InitializeComponent();
      InitializeControl();
      }

    void InitializeControl()
      {
      edClientApplicationID.Text = "";
      edSharePointTenantID.Text = "";
      edSharePointTenantUrl.Text = "";
      edSharePointSiteUrl.Text = "";
      edRootFolder.Text = "Documents partages";
      //edParentLibrary.Text = "Documents";
      edParentFolderName.Text = "";
      }

    private async void btnSharePointFolders_Click(object sender, EventArgs e)
      {
      edResponse.Text += "\r\btnSharePointFolders_Click enter";
      //Task.Run(() => AddFolderToLibrary()).Wait();
      await AddFolderToLibrary();
      edResponse.Text += "\r\btnSharePointFolders_Click leave";
      }

    public async Task AddFolderToLibrary()
      {
      edResponse.Text += "\r\nAddFolderToLibrary enter";

      var siteUrl = new Uri(edSharePointTenantUrl.Text + "/" + edSharePointSiteUrl.Text);

      var accessToken = await AcquireTokenAsync(siteUrl);
      using (var clientContext = new ClientContext(siteUrl))
        {
        clientContext.ExecutingWebRequest += async (sender, e) =>
          {
            // Insert the access token in the request
            e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
          };
        try
          {
          // Read web properties
          var web = clientContext.Web;
          clientContext.Load(web, w => w.Id, w => w.Title);
          await clientContext.ExecuteQueryAsync();
          Debug.WriteLine($"{web.Id} - {web.Title}");
          edResponse.Text += "\r\nWeb Site ID: " + web.Id + " Web Site Title" + web.Title;
          // Read folders
          var folders = web.GetFolderByServerRelativeUrl(edRootFolder.Text);
          clientContext.Load(folders, d => d.Name);
          await clientContext.ExecuteQueryAsync();
          Debug.WriteLine($"Folders : {folders.Name} ");
          edResponse.Text += "\r\nFolders: " + folders.Name;
          var files = folders.Files;
          clientContext.Load(files);
          await clientContext.ExecuteQueryAsync();
          edResponse.Text += "\r\nFile count: " + files.Count;
          foreach (File file in files)
            {
            Debug.WriteLine("\r\nFile Title: " + file.Name);
            edResponse.Text += "\r\nFile Title: " + file.Name;
            }
          }
        catch (Exception ex)
          {
          Debug.WriteLine("Error: " + ex.Message);
          edResponse.Text += "\r\nError: " + ex.Message;
          }
        }
      edResponse.Text += "\r\nAddFolderToLibrary leave";
      }

    async Task<string> AcquireTokenAsync(Uri siteUrl)
      {
      AuthenticationResult result=null;
      var clientId = edClientApplicationID.Text;
      var tenantId = edSharePointTenantID.Text;
      var authority = $"https://login.microsoftonline.com/{tenantId}/";
      var redirectUri = "";

      string resource = $"{siteUrl.Scheme}://{siteUrl.Authority}";

      var scopes = new String[] { $"{resource}/.default" };
      //      string[] scopes = new string[] { "user.read" };
      // .WithDefaultRedirectUri()
      edResponse.Text += "\r\nAcquireTokenAsync enter";

      IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                      .Create(clientId)
                      .WithTenantId(tenantId)
                      .WithAuthority(authority)
                      .WithRedirectUri(redirectUri)
                      .Build();
      try
        {
        edResponse.Text += "\r\nAcquireTokenAsync AcquireTokenInteractive";
        result = await publicClientApplication
            .AcquireTokenInteractive(scopes)
            .ExecuteAsync();
        }
      catch(Exception ex)
        {
        edResponse.Text += "\r\nAcquireTokenAsync exception" + ex.Message;
        }
      //catch (MsalUiRequiredException ex)
      //  {
      //  edResponse.Text += "\r\nAcquireTokenAsync AcquireTokenInteractive exception";
      //  }
      //IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
      //                .Create(clientId)
      //                .WithTenantId(tenantId)
      //                .WithAuthority(authority)
      //                .WithDefaultRedirectUri()
      //                .Build();
      //edResponse.Text += "\r\nAcquireTokenAsync after PublicClientApplicationBuilder creation";

      AuthenticationResult tokenResult = null;

      // Try to see if we already have an account in the cache
      var account = await publicClientApplication.GetAccountsAsync().ConfigureAwait(false);
      //edResponse.Text += "\r\nAcquireTokenAsync after account get";
      try
        {



        Console.WriteLine($"Access Token: {result.AccessToken}");


        // Try to get the token from the tokens cache
        tokenResult = await publicClientApplication.AcquireTokenSilent(scopes, account.FirstOrDefault())
            .ExecuteAsync().ConfigureAwait(false);
        }
      catch (MsalUiRequiredException)
        {
        //edResponse.Text += "\r\nAcquireTokenAsync catch (MsalUiRequiredException)";
        // Try to get the token directly through AAD if it is not available in the tokens cache
        try
          {
          //edResponse.Text += "\r\nAcquireTokenAsync before AcquireTokenInteractive";
          tokenResult = await publicClientApplication.AcquireTokenInteractive(scopes)
              .ExecuteAsync().ConfigureAwait(false);
          }
        catch (Exception except)
          {
          //edResponse.Text += "\r\nAcquireTokenInteractive exception" + except.Message;
          }
        }
      //edResponse.Text += "\r\nAcquireTokenAsync leave";
      return tokenResult != null ? tokenResult.AccessToken : null;
      }

    private async void btnCreateFolder_Click(object sender, EventArgs e)
      {
      List listLibrary = null;
      FolderCollection colLibraryFolders = null;
      Folder folderAdded;

      var siteUrl = new Uri(edSharePointTenantUrl.Text + "/" + edSharePointSiteUrl.Text);
      var accessToken = await AcquireTokenAsync(siteUrl);
      using (var clientContext = new ClientContext(siteUrl))
        {
        clientContext.ExecutingWebRequest += async (senderCF, eCF) =>
        {
          // Insert the access token in the request
          eCF.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
        };
        try
          {
          FolderCollection folderCollection = clientContext.Web.GetFolderByServerRelativeUrl(edRootFolder.Text + "/" + edParentFolderName.Text).Folders;
          clientContext.Load(folderCollection);
          clientContext.ExecuteQuery();
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
            clientContext.ExecuteQuery();
            }
          }
        catch (Exception ex)
          {
          Debug.WriteLine("Error: " + ex.Message);
          edResponse.Text += "\r\nError: " + ex.Message;
          }
        }
      }

    public List GetListByUrl(ClientContext clientContext, ListCollection lists, string strURL)
      {
      List listFolderList = null;

      foreach (List curList in lists)
        {
        Folder curRoot = curList.RootFolder;
        clientContext.Load(curRoot);
        clientContext.ExecuteQuery();
        if (curRoot.ServerRelativeUrl == strURL)
          {
          // On a trouvé la librairie
          listFolderList = curList;
          break;
          }
        }
      return listFolderList;
      }

    }
  }
