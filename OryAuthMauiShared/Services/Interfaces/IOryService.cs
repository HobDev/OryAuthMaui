using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface IOryService
{
    Task<ClientRegistrationFlow> CreateRegistrationFlow();

    Task<ClientSuccessfulNativeRegistration> RegisterUser( Dictionary<string, object> traits, string password, string flowId);



}
