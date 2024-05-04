using console_tic_tac_toe;
internal class Program
{
    private static void Main(string[] args)
    {
        // trying the Minimax function

        State state = new State(); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(0, 0)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(1, 1)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(2, 2)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(2, 1)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(0, 1)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        state = new State(state, new Move(0, 2)); Console.WriteLine("{0}, {1}", state.Turn, state.Depth);
        Console.WriteLine();

        var possibleMoves = state.getEmptyCells();
        foreach (var possibleMove in possibleMoves)
        {
                Console.Write(possibleMove.I);
                Console.Write(' ');
                Console.Write(possibleMove.J);
                Console.Write('\n');
        }

        state.Minimax();
        Console.WriteLine(state.Value);
    }
}