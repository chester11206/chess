using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;//匯入網路通訊協定相關函數
using System.Net.Sockets;//匯入網路插座功能函數
using System.Threading;//匯入多執行緒功能函數

namespace Chess
{

    public partial class Form1 : Form
    {
        // 初始化狀態
        private Board board = new Board();
        private Piece[,] piece = new Piece[SIDE_NUM,PIECE_NUM];
        private static readonly int PIECE_NUM = 16;
        private static readonly int SIDE_NUM = 2;
        private static readonly int COL_NUM = 9;
        private static readonly int ROW_NUM = 10;
        private static readonly int PIECE_WIDTH = 25;
        public static readonly int TARGET_SIZE = 15;
        public static readonly int CORNER_SIZE = 5;
        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度
        private static int INTERVAL = 25; //任兩條棋盤線的距離
        private static int mySide; //1 or 0
        private static bool canMove=false;


        // 線上版象棋
        Socket T;//通訊物件
        Thread Th_chess;//網路監聽執行緒
        Thread Th_main;
        private static string MyName;
        private static string OpponentName;
        private Form mainForm = new Form();

        public Form1(string myName, string opponentName, Socket t, Thread th, int side)
        {

            CheckForIllegalCrossThreadCalls = false;
            MyName = myName;
            OpponentName = opponentName;
            mySide= side; 
            Th_main=th;
            Situation.side=mySide;
            if(mySide == 1) canMove=true;
            T = t;
            Th_chess = new Thread(Listen); //建立監聽執行緒
            Th_chess.IsBackground = true; //設定為背景執行緒
            Th_chess.Start(); //開始監聽

            InitializeComponent();
            board.SetBoard(board);
            piece = board.GetPiece();
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < PIECE_NUM; j++)
                {
                    piece[i, j].MouseClick += new MouseEventHandler(pc_MouseClick);
                    this.Controls.Add(piece[i, j]);
                    this.BringToFront();
                }
            }

        }
        private void Listen()
        {
            EndPoint ServerEP = (EndPoint)T.RemoteEndPoint; //Server 的 EndPoint
            byte[] B = new byte[1023]; //接收用的 Byte 陣列
            int inLen = 0; //接收的位元組數目
            string Msg; //接收到的完整訊息
            string St; //命令碼
            string Str; //訊息內容(不含命令碼)
            while (true)//無限次監聽迴圈
            {
                try
                {
                    inLen = T.ReceiveFrom(B, ref ServerEP);//收聽資訊並取得位元組數
                }
                catch (Exception)//產生錯誤時
                {
                    T.Close();//關閉通訊器
                    MessageBox.Show("伺服器斷線了！!!");//顯示斷線
                    Th_chess.Abort();//刪除執行緒
                }
                Msg = Encoding.Default.GetString(B, 0, inLen); //解讀完整訊息
                St = Msg.Substring(0, 1); //取出命令碼 (第一個字)
                Str = Msg.Substring(1); //取出命令碼之後的訊息   
                switch (St)//依命令碼執行功能
                {
                    case "5":
                        canMove = true;
                        bool flag = false;
                        string[] C = Str.Split('|');
                        if(PieceExist(int.Parse(C[3]),int.Parse(C[4]))!=null){

                            if (PieceExist(int.Parse(C[3]),int.Parse(C[4])).type.Equals("general")){
                                flag=true;
                            }
                            Piece tem = PieceExist(int.Parse(C[3]), int.Parse(C[4]));
                            this.Controls.Remove(tem);
                            tem.changeLocation(-1, -1);
                        }
                        
                        piece[int.Parse(C[1]), int.Parse(C[2])].changeLocation(int.Parse(C[3]), int.Parse(C[4]));
                        if(flag)
                        {
                            MessageBox.Show("You Lose");
                            //todo: 切換至主畫面
                            //mainForm.Visible=  true;
                            Form2 f = new Form2(T, Th_main, MyName);
                            f.ShowDialog();
                            this.Close();
                        }
                        break;
                    case "6":
                        MessageBox.Show("You Win");
                        //todo: 切換至主畫面
                        //mainForm.Visible=  true;
                        Form2 f1 = new Form2(T, Th_main, MyName);
                        f1.ShowDialog();
                        this.Close();
                        break;
                }      
            }
        }

        //傳送訊息給 Server (Send Message to the Server)
        private void Send(string Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str); //翻譯文字為Byte陣列
            T.Send(B, 0, B.Length, SocketFlags.None); //使用連線物件傳送資料
        }

        public Form getForm {
		    get { return mainForm; }

		    set { mainForm = value; }
	    }

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

        // 點擊棋子的事件
        public void pc_MouseClick(object sender, EventArgs e)
        {
            if(canMove){
                Piece pc = (Piece)sender;
                if (pc.side == Convert.ToBoolean(Situation.side))  // 棋子是進攻方
                {
                    var targetList1 = PlaceToMove(pc.type, pc.side, pc.CoX, pc.CoY);
                    int CandNum = targetList1.Item1;
                    if (CandNum != 0)   // 棋子可以移動
                    {
                        if (!Situation.selecting)   // 非選擇中
                        {
                            Situation.selecting = true;
                            Situation.index = pc.id;
                        }
                        else if (pc.id != Situation.index)
                        {
                            Situation.index = pc.id;
                            // 刪除之前的target
                            deleteTargert1:
                            foreach (Control c in this.Controls)
                            {
                                if (c is Target)
                                {
                                    c.Dispose();
                                    this.Controls.Remove(c);
                                }
                            }

                            foreach (Control c in this.Controls)
                            {
                                if (c is Target)
                                {
                                    goto deleteTargert1;
                                }
                            }
                        }
                        else
                            goto cantMove;
                        boolPoint[] CandPoint = new boolPoint[17];
                        CandPoint = targetList1.Item2;
                        for (int i = 0; i < CandNum; i++)
                        {
                            Piece canEat = CandPoint[i].canEat;
                            int CoX = CandPoint[i].Location.X;
                            int CoY = CandPoint[i].Location.Y;
                            DrawTarget(CoX, CoY, pc.side, pc.id, canEat);
                        }
                        cantMove:;
                    }
                }
            }
        }

        // 依棋種不同，找出該棋可走的位置座標
        public Tuple<int, boolPoint[]> PlaceToMove(string type, bool side, int CoX, int CoY)
        {
            int moveNum = 0;
            boolPoint[] result = new boolPoint[17];
            switch (type)
            {
                case "car":
                    int[] carstep = { 1, 0, -1, 0, 0, 1, 0, -1 };
                    int carstepnum = carstep.Length;
                    for (int i = 0; i < carstepnum; i+=2)
                    {
                        for (int j = 1; j < Math.Abs(carstep[i]) * COL_NUM + Math.Abs(carstep[i+1]) * ROW_NUM; j++)
                        {
                            if (OnBoard(CoX + carstep[i]*j, CoY + carstep[i+1]*j))
                            {
                                if (PieceExist(CoX + carstep[i] * j, CoY + carstep[i + 1] * j) == null)
                                {
                                    result[moveNum] = new boolPoint(null, new Point(CoX + carstep[i] * j, CoY + carstep[i + 1] * j));
                                    moveNum++;
                                }
                                else
                                {
                                    if (PieceExist(CoX + carstep[i] * j, CoY + carstep[i + 1] * j).side == !side)
                                    {
                                        result[moveNum] = new boolPoint(PieceExist(CoX + carstep[i] * j, CoY + carstep[i + 1] * j), new Point(CoX + carstep[i] * j, CoY + carstep[i + 1] * j));
                                        moveNum++;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    
                    break;
                case "horse": // 馬的走法
                    int[] horsestep = { 2, 1, 1, 2, -1, 2, -2, 1, -2, -1, -1, -2, 1, -2, 2, -1 };
                    int horsestepnum = horsestep.Length;
                    for (int i = 0; i < horsestepnum; i += 2)
                    {
                        if (OnBoard(CoX + horsestep[i], CoY + horsestep[i + 1]))
                        {
                            if (PieceExist(CoX + (horsestep[i] - Math.Sign(horsestep[i])*1), CoY + (horsestep[i + 1] - Math.Sign(horsestep[i+1]) * 1)) == null)    //判斷是否拐馬腳
                            {
                                if (PieceExist(CoX + horsestep[i], CoY + horsestep[i + 1]) == null)    //判斷是否有棋子
                                {
                                    result[moveNum] = new boolPoint(null, new Point(CoX + horsestep[i], CoY + horsestep[i + 1]));
                                    //result[moveNum].Location = new Point(CoX + horsestep[i], CoY + horsestep[i + 1]);
                                    moveNum++;
                                }
                                else if (PieceExist(CoX + horsestep[i], CoY + horsestep[i + 1]).side == !side)  //有棋子但是為對方棋子
                                {
                                    result[moveNum] = new boolPoint(PieceExist(CoX + horsestep[i], CoY + horsestep[i + 1]), new Point(CoX + horsestep[i], CoY + horsestep[i + 1]));
                                    moveNum++;
                                }
                            }
                        }
                    }
                    break;
                case "elephant": // 象的走法
                    int[] elephantstep = { 2, 2, -2, 2, -2, -2, 2, -2 };
                    int elephantstepnum = elephantstep.Length;
                    for (int i = 0; i < elephantstepnum; i += 2)
                    {
                        if(OnBoard(CoX + elephantstep[i], CoY + elephantstep[i + 1]))
                        {
                            if (PieceExist(CoX + (elephantstep[i] - Math.Sign(elephantstep[i]) * 1), CoY + (elephantstep[i + 1] - Math.Sign(elephantstep[i + 1]) * 1)) == null)    //判斷是否拐馬腳
                            {
                                if (PieceExist(CoX + elephantstep[i], CoY + elephantstep[i + 1]) == null)    //判斷是否有棋子
                                {
                                    result[moveNum] = new boolPoint(null, new Point(CoX + elephantstep[i], CoY + elephantstep[i + 1]));
                                    moveNum++;
                                }
                                else if (PieceExist(CoX + elephantstep[i], CoY + elephantstep[i + 1]).side == !side)    //有棋子但是為對方棋子
                                {
                                    result[moveNum] = new boolPoint(PieceExist(CoX + elephantstep[i], CoY + elephantstep[i + 1]), new Point(CoX + elephantstep[i], CoY + elephantstep[i + 1]));
                                    moveNum++;
                                }
                            }
                        }
                        
                    }
                    break;
                case "guard":
                    int[] guardstep = { 1, 1, -1, 1, -1, -1, 1, -1 };
                    int guardstepnum = guardstep.Length;
                    for (int i = 0; i < guardstepnum; i += 2)
                    {
                        bool canMove = false;
                        if (OnBoard(CoX + guardstep[i], CoY + guardstep[i + 1]))
                        {
                            if (side && CoX + guardstep[i] <= 6 && CoX + guardstep[i] >= 4 && CoY + guardstep[i + 1] <= 3 && CoY + guardstep[i+1] >= 1)
                            {
                                canMove = true;
                            }
                            else if (!side && CoX + guardstep[i] <= 6 && CoX + guardstep[i] >= 4 && CoY + guardstep[i + 1] <= 10 && CoY + guardstep[i+1] >= 8)    //判斷是否拐馬腳
                            {
                                canMove = true;
                            }
                        }
                        if (canMove)
                        {
                            if (PieceExist(CoX + guardstep[i], CoY + guardstep[i + 1]) == null)    //判斷是否有棋子
                            {
                                result[moveNum] = new boolPoint(null, new Point(CoX + guardstep[i], CoY + guardstep[i + 1]));
                                moveNum++;
                            }
                            else if (PieceExist(CoX + guardstep[i], CoY + guardstep[i + 1]).side == !side)    //有棋子但是為對方棋子
                            {
                                result[moveNum] = new boolPoint(PieceExist(CoX + guardstep[i], CoY + guardstep[i + 1]), new Point(CoX + guardstep[i], CoY + guardstep[i + 1]));
                                moveNum++;
                            }
                        }
                    }
                    break;
                case "general":
                    int[] generalstep = { 1, 0, -1, 0, 0, 1, 0, -1 };
                    int generalstepnum = generalstep.Length;
                    for (int i = 0; i < generalstepnum; i += 2)
                    {
                        bool canMove = false;
                        if (OnBoard(CoX + generalstep[i], CoY + generalstep[i + 1]))
                        {
                            if (side && CoX + generalstep[i] <= 6 && CoX + generalstep[i] >= 4 && CoY + generalstep[i + 1] <= 3 && CoY + generalstep[i + 1] >= 1)
                            {
                                canMove = true;
                            }
                            else if (!side && CoX + generalstep[i] <= 6 && CoX + generalstep[i] >= 4 && CoY + generalstep[i + 1] <= 10 && CoY + generalstep[i + 1] >= 8)    //判斷是否拐馬腳
                            {
                                canMove = true;
                            }
                        }
                        if (canMove)
                        {
                            if (PieceExist(CoX + generalstep[i], CoY + generalstep[i + 1]) == null)    //判斷是否有棋子
                            {
                                result[moveNum] = new boolPoint(null, new Point(CoX + generalstep[i], CoY + generalstep[i + 1]));
                                moveNum++;
                            }
                            else if (PieceExist(CoX + generalstep[i], CoY + generalstep[i + 1]).side == !side)    //有棋子但是為對方棋子
                            {
                                result[moveNum] = new boolPoint(PieceExist(CoX + generalstep[i], CoY + generalstep[i + 1]), new Point(CoX + generalstep[i], CoY + generalstep[i + 1]));
                                moveNum++;
                            }
                        }
                    }
                    bool facetoface = true;
                    int king = -1;
                    for(int i = 0; i < ROW_NUM; i++)
                    {
                        if (PieceExist(CoX, CoY + i + 1) != null)
                        {
                            if(PieceExist(CoX, CoY + i + 1).type == "general")
                            {
                                facetoface = true;
                                king = i;
                                break;
                            }
                            else
                            {
                                facetoface = false;
                                break;
                            }
                        }
                    }
                    if (facetoface && king != -1)
                    {
                        result[moveNum] = new boolPoint(PieceExist(CoX, CoY + king + 1), new Point(CoX, CoY + king + 1));
                        moveNum++;
                    }
                    break;
                case "bang":
                    int[] bangstep = { 1, 0, -1, 0, 0, 1, 0, -1 };
                    int bangstepnum = bangstep.Length;
                    for (int i = 0; i < bangstepnum; i += 2)
                    {
                        for (int j = 1; j < Math.Abs(bangstep[i]) * COL_NUM + Math.Abs(bangstep[i + 1]) * ROW_NUM; j++)
                        {
                            if (OnBoard(CoX + bangstep[i] * j, CoY + bangstep[i + 1] * j))
                            {
                                if (PieceExist(CoX + bangstep[i] * j, CoY + bangstep[i + 1] * j) == null)
                                {
                                    result[moveNum] = new boolPoint(null, new Point(CoX + bangstep[i] * j, CoY + bangstep[i + 1] * j));
                                    moveNum++;
                                }
                                else
                                {
                                    for (int k = 1; k < Math.Abs(bangstep[i]) * COL_NUM + Math.Abs(bangstep[i + 1]) * ROW_NUM - j; k++)
                                    {
                                        if (OnBoard(CoX + bangstep[i] * (j + k), CoY + bangstep[i + 1] * (j + k)))
                                        {
                                            if (PieceExist(CoX + bangstep[i] * (j + k), CoY + bangstep[i + 1] * (j + k)) != null)
                                            {
                                                if (PieceExist(CoX + bangstep[i] * (j + k), CoY + bangstep[i + 1] * (j + k)).side == !side)
                                                {
                                                    result[moveNum] = new boolPoint(PieceExist(CoX + bangstep[i] * (j + k), CoY + bangstep[i + 1] * (j + k)), new Point(CoX + bangstep[i] * (j + k), CoY + bangstep[i + 1] * (j + k)));
                                                    moveNum++;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case "soldier":
                    int[] soldierstep = { 1, 0, -1, 0, 0, 1, 0, -1 };
                    int soldierstepnum = soldierstep.Length;
                    for (int i = 0; i < soldierstepnum; i += 2)
                    {
                        if (side)
                        {
                            if ((CoY >= 6 && i == 6) || (CoY < 6 && i != 4))
                                goto cantMove;
                        }
                        else
                        {
                            if ((CoY <= 5 && i == 4) || (CoY > 5 && i != 6))
                                goto cantMove;
                        }
                        if (OnBoard(CoX + soldierstep[i], CoY + soldierstep[i + 1]))
                        {
                            if (PieceExist(CoX + soldierstep[i], CoY + soldierstep[i + 1]) == null)    //判斷是否有棋子
                            {
                                result[moveNum] = new boolPoint(null, new Point(CoX + soldierstep[i], CoY + soldierstep[i + 1]));
                                moveNum++;
                            }
                            else if (PieceExist(CoX + soldierstep[i], CoY + soldierstep[i + 1]).side == !side)    //有棋子但是為對方棋子
                            {
                                result[moveNum] = new boolPoint(PieceExist(CoX + soldierstep[i], CoY + soldierstep[i + 1]), new Point(CoX + soldierstep[i], CoY + soldierstep[i + 1]));
                                moveNum++;
                            }
                        }

                        cantMove:;
                    }
                    break;
                default:
                    break;
            }
            return new Tuple<int, boolPoint[]>(moveNum, result);
        }

        public bool OnBoard(int CoX, int CoY)
        {
            if (CoX < 1 || CoX > 9 || CoY < 1 || CoY > 10)
                return false;
            else
                return true;
        }

        public Piece PieceExist(int CoX, int CoY)
        {
            for (int i = 0; i < SIDE_NUM; i++)
            {
                for (int j = 0; j < PIECE_NUM; j++)
                {
                    if (piece[i, j].CoX == CoX && piece[i, j].CoY == CoY)
                    {
                        return piece[i, j];
                        break;
                    }
                }
            }
            return null;
        }

        private void DrawTarget(int CoX, int CoY, bool side, int id, Piece canEat)
        {
            Target tempTarget = new Target(CoX, CoY, side, id, canEat);
            tempTarget.MouseClick += new MouseEventHandler(tg_MouseClick);
            // 有問題，因為是用blackpiece.control去畫，所以座標變成是以blackpiece的最左上角為(0,0)
            // 應該要以整個棋盤的最左上角為(0,0), 但無法呼叫form1.control.add
            //this.board.placeTarget(bp);
            this.Controls.Add(tempTarget);
            tempTarget.BringToFront();
            
            //bp.BringToFront();
            //bp.targetSquare[bp.targetNum] = tempTarget;
            //bp.targetNum++;
        }

        private void tg_MouseClick(object sender, EventArgs e)
        {
            Target tg = (Target)sender;
            deleteTargert2:
            foreach (Control c in this.Controls)
            {
                if (c is Target)
                {
                    c.Dispose();
                    this.Controls.Remove(c);
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c is Target)
                {
                    goto deleteTargert2;
                }
            }
            int id = tg.fromId;
            if (tg.canEat != null)
            {
                tg.canEat.Dispose();
                this.Controls.Remove(tg.canEat);
                piece[Convert.ToInt32(!tg.canEat.side), tg.canEat.id].changeLocation(-1,-1);
            }
            if(tg.fromSide)
            {
                piece[0, id].changeLocation(tg.CoX, tg.CoY);
                string msg = OpponentName+"|"+"0"+"|"+id+"|"+tg.CoX+"|"+tg.CoY;
                canMove=false;
                if(tg.canEat != null && tg.canEat.type == "general")
                {
                    Send("6"+msg);
                }
                else
                {
                    Send("5" + msg);
                }
            }
            else
            {
                piece[1, id].changeLocation(tg.CoX, tg.CoY);
                string msg = OpponentName+"|"+"1"+"|"+id+"|"+tg.CoX+"|"+tg.CoY;
                canMove=false;
                if(tg.canEat != null && tg.canEat.type == "general")
                {
                    Send("6"+msg);
                }
                else
                {
                    Send("5" + msg);
                }
            }         
            Situation.selecting = !Situation.selecting;
            Situation.index = -1;
        }

        // 當游標移到棋子上時改變游標樣式，失敗
        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        //    if(black1.PieceExist(e.X, e.Y))
        //    {
        //        this.Cursor = Cursors.Hand;
        //    }
        //    else
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
