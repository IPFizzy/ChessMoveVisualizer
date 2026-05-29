namespace ChessBoardGUIApp
{
    partial class FrmChessBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbChessPieces = new ComboBox();
            lblSelectMessage = new Label();
            lblPieces = new Label();
            pnlChessBoard = new Panel();
            lblTheme = new Label();
            cmbColorThemes = new ComboBox();
            SuspendLayout();
            // 
            // cmbChessPieces
            // 
            cmbChessPieces.FormattingEnabled = true;
            cmbChessPieces.Items.AddRange(new object[] { "King", "Queen", "Bishop", "Knight", "Rook" });
            cmbChessPieces.Location = new Point(566, 7);
            cmbChessPieces.Name = "cmbChessPieces";
            cmbChessPieces.Size = new Size(121, 23);
            cmbChessPieces.TabIndex = 0;
            // 
            // lblSelectMessage
            // 
            lblSelectMessage.AutoSize = true;
            lblSelectMessage.Location = new Point(12, 15);
            lblSelectMessage.Name = "lblSelectMessage";
            lblSelectMessage.Size = new Size(394, 15);
            lblSelectMessage.TabIndex = 1;
            lblSelectMessage.Text = "Select a chess piece and its location on the board and see the legal moves";
            // 
            // lblPieces
            // 
            lblPieces.AutoSize = true;
            lblPieces.Location = new Point(522, 10);
            lblPieces.Name = "lblPieces";
            lblPieces.Size = new Size(43, 15);
            lblPieces.TabIndex = 2;
            lblPieces.Text = "Pieces:";
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(12, 33);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(500, 500);
            pnlChessBoard.TabIndex = 3;
            // 
            // lblTheme
            // 
            lblTheme.AutoSize = true;
            lblTheme.Location = new Point(518, 61);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(47, 15);
            lblTheme.TabIndex = 5;
            lblTheme.Text = "Theme:";
            // 
            // cmbColorThemes
            // 
            cmbColorThemes.FormattingEnabled = true;
            cmbColorThemes.Items.AddRange(new object[] { "Classic", "Cool", "Warm", "Neon", "Pastel" });
            cmbColorThemes.Location = new Point(566, 58);
            cmbColorThemes.Name = "cmbColorThemes";
            cmbColorThemes.Size = new Size(121, 23);
            cmbColorThemes.TabIndex = 4;
            cmbColorThemes.SelectedIndexChanged += CmbColorThemesSelectedIndexChanged;
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 546);
            Controls.Add(lblTheme);
            Controls.Add(cmbColorThemes);
            Controls.Add(pnlChessBoard);
            Controls.Add(lblPieces);
            Controls.Add(lblSelectMessage);
            Controls.Add(cmbChessPieces);
            Name = "FrmChessBoard";
            Text = "Chess Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbChessPieces;
        private Label lblSelectMessage;
        private Label lblPieces;
        private Panel pnlChessBoard;
        private Label lblTheme;
        private ComboBox cmbColorThemes;
    }
}
