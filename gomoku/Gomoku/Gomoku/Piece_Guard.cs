using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Guard : Piece
    {
        public Piece_Guard (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.guard_black;
            else
                this.Image = Properties.Resources.guard_red;
        }
    }
}
