

namespace OryAuthMauiMvvm.ViewModels;

public partial class LoginViewModel: ObservableObject
{


    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;
    private ILoginService _loginService;

    private IJWTService _jwtService;
   private INavigationService _navigationService;
   private ISecureStorage _secureStorage;
   
   public LoginViewModel(ILoginService loginService, IJWTService jwtService ,INavigationService navigationService, ISecureStorage secureStorage)
   {
        _loginService= loginService;
        _jwtService= jwtService;
        _navigationService= navigationService;
        _secureStorage= secureStorage;
   }

   [RelayCommand]
   async Task Login()
   {
        BusyPopup busyPopup = new BusyPopup("Logging in...");
        try
    {
       if(string.IsNullOrWhiteSpace(EmailId) || string.IsNullOrWhiteSpace(Password))
       {
        await Shell.Current.DisplayAlert("Error","email and password is required","Ok");
       }
       else
       {
             
              Shell.Current.ShowPopup(busyPopup);  
          ClientLoginFlow? flow=await _loginService.CreateLoginFlow();
          string _flowId= flow.Id;
         ClientSuccessfulNativeLogin? result=  await _loginService.LoginUser(email:EmailId, loginPassword: Password, _flowId);

                string? sessionToken = result.SessionToken;
              

                string jwt = await _jwtService.GetSessionJWTAsync(sessionToken);
                 
                await Shell.Current.DisplayAlert("JWT", jwt, "Okay");

                await _secureStorage.SetAsync("sessionToken", sessionToken);
                await _navigationService.NavigateToAsync($"///{nameof(MainPage)}");

                busyPopup?.Close();
            }
    }
    catch(Exception ex)
    {
        busyPopup?.Close();
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
           await _navigationService.NavigateToAsync(nameof(RecoverPasswordPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

}
