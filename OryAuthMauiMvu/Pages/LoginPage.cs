using MauiReactor;

namespace OryAuthMauiMvu.Pages;

class LoginPageState
{
    private readonly  OryService _oryService;
    private string _flowId;
}

class LoginPage : Component<LoginPageState>
{
    protected override void OnMounted()
    {
        Fetch();
       
        base.OnMounted();
    }

    private void Fetch()
    {
       var _oryService= Services.GetService<OryService>();
    }

    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VerticalStackLayout
                {
                    

                    new Label("Login!")
                        .FontSize(32)
                        .HCenter(),

                    new Entry()
                    .Placeholder("Email")
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter(),

                        new Entry()
                    .Placeholder("Password")
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter(),

                    new Button("Login")
                        .OnClicked(Login)
                        .HCenter()                    
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }

    private async Task Login()
    {
       
    }
}