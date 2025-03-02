using System;

using CommunityToolkit.Maui.Views;

namespace OryAuthMauiMvvm.Popups;

public class BusyPopup: Popup
{
    public BusyPopup(string Message)
    {
        CanBeDismissedByTappingOutsideOfPopup = false;
        Content = new VerticalStackLayout
        {
            Padding = new Thickness(40),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new ActivityIndicator
                {
                    IsRunning = true,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                },
                new Label
                {
                    TextColor=Colors.Black,
                    Text = Message,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            }
        };
    }

  

}
