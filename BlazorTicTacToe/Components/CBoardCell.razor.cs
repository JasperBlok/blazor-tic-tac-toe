namespace BlazroTicTacToe.Components;

using BlazroTicTacToe.Models;
using Microsoft.AspNetCore.Components;

public partial class CBoardCell
{
    [Parameter, EditorRequired]
    public BoardCell Cell { get; set; } = null!;

    [Parameter, EditorRequired]
    public Action<BoardCell> OnClick { get; set; } = null!;

    private void OnButtonClick() => OnClick(Cell);
}
