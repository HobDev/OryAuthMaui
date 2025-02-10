
using Ory.Client.Model;

namespace OryAuthMauiMvvm.ViewModels;

public partial class RegisterViewModel: ObservableObject
{

    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;


     private readonly IRegistrationService _registrationService;
     private readonly INavigationService _navigationService;
     
    public RegisterViewModel(IRegistrationService registrationService, INavigationService navigationService)
    {
        _registrationService = registrationService;
        _navigationService= navigationService;
    }
    

   
   [RelayCommand]
     async Task Register()
    {
      ClientRegistrationFlow? flow= await  _registrationService.CreateRegistrationFlow();
     string _flowId = flow.Id;
        
         var traits = new Dictionary<string, object>
         {
             {"email", EmailId},
         };

         try
        {
            ClientSuccessfulNativeRegistration? result = await _registrationService.RegisterUser( traits, Password, _flowId);
          // Handle successful registration
           await  _navigationService.NavigateToAsync($"///{nameof(MainPage)}");
        
        }
        catch (Exception ex)
        {
            // Handle registration error
            await Shell.Current.DisplayAlert("Error",ex.Message,"Okay");
        }
    }   
}
