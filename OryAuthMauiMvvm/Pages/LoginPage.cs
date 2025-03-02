namespace OryAuthMauiMvvm.Pages;

public class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
        Content = new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,   
            VerticalOptions = LayoutOptions.Center,
            Spacing = 20,
            Children =
            {
              
                new Entry
                {
                    Placeholder = "email",
                    WidthRequest = 300,
                    FontSize = 18,
                    HorizontalOptions = LayoutOptions.Center
                }.Bind(Entry.TextProperty, nameof(viewModel.EmailId)).Margins(0,30,0,0),
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
                    Text = "LOG IN ",
                    WidthRequest = 300,
                    Command = viewModel.LoginCommand
                },

                 new Button
                {
                    Text = "Sign Up",
                    WidthRequest = 300,
                    Command = viewModel.SignUpCommand
                }.Margins(0,30,0,0 ),

                 new Button
                {
                    Text = "Forgot Password",
                    WidthRequest = 300,
                    Command = viewModel.ForgotPasswordCommand
                }.Margins(0,10,0,0)

            }
        };

        BindingContext = viewModel;
    }
}