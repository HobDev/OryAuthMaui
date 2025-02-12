namespace OryAuthMauiMvvm;

public partial class App : Application
{

    readonly AppShell _appShell;
	public App(AppShell appShell)
	{
		_appShell = appShell;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(_appShell);   
	}
}