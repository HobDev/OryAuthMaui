using System;

using CommunityToolkit.Mvvm.Input;

namespace OryAuthMauiMvvm.ViewModels;

public partial class MainViewModel
{
    private readonly ILogoutService _logoutService;
    private readonly IRecoveryService  _recoveryService;

    private readonly INavigationService _navigationService; 
    public MainViewModel(ILogoutService logoutService, IRecoveryService recoveryService, INavigationService navigationService)
    {
        _logoutService = logoutService;
        _recoveryService = recoveryService;
        _navigationService = navigationService;
    }
    

     [RelayCommand]
     async Task Logout()
     {
        try
        {
           await _logoutService.LogoutUser();
        }
        catch(Exception ex)
        {
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
