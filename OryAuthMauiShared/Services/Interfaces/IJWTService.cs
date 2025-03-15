

namespace OryAuthMauiShared.Services.Interfaces;

public interface IJWTService
{

   Task<string> GetSessionJWTAsync(string sessionToken);

}
