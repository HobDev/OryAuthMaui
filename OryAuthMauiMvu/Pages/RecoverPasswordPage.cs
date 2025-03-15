using MauiReactor;

using Ory.Client.Model;

namespace OryAuthMauiMvu.Pages;

class RecoverPasswordPageState
{
 public string? EmailId { get; set; }
   
}

partial class RecoverPasswordPage : Component<RecoverPasswordPageState>
{

    [Inject]
    private readonly IRecoveryService _recoveryService;
    [Inject]
    private readonly INavigationService _navigationService;

    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VerticalStackLayout
                {
                   
                    new Entry { }
                    .FontSize(20)
                    .Placeholder("Email"),
                    

                    new Button {  "Recover Password" }
                    .OnClicked(() => RecoverPassword()),    
                  

                    new Button {"Go Back" }
                    .OnClicked(() => GoBack())
                   


                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }


 
    async Task RecoverPassword()
    {
        try
        {
            if(string.IsNullOrWhiteSpace(State.EmailId))
            {
                await MauiControls.Shell.Current.DisplayAlert("Error", "Email is required", "Ok");
                return;
            }   
            ClientRecoveryFlow? flow = await _recoveryService.CreateRecoveryFlow();
            string? flowId = flow.Id;

            ClientRecoveryFlow? clientRecoveryFlow = await _recoveryService.RecoverPassword(State.EmailId, flowId);
           
            await MauiControls.Shell.Current.DisplayAlert("Success", "Password recovery link sent to your email", "Ok");

          await _navigationService.GoBackAsync();

        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }
    }

   
    async Task GoBack()
    {
        try
        {
            await _navigationService.GoBackAsync();
        }
        catch (Exception ex)
        {
            await MauiControls.Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }

    }
}
