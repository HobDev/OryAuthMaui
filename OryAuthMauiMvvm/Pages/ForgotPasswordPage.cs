namespace OryAuthMauiMvvm.Pages;

public class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}