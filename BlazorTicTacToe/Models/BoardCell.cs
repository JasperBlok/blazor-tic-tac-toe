namespace BlazroTicTacToe.Models;

public class BoardCell
{
    // Static Definitions for symbols and colors
    public const string cSymbolPlayerX = "x";
    public const string cSymbolPlayerO = "o";
    public const string cSymbolDefault = "-";

    public const string cColorPlayerX = " btn-danger ";
    public const string cColorPlayerO = " btn-success ";
    public const string cColorDefault = " btn-secondary ";

    public const string cDisabledText = " disabled ";
    public const string cEnabledText = "";

    public CellState State { get; private set; } = CellState.DEFAULT;

    public string Text => State switch
    {
        CellState.DEFAULT => cSymbolDefault,
        CellState.CIRCLE => cSymbolPlayerO,
        CellState.CROSS => cSymbolPlayerX,
        _ => cSymbolDefault,
    };

    public string Color => State switch
    {
        CellState.DEFAULT => cColorDefault,
        CellState.CIRCLE => cColorPlayerO,
        CellState.CROSS => cColorPlayerX,
        _ => cColorDefault,
    };

    public bool Disabled { get; private set; }

    public string DisabledText
    {
        get
        {
            if (Disabled)
            {
                return cDisabledText;
            }

            return State switch
            {
                CellState.DEFAULT => cEnabledText,
                CellState.CIRCLE => cDisabledText,
                CellState.CROSS => cDisabledText,
                _ => cEnabledText,
            };
        }
    }

    public BoardCell() { }
    public BoardCell(CellState cellState)
    {
        ChangeState(cellState);
    }

    /// <summary>
    /// Changed button adequate to the state
    /// </summary>
    /// <param name="cellState">The state to set.</param>
    public void ChangeState(CellState cellState)
    {
        State = cellState;
    }

    public void Disable()
    {
        Disabled = true;
    }

    public void Enable()
    {
        Disabled = false;
    }
}