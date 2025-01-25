using System;
using System.Data;
using System.Drawing;
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

            pointSize = 100; // 每個格子的大小
            gap = 10; // 格子之間的間距
            totalWidth = (pointSize * 3) + (gap * (3 - 1)); // 棋盤的寬度
            totalHeight = (pointSize * 3) + (gap * (3 - 1)); // 棋盤的高度
            startX = (this.ClientSize.Width / 2) - (totalWidth / 2); // 棋盤的起始X座標
            startY = 10; // 棋盤的起始Y座標
            // 用來顯示picturebox
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox playPoint = new PictureBox();
                    playPoint.Width = pointSize;
                    playPoint.Height = pointSize;
                    playPoint.BackColor = Color.White;
                    playPoint.SizeMode = PictureBoxSizeMode.StretchImage;
                    playPoint.Name = $"{i}{j}";
                    int x = startX + (j * (pointSize + gap));
                    int y = startY + (i * (pointSize + gap));
                    playPoint.Location = new Point(x, y);

                    this.Controls.Add(playPoint);
                    playPoint.Click += new System.EventHandler(this.playPoint_Click);
                }
            }
            // 崁入事件function
            Share.statusUpdated += statusUpdated;
            Share.gameEnd += gameEnd;
            // npc(電腦)先下
            npcPlay();
        }
        private void gameEnd() // 遊戲結束
        {
            // 顯示繼續玩的按鈕
            Button restart = new Button();
            restart.Text = "Play Again";
            restart.Location = new Point((this.ClientSize.Width / 2) - (restart.Width / 2), this.ClientSize.Height - restart.Height - 10);
            restart.Click += new EventHandler(restart_Click);
            this.Controls.Add(restart);
        }
        void restart_Click(object sender, EventArgs e) // 重新開始遊戲按鈕
        {
            Button restart = (Button)sender;
            this.Controls.Remove(restart);
            Share.reset();
            npcPlay();
        }
        private void checkRules() // 檢查整個棋盤是否有人贏
        {
            for (int i = 0; i < 8; i++) // 有8條連成一條線的連線
            {
                if (!Share.hasChecked.Contains(i)) // 如果這條連線還沒檢查過
                {
                    int[] line = new int[3]; // 連成一條線的3個格子
                    for (int j = 0; j < 3; j++)
                    {
                        line[j] = Share.get(Share.rules[i, j, 0], Share.rules[i, j, 1]);
                    }
                    if (line[0] == line[1] && line[1] == line[2]) // 如果這條連線有連成一條線
                    {
                        if (line[0] == 0) // 如果是玩家贏了
                        {
                            Share.userScore += 1;
                            Share.hasChecked.Add(i); // 把這條連線加入已經檢查過的連線
                        }
                        else if (line[0] == 1) // 如果是npc贏了
                        {
                            Share.npcScore += 1;
                            Share.hasChecked.Add(i); // 把這條連線加入已經檢查過的連線
                        }
                        // 更新計分板label分數
                        npcScore.Text = Share.npcScore.ToString();
                        userScore.Text = Share.userScore.ToString();
                    }
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e) // 畫出棋盤
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


        private void statusUpdated() // 更新棋盤
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox playPoint = (PictureBox)this.Controls.Find($"{i}{j}", true)[0];
                    if (Share.get(i, j) == 0)
                    {
                        playPoint.Image = Properties.Resources.o;
                    }
                    else if (Share.get(i, j) == 1)
                    {
                        playPoint.Image = Properties.Resources.x;
                    }
                    else
                    {
                        playPoint.Image = null;
                    }
                }
            }
        }
        private void playPoint_Click(object sender, System.EventArgs e)
        {
            PictureBox playPoint = (PictureBox)sender; // 取得被點擊的PictureBox資料
            var first = int.Parse(playPoint.Name[0].ToString());
            var second = int.Parse(playPoint.Name[1].ToString());

            if (Share.get(first, second) == 2) // 如果該格子是空的
            {
                Share.set(first, second, 0); // 設定該格子為玩家
                npcPlay();
                checkRules();
            }
        }
        private void npcPlay()
        {
            Random random = new Random();
            while (true)
            {
                int first = random.Next(0, 3);
                int second = random.Next(0, 3);
                if (Share.get(first, second) == 2) // 如果該格子是空的
                {
                    Share.set(first, second, 1); // 設定該格子為npc
                    break;
                }
            }
            // 檢查整個棋盤是否有人贏
            checkRules();
        }
    }
}
