using System;

namespace OryAuthMauiMvvm.ViewModels;

public class LoginViewModel
{
    public Command LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(async()=> await Login());
    }

    private async Task Login()
    {
        // Login logic here
    }
}
