using MauiReactor;

using Ory.Client.Model;

namespace OryAuthMauiMvu.Pages;

class RecoverPasswordPageState
{
    
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
                    new Image("dotnet_bot.png")
                        .HeightRequest(200)
                        .HCenter()
                        .Set(MauiControls.SemanticProperties.DescriptionProperty, "Cute dot net bot waving hi to you!"),

                    new Label("Hello, World!")
                        .FontSize(32)
                        .HCenter(),

                    new Label("Welcome to MauiReactor: MAUI with superpowers!")
                        .FontSize(18)
                        .HCenter(),

                          
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
            ClientRecoveryFlow? flow = await _recoveryService.CreateRecoveryFlow();
            string? flowId = flow.Id;

            ClientRecoveryFlow? clientRecoveryFlow = await _recoveryService.RecoverPassword("{email here}", flowId);


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
