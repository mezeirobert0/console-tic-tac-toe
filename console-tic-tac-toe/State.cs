using System.ComponentModel.DataAnnotations;

namespace console_tic_tac_toe
{
    enum Result { X, O, draw, none}
    internal class State
    {
        private char[,] board;
        private Result result;
        private char turn;
        private short depth;
        private short value;

        public short Value
        {
            get { return value; }
        }

        public char Turn
        {
            get { return turn; }
        }

        public short Depth
        {
            get { return depth; }
        }

        public State(State? old = null, Move? move = null) 
        {   
            // initializing an empty board
            board = new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } };

            // neither of the players has won yet, nor is it a draw
            result = Result.none;

            // X always makes the first move
            turn = 'X'; 

            // neither of the playes has made a move yet
            depth = 0;

            if (old != null)
            {
                for (short i = 0; i < 3; i++)
                    for (short j = 0; j < 3; j++)
                        board[i, j] = old.board[i, j];

                result = old.result;
                turn = old.turn;
                depth = old.depth;
            }

            if (move != null)
            {
                if (depth == 9)
                    throw new InvalidOperationException("The board is already full!");
                
                if (board[move.I, move.J] != '\0')
                    throw new InvalidOperationException("The spot is occupied!");

                board[move.I, move.J] = turn;
                depth++;

                // checking if a player has won or if it's a draw

                // a player can win only if at least 5 moves have been made
                if (depth >= 5)
                {
                    // first row
                    if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // second row
                    else if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 0] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // third row
                    else if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // first column
                    else if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // second column
                    else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // third column
                    else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // first diagonal
                    else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    // second diagonal
                    else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != '\0')
                    {
                        value = (short)(turn == 'X' ? 1 : -1);
                        result = turn == 'X' ? Result.X : Result.O;
                    }

                    else
                    {
                        if (depth < 9) 
                            result = Result.none; // the game is still on

                        else
                        {
                            result = Result.draw; // it's a draw
                            value = 0; // the value is 0 in case of a draw
                        }
                    }
                }

                turn = turn == 'X' ? 'O' : 'X'; // changing the turn
            }
        }

        public void DisplayBoard()
        {
            for (short i = 0; i < 3; i++)
            {
                for (short j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                        Console.Write("  ");
                    else
                        Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Move[] GetEmptyCells()
        {
            Move[] emptyCells = new Move[9-depth];
            short n = 0;

            for (short i = 0; i < 3; i++)
                for (short j = 0; j < 3; j++)
                    if (board[i, j] == '\0')
                        emptyCells[n++] = new Move(i, j);

            return emptyCells;
        }



        // minimax function for determining the current state's score and the next best move
        public Move Minimax()
        {
            Move nextMove = new Move(-1, -1);
            
            // if the state is a terminal one (win or draw) we already know its value
            if (result != Result.none)
                return nextMove;

            if (turn == 'X')
            {
                value = -10000;
                Move[] possibleMoves = GetEmptyCells();

                foreach (Move possibleMove in possibleMoves) 
                {
                    State nextState = new State(this, possibleMove);
                    nextState.Minimax();

                    // value = Math.Max(value, nextState.value);
                    if (nextState.value > value)
                    {
                        value = nextState.value;
                        nextMove.I = possibleMove.I;
                        nextMove.J = possibleMove.J;
                    }
                }
            }

            if (turn == 'O')
            {
                value = 10000;
                Move[] possibleMoves = GetEmptyCells();

                foreach (Move possibleMove in possibleMoves)
                {
                    State nextState = new State(this, possibleMove);
                    nextState.Minimax();

                    // value = Math.Max(value, nextState.value);
                    if (nextState.value < value)
                    {
                        value = nextState.value;
                        nextMove.I = possibleMove.I;
                        nextMove.J = possibleMove.J;
                    }
                }
            }

            return nextMove;
        }
    }
}
