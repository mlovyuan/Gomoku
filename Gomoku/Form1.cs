using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private bool Black;
        private Board Board;
        public Form1()
        {
            InitializeComponent();
            Black = true;
            Board = new Board();
        }

        // 按下滑鼠
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (Black)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                Black = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                Black = true;
            }
        }

        // 滑鼠移動時
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Board.Placed(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
