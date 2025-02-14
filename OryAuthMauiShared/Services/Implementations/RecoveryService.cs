using System;
using Ory.Client.Api;
using Ory.Client.Client;
using Ory.Client.Model;
using OryAuthMauiShared.Services.Interfaces;

namespace OryAuthMauiShared.Services.Implementations;

/// <summary>
/// this class is responsible for handling the recovery flow when a user forgets or wants to change their password
/// </summary>
public class RecoveryService : IRecoveryService
{
    private readonly FrontendApi _frontendApi;

    public RecoveryService()
    {
        var configuration = new Configuration
        {
            BasePath = AppConstants.BaseUrl
        };

        _frontendApi = new FrontendApi(configuration);
    }

    public async Task<ClientRecoveryFlow> CreateRecoveryFlow()
    {
        try
        {
            return await _frontendApi.CreateNativeRecoveryFlowAsync();
        }
        catch (ApiException e)
        {
            Console.WriteLine($"Error creating registration flow: {e.Message}");
            throw;
        }
    }

 

    public async Task<ClientRecoveryFlow> RecoverPassword(string email, string flowId)
    {
        try
        {
            var recoveryBody = new ClientUpdateRecoveryFlowBody
            (
                new ClientUpdateRecoveryFlowWithLinkMethod
                (
                    method: ClientUpdateRecoveryFlowWithLinkMethod.MethodEnum.Link,
                    email: email
                )
            );

            return await _frontendApi.UpdateRecoveryFlowAsync(flowId, recoveryBody);
        }
        catch (ApiException e)
        {
            Console.WriteLine($"Error recovering password: {e.Message}");
            throw;
        }
    }
}
