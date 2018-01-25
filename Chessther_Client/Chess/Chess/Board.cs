using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        private static readonly int PIECE_WIDTH = 25;

        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度 => Y = 0
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度 => X = 0 
        private static int INTERVAL = 25; //任兩條棋盤線的距離

        
        Piece[,] piece = new Piece[2, 16];
        public void SetBoard(Board board)
        {
            //TODO: 初始化所有黑棋
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    piece[i, j] = new Piece(j+1, 9*i+1, Transform.getType(j), !Convert.ToBoolean(i), j);
                }
            }
            for(int i = 0; i < 2; i++)
            {
                for(int j = 9; j < 11; j++)
                {
                    piece[i, j] = new Piece(6 * j - 52, 5 * i + 3, Transform.getType(j), !Convert.ToBoolean(i), j);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 11; j < 16; j++)
                {
                    piece[i, j] = new Piece(2*j-21, 3*i+4, Transform.getType(j), !Convert.ToBoolean(i), j);
                }
            }


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