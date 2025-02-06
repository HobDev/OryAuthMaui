using System;
using Ory.Client.Model;

namespace OryAuthMauiShared.Services.Implementations;

public class LoginService : ILoginService
{
       private readonly FrontendApi _frontendApi;
     public LoginService()
    {
        var configuration = new Configuration
        {
            BasePath = "https://kind-kapitsa-rmqphy91zf.projects.oryapis.com"
        };

        _frontendApi = new FrontendApi(configuration);
    }

    public async Task<ClientLoginFlow> CreateLoginFlow()
    {
        try
        {
            return await _frontendApi.CreateNativeLoginFlowAsync();
        }
        catch (ApiException e)
        {
            Console.WriteLine($"Error creating registration flow: {e.Message}");
            throw;
        }
    }

    public async Task<ClientSuccessfulNativeLogin> LoginUser(string email, string loginPassword, string flowId)
    {
         ClientSuccessfulNativeLogin? result=null;
            ClientUpdateLoginFlowBody? clientUpdateLoginFlowBody = new ClientUpdateLoginFlowBody
            (
                new  ClientUpdateLoginFlowWithPasswordMethod
            (
              
                identifier: email,
                password: loginPassword
                
            )
            );

         try     
        {
             result = _frontendApi.UpdateLoginFlow(flowId, clientUpdateLoginFlowBody);
        }
        

          catch (ApiException  e)
            {
                Debug.Print("Exception when calling FrontendApi.UpdateRegistrationFlow: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        return result;
    }
}
