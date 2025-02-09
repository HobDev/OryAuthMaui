using System;

namespace OryAuthMauiMvvm;

public class AppShell: Shell
{

   
    public AppShell()
    {

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));

        bool isLoggedIn=false;

        TabBar loginTab = new TabBar
        {
            Items =
                {
                    new ShellContent{ Route=nameof(LoginPage),ContentTemplate=new DataTemplate(typeof(LoginPage))}
                }
        };

        TabBar mainTab = new TabBar
        {
            Items =
                {
                    new ShellContent{ Route=nameof(MainPage),ContentTemplate=new DataTemplate(typeof(MainPage))}
                }
        };

          if(isLoggedIn)
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
