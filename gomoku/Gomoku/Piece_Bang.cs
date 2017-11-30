using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Bang : Piece
    {
        public Piece_Bang (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.bang_black;
            else
                this.Image = Properties.Resources.bang_red;
        }
    }
}
