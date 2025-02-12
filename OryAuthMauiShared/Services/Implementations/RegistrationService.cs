using OryAuthMauiShared.Models;

namespace OryAuthMauiShared.Services.Implementations;

public class RegistrationService : IRegistrationService
{
    private readonly FrontendApi _frontendApi;


    public RegistrationService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
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



    public async Task<ClientSuccessfulNativeRegistration?> RegisterUser(Dictionary<string, object> registrationTraits, string registrationPassword, string flowId)
    {
        ClientSuccessfulNativeRegistration? result = null;
        ClientUpdateRegistrationFlowBody? clientUpdateRegistrationFlowBody = new Ory.Client.Model.ClientUpdateRegistrationFlowBody
        (
            new ClientUpdateRegistrationFlowWithPasswordMethod
        (
            method: "password",
            password: registrationPassword,
                 traits: registrationTraits

        )
        );

       
            result =await _frontendApi.UpdateRegistrationFlowAsync(flowId, clientUpdateRegistrationFlowBody);

        return result;
    }


}
