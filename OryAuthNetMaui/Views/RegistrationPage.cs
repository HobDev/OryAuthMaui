﻿using MauiReactor;


namespace OryAuthNetMaui.Views;

class RegistrationPageState
{
    private readonly OryService _oryService;
    private string _flowId;
}

class RegistrationPage : Component<RegistrationPageState>
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
                   

                    new Label("Register!")
                        .FontSize(32)
                        .HCenter(),

                    new Entry()
                    .Placeholder("Email")
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter(),

                        new Entry()
                    .Placeholder("Password")
                    .HCenter()
                    .WidthRequest(300)
                        .FontSize(18)
                        .HCenter(),

                    new Button("Register")
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
        var _oryService= Services.GetService<OryService>();
        var flow = await _oryService.CreateRegistrationFlow();
        _flowId = flow.Id;
        // Use flow.Ui to populate your registration form
    }
}
