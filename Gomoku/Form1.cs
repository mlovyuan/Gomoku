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
        private bool black;
        private Board board;
        private PieceType nextType;
        public Form1()
        {
            InitializeComponent();
            black = true;
            board = new Board();
            nextType = PieceType.Black;
        }

        // 按下滑鼠
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = board.PlacePiece(e.X, e.Y, nextType);
            if (piece != null)
            {
                this.Controls.Add(piece);
                if (nextType == PieceType.Black)
                {
                    nextType = PieceType.White;
                }
                else if (nextType == PieceType.White)
                {
                    nextType = PieceType.Black;
                }
            }
        }

        // 滑鼠移動時
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.Placed(e.X, e.Y))
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
