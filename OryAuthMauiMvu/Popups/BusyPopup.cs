using System;
using System.ComponentModel;
using MauiReactor;
using MauiReactor.Internals;

namespace OryAuthMauiMvu.Popups;




class BusyPopup : MauiReactor.Component
{
    private readonly string _message;

    public BusyPopup(string message)
    {
        _message = message;
       
    }

    public override VisualNode Render()
    {
        return new ContentPage
        (
        
            Border(
               
            Grid(
                "Auto,Auto",
                "*",
                new ActivityIndicator()
                .GridRow(0)
                .GridColumn(0),
                new Label()
                .Text(_message)
                .GridRow(0)
                .GridColumn(1)
            )
            )
            .Margin(30)
            .Padding(30)
        )
        ;
    }
}
