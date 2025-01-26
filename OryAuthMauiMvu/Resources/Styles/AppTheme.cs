using System;
using MauiReactor;

namespace OryAuthMauiMvu.Resources.Styles;

public class AppTheme : Theme
{
      public static void ToggleCurrentAppTheme()
    {
        if (MauiControls.Application.Current != null)
        {
            MauiControls.Application.Current.UserAppTheme = IsDarkTheme ? Microsoft.Maui.ApplicationModel.AppTheme.Light : Microsoft.Maui.ApplicationModel.AppTheme.Dark;
        }
    }


    public static Color DarkBackground { get; } = Color.FromArgb("#FF17171C");
    public static Color DarkText { get; } = Color.FromArgb("#FFFFFFFF");
    public static Color LightBackground { get; } = Color.FromArgb("#FFF1F2F3");
    public static Color LightText { get; } = Color.FromArgb("#FF000000");

    protected override void OnApply()
    {
        ContentPageStyles.Default = _ => _
            .BackgroundColor(IsDarkTheme ? DarkBackground : LightBackground);

            LabelStyles.Default = _ => _
            .TextColor(IsDarkTheme ? DarkText : LightText);
    }
}
