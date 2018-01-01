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
    public partial class Form2 : Form
    {
        //公用變數
        Socket T;//通訊物件
        Thread Th;//網路監聽執行緒
        string User;//使用者
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Socket t, Thread th, string user){
            InitializeComponent();
            T=t;
            User=user;
            CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒錯誤
            TextBox3.Text=User;
            string IP = TextBox1.Text;//伺服器IP
            int Port = int.Parse(TextBox2.Text);//伺服器Port
            //建立通訊物件，參數代表可以雙向通訊的TCP連線
            try
            {
                Th = new Thread(Listen); //建立監聽執行緒
                Th.IsBackground = true; //設定為背景執行緒
                Th.Start(); //開始監聽
                TextBox4.Text = "再次回到遊戲大廳！" + "\r\n";
                Send("0" + User);  //連線後隨即傳送自己的名稱給伺服器
            }
            catch (Exception)
            {
                TextBox4.Text = "無法連上伺服器！" + "\r\n"; //連線失敗時顯示訊息
                return;
            }
            Button1.Enabled = false; //讓連線按鍵失效，避免重複連線
            Button2.Enabled = true;  //如連線成功可以開始發送訊息
        }   
        //監聽 Server 訊息 (Listening to the Server)
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
                    ListBox1.Items.Clear();//清除線上名單
                    MessageBox.Show("伺服器斷線了！");//顯示斷線
                    Button1.Enabled = true;//連線按鍵恢復可用
                    Th.Abort();//刪除執行緒
                }
                Msg = Encoding.Default.GetString(B, 0, inLen); //解讀完整訊息
                St = Msg.Substring(0, 1); //取出命令碼 (第一個字)
                Str = Msg.Substring(1); //取出命令碼之後的訊息   
                switch (St)//依命令碼執行功能
                {
                    case "L"://接收線上名單
                        ListBox1.Items.Clear(); //清除名單
                        string[] M = Str.Split(','); //拆解名單成陣列
                        for (int i = 0; i < M.Length; i++)
                        {
                            ListBox1.Items.Add(M[i]); //逐一加入名單
                        }
                        break;
                    case "1"://接收廣播訊息
                        TextBox4.Text += "(公開)" + Str + "\r\n";//顯示訊息並換行
                        TextBox1.SelectionStart = TextBox1.Text.Length; //游標移到最後
                        TextBox1.ScrollToCaret(); //捲動到游標位置
                        break;
                    case "2"://接收私密訊息
                        TextBox4.Text += "(私密)" + Str + "\r\n";//顯示訊息並換行
                        TextBox1.SelectionStart = TextBox1.Text.Length;//游標移到最後
                        TextBox1.ScrollToCaret();//捲動到游標位置
                        break;
                    case "3"://收到對戰邀請
                        string[] C = Str.Split('|');
                        DialogResult dr = MessageBox.Show("Accept a challenge from "+C[0]+" ？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            //選擇確認
                            Send("4"+C[1]+"|"+C[0]);
                            string opponentName = C[0];
                            Form1 f = new Form1(User, opponentName, T, Th, 1);
                            f.getForm=this;
                            this.Hide();
                            f.ShowDialog();
                         
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            //選擇拒絕
                            Send("2"+C[1]+" refuse to accept your challenge!"+"|"+C[0]);
                        }
                        break;
                    case "4"://對手同意對戰
                            string OpponentName = Str;                       
                            Form1 f1 = new Form1(User, OpponentName, T, Th, 0);
                            f1.getForm=this;
                            this.Hide();
                            f1.ShowDialog();
                           
                        break;
                    case "M":
                        TextBox4.Text += "Server: " + Str + "\r\n";
                        TextBox1.SelectionStart = TextBox1.Text.Length; //游標移到最後
                        TextBox1.ScrollToCaret(); //捲動到游標位置
                        break;
                }
            }
        }
        //送出訊息
        private void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text == "") return; //未輸入訊息不傳送資料
            if (ListBox1.SelectedIndex < 0)//未選取傳送對象(廣播)，命令碼：1
            {
                Send("1" + User + " said " + TextBox5.Text);
            }
            else//有選取傳送對象(私密訊息)，命令碼：2
            {
                Send("2" + User + " said " + TextBox5.Text + "|" + ListBox1.SelectedItem);
                TextBox4.Text += " Tell " + ListBox1.SelectedItem + "：" + TextBox5.Text + "\r\n";
            }
            TextBox5.Text = ""; //清除發言框
        }
        //邀請對戰
        private void Button4_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)//未選取邀請對象命令碼
            {
                TextBox4.Text += "請選取要邀請對象";
            }
            else//有選取邀請對象
            {
                Send("3" + User +"|" + ListBox1.SelectedItem);
                TextBox4.Text += " Inviting " + ListBox1.SelectedItem +"\r\n";
            }
            TextBox5.Text = ""; //清除發言框
        }


        //傳送訊息給 Server (Send Message to the Server)
        private void Send(string Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str); //翻譯文字為Byte陣列
            T.Send(B, 0, B.Length, SocketFlags.None); //使用連線物件傳送資料
        }
        //登入伺服器
        private void Button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒錯誤
            User = TextBox3.Text;//使用者名稱
            string IP = TextBox1.Text;//伺服器IP
            int Port = int.Parse(TextBox2.Text);//伺服器Port
            //建立通訊物件，參數代表可以雙向通訊的TCP連線
            try
            {
                IPEndPoint EP = new IPEndPoint(IPAddress.Parse(IP), Port);//伺服器的連線端點資訊
                T = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                T.Connect(EP); //連上伺服器的端點EP(類似撥號給電話總機)
                Th = new Thread(Listen); //建立監聽執行緒
                Th.IsBackground = true; //設定為背景執行緒
                Th.Start(); //開始監聽
                TextBox4.Text = "已連線伺服器！" + "\r\n";
                Send("0" + User);  //連線後隨即傳送自己的名稱給伺服器
            }
            catch (Exception)
            {
                TextBox4.Text = "無法連上伺服器！" + "\r\n"; //連線失敗時顯示訊息
                return;
            }
            Button1.Enabled = false; //讓連線按鍵失效，避免重複連線
            Button2.Enabled = true;  //如連線成功可以開始發送訊息
        }
        //準備廣播
        private void Button3_Click(object sender, EventArgs e)
        {
            ListBox1.ClearSelected(); //清除選取
        }
        //視窗關閉，代表離線
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Button1.Enabled == false)
            {
               // Send("8" + User); //傳送自己的離線訊息給伺服器
                T.Close(); //關閉網路通訊器
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
