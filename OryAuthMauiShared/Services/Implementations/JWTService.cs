using System;

namespace OryAuthMauiShared.Services.Implementations;

public class JWTService : IJWTService
{
    private readonly FrontendApi _frontendApi;

    public JWTService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
    }

    public async Task<string> GetSessionJWTAsync(string sessionToken)
    {
        string jwt = string.Empty;
        
            // ClientSession? clientSession = await _frontendApi.ToSessionAsync(xSessionToken: sessionToken, tokenizeAs:);
            //jwt = clientSession.Tokenized;
        
        return jwt;
    }

}
