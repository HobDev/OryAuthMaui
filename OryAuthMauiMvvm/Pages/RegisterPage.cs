using OryAuthMauiMvvm.ViewModels;

namespace OryAuthMauiMvvm.Pages;

public class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		
		Content = new VerticalStackLayout
		{
			Children = 
			{
				new Label
				 { 
					HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Register!"
				},
				new Entry
				{
					Placeholder = "Username",
					WidthRequest = 300,
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center
				},
				new Entry
				{
					Placeholder = "Email",
					WidthRequest = 300,
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center
				},
				new Button
				{
					Text = "Register",
					Command = viewModel.RegisterCommand	
				}

			}
		};

		BindingContext = viewModel;
	}
}