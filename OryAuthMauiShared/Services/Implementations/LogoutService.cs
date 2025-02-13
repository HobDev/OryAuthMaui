using System;

using OryAuthMauiShared.Models;

namespace OryAuthMauiShared.Services.Implementations;

public class LogoutService : ILogoutService
{

    private readonly FrontendApi _frontendApi;
    private readonly ISecureStorage _secureStorage;
    public LogoutService(ISecureStorage secureStorage)
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
        _secureStorage = secureStorage;
    }
    public async Task LogoutUser()
    {
        
        // ClientPerformNativeLogoutBody? clientPerformNativeLogoutBody= new ClientPerformNativeLogoutBody
        // (
        //     sessionToken: "ory_st_fQqa42WZwPZlTgBNk5e6A21Vh8mUjDut"
        // );
       
       string? sessionToken = await _secureStorage.GetAsync("sessionToken");    
       await  _frontendApi.UpdateLogoutFlowAsync(sessionToken);
    }
}
