



namespace OryAuthMauiShared.Services.Implementations;

public class RegistrationService : IRegistrationService
{
    private readonly FrontendApi _frontendApi;


    public RegistrationService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.baseUrl
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

        try
        {
            result = _frontendApi.UpdateRegistrationFlow(flowId, clientUpdateRegistrationFlowBody);
        }


        catch (ApiException e)
        {
            Debug.Print("Exception when calling FrontendApi.UpdateRegistrationFlow: " + e.Message);
            Debug.Print("Status Code: " + e.ErrorCode);
            Debug.Print(e.StackTrace);
        }

        return result;
    }


}
