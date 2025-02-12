
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
  
    
}

partial class AppShell : Component<AppShellState>
{

    public bool isLoggedIn { get; set; } = true;

    private  FrontendApi _frontendApi;

    [Inject]
    readonly ISecureStorage _secureStorage;


    protected override void OnMounted()
    {
        MauiReactor.Routing.RegisterRoute<RegisterPage>(nameof(RegisterPage));
        MauiReactor.Routing.RegisterRoute<ForgotPasswordPage>(nameof(ForgotPasswordPage));
        MauiReactor.Routing.RegisterRoute<ChangePasswordPage>(nameof(ChangePasswordPage));

        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);

        Task.Run(async () => await CheckIfUserIsLoggedIn()).Wait();

        base.OnMounted();
    }


    public override VisualNode Render()
    => Window
   (
      !isLoggedIn ?
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


    private async Task CheckIfUserIsLoggedIn()
    {
        try
        {
            string? sessionToken = await _secureStorage.GetAsync("sessionToken");
            if (sessionToken == null)
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

