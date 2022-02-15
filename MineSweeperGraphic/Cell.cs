using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGraphic
{
    public struct Cell
    {
        public int side = 0;
        public int x = 0, y = 0;
        public int number = 0;
        public enum State
        {
            Opened,
            Closed,
            Flag,
            Bomb
        }
        public State cell_state = State.Closed;

        public Cell(int x, int y, int side)
        {
            this.side = side;
            this.x = x;
            this.y = y;
        }



    }
}
