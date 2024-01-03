namespace BlazorTicTacToe.Test.Tests;

using BlazroTicTacToe.Models;

public class TestBoardCell
{
    [Fact]
    public void BoardCell_GetText_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        string result1 = cell.Text;

        cell.ChangeState(CellState.CIRCLE);
        string result2 = cell.Text;

        cell.ChangeState(CellState.CROSS);
        string result3 = cell.Text;

        // Assert
        result1.Should().Be(BoardCell.cSymbolDefault);
        result2.Should().Be(BoardCell.cSymbolPlayerO);
        result3.Should().Be(BoardCell.cSymbolPlayerX);
    }
    [Fact]
    public void BoardCell_GetColor_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        string result1 = cell.Color;

        cell.ChangeState(CellState.CIRCLE);
        string result2 = cell.Color;

        cell.ChangeState(CellState.CROSS);
        string result3 = cell.Color;

        // Assert
        result1.Should().Be(BoardCell.cColorDefault);
        result2.Should().Be(BoardCell.cColorPlayerO);
        result3.Should().Be(BoardCell.cColorPlayerX);
    }
    [Fact]
    public void BoardCell_GetDisabledText_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        string result1 = cell.DisabledText;

        cell.ChangeState(CellState.CIRCLE);
        string result2 = cell.DisabledText;

        cell.ChangeState(CellState.CROSS);
        string result3 = cell.DisabledText;

        // Assert
        result1.Should().Be(BoardCell.cEnabledText);
        result2.Should().Be(BoardCell.cDisabledText);
        result3.Should().Be(BoardCell.cDisabledText);
    }


    [Fact]
    public void BoardCell_Constructor_Default()
    {
        // Arrange 
        BoardCell cell = new();

        // Assert
        cell.State.Should().Be(CellState.DEFAULT);
    }
    [Fact]
    public void BoardCell_Constructor_ManuallySet()
    {
        // Arrange 
        BoardCell cell = new(CellState.CROSS);

        // Assert
        cell.State.Should().Be(CellState.CROSS);
    }

    [Fact]
    public void BoardCell_ChangeState_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        CellState result1 = cell.State;

        cell.ChangeState(CellState.CROSS);
        CellState result2 = cell.State;

        cell.ChangeState(CellState.CIRCLE);
        CellState result3 = cell.State;

        cell.ChangeState(CellState.DEFAULT);
        CellState result4 = cell.State;

        // Assert
        result1.Should().Be(CellState.DEFAULT);
        result2.Should().Be(CellState.CROSS);
        result3.Should().Be(CellState.CIRCLE);
        result4.Should().Be(CellState.DEFAULT);
    }


    [Fact]
    public void BoardCell_Disable_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        cell.Disable();

        // Assert
        cell.Disabled.Should().BeTrue();
    }
    [Fact]
    public void BoardCell_Enable_Successful()
    {
        // Arrange 
        BoardCell cell = new(CellState.DEFAULT);

        // Act
        cell.Disable();
        cell.Enable();

        // Assert
        cell.Disabled.Should().BeFalse();
    }
}
