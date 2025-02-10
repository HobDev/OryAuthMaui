using System;

using OryAuthMauiShared.Models;

namespace OryAuthMauiShared.Services.Implementations;

public class LogoutService : ILogoutService
{

    private readonly FrontendApi _frontendApi;
    public LogoutService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
    }
    public async Task LogoutUser()
    {
        
        // ClientPerformNativeLogoutBody? clientPerformNativeLogoutBody= new ClientPerformNativeLogoutBody
        // (
        //     sessionToken: "ory_st_fQqa42WZwPZlTgBNk5e6A21Vh8mUjDut"
        // );
       await  _frontendApi.UpdateLogoutFlowAsync("ory_st_SQVuA9fXnWGV896KLK3VnRM1nFJvbUqI");
    }
}
