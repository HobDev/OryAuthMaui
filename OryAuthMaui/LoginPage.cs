
using MauiReactor;

namespace OryAuthMaui;

public class LoginPage : Component
{
	public override VisualNode Render()
	{
		return ContentPage(
			VStack(
				Label("Buy Page")
					.FontSize(24)
					.HCenter()
					.VCenter(),
				Label("Select a subscription to buy")
					.FontSize(18),
				Button("Buy Subscription")
					.HCenter()
			)
		);
	}
}