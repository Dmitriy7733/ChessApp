using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(MainForm_Paint);
            this.MouseClick += new MouseEventHandler(MainForm_MouseClick);
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawChessBoard(e.Graphics);
        }

        private void DrawChessBoard(Graphics g)
        {
            int size = 50;
            Brush brush1 = new SolidBrush(Color.LightGray);
            Brush brush2 = new SolidBrush(Color.White);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        g.FillRectangle(brush1, i * size, j * size, size, size);
                    else
                        g.FillRectangle(brush2, i * size, j * size, size, size);
                }
            }

            // Draw chess pieces
            DrawChessPiece(g, Brushes.Black, 1, 0, "♖"); // Rook
            DrawChessPiece(g, Brushes.Black, 2, 0, "♘"); // Knight
            DrawChessPiece(g, Brushes.Black, 3, 0, "♗"); // Bishop
            DrawChessPiece(g, Brushes.Black, 4, 0, "♕"); // Queen
            DrawChessPiece(g, Brushes.Black, 5, 0, "♔"); // King
            DrawChessPiece(g, Brushes.Black, 6, 0, "♗"); // Bishop
            DrawChessPiece(g, Brushes.Black, 7, 0, "♘"); // Knight
            DrawChessPiece(g, Brushes.Black, 0, 0, "♖"); // Rook

            for (int i = 0; i < 8; i++)
            {
                DrawChessPiece(g, Brushes.Black, i, 1, "♙"); // Pawn
            }

            brush1.Dispose();
            brush2.Dispose();
        }

        private void DrawChessPiece(Graphics g, Brush brush, int x, int y, string symbol)
        {
            int size = 50;
            Font font = new Font("Arial", 30);
            g.DrawString(symbol, font, brush, x * size + 12, y * size + 5);
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Show context menu for chess piece
                ContextMenu contextMenu = new ContextMenu();
                MenuItem deleteMenuItem = new MenuItem("Delete");
                deleteMenuItem.Click += DeleteMenuItem_Click;
                contextMenu.MenuItems.Add(deleteMenuItem);

                // Show context menu at mouse click position
                contextMenu.Show(this, e.Location);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chess Piece Deleted");
        }
    }
}
