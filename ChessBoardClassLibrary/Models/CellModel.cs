/*
 * Keon Bushman
 * CST - 250
 * 05/31/2026
 * Chess Board Project
 * Activity 2
 * Activity 2 Guide
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardClassLibrary.Models
{
    public class CellModel
    {
        // Class level properties with public getters and private setters.
        // This is an example of encapsulation: external code can read the values,
        // but only this class can modify them.
        public int Row { get; private set; }
        public int Column { get; private set; }

        // These properties need to be both readable and writable from outside the model,
        // so we use public getters and setters. This is appropriate for properties
        // where external components (e.g., the board logic) are responsible for updating them.
        public string PieceOccupyingCell { get; set; }
        public bool IsLegalNextMove { get; set; }

        /// <summary>
        /// Parameterized Constructor for cell model class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public CellModel(int row, int column)
        {
            Row = row;
            Column = column;

            // Set default values for the other properties
            PieceOccupyingCell = "";
            IsLegalNextMove = false;
        }
    }
}
