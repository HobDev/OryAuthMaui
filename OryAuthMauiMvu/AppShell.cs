
using MauiReactor;
using System;
using Ory.Client.Api;
using Ory.Client.Client;
using Ory.Client.Model;
using OryAuthMauiShared.Models;

using OryAuthMauiMvu.Pages;

namespace OryAuthMauiMvu;

partial class AppShellState
{
   
 
    public bool IsLoggedIn { get; set; }
   
}

partial class AppShell : Component<AppShellState>
{

    [Inject]
    public readonly ILoginStatusService _loginStatusService;



    protected override void OnMounted()
    {
        MauiReactor.Routing.RegisterRoute<RegisterPage>(nameof(RegisterPage));
        MauiReactor.Routing.RegisterRoute<ForgotPasswordPage>(nameof(ForgotPasswordPage));
        MauiReactor.Routing.RegisterRoute<ChangePasswordPage>(nameof(ChangePasswordPage));

        State.IsLoggedIn = _loginStatusService.IsLoggedIn;

        base.OnMounted();
    }


    public override VisualNode Render()
    => Window
   (
      !State.IsLoggedIn ?
       RenderLogin()
       :
       RenderShell()
   );

     VisualNode RenderLogin()
      =>Shell(
             TabBar(
                ShellContent("LoginPage")
                .RenderContent(() => new LoginPage())
                .Route(nameof(LoginPage))
            ),
             TabBar(
                ShellContent("MainPage")
                .RenderContent(() => new MainPage())
                .Route(nameof(MainPage))
             )
        );

        VisualNode RenderShell()
        =>Shell(
             TabBar(
                ShellContent("MainPage")
                .RenderContent(()=> new MainPage())
                .Route(nameof(MainPage))
             ),
            TabBar(
                ShellContent("LoginPage")
                .RenderContent(()=> new LoginPage())
                .Route(nameof(LoginPage))
            )
        );


   
}

