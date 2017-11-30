using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Elephant : Piece
    {
        public Piece_Elephant (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.elephant_black;
            else
                this.Image = Properties.Resources.elephant_red;
        }
    }
}
