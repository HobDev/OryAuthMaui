
using MauiReactor;


namespace OryAuthMauiMvu.Pages;

class RegisterPageState
{
  public string EmailId{get;set;}   
   public string Password {get;set;}

}

partial class RegisterPage : Component<RegisterPageState>
{
    [Inject]
    IOryService _oryService;
    
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VStack
                {

                    new Label("Register!")
                        .FontSize(32)
                        .HCenter(),

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
       
        var flow = await _oryService.CreateRegistrationFlow();
        string _flowId = flow.Id;
       // Use flow.Ui to populate your registration form


         var traits = new Dictionary<string, object>
         {
             {"email", State.EmailId},
            //{"password", Password}
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
