namespace console_tic_tac_toe
{
    internal static class Helper
    {
        // Knuth Shuffle method for randomly shuffling an array of Move objects
        public static void ShuffleMoves(this Random rng, Move[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);

                Move temp = new Move(array[n]);

                array[n].I = array[k].I;
                array[n].J = array[k].J;

                array[k].I = temp.I;
                array[k].J = temp.J;
            }
        }
    }
}
