using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        private Piece[,] piece = new Piece[10, 9];
        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度
        private static int INTERVAL = 25; //任兩條棋盤線的距離

        public Form1()
        {
            InitializeComponent();
            board.SetBoard(board);
            piece = board.GetPiece();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.Controls.Add(piece[i, j]);
                    this.BringToFront();
                }
            }

        }

        //private bool isBlack = true; // 用來決定換誰下棋
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = MARGIN_LEFT * 2 + INTERVAL * 8; //resize 
            panel1.Height = MARGIN_TOP * 2 + INTERVAL * 9; //resize

            Pen blackPen = new Pen(Color.Black);
            Pen blackWidthPen = new Pen(Color.Black, 3);
            Pen blackWidthPen2 = new Pen(Color.White, 2);
            //豎線
            for (int i = MARGIN_LEFT; i <= MARGIN_LEFT + INTERVAL * 8; i += INTERVAL) 
                e.Graphics.DrawLine(blackPen, i, MARGIN_TOP, i, MARGIN_TOP + INTERVAL * 9);
            //橫線
            for (int i = MARGIN_TOP; i <= MARGIN_TOP + INTERVAL * 9; i += INTERVAL)
                e.Graphics.DrawLine(blackPen, MARGIN_LEFT, i, MARGIN_LEFT + INTERVAL * 8, i);
            // 外框
            e.Graphics.DrawLine(blackWidthPen, MARGIN_LEFT - 3, MARGIN_TOP - 3, MARGIN_LEFT - 3, MARGIN_TOP + INTERVAL * 9 + 3); // 左
            e.Graphics.DrawLine(blackWidthPen, MARGIN_LEFT + INTERVAL * 8 + 3, MARGIN_TOP - 3, MARGIN_LEFT + INTERVAL * 8 + 3, MARGIN_TOP + INTERVAL * 9); // 右
            e.Graphics.DrawLine(blackWidthPen, MARGIN_LEFT - 4, MARGIN_TOP - 3, MARGIN_LEFT + INTERVAL * 8 + 4, MARGIN_TOP - 3); // 上
            e.Graphics.DrawLine(blackWidthPen, MARGIN_LEFT - 4, MARGIN_TOP + INTERVAL * 9 + 3, MARGIN_LEFT + INTERVAL * 8 + 4, MARGIN_TOP + INTERVAL * 9 + 3); // 下
            // XX
            e.Graphics.DrawLine(blackPen, MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP, MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP + INTERVAL * 2);
            e.Graphics.DrawLine(blackPen, MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP, MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP + INTERVAL * 2);
            e.Graphics.DrawLine(blackPen, MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP + INTERVAL * 7, MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP + INTERVAL * 9);
            e.Graphics.DrawLine(blackPen, MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP + INTERVAL * 9, MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP + INTERVAL * 7);
            //楚河漢界  => is there a better way to build it?
            panel2.Width = INTERVAL * 8 - 4;
            panel2.Height = INTERVAL - 2;
            panel2.Location = new Point(MARGIN_LEFT + 2, MARGIN_TOP + INTERVAL * 4 + 2);
            label1.Width = INTERVAL * 8 - 4;
            label1.Height = INTERVAL - 2;
            label1.Location = new Point(MARGIN_LEFT + INTERVAL + 2, MARGIN_TOP + INTERVAL * 4 + 2);
            // 將panel1移至最下層
            panel1.SendToBack();
        }

        /*private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //因為圖案的左上角會定位於e.X e.Y，為了要讓棋子中心點位於交叉點，應位移
            //直接於peice.cs中定義棋子位移後的位置
            if (isBlack && board.CanBePlaced(e.X, e.Y))
            {
                this.Controls.Add(new Black(e.X, e.Y));
                isBlack = false;
            }
            else if(!isBlack && board.CanBePlaced(e.X, e.Y))
            {
                this.Controls.Add(new white(e.X, e.Y));
                isBlack = true;
            }
            
        }*/

        /*private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           if(board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            
        }*/
    }
}
