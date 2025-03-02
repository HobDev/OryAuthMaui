

namespace OryAuthMauiMvvm.ViewModels;

public partial class MainViewModel
{
    private readonly ILogoutService _logoutService;
    private readonly IRecoveryService  _recoveryService;
    private readonly INavigationService _navigationService; 

    private readonly ILoginStatusService _loginStatusService;
    public MainViewModel(ILogoutService logoutService, IRecoveryService recoveryService, ILoginStatusService loginStatusService ,INavigationService navigationService)
    {
        _logoutService = logoutService;
        _recoveryService = recoveryService;
        _loginStatusService = loginStatusService;
        _navigationService = navigationService;
    }
    

     [RelayCommand]
     async Task Logout()
     {
        BusyPopup? busyPopup = new BusyPopup("Logging out...");
        try
        {
            
              Shell.Current.ShowPopup(busyPopup);
           await _logoutService.LogoutUser();
            bool isLoggedIn = _loginStatusService.IsLoggedIn;
            if (!isLoggedIn)
            {
                await _navigationService.NavigateToAsync($"///{nameof(LoginPage)}");
                busyPopup?.Close();
            }
            else
            {
                busyPopup?.Close();
                await Shell.Current.DisplayAlert("Error", "Logout failed", "Okay");
            }
        }
        catch(Exception ex)
        {
            busyPopup?.Close();
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }
     }

     [RelayCommand]
     async Task ChangePassword()
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
