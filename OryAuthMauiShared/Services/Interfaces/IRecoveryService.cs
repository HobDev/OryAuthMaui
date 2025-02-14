using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface IRecoveryService
{
    Task<ClientRecoveryFlow> CreateRecoveryFlow();
    Task<ClientRecoveryFlow> RecoverPassword(string email, string flowId);
}
