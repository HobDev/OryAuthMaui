using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface IOryService
{
    Task<ClientRegistrationFlow> CreateRegistrationFlow();

    Task<ClientSuccessfulNativeRegistration> RegisterUser(string flowId, Dictionary<string, object> traits);



}
