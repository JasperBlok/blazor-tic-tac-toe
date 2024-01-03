namespace BlazroTicTacToe.Models;

public class GameLogic
{
    // --- Events --- //
    public event MessageDelegate? RaiseMessage;
    public delegate void MessageDelegate(string message);


    // --- Data --- //
    public CellState CurrentPlayer { get; set; } = CellState.CROSS;

    /// <summary>
    /// Gets a value indicating whether the board is full.
    /// </summary>
    public bool IsBoardFull
    {
        get
        {
            foreach (BoardCell item in CurrentBoardData)
            {
                if (item.State == CellState.DEFAULT)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Gets the array with the board data
    /// </summary>
    public BoardCell[,] CurrentBoardData { get; } = {
        { new(), new(), new() },
        { new(), new(), new() },
        { new(), new(), new() },
    };


    // --- Functions --- //
    /// <summary>
    /// Changes the player
    /// </summary>
    public void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer is CellState.CROSS ? CellState.CIRCLE : CellState.CROSS;
    }

    /// <summary>
    /// Triggered when clicked on a cell
    /// </summary>
    /// <param name="cell">The cell that was clicked.</param>
    public void BoardCellOnClick(BoardCell cell)
    {
        cell.ChangeState(CurrentPlayer);

        if (CheckIfCurrentPlayerWon())
        {
            LockBoard();

            // Alert that the game is over and who has won
            string playerName = CurrentPlayer is CellState.CIRCLE ? "Circle" : "Cross";
            RaiseMessage?.Invoke("Player with " + playerName + " won! Click Restart to try again.");

            return;
        }

        if (IsBoardFull)
        {
            // Alert that the game is over because of no space on the board
            RaiseMessage?.Invoke("Board is full, so the match is a draw. Click Restart to continue.");
            return;
        }

        ChangePlayer();
    }

    /// <summary>
    /// Triggered when clicked on a cell, but use specific CellState.
    /// </summary>
    /// <remarks>
    /// Only used for unit testing
    /// </remarks>
    public void BoardCellOnClick(BoardCell cell, CellState state)
    {
        CurrentPlayer = state;
        BoardCellOnClick(cell);
    }

    /// <summary>
    /// Check if current player has winning combination.
    /// </summary>
    /// <returns><see langword="true"/> if the current player has won, otherwise <see langword="false"/>.<</returns>
    public bool CheckIfCurrentPlayerWon()
    {
        for (int col = 0; col < CurrentBoardData.GetLength(0); col++)
        {
            for (int row = 0; row < CurrentBoardData.GetLength(1); row++)
            {
                if (CurrentBoardData[col, row].State == CurrentPlayer)
                {
                    // Checkes for lines made with current cell as center
                    if (CheckCellForCurrentPlayer(col - 1, row - 1) && CheckCellForCurrentPlayer(col + 1, row + 1)) return true;
                    if (CheckCellForCurrentPlayer(col - 1, row + 1) && CheckCellForCurrentPlayer(col + 1, row - 1)) return true;
                    if (CheckCellForCurrentPlayer(col - 0, row - 1) && CheckCellForCurrentPlayer(col + 0, row + 1)) return true;
                    if (CheckCellForCurrentPlayer(col - 1, row - 0) && CheckCellForCurrentPlayer(col + 1, row - 0)) return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Checks if cell at chosen coordinates is of the current player.
    /// </summary>
    /// <param name="col">The column position of the cell.</param>
    /// <param name="row">The row position of the cell.</param>
    /// <returns>
    /// <see langword="true"/> if the cell is of the current player, otherwise <see langword="false"/>.
    /// </returns>
    public bool CheckCellForCurrentPlayer(int col, int row)
    {
        // Check if coordinates are inside of index
        if (col < CurrentBoardData.GetLength(0) && col >= 0 &&
            row < CurrentBoardData.GetLength(1) && row >= 0)
        {
            // If searched cell is in an array, check if it matches current player
            if (CurrentBoardData[col, row].State == CurrentPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // If checked place is out of bound (what is gonna happen), return that the cell is not of interest for current player
            return false;
        }
    }

    /// <summary>
    /// Set all buttons to be unclickable.
    /// </summary>
    public void LockBoard()
    {
        foreach (BoardCell item in CurrentBoardData)
        {
            item.Disable();
        }
    }

    /// <summary>
    /// Restart board settings to default.
    /// </summary>
    public void RestartBoard()
    {
        foreach (BoardCell item in CurrentBoardData)
        {
            item.Enable();
            item.ChangeState(CellState.DEFAULT);
        }
    }
}