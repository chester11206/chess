using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Situation
    {
        // 狀態，包含換誰進攻(side)、是否在選擇中(selecting)、準備移動的棋子編號(index)
        public static int side = 1;         // 黑1，紅0
        public static bool selecting = false;    // 1為選擇中，0為沒有在選擇
        public static int index = -1;         // 準備移動的棋子編號  
    }
}
