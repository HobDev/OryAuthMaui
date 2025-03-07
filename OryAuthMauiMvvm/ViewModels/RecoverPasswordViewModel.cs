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
            ClientRecoveryFlow? flow = await _recoveryService.CreateRecoveryFlow();
            string? flowId = flow.Id;

            ClientRecoveryFlow? clientRecoveryFlow = await _recoveryService.RecoverPassword(this.EmailId, flowId);


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
