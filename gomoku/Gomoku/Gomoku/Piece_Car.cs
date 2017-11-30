using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_Car : Piece
    {
        public Piece_Car (int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.car_black;
            else
                this.Image = Properties.Resources.car_red;
        }
    }
}
