using MauiReactor;


using Ory.Client.Model;

namespace OryAuthMauiMvu.Pages;

class LoginPageState
{
   public string? EmailId {get; set;}
   public string? Password {get; set;}
}

 partial class LoginPage : Component<LoginPageState>
{
    [Inject]
    readonly ILoginService _loginService;

    [Inject]
    readonly INavigationService _navigationService;
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VStack
                {
                    new Entry()
                    .Placeholder("Email")
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter()
                        .OnTextChanged(text => State.EmailId = text),

                        new Entry()
                    .Placeholder("Password")
                    .IsPassword(true)
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter()
                        .OnTextChanged(text => State.Password = text),

                    new Button("LOGIN")
                    .WidthRequest(300)
                        .OnClicked(Login)
                        .HCenter(),

                         new Button("Sign Up")
                    .WidthRequest(300)
                        .OnClicked(SignUp)
                        .HCenter()
                        .Margin(0,30,0,0 ),

                         new Button("Forgot Password")
                    .WidthRequest(300)
                        .OnClicked(ForgotPassword)
                        .HCenter()
                        .Margin(0,10,0,0 )
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }


    private async Task Login()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(State.EmailId) || string.IsNullOrWhiteSpace(State.Password))
            {
                await MauiControls.Shell.Current.DisplayAlert("Error", "email and password is required", "Ok");
            }
            else
            {
                ClientLoginFlow? flow = await _loginService.CreateLoginFlow();
                string _flowId = flow.Id;
                await _loginService.LoginUser(email: State.EmailId, loginPassword: State.Password, _flowId);
            }
        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }

    }

    private async Task SignUp()
    {
        try
        {
            await _navigationService.NavigateToAsync(nameof(RegisterPage));
        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

    private async Task ForgotPassword()
    {
        try
        {
            await _navigationService.NavigateToAsync(nameof(ForgotPasswordPage));
        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }
}
