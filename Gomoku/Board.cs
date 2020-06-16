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
        private Piece[,] pieces = new Piece[9, 9];

        // 檢查該位置是否有重複落子，若無才可放
        public Piece PlacePiece(int x, int y, PieceType type)
        {
            // x, y是實際位置， nodeLocation內的則是棋盤上人為給的位置
            Point nodeLocation = FindNode(x, y);
            if (nodeLocation == NoMatch)
            {
                return null;
            }
            // 看棋子是不是有重複
            if (pieces[nodeLocation.X, nodeLocation.Y] != null)
            {
                return null;
            }

            Point formPosition = ConvertToFormPosition(nodeLocation);
            if (type == PieceType.Black)
            {
                pieces[nodeLocation.X, nodeLocation.Y] = new BlackPiece(formPosition.X, formPosition.Y);
            }
            else if (type == PieceType.White)
            {
                pieces[nodeLocation.X, nodeLocation.Y] = new WhitePiece(formPosition.X, formPosition.Y);
            }
            return pieces[nodeLocation.X, nodeLocation.Y];
        }

        private Point ConvertToFormPosition(Point nodeLocation)
        {
            Point formPosition = new Point();
            formPosition.X = nodeLocation.X * NodeDistance + Boundary;
            formPosition.Y = nodeLocation.Y * NodeDistance + Boundary;
            return formPosition;
        }

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
