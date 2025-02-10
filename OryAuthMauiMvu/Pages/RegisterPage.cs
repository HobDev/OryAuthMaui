
using MauiReactor;
using Ory.Client.Model;


namespace OryAuthMauiMvu.Pages;

class RegisterPageState
{
  public string? EmailId{get;set;}   
   public string? Password {get;set;}

}

partial class RegisterPage : Component<RegisterPageState>
{
    [Inject]
    readonly IRegistrationService _registrationService;

    [Inject]
    readonly INavigationService _navigationService;
    
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VStack
                {
                    new Entry()
                    .Placeholder("Email")
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter()
                        .OnTextChanged(text => State.EmailId = text),          

                        new Entry()
                    .Placeholder("Password")
                    .IsPassword(true)
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter()
                        .OnTextChanged(text => State.Password = text),

                    new Button("Register")
                    .WidthRequest(300)
                        .OnClicked(Register)
                        .HCenter()                    
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }

    private async Task Register()
    {
       
        var flow = await _registrationService.CreateRegistrationFlow();
        string _flowId = flow.Id;
      
         var traits = new Dictionary<string, object>
         {
             {"email", State.EmailId},
         };

         try
        {
          ClientSuccessfulNativeRegistration? result = await _registrationService.RegisterUser(traits, State.Password, _flowId);
         // Handle successful registration
          await _navigationService.NavigateToAsync(nameof(MainPage));
        }
        catch (Exception ex)
        {
            // Handle registration error
          await  MauiControls.Shell.Current.DisplayAlert("Error",ex.Message,"Okay");
        }
    }
}
