using System;

namespace OryAuthMauiShared.Services.Implementations;

public class LoginStatusService : ILoginStatusService
{

    private readonly FrontendApi _frontendApi;

    private readonly ISecureStorage _secureStorage;

    public bool IsLoggedIn { get; set; }

    public LoginStatusService(ISecureStorage secureStorage)
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
        _secureStorage = secureStorage;

       Task.Run(async ()=> await IsUserLoggedIn()).Wait();    
    }

     public async Task IsUserLoggedIn()
      {

            string? sessionToken = await _secureStorage.GetAsync("sessionToken");
            if (sessionToken == null)
            {
                IsLoggedIn = false;
                return;
               
            }
            ClientSession session = await _frontendApi.ToSessionAsync(sessionToken);

            IsLoggedIn= session != null;

            _secureStorage.Remove("sessionToken");    
    }
}
