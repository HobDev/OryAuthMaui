
using CommunityToolkit.Maui.Views;

using MauiReactor;

using OryAuthMauiMvu.Popups;


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
  readonly INavigationService _navigationService;

  [Inject]
    readonly ILoginStatusService _loginStatusService;

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
                        .Margin(0,10,0,0 ),

                      
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
           bool isLoggedIn=   _loginStatusService.IsLoggedIn; 
              if(!isLoggedIn)
              {
                await _navigationService.NavigateToAsync($"///{nameof(LoginPage)}");
              }
              else
              {
                await MauiControls.Shell.Current.DisplayAlert("Error", "Logout failed", "Okay");
              }
        }
        catch(Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

    async Task ChangePassword()
    {
        try
        {
            await _navigationService.NavigateToAsync(nameof(RecoverPasswordPage));
        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }
}
