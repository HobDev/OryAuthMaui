using MauiReactor;

namespace OryAuthMauiMvu.Pages;

class ForgotPasswordPageState
{
    public int Counter { get; set; }
}

class ForgotPasswordPage : Component<ForgotPasswordPageState>
{
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

                    new Button(State.Counter == 0 ? "Click me" : $"Clicked {State.Counter} times!")
                        .OnClicked(()=>SetState(s => s.Counter ++))
                        .HCenter()                    
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
    }
}
