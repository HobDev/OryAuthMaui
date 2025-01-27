using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OryAuthMauiMvvm.ViewModels;

public partial class RegisterViewModel: ObservableObject
{

     public Command RegisterCommand { get; }

    [ObservableProperty]
    string emailId;

    [ObservableProperty]
    string password;

    private string _flowId;

     private readonly OryService _oryService;
     
    public RegisterViewModel(OryService oryService)
    {
        _oryService = oryService;
        RegisterCommand = new Command(async ()=>await Register());
    }
    

   

    private async Task Register()
    {
      var flow= await  _oryService.CreateRegistrationFlow();
        _flowId = flow.Id;
         // Use flow.Ui to populate your registration form


         var traits = new Dictionary<string, object>
         {
             {"email", EmailId},
            //  {"password", Password}
         };

         try
        {
          //  var result = await _oryService.RegisterUser(_flowId, traits);
          // Handle successful registration
        }
        catch (Exception ex)
        {
            // Handle registration error
        }
    }   
}
