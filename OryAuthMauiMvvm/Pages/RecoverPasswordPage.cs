namespace OryAuthMauiMvvm.Pages;

public class RecoverPasswordPage : ContentPage
{
	public RecoverPasswordPage(RecoverPasswordViewModel viewModel)
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
               
                new Button
                {
                    Text = "RECOVER PASSWORD",
                    WidthRequest = 300,
                    Command = viewModel.RecoverPasswordCommand
                },
            }
        };

        BindingContext = viewModel;
	}
}