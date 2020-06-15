using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Board
    {
        private readonly static int Boundary = 75;
        private readonly static int NodeRadius = 12;
        private readonly static int NodeDistance = 75;
        private readonly static Point NoMatch = new Point(-1, -1);

        // 檢查位置是否能被落子
        public bool Placed(int x, int y)
        {
            Point nodeLocation = FindNode(x, y);
            if (nodeLocation == NoMatch)
            {
                return false;
            }
            return true;
        }

        // 棋盤是二維的，所以對XY座標各自做判斷
        private Point FindNode(int x, int y)
        {
            int nodeX = FindNode(x);
            int nodeY = FindNode(y);
            if(nodeX == -1 || nodeY ==-1)
            {
                return NoMatch;
            }
            return new Point(nodeX, nodeY);
        }

        // 判斷一維情形下是哪個節點
        private int FindNode(int position)
        {
            if (position < Boundary - NodeRadius)
            {
                return -1;
            }

            position -= Boundary;
            int quotient = position / NodeDistance;
            int remainder = position % NodeDistance;

            if (remainder <= NodeRadius)
            {
                return quotient;
            }
            else if (remainder > NodeDistance - NodeRadius)
            {
                return quotient + 1;
            }
            else
                return -1;
        }
    }
}
