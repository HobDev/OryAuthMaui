using System;
using Ory.Client.Api;
using Ory.Client.Client;
using Ory.Client.Model;

using OryAuthMauiShared.Models;

namespace OryAuthMauiMvvm;

public class AppShell : Shell
{
 
    readonly  ILoginStatusService _loginStatusService;
    public AppShell(ILoginStatusService loginStatusService)
    {
        _loginStatusService = loginStatusService;
     
    

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));

      bool isLoggedIn = _loginStatusService.IsLoggedIn;
     

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

   
}
