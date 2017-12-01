using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Gomoku
{
    abstract class Piece : OvalPictureBox
    {
        private static readonly int PIECE_WIDTH = 25;
        public Piece(int x, int y, bool isBlack) {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            this.BackColor = Color.SandyBrown;
            this.Location = new Point(x - PIECE_WIDTH/2, y - PIECE_WIDTH/2);
            this.Size = new Size(PIECE_WIDTH, PIECE_WIDTH);
        }
        
    }
}
