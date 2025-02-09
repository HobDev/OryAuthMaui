
using Ory.Client.Model;

namespace OryAuthMauiMvvm.ViewModels;

public partial class RegisterViewModel: ObservableObject
{

    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;


     private readonly IRegistrationService _registrationService;
     
    public RegisterViewModel(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
      
    }
    

   
   [RelayCommand]
     async Task Register()
    {
      ClientRegistrationFlow? flow= await  _registrationService.CreateRegistrationFlow();
     string _flowId = flow.Id;
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
