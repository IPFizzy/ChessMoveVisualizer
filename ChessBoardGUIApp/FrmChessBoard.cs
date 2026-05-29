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

namespace ChessBoardGUIApp
{
    public partial class FrmChessBoard : Form
    {
        // Class level variables
        private BoardModel _board;
        private BoardLogic _boardLogic;

        // 2D array of buttons for the chess board
        private Button[,] _buttons;

        /// <summary>
        /// Default constructor for FrmChessBoard.
        /// </summary>
        public FrmChessBoard()
        {
            InitializeComponent();

            // Initialize class level variables
            _board = new BoardModel(8);
            _boardLogic = new BoardLogic();
            _buttons = new Button[8, 8];

            // Set default chess piece selection
            cmbChessPieces.SelectedIndex = -1;

            // Set up the buttons on the chess board before applying colors
            SetUpButtons();

            // Set the default color theme after the buttons exist
            if (cmbColorThemes.Items.Count > 0)
            {
                cmbColorThemes.SelectedIndex = 0;
            }

            // Apply the default color theme
            ApplyColorTheme();
        }

        /// <summary>
        /// Populate the panel control with buttons.
        /// </summary>
        private void SetUpButtons()
        {
            // Declare and initialize
            // Calculate the size of each button based on
            // the panel width and the number of buttons needed
            int buttonSize = pnlChessBoard.Width / _board.Size;

            // Set the panel to be square
            pnlChessBoard.Height = pnlChessBoard.Width;

            // Use nested for loops to loop through the boards Grid
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // Set up each individual button
                    // Create a new button in the 2D array
                    _buttons[row, col] = new Button();

                    // Get the current button
                    Button button = _buttons[row, col];

                    // Set the size for the button
                    button.Width = buttonSize;
                    button.Height = buttonSize;

                    // Set the location of the button
                    // using the left and top sides
                    button.Left = row * buttonSize;
                    button.Top = col * buttonSize;

                    // Attach a click event handler to the button
                    button.Click += BtnSquareClickEH;

                    // Store the location of the button in
                    // the Tag property using a Point object
                    button.Tag = new Point(row, col);

                    // Set the text for the button
                    button.Text = $"{row}, {col}";

                    // Add the button to the panels controls
                    pnlChessBoard.Controls.Add(_buttons[row, col]);
                }
            }
        } // End of SetUpButtons method

        /// <summary>
        /// Click Event Handler for the chess board buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSquareClickEH(object? sender, EventArgs e)
        {
            // Make sure the sender is a button
            if (sender is not Button button)
            {
                MessageBox.Show("The selected control is not a valid board square.");
                return;
            }

            // Make sure the button tag contains a point
            if (button.Tag is not Point point)
            {
                MessageBox.Show("The selected board square does not have a valid location.");
                return;
            }

            // Check that a chess piece has been selected
            if (cmbChessPieces.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a chess piece before clicking the board.");
                return;
            }

            // Declare and initialize
            int row = point.X;
            int col = point.Y;
            string piece = cmbChessPieces.Text;

            // Check that the selected location is within the board
            if (row < 0 || row >= _board.Size || col < 0 || col >= _board.Size)
            {
                MessageBox.Show("The selected location is outside of the board.");
                return;
            }

            // Show the user their choice
            MessageBox.Show($"You clicked on row {row} and column {col}");

            // Send the board, current cell, and piece to the business logic layer
            _board = _boardLogic.MarkLegalMoves(_board, _board.Grid[row, col], piece);

            // Update the buttons
            UpdateButtons();

            // Reapply the selected color theme
            ApplyColorTheme();
        }

        /// <summary>
        /// Update the text for each button based on the board.
        /// </summary>
        private void UpdateButtons()
        {
            // Declare and initialize
            string piece;

            // Set up a dictionary to get the names of the chess pieces
            Dictionary<string, string> pieceMap = new Dictionary<string, string>
            {
                { "N", "Knight" },
                { "R", "Rook" },
                { "B", "Bishop" },
                { "Q", "Queen" },
                { "K", "King" }
            };

            // Loop through each cell in the grid to update the corresponding button
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    if (_board.Grid[row, col].PieceOccupyingCell != "")
                    {
                        // Use the dictionary to get the name of the chess piece
                        piece = pieceMap[_board.Grid[row, col].PieceOccupyingCell];

                        // Update the text for the button
                        _buttons[row, col].Text = piece;
                    }
                    else if (_board.Grid[row, col].IsLegalNextMove)
                    {
                        // Set the text to show a legal move
                        _buttons[row, col].Text = "Legal Move";
                    }
                    else
                    {
                        // Clear the text for any other buttons
                        _buttons[row, col].Text = "";
                    }
                }
            }

            // Reapply the current color theme after updating button text
            ApplyColorTheme();
        } // End of UpdateButtons method

        /// <summary>
        /// Apply the selected color theme to the chessboard buttons.
        /// </summary>
        private void ApplyColorTheme()
        {
            // Stop the method if the buttons have not been created yet
            if (_buttons == null || _board == null)
            {
                return;
            }

            // Stop the method if the first button has not been created yet
            if (_buttons[0, 0] == null)
            {
                return;
            }

            // Declare color variables
            Color lightColor;
            Color darkColor;
            Color legalMoveColor;
            Color pieceColor;

            // Set colors based on the selected theme
            switch (cmbColorThemes.Text)
            {
                case "Cool":
                    lightColor = Color.LightCyan;
                    darkColor = Color.SteelBlue;
                    legalMoveColor = Color.LightGreen;
                    pieceColor = Color.LightYellow;
                    break;

                case "Warm":
                    lightColor = Color.Moccasin;
                    darkColor = Color.IndianRed;
                    legalMoveColor = Color.Gold;
                    pieceColor = Color.LightYellow;
                    break;

                case "Neon":
                    lightColor = Color.FromArgb(180, 255, 0);
                    darkColor = Color.FromArgb(255, 255, 0);
                    legalMoveColor = Color.FromArgb(0, 255, 255);
                    pieceColor = Color.FromArgb(255, 0, 255);
                    break;

                case "Pastel":
                    lightColor = Color.FromArgb(255, 220, 235);
                    darkColor = Color.FromArgb(200, 230, 255);
                    legalMoveColor = Color.FromArgb(210, 255, 210);
                    pieceColor = Color.FromArgb(255, 245, 190);
                    break;

                default:
                    lightColor = Color.White;
                    darkColor = Color.Gray;
                    legalMoveColor = Color.LightGreen;
                    pieceColor = Color.LightYellow;
                    break;
            }

            // Loop through each button and apply the selected colors
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // Get the current button and cell
                    Button button = _buttons[row, col];
                    CellModel cell = _board.Grid[row, col];

                    // Apply special colors for pieces and legal moves
                    if (cell.PieceOccupyingCell != "")
                    {
                        button.BackColor = pieceColor;
                    }
                    else if (cell.IsLegalNextMove)
                    {
                        button.BackColor = legalMoveColor;
                    }
                    else if ((row + col) % 2 == 0)
                    {
                        button.BackColor = lightColor;
                    }
                    else
                    {
                        button.BackColor = darkColor;
                    }

                    // Make text readable
                    button.ForeColor = Color.Black;
                }
            }
        } // End of ApplyColorTheme method

        /// <summary>
        /// Change the chessboard colors when a new theme is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbColorThemesSelectedIndexChanged(object sender, EventArgs e)
        {
            // Apply the selected color theme
            ApplyColorTheme();
        }
    }
}
