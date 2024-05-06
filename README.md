# Tic-Tac-Toe — Player vs. Unbeatable Bot — a C# console app
This is a Tic-Tac-Toe game, in a seamless console interface, that allows the player to play against a bot that makes its moves based on the MiniMax algorithm.

## Pre-requisites:
* .NET 8.0 (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Visual Studio with the `.NET desktop development` package (optional)
* Git (used for cloning the project, optional)

## Installation

Open the terminal, navigate to the desired location of the project using `cd` and clone the repository using the following command:
```bash
git clone https://github.com/mezeirobert0/console-tic-tac-toe.git
```
OR
Go to the remote GitHub repository (https://github.com/mezeirobert0/console-tic-tac-toe), go to `Code > Download ZIP` and unzip the folder in the desired location.

## Running the app

### Visual Studio
Double-click on `console-tic-tac-toe.sln` after opening the folder of the project and debug the program.
### Without VS
Navigate to `console-tic-tac-toe\console-tic-tac-toe\bin\Release\net8.0\publish` and double-click on `console-tic-tac-toe.exe`.

## Usage
The user is asked what symbol to play with — X or O
```
Do you want to play as X or O?: X
```
Upper case X or O are the only accepted inputs; in case the user inputs something else, the program will output it's an invalid choice and prompt the user again to type in the desired symbol:
```
Do you want to play as X or O?: 490
Invalid input! Enter X or O and hit enter.
```
X starts first, and O follows after it.
As soon as the user types in X or O and hits enter, a Tic-Tac-Toe Board is displayed:
```
     |     |
  1  |  2  |  3
_____|_____|_____
     |     |
  4  |  5  |  6
_____|_____|_____
     |     |
  7  |  8  |  9
     |     |

Your turn - X

Enter a digit 1-9 from the table:
```
Each of the digits 1-9 represent an empty spot on the board.

Should the user input a digit correspoding to an occupied spot OR something other than a single non-zero digit, the program will notify them it's an invalid input and prompt the user again to type in the number corresponding to an empty spot for the next move:
```
     |     |
  1  |  X  |  3
_____|_____|_____
     |     |
  4  |  X  |  O
_____|_____|_____
     |     |
  7  |  8  |  9
     |     |

Your turn - O

Enter a digit 1-9 from the table: 2
Invalid input!
Enter a digit 1-9 from the table:
```
After the bot/player has made a choice regarding the next move, the console is cleared and the updated board is printed, along with the prompt if it's the player's turn.

It's also worth mentioning that the bot's moves are delayed by 1250 ms.

After the bot wins (It's virtually impossible for the user to win) or all the spots have been occupied and it's a tie, the final state of the game is printed to the console:
```
Bot wins!
```
```
It's a draw!
```
Then the user is asked if they want to replay:
```
Do you want to play again? (Y): 
```
If the input is the uppercase Y, the game starts all over again at asking the user whether they want to play with X or O. Any other input will terminate the console window and thus close the game.
