namespace OryAuthMauiMvvm.Pages;

public class RecoverPasswordPage : ContentPage
{
	public RecoverPasswordPage(RecoverPasswordViewModel viewModel)
    {
        
		Content = new VerticalStackLayout
		{
            Padding = new Thickness(20),
            Spacing = 20,
			Children = 
            {
				new Label { Text = "Recover Password" },
                new Entry { Placeholder = "Email" }.Bind(nameof(viewModel.EmailId)),
                new Button { Text = "Recover Password" }.BindCommand(nameof(viewModel.RecoverPasswordCommand)),
                new Button { Text = "Go Back" }.BindCommand(nameof(viewModel.GoBackCommand))    
			}
		};


        BindingContext = viewModel;
	}
}