
using MauiReactor;

using OryAuthMauiMvu.Pages;

namespace OryAuthMauiMvu;

class AppShellState
    {
        
    }

class AppShell : Component<AppShellState>
{
    

     public override VisualNode Render()
      =>Shell(
            TabBar(
                
                ShellContent("RegisterPage")
                    .RenderContent(()=>new RegisterPage())
             
           
        ).Route("MainTabBar")
        );
}

