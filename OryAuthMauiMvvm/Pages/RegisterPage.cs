

namespace OryAuthMauiMvvm.Pages;

public class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		
		Content = new VerticalStackLayout
		{
			Spacing=20,
			Children = 
			{
				new Label
				 { 
					HorizontalOptions = LayoutOptions.Center, 
					VerticalOptions = LayoutOptions.Center, 
					Text = "Register!",
					FontSize = 24
				},
				new Entry
				{
					Placeholder = "email",
					WidthRequest = 300,
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center
				}.Bind(Entry.TextProperty, nameof(viewModel.EmailId)),
				new Entry
				{
					Placeholder = "Password",
					IsPassword = true,
					WidthRequest = 300,
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center
				}.Bind(Entry.TextProperty, nameof(viewModel.Password)),
				new Button
				{
					Text = "Register",
					WidthRequest = 300,
					Command = viewModel.RegisterCommand	
				}

			}
		};

		BindingContext = viewModel;
	}
}