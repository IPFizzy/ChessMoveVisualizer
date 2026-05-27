/*
 * Keon Bushman
 * CST - 250
 * 05/31/2026
 * Chess Board Project
 * Activity 2
 * Activity 2 Guide
 */

using ChessBoardClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        /// <summary>
        /// Reset the board by setting the
        /// cell properties back to default.
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private BoardModel ResetBoard(BoardModel board)
        {
            // Use a foreach loop to iterate over every cell
            foreach (CellModel cell in board.Grid)
            {
                // Set the properties to their defaults
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = "";
            }

            // Return the board back to the presentation layer
            return board;
        }

        /// <summary>
        /// Check if a row/column location is on the board.
        /// Encapsulate this method so it can only be
        /// called from this class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            // Get the size of the board
            int size = board.Size;

            // Check if the row is on the board
            bool isRowSafe = row >= 0 && row < size;

            // Check if the column is on the board
            bool isColumnSafe = col >= 0 && col < size;

            // Return true if both row and column are safe
            return isRowSafe && isColumnSafe;
        }

        /// <summary>
        /// Mark the legal moves for the given piece and location.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <param name="chessPiece"></param>
        /// <returns></returns>
        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
        {
            // Reset the board
            board = ResetBoard(board);

            // Use a switch statement to determine the behavior of the piece
            switch (chessPiece.ToLower())
            {
                case "knight":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                    // Mark the valid moves for the knight
                    board = MarkValidKnightMoves(board, currentCell);
                    break;

                case "rook":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "R";
                    // Mark the valid rook moves
                    board = MarkValidRookMoves(board, currentCell);
                    break;

                case "bishop":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "B";
                    // Mark the valid bishop moves
                    board = MarkValidBishopMoves(board, currentCell);
                    break;

                case "queen":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "Q";
                    // Mark the valid queen moves
                    board = MarkValidQueenMoves(board, currentCell);
                    break;

                case "king":
                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "K";
                    // Mark the valid king moves
                    board = MarkValidKingMoves(board, currentCell);
                    break;

                default:
                    // If the piece is not valid, return the board as is
                    return board;
            }

            // Return the updated board
            return board;
        } // End of MarkLegalMoves method

        /// <summary>
        /// Mark the valid moves for the knight.
        /// Access modifier is private meaning this method is encapsulated within the
        /// BoardLogic class and cannot be accessed directly outside the class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidKnightMoves(BoardModel board, CellModel currentCell)
        {
            // Possible moves for knight row
            int[] knightRowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };

            // Possible moves for knight column
            int[] knightColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Loop through the knights moves
            for (int i = 0; i < knightRowMoves.Length; i++)
            {
                // Check if each move is on the board
                if (IsOnBoard(board, currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]))
                {
                    // If the cell is on the board, label it as a possible move for the knight
                    board.Grid[currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]].IsLegalNextMove = true;
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the rook.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell)
        {
            // Loop through every cell on the board
            foreach (CellModel cell in board.Grid)
            {
                // Check if the cell is in the same row or same column
                if (cell.Row == currentCell.Row || cell.Column == currentCell.Column)
                {
                    // Do not mark the current cell as a legal move
                    if (cell.Row != currentCell.Row || cell.Column != currentCell.Column)
                    {
                        cell.IsLegalNextMove = true;
                    }
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the bishop.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidBishopMoves(BoardModel board, CellModel currentCell)
        {
            // Loop through every cell on the board
            foreach (CellModel cell in board.Grid)
            {
                // Check if the cell is diagonal from the current cell
                if (Math.Abs(cell.Row - currentCell.Row) == Math.Abs(cell.Column - currentCell.Column))
                {
                    // Do not mark the current cell as a legal move
                    if (cell.Row != currentCell.Row || cell.Column != currentCell.Column)
                    {
                        cell.IsLegalNextMove = true;
                    }
                }
            }

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the queen.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidQueenMoves(BoardModel board, CellModel currentCell)
        {
            // Mark the rook style moves for the queen
            board = MarkValidRookMoves(board, currentCell);

            // Mark the bishop style moves for the queen
            board = MarkValidBishopMoves(board, currentCell);

            return board;
        }

        /// <summary>
        /// Mark the valid moves for the king.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private BoardModel MarkValidKingMoves(BoardModel board, CellModel currentCell)
        {
            // Loop through the possible row changes
            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                // Loop through the possible column changes
                for (int colOffset = -1; colOffset <= 1; colOffset++)
                {
                    // Calculate the possible move location
                    int newRow = currentCell.Row + rowOffset;
                    int newCol = currentCell.Column + colOffset;

                    // Do not mark the current cell as a legal move
                    bool isCurrentCell = rowOffset == 0 && colOffset == 0;

                    // Check if the move is on the board and not the current cell
                    if (!isCurrentCell && IsOnBoard(board, newRow, newCol))
                    {
                        board.Grid[newRow, newCol].IsLegalNextMove = true;
                    }
                }
            }

            return board;
        }
    }
}
