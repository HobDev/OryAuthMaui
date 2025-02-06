using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface ILoginService
{
      Task<ClientLoginFlow> CreateLoginFlow();

    Task<ClientSuccessfulNativeLogin> LoginUser( string email, string loginPassword, string flowId);
}
