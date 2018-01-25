using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Transform
    {
        private static int MARGIN_TOP = 20; //棋盤線的上方空白寬度
        private static int MARGIN_LEFT = 20; //棋盤線的左方空白寬度
        private static int INTERVAL = 25; //任兩條棋盤線的距離
        public static Point getCoordinate(int x, int y, int offset)
        {
            Point p = new Point(MARGIN_LEFT + (x-1) * INTERVAL - offset / 2, MARGIN_TOP + (y-1) * INTERVAL - offset / 2);
            return p;
        }

        public static string getType(int type)
        {
            string typeName = "";
            switch (type)
            {
                case 0:
                case 8:
                    typeName = "car";
                    break;
                case 1:
                case 7:
                    typeName = "horse";
                    break;
                case 2:
                case 6:
                    typeName = "elephant";
                    break;
                case 3:
                case 5:
                    typeName = "guard";
                    break;
                case 4:
                    typeName = "general";
                    break;
                case 9:
                case 10:
                    typeName = "bang";
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    typeName = "soldier";
                    break;
                default:
                    break;
            }
            return typeName;
        }
    }
}
