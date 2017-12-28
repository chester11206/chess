using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    public class Target:Button
    {
        private static readonly int PIECE_WIDTH = 25;
        public static readonly int TARGET_SIZE = 15;
        public static readonly int CORNER_SIZE = 5;
        private bool _fromSide;
        private int _fromId;
        private int _CoX;
        private int _CoY;
        private Piece _canEat;

        public Target(int CoX, int CoY, bool side, int id, Piece canEat)
        {
            this.ForeColor = Color.Transparent;//前景  
            this.BackColor = Color.Transparent;//去背景
            this.FlatStyle = FlatStyle.Popup;
            this.FlatAppearance.BorderSize = 0;//去边线  
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过  
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下  
            this.Location = Transform.getCoordinate(CoX, CoY, TARGET_SIZE);
            this.Size = new Size(TARGET_SIZE, TARGET_SIZE);
            this.Paint += new PaintEventHandler(target_paint);
            this._fromSide = side;
            this._fromId = id;
            this._CoX = CoX;
            this._CoY = CoY;
            this._canEat = canEat;
        }

        private void target_paint(object sender, PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, 6);
            e.Graphics.DrawLine(redPen, 0, 0, CORNER_SIZE, 0);  //左上橫
            e.Graphics.DrawLine(redPen, 0, 0, 0, CORNER_SIZE);  //左上豎
            e.Graphics.DrawLine(redPen, 0, TARGET_SIZE-1, CORNER_SIZE, TARGET_SIZE-1);  //左下橫
            e.Graphics.DrawLine(redPen, 0, TARGET_SIZE, 0, TARGET_SIZE - CORNER_SIZE-1);  //左下豎
            e.Graphics.DrawLine(redPen, TARGET_SIZE-1, TARGET_SIZE-1, TARGET_SIZE-1, TARGET_SIZE - CORNER_SIZE-1);  //右下豎
            e.Graphics.DrawLine(redPen, TARGET_SIZE-1, TARGET_SIZE-1, TARGET_SIZE - CORNER_SIZE-1, TARGET_SIZE-1);  //右下橫
            e.Graphics.DrawLine(redPen, TARGET_SIZE, 0, TARGET_SIZE - CORNER_SIZE, 0);  //右上橫
            e.Graphics.DrawLine(redPen, TARGET_SIZE-1, 0, TARGET_SIZE-1, CORNER_SIZE);  //右上豎

        }

        public bool fromSide
        {
            get
            {   return _fromSide;   }
            set
            {   _fromSide = value;  }
        }

        public int fromId
        {
            get
            {   return _fromId; }
            set
            {   _fromId = value;    }
        }

        public int CoX
        {
            get
            {   return _CoX;    }
            set
            {   _CoX = value;   }
        }

        public int CoY
        {
            get
            { return _CoY; }
            set
            { _CoY = value; }
        }

        public Piece canEat
        {
            get
            { return _canEat; }
            set
            { _canEat = value; }
        }
    }
}
