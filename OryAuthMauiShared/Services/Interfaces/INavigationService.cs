using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface INavigationService
{

    Task InitializeAsync();
    Task NavigateToAsync(string route, ShellNavigationQueryParameters? routeParameters = null);

  
    Task GoBackAsync();
}
