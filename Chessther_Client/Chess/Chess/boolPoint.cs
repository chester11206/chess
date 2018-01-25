using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public class boolPoint
    {
        private Piece _canEat;
        private Point _Location= new Point(-1,-1);

        public boolPoint(Piece e, Point l)
        {
            this._canEat = e;
            this._Location = l;
        }

        public Piece canEat
        {
            get
            { return _canEat; }
            set
            { _canEat = value; }
        }

        public Point Location
        {
            get
            { return _Location; }
            set
            { _Location = value; }
        }
    }
}
