using System;
using Ory.Client.Model;

using OryAuthMauiShared.Models;

namespace OryAuthMauiShared.Services.Implementations;

public class LoginService : ILoginService
{
       private readonly FrontendApi _frontendApi;
     public LoginService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
    }

    public async Task<ClientLoginFlow> CreateLoginFlow()
    {
        
            return await _frontendApi.CreateNativeLoginFlowAsync();
       
    }

    public async Task<ClientSuccessfulNativeLogin> LoginUser(string email, string loginPassword, string flowId)
    {
         ClientSuccessfulNativeLogin? result=null;
            ClientUpdateLoginFlowBody? clientUpdateLoginFlowBody = new ClientUpdateLoginFlowBody
            (
                new  ClientUpdateLoginFlowWithPasswordMethod
            (
                method:"password",
                identifier: email,
                password: loginPassword
                
            )
            );

             result =await _frontendApi.UpdateLoginFlowAsync(flowId, clientUpdateLoginFlowBody);

        return result;
    }
}
