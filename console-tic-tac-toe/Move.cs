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

        public short I
        {
            get { return i; }
        }
            
        public short J
        {
            get { return j; }
        }
    }
}
