using System;
using Ory.Client.Api;
using Ory.Client.Client;
using Ory.Client.Model;

using OryAuthMauiShared.Models;

namespace OryAuthMauiMvvm;

public class AppShell : Shell
{
    private readonly FrontendApi _frontendApi;
    private readonly ISecureStorage _secureStorage;

    bool isLoggedIn = false;

    public AppShell(ISecureStorage secureStorage)
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
        _secureStorage = secureStorage;

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));

      
         Task.Run(async () => await CheckIfUserIsLoggedIn()).Wait();

        TabBar loginTab = new TabBar
        {
            Items =
            {
                new ShellContent { Route = nameof(LoginPage), ContentTemplate = new DataTemplate(typeof(LoginPage)) }
            }
        };

        TabBar mainTab = new TabBar
        {
            Items =
            {
                new ShellContent { Route = nameof(MainPage), ContentTemplate = new DataTemplate(typeof(MainPage)) }
            }
        };

        if (isLoggedIn)
        {
            Items.Add(mainTab);
            Items.Add(loginTab);
        }
        else
        {
            Items.Add(loginTab);
            Items.Add(mainTab);
        }
    }

    private async Task CheckIfUserIsLoggedIn()
    {
        try
        {
            string? sessionToken = await _secureStorage.GetAsync("sessionToken");    
            if(sessionToken == null)
            {
                isLoggedIn = false;
                return;
            }   
            ClientSession session = await _frontendApi.ToSessionAsync(sessionToken);
           
           isLoggedIn = session != null;
        }
        catch (ApiException)
        {
         
            isLoggedIn = false;
        }
    }
}
