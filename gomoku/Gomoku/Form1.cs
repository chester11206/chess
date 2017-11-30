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
        //private bool isBlack = true; // 用來決定換誰下棋
        private Board board = new Board();
        public Form1()
        {
            InitializeComponent();

            //TODO: 初始化所有黑棋
            this.Controls.Add(new Piece_General(155, 20, true));  //將
            this.Controls.Add(new Piece_Guard(130, 20, true));    //士
            this.Controls.Add(new Piece_Guard(180, 20, true));    //士
            this.Controls.Add(new Piece_Elephant(105, 20, true)); //象
            this.Controls.Add(new Piece_Elephant(205, 20, true)); //象
            this.Controls.Add(new Piece_Horse(80, 20, true));     //馬
            this.Controls.Add(new Piece_Horse(230, 20, true));    //馬
            this.Controls.Add(new Piece_Car(55, 20, true));       //車
            this.Controls.Add(new Piece_Car(255, 20, true));      //車
            this.Controls.Add(new Piece_Bang(80, 70, true));      //炮
            this.Controls.Add(new Piece_Bang(230, 70, true));     //炮
            this.Controls.Add(new Piece_Soldier(55, 95, true));  //卒
            this.Controls.Add(new Piece_Soldier(105, 95, true)); //卒
            this.Controls.Add(new Piece_Soldier(155, 95, true)); //卒
            this.Controls.Add(new Piece_Soldier(205, 95, true)); //卒
            this.Controls.Add(new Piece_Soldier(255, 95, true)); //卒


            //TODO: 初始化所有紅棋
            this.Controls.Add(new Piece_General(155, 240, false));   //帥
            this.Controls.Add(new Piece_Guard(130, 240, false));     //仕
            this.Controls.Add(new Piece_Guard(180, 240, false));     //仕
            this.Controls.Add(new Piece_Elephant(105, 240, false));  //相
            this.Controls.Add(new Piece_Elephant(205, 240, false));  //相
            this.Controls.Add(new Piece_Horse(80, 240, false));      //馬
            this.Controls.Add(new Piece_Horse(230, 240, false));     //馬
            this.Controls.Add(new Piece_Car(55, 240, false));        //車
            this.Controls.Add(new Piece_Car(255, 240, false));       //車
            this.Controls.Add(new Piece_Bang(80, 190, false));       //炮
            this.Controls.Add(new Piece_Bang(230, 190, false));      //炮
            this.Controls.Add(new Piece_Soldier(55, 165, false));    //兵
            this.Controls.Add(new Piece_Soldier(105, 165, false));   //兵
            this.Controls.Add(new Piece_Soldier(155, 165, false));   //兵
            this.Controls.Add(new Piece_Soldier(205, 165, false));   //兵
            this.Controls.Add(new Piece_Soldier(255, 165, false));   //兵



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
