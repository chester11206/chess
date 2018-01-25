using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    public class Piece:PictureBox
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly int NODE_RADIUS = 10;
        public static readonly int NODE_DISTANCE = 25;
        public static readonly int OFFSET = 20;
        private static readonly int PIECE_WIDTH = 25;
        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度 => Y = 0
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度 => X = 0 
        private static int INTERVAL = 25; //任兩條棋盤線的距離

        protected string _type;     // 棋種
        protected bool _side;    // 黑1，紅0
        protected int _id;
        protected int _CoX;
        protected int _CoY;
        protected Target[] _targetSquare = new Target[17];   // 可以移動到的位置，用target(一種按鈕)標示
        protected int _targetNum = 0;

        // get set
        public bool side
        {
            get
            { return _side; }
            set
            { _side = value; }
        }

        public string type
        {
            get
            { return _type; }
            set
            { _type = value; }

        }

        public int id
        {
            get
            { return _id; }
            set
            { _id = value; }

        }

        public int CoX
        {
            get
            { return _CoX; }
            set
            { _CoX = value; }
        }

        public int CoY
        {
            get
            { return _CoY; }
            set
            { _CoY = value; }

        }

        public Target[] targetSquare
        {
            get
            { return _targetSquare; }
            set
            { _targetSquare = value; }
        }

        public int targetNum
        {
            get
            { return _targetNum; }
            set
            { _targetNum = value; }
        }

        // 初始化 賦圖
        public Piece(int CoX, int CoY, string type, bool side, int id)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            this.BackColor = Color.SandyBrown;
            this.Location = Transform.getCoordinate(CoX, CoY, PIECE_WIDTH);
            this.Size = new Size(PIECE_WIDTH, PIECE_WIDTH);
            this._type = type;
            this._side = side;
            this._id = id;
            this._CoX = CoX;
            this._CoY = CoY;

            switch (type)
            {
                //車 俥
                case "car":
                    if (_side)
                        this.Image = Properties.Resources.car_black;
                    else
                        this.Image = Properties.Resources.car_red;
                    break;
                //馬
                case "horse":
                    if (_side)
                        this.Image = Properties.Resources.horse_black;
                    else
                        this.Image = Properties.Resources.horse_red;
                    break;
                //象 相
                case "elephant":
                    if (_side)
                        this.Image = Properties.Resources.elephant_black;
                    else
                        this.Image = Properties.Resources.elephant_red;
                    break;
                //士 仕
                case "guard":
                    if (_side)
                        this.Image = Properties.Resources.guard_black;
                    else
                        this.Image = Properties.Resources.guard_red;
                    break;
                //將 帥
                case "general":
                    if (_side)
                        this.Image = Properties.Resources.general_black;
                    else
                        this.Image = Properties.Resources.general_red;
                    break;
                //包 炮
                case "bang":
                    if (_side)
                        this.Image = Properties.Resources.bang_black;
                    else
                        this.Image = Properties.Resources.bang_red;
                    break;
                //卒 兵
                case "soldier":
                    if (_side)
                        this.Image = Properties.Resources.soldier_black;
                    else
                        this.Image = Properties.Resources.soldier_red;
                    break;
                default:
                    break;
            }
        }

        public void changeLocation(int CoX, int CoY)
        {
            this._CoX = CoX;
            this._CoY = CoY;
            if (CoX == -1 || CoY == -1)
            {
                this.Location = new Point();
            }
            else
            {
                this.Location = Transform.getCoordinate(CoX, CoY, PIECE_WIDTH);
            }
        }
    }
}
