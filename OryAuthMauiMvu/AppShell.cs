using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiReactor;

using OryAuthMauiMvu.Pages;

namespace OryAuthMauiMvu;

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
                
                ShellContent("RegisterPage")
                    .RenderContent(()=>new RegisterPage())
             
           
        ).Route("MainTabBar")
        );
}

