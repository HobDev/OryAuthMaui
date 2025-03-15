using System;

namespace OryAuthMauiMvvm.ViewModels;


public partial class RecoverPasswordViewModel: ObservableObject
{

    [ObservableProperty]
    string emailId;

    private readonly IRecoveryService _recoveryService;
    private readonly INavigationService _navigationService;

    public RecoverPasswordViewModel(IRecoveryService recoveryService, INavigationService navigationService)
    {
        _recoveryService = recoveryService;
        _navigationService = navigationService;
    }


    [RelayCommand]
    async Task RecoverPassword()
    {
        
        try
        {

           if(string.IsNullOrWhiteSpace(EmailId))
              {
                await Shell.Current.DisplayAlert("Error", "Email is required", "Ok");
                return;
              }

            ClientRecoveryFlow? flow = await _recoveryService.CreateRecoveryFlow();
            string? flowId = flow.Id;

            ClientRecoveryFlow? clientRecoveryFlow = await _recoveryService.RecoverPassword(this.EmailId, flowId);

            
         await Shell.Current.DisplayAlert("Success", "Password recovery link sent to your email", "Ok");

          await _navigationService.GoBackAsync();
           

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    async Task GoBack()
    {
        try
        {
            await _navigationService.GoBackAsync();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
       
    }

}
