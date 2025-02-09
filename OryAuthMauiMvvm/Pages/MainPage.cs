namespace OryAuthMauiMvvm.Pages;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		Content = new VerticalStackLayout
		{
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