# Chess Move Visualizer

A complete **C# chess movement visualizer** that shows the legal movement pattern of a selected chess piece from any square on an empty 8×8 board. The solution includes a reusable class library plus both **Windows Forms** and **console** clients.

<p>
  <img src="https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/Windows%20Forms-Desktop-0078D4?style=flat-square&logo=windows11&logoColor=white" alt="Windows Forms" />
  <img src="https://img.shields.io/badge/Console-Client-555555?style=flat-square" alt="Console Client" />
  <img src="https://img.shields.io/badge/Status-Complete-238636?style=flat-square" alt="Project status: Complete" />
</p>

## Overview

Chess Move Visualizer is a desktop practice project focused on reusable object-oriented logic, two-dimensional board modeling, and graphical visualization. A user selects a chess piece, chooses a square, and the application marks every square that piece can reach according to its basic movement pattern.

The movement engine lives in a shared class library, allowing both the Windows Forms interface and the console application to use the same board and move-generation logic.

> This project is a **movement visualizer**, not a complete chess engine. It evaluates movement on an otherwise empty board and does not implement captures, blocking pieces, check, checkmate, pawns, castling, or complete game-state rules.

## Supported Pieces

- King
- Queen
- Bishop
- Knight
- Rook

Each selected piece is placed on the chosen square and its available movement pattern is calculated across the board.

## Features

- Interactive 8×8 chessboard
- Legal movement visualization for five standard chess pieces
- Boundary checking to prevent off-board moves
- Reusable board and cell models
- Dedicated business-logic layer for move generation
- Windows Forms graphical client
- Console-based client using the same class library
- Coordinate validation in the console application
- Dynamic GUI board generated from a two-dimensional button array
- Multiple board color themes
- Dedicated highlighting for the selected piece and legal moves
- Clear separation between board state, movement logic, and presentation

## Movement Logic

The application uses a different strategy for each chess piece.

### Knight

The knight uses eight predefined row-and-column offsets. Each candidate location is checked against the board boundaries before being marked as legal.

### Rook

Every square sharing the selected piece's row or column is marked as a legal move.

### Bishop

A square is considered diagonal when the absolute row difference equals the absolute column difference.

### Queen

Queen movement combines the rook and bishop movement calculations.

### King

The king checks the eight surrounding positions by iterating through row and column offsets from `-1` through `1`, excluding the current square.

## Windows Forms Client

The graphical application builds an 8×8 board from a two-dimensional array of buttons. After selecting a chess piece, the user clicks any square to calculate and display its movement pattern.

The chosen square displays the piece name, while reachable squares are labeled as legal moves.

### Color Themes

The interface includes several selectable board themes:

- Default
- Cool
- Warm
- Neon
- Pastel

Legal-move and selected-piece colors are applied separately from the alternating board-square colors so the current state remains easy to identify.

## Console Client

The console application provides the same core functionality in a text interface.

It:

1. Prints an empty chessboard.
2. Prompts for a supported chess piece.
3. Validates the selected piece.
4. Prompts for a row and column from `0` through `7`.
5. Validates both coordinates.
6. Calculates the legal movement pattern using the shared class library.
7. Prints the updated board with the selected piece and legal moves.

In the console display, `+` represents a legal destination and the selected piece is represented by its letter.

## Architecture

```text
ChessBoardClassLibrary/
├── ChessBoardClassLibrary/
│   ├── Models/
│   │   ├── BoardModel.cs
│   │   └── CellModel.cs
│   ├── Services/
│   │   └── BusinessLogicLayer/
│   │       └── BoardLogic.cs
│   └── ChessBoardClassLibrary.csproj
├── ChessBoardGUIApp/
│   ├── FrmChessBoard.cs
│   ├── FrmChessBoard.Designer.cs
│   ├── Program.cs
│   └── ChessBoardGUIApp.csproj
├── ChessBoardConsoleApp/
│   ├── Program.cs
│   └── ChessBoardConsoleApp.csproj
└── ChessBoardClassLibrary.slnx
```

### Models

`BoardModel` represents the chessboard as a two-dimensional collection of `CellModel` objects. Each cell tracks its location, whether it is currently a legal destination, and whether a selected piece occupies it.

### Business Logic

`BoardLogic` contains the movement rules. The presentation applications send the selected board cell and piece type to this layer, which resets the board state, places the piece, and marks valid destination cells.

### Presentation

The GUI and console projects independently display the board while sharing the same underlying models and movement calculations.

## Running the Project

### Requirements

- Windows 10 or Windows 11 for the Windows Forms client
- Visual Studio with .NET desktop development support, or the .NET 10 SDK

Clone the repository:

```bash
git clone https://github.com/IPFizzy/ChessBoardClassLibrary.git
cd ChessBoardClassLibrary
```

Open `ChessBoardClassLibrary.slnx` in Visual Studio.

### Run the graphical client

```bash
dotnet run --project ChessBoardGUIApp/ChessBoardGUIApp.csproj
```

### Run the console client

```bash
dotnet run --project ChessBoardConsoleApp/ChessBoardConsoleApp.csproj
```

### Build the full solution

```bash
dotnet build ChessBoardClassLibrary.slnx
```

## Practice Project Context

This repository began as a focused exercise in class libraries, two-dimensional arrays, and object-oriented application design and is preserved as a completed practice project. The finished solution demonstrates board modeling, piece-specific algorithms, input validation, reusable business logic, dynamic Windows Forms controls, theming, and multiple presentation layers.

## Recommended Repository Name

For a public portfolio, **`ChessMoveVisualizer`** is a stronger repository name than `ChessBoardClassLibrary` because it describes what the finished application actually does rather than how its code is organized.

The internal solution, project, folder, and namespace names can remain unchanged after the GitHub repository itself is renamed.

## Author

**Keon Bushman**  
Software Development Student & IT Professional  
[GitHub Profile](https://github.com/IPFizzy)
