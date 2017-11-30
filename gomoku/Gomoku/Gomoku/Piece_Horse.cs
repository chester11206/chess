using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Horse : Piece
    {
        public Piece_Horse (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.horse_black;
            else
                this.Image = Properties.Resources.horse_red;
        }
    }
}
