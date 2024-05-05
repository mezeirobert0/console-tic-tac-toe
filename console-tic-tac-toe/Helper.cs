namespace console_tic_tac_toe
{
    internal static class Helper
    {
        // Knuth Shuffle method for shuffling an array of Move objects
        public static void ShuffleMoves(this Random rng, Move[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                Move temp = new Move(array[n]);
                array[n] = new Move(array[k]);
                array[k] = new Move(temp);
            }
        }
    }
}
