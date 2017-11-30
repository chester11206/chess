using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Piece_General : Piece
    {
        public Piece_General(int x, int y, bool isBlack) : base(x, y, isBlack)
        {
            if (isBlack)
                this.Image = Properties.Resources.general_black;
            else
                this.Image = Properties.Resources.general_red;
        }
    }
}
