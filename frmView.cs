using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw3D
{
    public partial class frmView : Form
    {
        int curX;
        int curY;
        int curLnCol;
        int curLnStyl;
        int curTxtCol;
        Pen myPen = new Pen(Color.Gray, 1);
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Color[] myCol = new Color[] { Color.Black, Color.Red, Color.Blue, Color.Green, 
                                      Color.Yellow, Color.Violet, Color.SkyBlue, Color.Gray };

        public frmView()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictGraph.Size.Width, pictGraph.Size.Height);
            pictGraph.Image = bmp;
            _clearscreen();
        }

        public void _clearscreen()
        {
            Graphics g = Graphics.FromImage(pictGraph.Image);
            g.Clear(myCol[curLnCol]);
            g.Dispose();
        }

        public void _setcolor(int col)
        {
            curLnCol  = col;
        }

        public void _setlinestyle(int style)
        {
            curLnStyl = style;
        }

        public void _settextcolor(int col)
        {
            curTxtCol = col;
        }

        public void _setviewport(int sx, int sy, int ex, int ey)
        {
            this.Width          = ex - sx + 100;
            this.Height         = ey - sy + 150;
            pictGraph.Width     = ex - sx;
            pictGraph.Height    = ey - sy;
            pictGraph.Top       = 50;
            pictGraph.Left      = 50;
            Bitmap bmp = new Bitmap(pictGraph.Size.Width, pictGraph.Size.Height);
            pictGraph.Image = bmp;
            btnEnd.Left         = ex - 25;
            btnEnd.Top          = ey + 75;
        }

        public void _rectangle(int sx, int sy, int ex, int ey)
        {
            Graphics g = Graphics.FromImage(pictGraph.Image);
            myBrush.Color = myCol[curLnCol];
            g.FillRectangle(myBrush, sx, sy, clsCom.zsub(sx,ex), clsCom.zsub(sy,ey));
            g.Dispose();
        }

        public void _moveto(int x, int y)
        {
            curX    = x;
            curY    = y;
        }

        public void _lineto(int x, int y)
        {
            Graphics g = Graphics.FromImage(pictGraph.Image);
            myPen.Color = myCol[curLnCol];
            if( curLnStyl == 0xffff ) {
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            }
            else {
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            }
            myPen.Width = (float)2.0;
            g.DrawLine(myPen, curX, curY, x, y);
            g.Dispose();
        }

        public void _gputchar(int px, int py, char str)
        {
            Graphics g = Graphics.FromImage(pictGraph.Image);
            myBrush.Color = myCol[curTxtCol];
            g.DrawString(str.ToString(), this.Font, myBrush, (float)px, (float)py);
            g.Dispose();
        }

        public void _refresh()
        {
            pictGraph.Refresh();
        }

        private void pictGraphPaint(object sender, PaintEventArgs e)
        {
            pictGraph.Refresh();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 2; i++)
            {
            }
            this.Close();
        }

        private void pictMouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictGraph.CreateGraphics();
            _rectangle(100, 100, 200, 200);
         }

        private void pictMouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}