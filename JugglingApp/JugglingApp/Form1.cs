using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugglingApp
{
    public partial class BaseForm : Form
    {

        public Pen pen;
        public Graphics gfx;
        public SolidBrush brush;
        public Color color;
        public int scrHeight = Screen.PrimaryScreen.Bounds.Height;
        public int scrWidth = Screen.PrimaryScreen.Bounds.Width;

        List<int> currentSeq;
        int n;

        public BaseForm()
        {
            InitializeComponent();
            currentSeq = new List<int>();
            n = 16;
            gfx = CreateGraphics();
            Color color = Color.Black;
            pen = new Pen(color, 3);
            brush = new SolidBrush(color);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentSeq.Clear();
            ClearSequence();
            int tmpSeq = int.Parse(sequenceText.Text);
            while(tmpSeq > 0)
            {
                currentSeq.Add(tmpSeq % 10);
                tmpSeq = tmpSeq / 10;
            }
            currentSeq.Reverse();
            DrawSequence(currentSeq);
        }
        

        void DrawThrow(int beat, int h)
        {
            if(h != 0)
            {
                gfx.DrawArc(pen, 100 * beat + 200 + 12, scrHeight * 8 / 10 - 75 * h + 12, 100 * h, 150 * h, 0, -180);
            }
        }

        List<int> SiteSwap(List<int> sequence, int i, int j)
        {
            List<int> copy = new List<int>();
            for (int k = 0; k < sequence.Count; k++)
            {
                copy.Add(sequence[k]);
            }
            sequence[i] = copy[j] + j - i;
            sequence[j] = copy[i] + i - j;
            return sequence;
        }

        void DrawSequence(List<int> sequence)
        {
            SolidBrush defaultBrush = new SolidBrush(BaseForm.DefaultBackColor);
            int count = -sequence.Max();
            while (count < n)
            {
                for (int i = 0; i < currentSeq.Count; i++)
                {
                    if (count == n) break;
                    DrawThrow(count, currentSeq[i]);
                    count++;
                }
            }
            gfx.FillRectangle(defaultBrush, 0, 0, 150, 1080);
            gfx.FillRectangle(defaultBrush, 1920 - 150, 0, 1920, 1080);
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
            SolidBrush defaultBrush = new SolidBrush(BaseForm.DefaultBackColor);
            gfx.FillRectangle(defaultBrush, 0, 0, 1920, 1080);
            DrawBeats();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            DrawBeats();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SiteSwap ssf = new SiteSwap();
            ssf.Show();

            /*currentSeq = SiteSwap(currentSeq, 0, 1);
            ClearSequence();
            DrawSequence(currentSeq);*/
        }
    }
}
