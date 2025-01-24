using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ooxx
{
    public partial class Form1 : Form
    {
        int pointSize, gap, totalWidth, totalHeight, startX, startY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 600;
            pointSize = 100;
            gap = 10;
            totalWidth = (pointSize * 3) + (gap * (3 - 1));
            totalHeight = (pointSize * 3) + (gap * (3 - 1));
            startX = (this.ClientSize.Width / 2) - (totalWidth / 2);
            startY = 50;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox playPoint = new PictureBox();
                    playPoint.Width = pointSize;
                    playPoint.Height = pointSize;
                    playPoint.Name = $"{i}{j}";
                    int x = startX + (j * (pointSize + gap));
                    int y = startY + (i * (pointSize + gap));
                    playPoint.Location = new Point(x, y);

                    this.Controls.Add(playPoint);
                    playPoint.Click += new System.EventHandler(this.playPoint_Click);
                }
            }
            Share.statusUpdated += statusUpdated;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                for (int i = 1; i < 3; i++)
                {
                    int y = startY + (i * (pointSize + gap)) - (gap / 2);
                    e.Graphics.DrawLine(pen, startX, y, startX + totalWidth, y);
                }
                for (int j = 1; j < 3; j++)
                {
                    int x = startX + (j * (pointSize + gap)) - (gap / 2);
                    e.Graphics.DrawLine(pen, x, startY, x, startY + totalHeight);
                }
            }
        }


        private void statusUpdated()
        {
            MessageBox.Show("status updated");
        }
        private void playPoint_Click(object sender, System.EventArgs e)
        {
            PictureBox playPoint = (PictureBox)sender;
            var first = int.Parse(playPoint.Name[0].ToString());
            var second = int.Parse(playPoint.Name[1].ToString());

            if (Share.get(first, second) == 2)
            {
                Share.set(first, second, 0);
                npcPlay();
            }
        }
        private void npcPlay()
        {
            Random random = new Random();
            while (true)
            {
                int first = random.Next(0, 3);
                int second = random.Next(0, 3);
                if (Share.get(first, second) == 2)
                {
                    Share.set(first, second, 1);
                    break;
                }
            }
        }
    }
}
