using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WinFormMsGraphApp.Properties;
//using System;

namespace VisioAddInSharePoint
  {
  public partial class FormMicrosoftGraph : Form
    {
    IPublicClientApplication publicClientApplication;
    //Set the API Endpoint to Graph 'me' endpoint. 
    // To change from Microsoft public cloud to a national cloud, use another value of graphAPIEndpoint.
    // Reference with Graph endpoints here: https://docs.microsoft.com/graph/deployments#microsoft-graph-and-graph-explorer-service-root-endpoints
    string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";

    //Set the scope for API call to user.read
    string[] scopes = new string[] { "user.read" };
    // Below are the clientId (Application Id) of your app registration and the tenant information. 
    // You have to replace:
    // - the content of ClientID with the Application Id for your app registration
    // - The content of Tenant by the information about the accounts allowed to sign-in in your application:
    //   - For Work or School account in your org, use your tenant ID, or domain
    //   - for any Work or School accounts, use organizations
    //   - for any Work or School accounts, or Microsoft personal account, use common
    //   - for Microsoft Personal account, use consumers
    private static string ClientId = "4a1aa1d5-c567-49d0-ad0b-cd957a47f842";

    // Note: Tenant is important for the quickstart.
    private static string Tenant = "common";
    private static string Instance = "https://login.microsoftonline.com/";
    private static IPublicClientApplication _clientApp;

    public static IPublicClientApplication PublicClientApp { get { return _clientApp; } }



    public FormMicrosoftGraph()
      {
      InitializeComponent();
      }

    public static void CreateApplication()
      {
      BrokerOptions brokerOptions = new BrokerOptions(BrokerOptions.OperatingSystems.Windows);

      _clientApp = PublicClientApplicationBuilder.Create(ClientId)
          .WithAuthority($"{Instance}{Tenant}")
          .WithDefaultRedirectUri()
          .WithBroker(brokerOptions)
          .Build();

      MsalCacheHelper cacheHelper = CreateCacheHelperAsync().GetAwaiter().GetResult();

      // Let the cache helper handle MSAL's cache, otherwise the user will be prompted to sign-in every time.
      cacheHelper.RegisterCache(_clientApp.UserTokenCache);
      }

    private static async Task<MsalCacheHelper> CreateCacheHelperAsync()
      {
      // Since this is a WPF application, only Windows storage is configured
      var storageProperties = new StorageCreationPropertiesBuilder(
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".msalcache.bin",
                        MsalCacheHelper.UserRootDirectory)
                          .Build();

      MsalCacheHelper cacheHelper = await MsalCacheHelper.CreateAsync(
                  storageProperties,
                  new TraceSource("MSAL.CacheTrace"))
               .ConfigureAwait(false);

      return cacheHelper;
      }

    private async void btnCallGraphButton_Click(object sender, EventArgs e)
      {
      AuthenticationResult authResult = null;
      edResultText.Text = string.Empty;
      edTokenInfoText.Text = string.Empty;

      CreateApplication();
      try
        {
        // if the user signed-in before, remember the account info from the cache
        IAccount firstAccount = (await _clientApp.GetAccountsAsync()).FirstOrDefault();
        // otherwise, try witht the Windows account
        if (firstAccount == null)
          {
          firstAccount = PublicClientApplication.OperatingSystemAccount;
          }
        try
          {
          authResult = await _clientApp.AcquireTokenSilent(scopes, firstAccount)
              .ExecuteAsync();
          }
        catch (MsalUiRequiredException ex)
          {
          // A MsalUiRequiredException happened on AcquireTokenSilent. 
          // This indicates you need to call AcquireTokenInteractive to acquire a token
          edResultText.Text += "\r\nError MsalUiRequiredException: " + ex.Message;
          System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

          try
            {
            authResult = await _clientApp.AcquireTokenInteractive(scopes)
                .WithAccount(firstAccount)
                .WithParentActivityOrWindow(this.Handle) // optional, used to center the browser on the window
                .WithPrompt(Prompt.SelectAccount)
                .ExecuteAsync();
            }
          catch (MsalException msalex)
            {
            edResultText.Text = $"Error MsalException Acquiring Token:{System.Environment.NewLine}{msalex}";
            }
          }
        catch (Exception ex)
          {
          edResultText.Text = $"Error Exception Acquiring Token Silently:{System.Environment.NewLine}{ex}";
          return;
          }
        }
      catch (Exception ex)
        {
        edResultText.Text = $"Error Exception:{System.Environment.NewLine}{ex}";
        return;
        }

      if (authResult != null)
        {
        edResultText.Text = await GetHttpContentWithToken(graphAPIEndpoint, authResult.AccessToken);
        DisplayBasicTokenInfo(authResult);
        }
      }

    /// <summary>
    /// Perform an HTTP GET request to a URL using an HTTP Authorization header
    /// </summary>
    /// <param name="url">The URL</param>
    /// <param name="token">The token</param>
    /// <returns>String containing the results of the GET operation</returns>
    public async Task<string> GetHttpContentWithToken(string url, string token)
      {
      var httpClient = new System.Net.Http.HttpClient();
      System.Net.Http.HttpResponseMessage response;
      try
        {
        var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
        //Add the token in Authorization header
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        return content;
        }
      catch (Exception ex)
        {
        return ex.ToString();
        }
      }

    /// <summary>
    /// Display basic information contained in the token
    /// </summary>
    private void DisplayBasicTokenInfo(AuthenticationResult authResult)
      {
      edTokenInfoText.Text = "";
      if (authResult != null)
        {
        edTokenInfoText.Text += $"Username: {authResult.Account.Username}" + Environment.NewLine;
        edTokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
        }
      }

    }
  }
