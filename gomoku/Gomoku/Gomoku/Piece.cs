﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int PIECE_WIDTH = 50;
        public Piece(int x, int y) {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - PIECE_WIDTH/2, y - PIECE_WIDTH/2);
            this.Size = new Size(PIECE_WIDTH, PIECE_WIDTH);
        }
    }
}