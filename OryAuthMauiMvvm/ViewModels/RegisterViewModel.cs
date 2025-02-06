

using Ory.Client.Model;

namespace OryAuthMauiMvvm.ViewModels;

public partial class RegisterViewModel: ObservableObject
{

     public Command RegisterCommand { get; }

    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;

    private string _flowId;

     private readonly IRegistrationService _registrationService;
     
    public RegisterViewModel(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
        RegisterCommand = new Command(async ()=>await Register());
    }
    

   

    private async Task Register()
    {
      var flow= await  _registrationService.CreateRegistrationFlow();
        _flowId = flow.Id;
         // Use flow.Ui to populate your registration form


         var traits = new Dictionary<string, object>
         {
             {"email", EmailId},
         };

         try
        {
            ClientSuccessfulNativeRegistration? result = await _registrationService.RegisterUser( traits, Password, _flowId);
          // Handle successful registration
        }
        catch (Exception ex)
        {
            // Handle registration error
        }
    }   
}
