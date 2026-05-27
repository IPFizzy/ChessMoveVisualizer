/*
 * Keon Bushman
 * CST - 250
 * 05/31/2026
 * Chess Board Project
 * Activity 2
 * Activity 2 Guide
 */

using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

//---------------------------------------------------------------
// Start of Main Method
//---------------------------------------------------------------

// Print a welcome message for the user
Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);

// Show the empty board
Utility.PrintBoard(board);

// Prompt the user for the type of chess piece
Console.Write("Enter a chess piece: King, Queen, Bishop, Knight, or Rook: ");
string piece = Console.ReadLine() ?? "";

while (piece != "King" && piece != "Queen" && piece != "Bishop" &&
       piece != "Knight" && piece != "Rook")
{
    Console.WriteLine("Invalid chess piece. Please enter King, Queen, Bishop, Knight, or Rook.");
    Console.Write("Enter a chess piece: King, Queen, Bishop, Knight, or Rook: ");
    piece = Console.ReadLine() ?? "";
}

// Prompt the user for the location of the chess piece
Tuple<int, int> rowAndCol = Utility.GetRowAndCol(board);

// Mark the legal moves based on the input
BoardLogic boardLogic = new BoardLogic();
CellModel currentCell = board.Grid[rowAndCol.Item1, rowAndCol.Item2];
board = boardLogic.MarkLegalMoves(board, currentCell, piece);

// Print out the new chess board
Utility.PrintBoard(board);

//---------------------------------------------------------------
// End of Main Method
//---------------------------------------------------------------

//---------------------------------------------------------------
// Define a utility class
//---------------------------------------------------------------

public static class Utility
{
    /// <summary>
    /// Print the given board to the console.
    /// </summary>
    /// <param name="board"></param>
    internal static void PrintBoard(BoardModel board)
    {
        // Add space before the board
        Console.WriteLine();

        // Print the column headers
        Console.Write("   ");

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write($"  {col} ");
        }

        Console.WriteLine();

        // Print the top border
        Console.Write("   ");

        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("+---");
        }

        Console.WriteLine("+");

        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Print the row number
            Console.Write($" {row} ");

            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Get the current cell from the grid
                CellModel cell = board.Grid[row, col];

                // Check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    // Print a + for a legal move
                    Console.Write("| + ");
                }

                // Check if there is a piece occupying the cell
                else if (cell.PieceOccupyingCell != "")
                {
                    // Print the chess piece letter
                    Console.Write($"| {cell.PieceOccupyingCell} ");
                }
                else
                {
                    // Print a blank space for anything else
                    Console.Write("|   ");
                }
            }

            Console.WriteLine("|");

            // Print the row border
            Console.Write("   ");

            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("+---");
            }

            Console.WriteLine("+");
        }
    } // End of PrintBoard method

    /// <summary>
    /// Get the row and column for the piece.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol(BoardModel board)
    {
        // Create variables to store the row and column
        int row;
        int col;

        // Get a valid row from the user
        Console.Write("Enter the row number of the piece: ");

        while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= board.Size)
        {
            Console.WriteLine("Invalid row. Please enter a number between 0 and 7.");
            Console.Write("Enter the row number of the piece: ");
        }

        // Get a valid column from the user
        Console.Write("Enter the column number of the piece: ");

        while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= board.Size)
        {
            Console.WriteLine("Invalid column. Please enter a number between 0 and 7.");
            Console.Write("Enter the column number of the piece: ");
        }

        // Return the data
        return Tuple.Create(row, col);
    }
}