# Battleship game

## About
There are two Destroyers on a board (4 cells), and one Battleship (5 cells). Shot them all to win the game. The board is harcoded (10x10). 

## Installation
- .NET7 SDK
- npm >17.X (if web)

## Console Game
Use keyboard to indicate which cell you want to try. Rows are marked as 1-10 numbers, columns as A-J. Plece column first, for example A5.

Type 'surrender' if you want to give up and print final board.

Instruction:
```
dotnet restore
dotnet build
dotnet test

cd .\Guestline.Battleships.Console
dotnet run
```

## Stateful web game (with UI)
Server remembers state of the game. If you restart it, you can't restore the state. The UI is intuitive.

Instruction:
```
cd .\Guestline.Battleships.Web\web
npm install
npm run build

cd ../..
dotnet restore
dotnet build

cd .\Guestline.Battleships.Web
dotnet run
```
Note: the game will be available on localhost, see the console (usually localhost:5000 or similar)