using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度 => Y = 0
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度 => X = 0 
        private static int INTERVAL = 25; //任兩條棋盤線的距離

        Piece[,] piece = new Piece[10, 9];
        public void SetBoard(Board board)
        {
            //TODO: 初始化所有黑棋
            piece[0, 0] = new Piece_Car(MARGIN_LEFT, MARGIN_TOP, true); //車
            piece[0, 1] = new Piece_Horse(MARGIN_LEFT + INTERVAL, MARGIN_TOP, true); //馬
            piece[0, 2] = new Piece_Elephant(MARGIN_LEFT + INTERVAL * 2, MARGIN_TOP, true); //象
            piece[0, 3] = new Piece_Guard(MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP, true); //士
            piece[0, 4] = new Piece_General(MARGIN_LEFT + INTERVAL * 4, MARGIN_TOP, true); //將
            piece[0, 5] = new Piece_Guard(MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP, true); //士
            piece[0, 6] = new Piece_Elephant(MARGIN_LEFT + INTERVAL * 6, MARGIN_TOP, true); //象
            piece[0, 7] = new Piece_Horse(MARGIN_LEFT + INTERVAL * 7, MARGIN_TOP, true); //馬
            piece[0, 8] = new Piece_Car(MARGIN_LEFT + INTERVAL * 8, MARGIN_TOP, true);    //車
            piece[2, 1] = new Piece_Bang(MARGIN_LEFT + INTERVAL, MARGIN_TOP + INTERVAL * 2, true);    //炮
            piece[2, 7] = new Piece_Bang(MARGIN_LEFT + INTERVAL * 7, MARGIN_TOP + INTERVAL * 2, true);   //炮
            piece[3, 0] = new Piece_Soldier(MARGIN_LEFT, MARGIN_TOP + INTERVAL * 3, true);  //卒
            piece[3, 2] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 2, MARGIN_TOP + INTERVAL * 3, true); //卒
            piece[3, 4] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 4, MARGIN_TOP + INTERVAL * 3, true); //卒
            piece[3, 6] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 6, MARGIN_TOP + INTERVAL * 3, true); //卒
            piece[3, 8] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 8, MARGIN_TOP + INTERVAL * 3, true); //卒

            //TODO: 初始化所有紅棋
            piece[9, 0] = new Piece_Car(MARGIN_LEFT, MARGIN_TOP  + INTERVAL * 9, false);        //車
            piece[9, 1] = new Piece_Horse(MARGIN_LEFT + INTERVAL, MARGIN_TOP + INTERVAL * 9, false);      //馬
            piece[9, 2] = new Piece_Elephant(MARGIN_LEFT + INTERVAL * 2, MARGIN_TOP + INTERVAL * 9, false);  //相
            piece[9, 3] = new Piece_Guard(MARGIN_LEFT + INTERVAL * 3, MARGIN_TOP + INTERVAL * 9, false);     //仕
            piece[9, 4] = new Piece_General(MARGIN_LEFT + INTERVAL * 4, MARGIN_TOP + INTERVAL * 9, false);   //帥
            piece[9, 5] = new Piece_Guard(MARGIN_LEFT + INTERVAL * 5, MARGIN_TOP + INTERVAL * 9, false);     //仕
            piece[9, 6] = new Piece_Elephant(MARGIN_LEFT + INTERVAL * 6, MARGIN_TOP + INTERVAL * 9, false);  //相
            piece[9, 7] = new Piece_Horse(MARGIN_LEFT + INTERVAL * 7, MARGIN_TOP + INTERVAL * 9, false);     //馬
            piece[9, 8] = new Piece_Car(MARGIN_LEFT + INTERVAL * 8, MARGIN_TOP + INTERVAL * 9, false);       //車
            piece[7, 1] = new Piece_Bang(MARGIN_LEFT + INTERVAL, MARGIN_TOP + INTERVAL * 7, false);       //炮
            piece[7, 7] = new Piece_Bang(MARGIN_LEFT + INTERVAL * 7, MARGIN_TOP + INTERVAL * 7, false);      //炮
            piece[6, 0] = new Piece_Soldier(MARGIN_LEFT, MARGIN_TOP + INTERVAL * 6, false);    //兵
            piece[6, 2] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 2, MARGIN_TOP + INTERVAL * 6, false);   //兵
            piece[6, 4] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 4, MARGIN_TOP + INTERVAL * 6, false);   //兵
            piece[6, 6] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 6, MARGIN_TOP + INTERVAL * 6, false);   //兵
            piece[6, 8] = new Piece_Soldier(MARGIN_LEFT + INTERVAL * 8, MARGIN_TOP + INTERVAL * 6, false);   //兵
        }
        public Piece[,] GetPiece()
        {
            return piece;
        }

        /*
        public bool CanBePlaced(int x, int y)
        {
            //找出最近的節點
            Point nodeId = FindTheClosestNode(x, y);
            //如果沒有，回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;
            //如果有，檢查是否已經有棋子
            return true;
        }
        private Point FindTheClosestNode(int x, int y)
        {
            int nodeIdX = FindTheClosestNode(x);
            if (nodeIdX == -1)
                return NO_MATCH_NODE;

            int nodeIdY = FindTheClosestNode(y);
            if (nodeIdY == -1)
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }
        private int FindTheClosestNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;
            pos -= OFFSET;
            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;
            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
        */
    }
}
