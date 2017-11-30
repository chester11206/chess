using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Soldier : Piece
    {
        public Piece_Soldier (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.soldier_black;
            else
                this.Image = Properties.Resources.soldier_red;
        }
    }
}
