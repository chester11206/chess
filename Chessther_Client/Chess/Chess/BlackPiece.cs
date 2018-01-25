using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class BlackPiece:Piece
    {
        public BlackPiece(int x, int y):base(x, y)
        {
            this.Image = Properties.Resources.black;
            this.MouseClick += new MouseEventHandler(bp_MouseClick);
            this.type = 1;
            this.side = false;
            this.CoX = this.Location.X;
            this.CoY = this.Location.Y;
        }

        // private int _CursorInitialX = 0, _CursorInitialY = 0;

        // 狀態，包含換誰進攻(side)、是否在選擇中(selecting)、準備移動的棋子編號(index)
        // 有問題，每次呼叫都只能重新初始化一個新的，沒辦法使用之前紀錄的狀態
        static Situation state = new Situation(false, false, -1);

        // 被點擊時的事件
        private void bp_MouseClick(object sender, EventArgs e)
        {
            if (!state.selecting)
            {
                if(this.side == state.side)
                {
                    state.selecting = true;
                    var targetList = PlaceToMove(this.type, CoX, CoY);
                    int CandNum = targetList.Item1;
                    if (CandNum != 0)
                    {
                        Point[] CandPoint = new Point[17];
                        CandPoint = targetList.Item2;
                        for(int i = 0; i < CandNum; i++)
                        {
                            int x = CandPoint[i].X;
                            int y = CandPoint[i].Y;
                            if(true)//!PieceExist(x, y))
                            {
                                this.DrawTarget(x, y);
                            }
                        }
                    }
                }
            }
        }

        // 依棋種不同，找出該棋可走的位置座標
        private Tuple<int, Point[]> PlaceToMove(int type, int x, int y)
        {
            int moveNum = 0;
            Point[] result = new Point[17];
            switch (type)
            {
                case 1: // 馬的走法
                    int[] horsestep = { 2, 1, 1, 2, -1, 2, -2, 1, -2, -1, -1, -2, 1, -2, 2, -1 };
                    int horsestepnum = horsestep.Length;
                    for (int i = 0; i < horsestepnum; i += 2)
                    {
                        if (true)// !PieceExist(x + NODE_DISTANCE * horsestep[i], y + NODE_DISTANCE * horsestep[i + 1]))
                        {
                            if (true)// !PieceExist(x + NODE_DISTANCE * (horsestep[i] - 1), y + NODE_DISTANCE * (horsestep[i + 1] - 1)))
                            {
                                result[i/2].X = x + NODE_DISTANCE * horsestep[i];
                                result[i/2].Y = y + NODE_DISTANCE * horsestep[i + 1];
                                moveNum++;
                            }
                        }
                    }
                    break;
                case 2: // 象的走法
                    int[] elephantstep = { 2, 2, -2, 2, -2, -2, 2, -2 };
                    int elephantstepnum = elephantstep.Length;
                    for (int i = 0; i < elephantstepnum; i += 2)
                    {
                        if (true)//PieceExist(x + NODE_DISTANCE * elephantstep[i], y + NODE_DISTANCE * elephantstep[i + 1]))
                        {
                            if (true)//PieceExist(x + NODE_DISTANCE * (elephantstep[i] - 1), y + NODE_DISTANCE * (elephantstep[i + 1] - 1)))
                            {
                                result[i/2].X = x + NODE_DISTANCE * elephantstep[i];
                                result[i/2].Y = y + NODE_DISTANCE * elephantstep[i + 1];
                                moveNum++;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return new Tuple<int, Point[]>(moveNum, result);
        }

        // 畫出可走的位置
        private void DrawTarget(int x, int y)
        {
            Target tempTarget = new Target(x, y);
            // 有問題，因為是用blackpiece.control去畫，所以座標變成是以blackpiece的最左上角為(0,0)
            // 應該要以整個棋盤的最左上角為(0,0), 但無法呼叫form1.control.add
            this.Controls.Add(tempTarget);
            this.targetSquare[targetNum] = tempTarget;
            this.targetNum++;
        }

        // 看座標上有沒有棋子 未完成
        public bool PieceExist(int x, int y)
        {
            if (x > OFFSET & x < (OFFSET + 8 * NODE_DISTANCE) & y > OFFSET & y < (OFFSET + 9 * NODE_DISTANCE))
            {
                if (x > this.Location.X & x < (this.Location.X + PIECE_SIZE) & y > this.Location.Y & y < (this.Location.Y + PIECE_SIZE))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
