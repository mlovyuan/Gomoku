using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    // 棋子圖片來自PictureBox
    abstract class Piece : PictureBox
    {
        private readonly static int ImageWidth = 50;
        // 棋子放置的位置
        public Piece(int x, int y)  
        {
            // 有this.BackColor欄位是因為繼承自PictureBox的關係
            this.BackColor = Color.Transparent;
            // 棋子放置的座標
            this.Location = new Point(x - ImageWidth/2, y - ImageWidth / 2);
            // 棋子的大小
            this.Size = new Size(ImageWidth, ImageWidth);

        }
    }
}
