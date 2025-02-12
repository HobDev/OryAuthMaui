

namespace OryAuthMauiMvvm.ViewModels;

public partial class LoginViewModel: ObservableObject
{


    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;
    private ILoginService _loginService;
   private INavigationService _navigationService;
   private ISecureStorage _secureStorage;
   
   public LoginViewModel(ILoginService loginService, INavigationService navigationService, ISecureStorage secureStorage)
   {
        _loginService= loginService;
        _navigationService= navigationService;
        _secureStorage= secureStorage;
   }

   [RelayCommand]
   async Task Login()
   {
    try
    {
       if(string.IsNullOrWhiteSpace(EmailId) || string.IsNullOrWhiteSpace(Password))
       {
        await Shell.Current.DisplayAlert("Error","email and password is required","Ok");
       }
       else
       {
          ClientLoginFlow? flow=await _loginService.CreateLoginFlow();
          string _flowId= flow.Id;
         ClientSuccessfulNativeLogin? result=  await _loginService.LoginUser(email:EmailId, loginPassword: Password, _flowId);

                string? sessionToken = result.SessionToken;
                // ClientIdentity.StateEnum? state= result.Identity.State;
                // string? identityId= result.Identity.Id;
                // string? jwt=  result.Session.Tokenized;

                await _secureStorage.SetAsync("sessionToken", sessionToken);
            }
    }
    catch(Exception ex)
    {
       await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
    }
   }

    [RelayCommand]
    async Task SignUp()
    {
        try
        {
           await _navigationService.NavigateToAsync(nameof(RegisterPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

    [RelayCommand]
    async Task ForgotPassword()
    {
        try
        {
           await _navigationService.NavigateToAsync(nameof(ForgotPasswordPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

}
