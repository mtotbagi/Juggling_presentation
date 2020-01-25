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
        public Graphics formGraphics;
        public SolidBrush brush;
        public Color color;
        public int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        public int screenWidth = Screen.PrimaryScreen.Bounds.Width;

        List<int> sequence;
        int n;

        public Form1()
        {
            InitializeComponent();
            sequence = new List<int>();
            n = 15;
            formGraphics = CreateGraphics();
            Color color = Color.Black;
            pen = new Pen(color, 3);
            brush = new SolidBrush(color);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(n <= 15)
            {
                for (int i = 0; i < sequence.Count; i++)
                {
                    DrawThrow(n, sequence[i]);
                }
            }
            label2.Text = screenHeight.ToString();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    formGraphics.DrawEllipse(pen, 100 * i + 200, screenHeight * 8 / 10, 25, 25);
                }
                else
                {
                    formGraphics.FillEllipse(brush, 100 * i + 200, screenHeight * 8 / 10, 25, 25);
                }
            }
        }

        void DrawThrow(int beat, int h)
        {
            formGraphics.DrawArc(pen, 100 * beat + 200 + 12, screenHeight * 8 / 10 - 75 * h + 12, 100 * h, 150 * h, 0, -180);
        }

        private void sequenceText_TextChanged(object sender, EventArgs e)
        {
            TextBox seqText = sender as TextBox;
            if (seqText.Text.Length > 0)
            {
                if (Char.IsNumber(seqText.Text[seqText.Text.Length - 1]))
                {
                    sequence.Add(seqText.Text[seqText.Text.Length - 1]);
                    label2.Text = sequence[0].ToString();
                }
                else
                {
                    label2.Text = "Error, please write only numbers";
                }
            
                label2.Text += seqText.Text[seqText.Text.Length - 1];
            }
        }
    }
}
