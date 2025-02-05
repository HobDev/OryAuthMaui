

using System.Diagnostics;
using RestSharp;

namespace OryAuthMauiShared.Services.Implementations;

public class OryService : IOryService
{
      private readonly FrontendApi _frontendApi;
   

    public OryService()
    {
        var configuration = new Configuration
        {
            BasePath = "https://kind-kapitsa-rmqphy91zf.projects.oryapis.com"
        };

        _frontendApi = new FrontendApi(configuration);
    }

    public async Task<ClientRegistrationFlow> CreateRegistrationFlow()
    {
        try
        {
            return await _frontendApi.CreateNativeRegistrationFlowAsync();
        }
        catch (ApiException e)
        {
            Console.WriteLine($"Error creating registration flow: {e.Message}");
            throw;
        }
    }

 

     public async Task<ClientSuccessfulNativeRegistration?> RegisterUser( Dictionary<string, object> traits, string password, string flowId)
    {
            ClientSuccessfulNativeRegistration? result=null;
            ClientUpdateRegistrationFlowBody? clientUpdateRegistrationFlowBody = new Ory.Client.Model.ClientUpdateRegistrationFlowBody
            (
                new  ClientUpdateRegistrationFlowWithPasswordMethod
            {
                Method = "password",
                Password = password,
                Traits = traits,
                
            }
            );

         try     
        {
             result = _frontendApi.UpdateRegistrationFlow(flowId, clientUpdateRegistrationFlowBody);
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
