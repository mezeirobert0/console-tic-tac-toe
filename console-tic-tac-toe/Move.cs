using System.ComponentModel;

namespace console_tic_tac_toe
{
    internal class Move
    {
        private short i;
        private short j;

        public Move(short i, short j)
        {
            this.i = i;
            this.j = j;
        }

        // copy constructor
        public Move(Move move)
        {
            i = move.i;
            j = move.j;
        }

        public short I
        {
            get { return i; }
            set { i = value; }
        }
            
        public short J
        {
            get { return j; }
            set { j = value; }
        }
    }
}
