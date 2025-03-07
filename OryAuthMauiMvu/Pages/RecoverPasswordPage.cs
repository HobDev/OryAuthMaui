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
                   new Entry()
                    .Placeholder("Email")
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter()
                        .OnTextChanged(text => State.EmailId = text),

                         new Button("RECOVER PASSWORD")
                    .WidthRequest(300)
                        .OnClicked(RecoverPassword)
                        .HCenter()
                        .Margin(0,10,0,0 )


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
            if (string.IsNullOrWhiteSpace(State.EmailId) )
            {
                await MauiControls.Shell.Current.DisplayAlert("Error", "email is required", "Ok");
            }
            else
            {
                ClientRecoveryFlow? flow = await _recoveryService.CreateRecoveryFlow();
                string? flowId = flow.Id;

                ClientRecoveryFlow? clientRecoveryFlow = await _recoveryService.RecoverPassword(State.EmailId, flowId);
            }
           


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
