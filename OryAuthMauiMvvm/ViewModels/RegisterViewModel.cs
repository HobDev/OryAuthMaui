using System;

namespace OryAuthMauiMvvm.ViewModels;

public class RegisterViewModel
{
    public RegisterViewModel()
    {
        RegisterCommand = new Command(async ()=>await Register());
    }

    public Command RegisterCommand { get; }

    private async Task Register()
    {
        
    }   
}
