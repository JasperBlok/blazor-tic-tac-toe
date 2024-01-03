namespace BlazroTicTacToe.Components.Pages;

using BlazroTicTacToe.Models;
using Microsoft.JSInterop;

public partial class Tictactoe
{
    private readonly GameLogic _gameLogic = new();

    public async void MessageHandler(string message)
    {
        await Alert(message);
    }

    private async Task Alert(string message)
    {
        await JsRuntime.InvokeAsync<object>("Alert", message);
    }


    // Equivelent of "OnLoad" 
    protected override void OnAfterRender(bool firstRender)
    {
        // execute conditionally for loading data, otherwise this will load
        // every time the page refreshes
        if (firstRender)
        {
            _gameLogic.RaiseMessage += MessageHandler;
        }
    }
}
