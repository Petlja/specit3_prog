using System;
using System.Drawing;
using System.Windows.Forms;

namespace teselacija
{
    public partial class Form1 : Form
    {
        public PointF[] pts = new PointF[4];
        public int DraggingPt = -1;
        public bool DraggingAll = false;
        float PrevMouseX = -1;
        float PrevMouseY = -1;
        public const float r = 10;
        public Form1()
        {
            InitializeComponent();
            pts[0] = new Point(323, 387);
            pts[1] = new Point(500, 350);
            pts[2] = new Point(487, 235);
            pts[3] = new Point(300, 200);
            this.MouseWheel += new MouseEventHandler(Form1_MouseMove);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (IsAtPixel(pts[i], e.X, e.Y)) { DraggingPt = i; }

            if (DraggingPt >= 0)
                pts[DraggingPt] = new Point(e.X, e.Y);
            else
            {
                DraggingAll = true;
                PrevMouseX = e.X;
                PrevMouseY = e.Y;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggingPt >= 0)
            {
                pts[DraggingPt].X = e.X;
                pts[DraggingPt].Y = e.Y;
                Invalidate();
            }
            else if (DraggingAll)
            {
                for (int i = 0; i < 4; i++)
                {
                    pts[i].X += e.X - PrevMouseX;
                    pts[i].Y += e.Y - PrevMouseY;
                }
                PrevMouseX = e.X;
                PrevMouseY = e.Y;
                Invalidate();
            }
            if (e.Delta != 0)
            {
                // mouse wheel moved, zoom in or zoom out
                int WheelDelta = SystemInformation.MouseWheelScrollDelta;
                float f = (float)Math.Pow(1.1, -e.Delta / WheelDelta);
                for (int i = 0; i < 4; i++)
                {
                    pts[i].X = e.X + (pts[i].X - e.X) * f;
                    pts[i].Y = e.Y + (pts[i].Y - e.Y) * f;
                }
                Invalidate();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            DraggingAll = false;
            DraggingPt = -1;
            Invalidate();
        }
        public static bool IsAtPixel(PointF P, float x, float y)
        {
            return (P.X - r < x && x < P.X + r) && (P.Y - r < y && y < P.Y + r);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brushForQuadrangles = new SolidBrush(Color.Green);
            Brush brushForDots = new SolidBrush(Color.Yellow);
            float x1 = pts[2].X - pts[0].X; // vector AC.X
            float y1 = pts[2].Y - pts[0].Y; // vector AC.Y
            float x2 = pts[3].X - pts[1].X; // vector DB.X
            float y2 = pts[3].Y - pts[1].Y; // vector DB.Y
            for (int i = -5; i <=5; i++)
            {
                for (int j = -5; j <= 5; j++)
                {
                    g.FillPolygon(brushForQuadrangles, new PointF[] 
                    {
                        new PointF(pts[0].X + i*x1 + j*x2, pts[0].Y + i*y1 + j*y2), 
                        new PointF(pts[1].X + i*x1 + j*x2, pts[1].Y + i*y1 + j*y2), 
                        new PointF(pts[2].X + i*x1 + j*x2, pts[2].Y + i*y1 + j*y2), 
                        new PointF(pts[3].X + i*x1 + j*x2, pts[3].Y + i*y1 + j*y2) 
                    }); 
                }
            }
            for (int i = 0; i < 4; i++)
                g.FillEllipse(brushForDots, pts[i].X - r, pts[i].Y - r, 2 * r, 2 * r);
        }
    }
}
