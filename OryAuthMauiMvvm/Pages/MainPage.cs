namespace OryAuthMauiMvvm.Pages;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		Content = new VerticalStackLayout
		{
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Spacing = 20,
			Children = {
				new Button { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Logout"
				}.BindCommand(nameof(viewModel.LogoutCommand)),

                new Button { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Change Password"
                }.BindCommand(nameof(viewModel.ChangePasswordCommand)),

            }
		};

        BindingContext=viewModel;
	}
}