using System;

namespace OryAuthMauiShared.Services.Interfaces;

public interface ILoginStatusService
{
    bool IsLoggedIn { get; set; }
  
}
