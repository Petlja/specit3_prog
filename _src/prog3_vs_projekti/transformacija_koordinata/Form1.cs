using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace transformacija_koordinata
{
    public partial class Form1 : Form
    {
        float FontSize = 16;

        float ScalingX = 50.0f;
        float ScalingY = 50.0f;
        float TranslationX = 0.0f;
        float TranslationY = 0.0f;

        float LastDraggingPosX = -1;
        float LastDraggingPosY = -1;
        bool IsDragging = false;

        string CurrentMousePos = "";
        float CurrentMousePosX = -1;
        float CurrentMousePosY = -1;

        // Lista temena mnogougla u koordinatama sveta
        List<PointF> PtsW = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseWheel += new MouseEventHandler(Form1_MouseMove);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
            this.ClientSize = new System.Drawing.Size(800, 600);

            // Biramo pocetni polozaj sistema sveta tako da je 
            // tacka (-1, -1) u donjem levom uglu prozora
            TranslationX = ScalingX;
            TranslationY = ClientSize.Height - ScalingY;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // zapocni vucenje
                IsDragging = true;
                LastDraggingPosX = e.X;
                LastDraggingPosY = e.Y;
            }
            else if (e.Button == MouseButtons.Left)
            {
                // Dodaj novo teme, preracunato u koordinate sveta
                float x, y;
                ScreenToWorld(e.X, e.Y, out x, out y);
                PtsW.Add(new PointF(x, y));
                ComputeAreaAndPerimeter();
                Invalidate();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                TranslationX += e.X - LastDraggingPosX;
                TranslationY += e.Y - LastDraggingPosY;
                LastDraggingPosX = e.X;
                LastDraggingPosY = e.Y;
                Invalidate();
            }
            if (e.Delta != 0)
            {
                // tocak misa je okrenut, zumiraj (ka ili od)
                int WheelDelta = SystemInformation.MouseWheelScrollDelta;
                float f = (float)Math.Pow(1.1, -e.Delta / WheelDelta);
                ScalingX *= f;
                ScalingY *= f;
                FontSize *= f;
                Invalidate();
            }
            // azuriraj koordinate misa za prikaz na ekranu
            CurrentMousePosX = e.X;
            CurrentMousePosY = e.Y;
            float x, y;
            ScreenToWorld(e.X, e.Y, out x, out y);
            CurrentMousePos = string.Format("({0:0.00}, {1:0.00})", x, y);
            Invalidate();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                IsDragging = false;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fnt = new Font("Arial", FontSize);

            float xs0 = 0, xs1 = ClientSize.Width;
            float ys0 = 0, ys1 = ClientSize.Height;
            float xw0, yw0, xw1, yw1;
            ScreenToWorld(xs0, ys0, out xw0, out yw0);
            ScreenToWorld(xs1, ys1, out xw1, out yw1);

            float gxw0 = (float)Math.Ceiling(xw0);
            float gxw1 = (float)Math.Floor(xw1);
            float gyw0 = (float)Math.Floor(yw0);
            float gyw1 = (float)Math.Ceiling(yw1);
            float gxs0, gys0, gxs1, gys1, xsYAxis, ysXAxis;
            WorldToScreen(gxw0, gyw0, out gxs0, out gys0);
            WorldToScreen(gxw1, gyw1, out gxs1, out gys1);
            WorldToScreen(0, 0, out xsYAxis, out ysXAxis);

            Pen p1 = new Pen(Color.Black, 1);
            Brush b = new SolidBrush(Color.Black);
            float xw = gxw0;
            for (float xs = gxs0; xs <= gxs1; xs += ScalingX)
            {
                g.DrawLine(p1, xs, ys0, xs, ys1);
                string txt = xw.ToString();
                SizeF txtSize = g.MeasureString(txt, fnt);
                g.DrawString(txt, fnt, b, xs, ys1 - txtSize.Height);
                xw += 1;
            }
            float yw = gyw0;
            for (float ys = gys0; ys <= gys1; ys += ScalingY)
            {
                g.DrawLine(p1, xs0, ys, xs1, ys);
                g.DrawString(yw.ToString(), fnt, b, xs0, ys);
                yw -= 1;
            }

            Pen p3 = new Pen(Color.Black, 3);
            g.DrawLine(p3, xs0, ysXAxis, xs1, ysXAxis); // x-osa
            g.DrawLine(p3, xsYAxis, ys0, xsYAxis, ys1); // y-osa

            if (CurrentMousePos != "")
            {
                g.DrawString(CurrentMousePos, new Font("Arial", 16), b, 
                    CurrentMousePosX, CurrentMousePosY);
            }

            Pen p = new Pen(Color.Blue, 3);
            int n = PtsW.Count;

            // Izracunaj temena u koordinatama ekrana
            List<PointF> ptsS = new List<PointF>();
            float x, y;
            for (int i = 0; i < n; i++)
            {
                WorldToScreen(PtsW[i].X, PtsW[i].Y, out x, out y);
                ptsS.Add(new PointF(x, y));
            }

            // Nacrtaj mnogougao, koristeci koordinate ekrana
            if (n > 0)
            {
                g.DrawLine(p, ptsS[n - 1].X, ptsS[n - 1].Y, ptsS[0].X, ptsS[0].Y);
                for (int i = 1; i < n; i++)
                    g.DrawLine(p, ptsS[i - 1].X, ptsS[i - 1].Y, ptsS[i].X, ptsS[i].Y);
            }
        }
        private void WorldToScreen(float xw, float yw, out float xs, out float ys)
        {
            xs = xw * ScalingX + TranslationX;
            ys = -yw * ScalingY + TranslationY;
        }
        private void ScreenToWorld(float xs, float ys, out float xw, out float yw)
        {
            xw = (xs - TranslationX) / ScalingX;
            yw = (ys - TranslationY) / -ScalingY;
        }
        private float Distance(PointF A, PointF B)
        {
            float dx = B.X - A.X;
            float dy = B.Y - A.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        private void ComputeAreaAndPerimeter()
        {
            int n = PtsW.Count;
            if (n < 3)
                return;

            float perimeter = Distance(PtsW[n - 1], PtsW[0]);
            for (int i = 1; i < n; i++)
                perimeter += Distance(PtsW[i - 1], PtsW[i]);

            float area = PtsW[0].X * (PtsW[n - 1].Y - PtsW[1].Y);
            area += PtsW[n - 1].X * (PtsW[n - 2].Y - PtsW[0].Y);
            for (int i = 1; i < n - 1; i++)
                area += PtsW[i].X * (PtsW[i - 1].Y - PtsW[i + 1].Y);

            area = 0.5f * Math.Abs(area);

            Text = string.Format("Обим={0:0.00}, Површина={1:0.00}", perimeter, area);
        }

    }
}
