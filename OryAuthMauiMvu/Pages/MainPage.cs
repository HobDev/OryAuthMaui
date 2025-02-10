using MauiReactor;

namespace OryAuthMauiMvu.Pages;

class MainPageState
{
    public int Counter { get; set; }
}

partial class MainPage : Component<MainPageState>
{
  [Inject]
  readonly ILogoutService _logoutService;
  [Inject]
  readonly IChangePasswordService _changePasswordService;

    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VStack
                {
                        new Button("Logout")
                    .WidthRequest(300)
                        .OnClicked(Logout)
                        .HCenter()
                        .Margin(0,30,0,0),

                            new Button("Change Password")
                    .WidthRequest(300)
                        .OnClicked(ChangePassword)
                        .HCenter()
                        .Margin(0,10,0,0 )
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }

    async Task Logout()
    {
        try
        {
            await _logoutService.LogoutUser();
        }
        catch
        {

        }
    }

    async Task ChangePassword()
    {

    }
}
