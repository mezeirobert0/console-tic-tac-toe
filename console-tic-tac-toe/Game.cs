namespace console_tic_tac_toe
{
    internal class Game
    {   
        private State state; // the current game state
        private string playerSymbol;
        private string botSymbol;

        public Game()
        {
            state = new State(); // initializing the state
            playerSymbol = botSymbol = "\0"; // initializing the player's and bot's symbols
        }

        public void RunGame()
        {
            playGame: // label to come back to if the player wants to play again
            Console.Write("Do you want to play as X or O?: ");
            playerSymbol = Console.ReadLine();

            // the player must input a symbol until a valid one (X or O) is inputted
            while (playerSymbol != "X" && playerSymbol != "O")
            {
                Console.Write("Invalid input! Enter X or O and hit enter: ");

                playerSymbol = Console.ReadLine();
            }

            botSymbol = playerSymbol[0] == 'X' ? "O" : "X";

            // while the game is not over yet
            while (state.Result == Result.none)
            {
                Console.Clear();
                state.DisplayBoard();
                Console.WriteLine();

                if (state.Turn == botSymbol[0])
                {
                    Console.WriteLine("Bot\'s turn - {0}\n", botSymbol);
                    Thread.Sleep(1250); // delaying the bot's move by 1250 ms
                    Move nextMove = state.Minimax(); // calculating the next best move
                    state = new State(state, nextMove); // applying the next best move to the current state
                }

                else
                {
                    Console.WriteLine("Your turn - {0}\n", playerSymbol);
                    Move nextMove = new Move(-1, -1); // initializing the player's move

                    playerInput: // label to come back to if the player's input is invalid
                    Console.Write("Enter a digit 1-9 from the table: ");
                    string digit = "\0"; // the player can input the digit corresponding to a square on the board 
                                         // 1 for [0, 0], 2 for [0, 1], etc.

                    digit = Console.ReadLine();

                    switch (digit[0])
                    {
                        case '1':
                            nextMove = new Move(0, 0);
                            break;
                        case '2':
                            nextMove = new Move(0, 1);
                            break;
                        case '3':
                            nextMove = new Move(0, 2);
                            break;
                        case '4':
                            nextMove = new Move(1, 0);
                            break;
                        case '5':
                            nextMove = new Move(1, 1);
                            break;
                        case '6':
                            nextMove = new Move(1, 2);
                            break;
                        case '7':
                            nextMove = new Move(2, 0);
                            break;
                        case '8':
                            nextMove = new Move(2, 1);
                            break;
                        case '9':
                            nextMove = new Move(2, 2);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }

                    // the player must input a string until a string with a single digit 1-9 is inputted
                    while (digit[0] < '1' || digit[0] > '9')
                    {
                        Console.Write("Enter a digit 1-9 from the table: ");
                        digit = Console.ReadLine();

                        switch (digit[0])
                        {
                            case '1':
                                nextMove = new Move(0, 0);
                                break;
                            case '2':
                                nextMove = new Move(0, 1);
                                break;
                            case '3':
                                nextMove = new Move(0, 2);
                                break;
                            case '4':
                                nextMove = new Move(1, 0);
                                break;
                            case '5':
                                nextMove = new Move(1, 1);
                                break;
                            case '6':
                                nextMove = new Move(1, 2);
                                break;
                            case '7':
                                nextMove = new Move(2, 0);
                                break;
                            case '8':
                                nextMove = new Move(2, 1);
                                break;
                            case '9':
                                nextMove = new Move(2, 2);
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                    }

                    try
                    {
                        state = new State(state, nextMove); // applying the next best move to the current state
                    }
                    catch (InvalidOperationException _)
                    {
                        Console.WriteLine("Invalid input!");
                        goto playerInput; // the player has inputted a digit 1-9, but that spot was already occupied
                    }
                    
                }
            }

            Console.Clear();
            state.DisplayBoard();
            Console.WriteLine();

            switch (state.Result)
            {
                case Result.X:
                    Console.WriteLine("{0} Wins!", playerSymbol == "X" ? "Player": "Bot");
                    break;

                case Result.O:
                    Console.WriteLine("{0} Wins!", playerSymbol == "O" ? "Player" : "Bot");
                    break;

                default:
                    Console.WriteLine("It's a draw!");
                    break;

            }

            Console.Write("Do you want to play again? (Y): ");
            string playAgain = "\0";
            playAgain = Console.ReadLine();

            if (playAgain == "Y")
            {
                state = new State();
                playerSymbol = botSymbol = "\0";
                Console.Clear();
                goto playGame; // coming back to the label to play again
            }
        }
    }
}
