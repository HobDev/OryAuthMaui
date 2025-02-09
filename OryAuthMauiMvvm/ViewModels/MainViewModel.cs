using System;

using CommunityToolkit.Mvvm.Input;

namespace OryAuthMauiMvvm.ViewModels;

public partial class MainViewModel
{
    private readonly ILogoutService _logoutService;
    private readonly IChangePasswordService _changePasswordService;

    public MainViewModel(ILogoutService logoutService, IChangePasswordService changePasswordService)
    {
       _logoutService = logoutService;
       _changePasswordService= changePasswordService;
    }

     [RelayCommand]
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

     [RelayCommand]
     async Task ChangePassword()
     {
        try
        {
           
        }
        catch
        {

        }
     }
}
