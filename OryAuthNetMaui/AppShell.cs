using System;
using MauiReactor;
using OryAuthNetMaui.Views;

namespace OryAuthNetMaui;

class AppShellState
    {
        public bool LoggedIn { get; set; }
    }
class AppShell : Component<AppShellState>
{

      protected override void OnMounted()
	{
		  

        base.OnMounted();

	}	

     public override VisualNode Render()
     => Window
    (
       !State.LoggedIn ? 
        RenderLogin()
        :
        RenderShell()
    );
       

       VisualNode RenderLogin() 
         =>Shell(
            TabBar(
                
                ShellContent("LoginPage")
                    .RenderContent(()=>new LoginPage())
             
           
        ).Route("MainTabBar")
        ); 

         VisualNode RenderShell()
          =>Shell(
            TabBar(
                
                ShellContent("MainPage")
                    .RenderContent(()=>new MainPage())
             
           
        ).Route("MainTabBar")
        );
}