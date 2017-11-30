using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private bool isBlack = true; // 用來決定換誰下棋
        private Board board = new Board();
        public Form1()
        {
            InitializeComponent();

            this.Controls.Add(new Black(150, 250, 0));
            this.Controls.Add(new Red(100, 200, 0));
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
