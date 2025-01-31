

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

 

     public async Task<ClientSuccessfulNativeRegistration> RegisterUser(string flowId, Dictionary<string, object> traits)
    {
        // try
        // {
        //     var submitRegistrationFlowBody = new SubmitRegistrationFlowBody(
        //         Method: "password",
        //         Password: "your_password_here",
        //         Traits: traits
        //     );

        //     return await _frontendApi.SubmitNativeRegistrationFlowAsync(flowId, submitRegistrationFlowBody);
        // }
        // catch (ApiException e)
        // {
        //     Console.WriteLine($"Error registering user: {e.Message}");
        //     throw;

        // }

        return new ClientSuccessfulNativeRegistration();
    }

    
}
