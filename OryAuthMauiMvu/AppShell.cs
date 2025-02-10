
using MauiReactor;

using OryAuthMauiMvu.Pages;

namespace OryAuthMauiMvu;

class AppShellState
    {
    public bool isLoggedIn { get; set; }
}

class AppShell : Component<AppShellState>
{

    protected override void OnMounted()
    {
        MauiReactor.Routing.RegisterRoute<RegisterPage>(nameof(RegisterPage));
        MauiReactor.Routing.RegisterRoute<ForgotPasswordPage>(nameof(ForgotPasswordPage));
        MauiReactor.Routing.RegisterRoute<ChangePasswordPage>(nameof(ChangePasswordPage));

        base.OnMounted();
    }


    public override VisualNode Render()
    => Window
   (
      !State.isLoggedIn ?
       RenderLogin()
       :
       RenderShell()
   );

     VisualNode RenderLogin()
      =>Shell(
             TabBar(
                ShellContent("LoginPage")
                .RenderContent(() => new LoginPage())
            ),
             TabBar(
                ShellContent("MainPage")
                .RenderContent(() => new MainPage())
             )
        );

        VisualNode RenderShell()
        =>Shell(
             TabBar(
                ShellContent("MainPage")
                .RenderContent(()=> new MainPage())
             ),
            TabBar(
                ShellContent("LoginPage")
                .RenderContent(()=> new LoginPage())
            )
        );
}

