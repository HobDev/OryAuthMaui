using System;
using Ory.Client.Api;
using Ory.Client.Client;
using Ory.Client.Model;

using OryAuthMauiShared.Models;

namespace OryAuthMauiMvvm;

public class AppShell : Shell
{
 
    
    public AppShell(ILoginStatusService loginStatusService)
    {

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(RecoverPasswordPage), typeof(RecoverPasswordPage));
      bool isLoggedIn = loginStatusService.IsLoggedIn;
     

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
