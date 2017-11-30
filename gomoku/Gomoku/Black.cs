using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// type
// 0 = general, 1 = guard, 2 = elephant, 3 = car, 4 = horse, 5 = bang, 6 = soldier
namespace Gomoku
{
    class Black : Piece
    {
        public Black(int x, int y, int type) : base(x, y)
        {
            switch (type)
            {
                case 0: this.Image = Properties.Resources.general_black; break;
                case 1: this.Image = Properties.Resources.guard_black; break;
                case 2: this.Image = Properties.Resources.elephant_black; break;
                case 3: this.Image = Properties.Resources.car_black; break;
                case 4: this.Image = Properties.Resources.horse_black; break;
                case 5: this.Image = Properties.Resources.bang_black; break;
                default: this.Image = Properties.Resources.soldier_black; break;
            }
        }

    }
}
