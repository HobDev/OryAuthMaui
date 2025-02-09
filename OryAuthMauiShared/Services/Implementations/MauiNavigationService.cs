using System;



namespace OryAuthMauiShared.Services.Implementations;

public class MauiNavigationService: INavigationService
{
    public Task InitializeAsync()
    {
        //return NavigateToAsync(string.IsNullOrEmpty(_settingsService.AuthAccessToken))
        //     ? "//Login"
        //     : "//Main/Catalog";
        return null;
    }

    public Task NavigateToAsync(string route, ShellNavigationQueryParameters? routeParameters = null)
    {
        return
             routeParameters != null
             ? Shell.Current.GoToAsync(route, routeParameters)
             : Shell.Current.GoToAsync(route);
    }

    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}
