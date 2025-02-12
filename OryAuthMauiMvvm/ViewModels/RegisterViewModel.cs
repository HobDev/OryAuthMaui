
using Android.SE.Omapi;

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

     private readonly ISecureStorage _secureStorage;    
     
    public RegisterViewModel(IRegistrationService registrationService, INavigationService navigationService, ISecureStorage secureStorage)
    {
        _registrationService = registrationService;
        _navigationService= navigationService;
        _secureStorage= secureStorage;
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

             string? sessionToken= result.SessionToken;
           //  ClientIdentity.StateEnum? state= result.Identity.State;
           // string? identityId= result.Identity.Id;
            //string? jwt=  result.Session.Tokenized;

            await _secureStorage.SetAsync("sessionToken", sessionToken);    
        
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
