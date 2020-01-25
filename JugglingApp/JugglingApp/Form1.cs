using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugglingApp
{
    public partial class Form1 : Form
    {

        public Pen pen;
        public Graphics gfx;
        public SolidBrush brush;
        public Color color;
        public int scrHeight = Screen.PrimaryScreen.Bounds.Height;
        public int scrWidth = Screen.PrimaryScreen.Bounds.Width;

        List<int> currentSeq;
        int n;
        int tmp;

        public Form1()
        {
            InitializeComponent();
            currentSeq = new List<int>();
            n = 15;
            tmp = 0;
            gfx = CreateGraphics();
            Color color = Color.Black;
            pen = new Pen(color, 3);
            brush = new SolidBrush(color);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearSequence();
            currentSeq.Clear();
            int tmpSeq = int.Parse(sequenceText.Text);
            while(tmpSeq > 0)
            {
                currentSeq.Add(tmpSeq % 10);
                tmpSeq = tmpSeq / 10;
            }
            currentSeq.Reverse();
            DrawSequence(currentSeq);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBeats();
        }

        void DrawThrow(int beat, int h)
        {
            gfx.DrawArc(pen, 100 * beat + 200 + 12, scrHeight * 8 / 10 - 75 * h + 12, 100 * h, 150 * h, 0, -180);
        }

        List<int> SiteSwap(List<int> sequence, int i, int j)
        {
            List<int> copy = sequence;
            sequence[i] = copy[j] + j - i;
            sequence[j] = copy[i] + i - j;
            return sequence;
        }

        void DrawSequence(List<int> sequence)
        {
            tmp = 0;
            while (tmp < 15)
            {
                for (int i = 0; i < currentSeq.Count; i++)
                {
                    if (tmp == 15) break;
                    label2.Text += currentSeq[i] + "a";
                    DrawThrow(tmp, currentSeq[i]);
                    tmp++;
                }
            }
        }

        void DrawBeats()
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    gfx.DrawEllipse(pen, 100 * i + 200, scrHeight * 8 / 10, 25, 25);
                }
                else
                {
                    gfx.FillEllipse(brush, 100 * i + 200, scrHeight * 8 / 10, 25, 25);
                }
            }
        }

        void ClearSequence()
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            gfx.FillRectangle(whiteBrush, 0, 0, 1920, 1080);
        }
    }
}
