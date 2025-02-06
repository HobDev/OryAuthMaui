

namespace OryAuthMauiShared.Services.Interfaces;

public interface IRegistrationService
{
    Task<ClientRegistrationFlow> CreateRegistrationFlow();

    Task<ClientSuccessfulNativeRegistration> RegisterUser( Dictionary<string, object> registrationTraits, string registrationPassword, string flowId);



}
