namespace ooxx
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userScore = new System.Windows.Forms.Label();
            this.npcScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "我";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "電腦";
            // 
            // userScore
            // 
            this.userScore.AutoSize = true;
            this.userScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userScore.Location = new System.Drawing.Point(12, 500);
            this.userScore.Name = "userScore";
            this.userScore.Size = new System.Drawing.Size(26, 29);
            this.userScore.TabIndex = 3;
            this.userScore.Text = "0";
            // 
            // npcScore
            // 
            this.npcScore.AutoSize = true;
            this.npcScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcScore.Location = new System.Drawing.Point(444, 500);
            this.npcScore.Name = "npcScore";
            this.npcScore.Size = new System.Drawing.Size(26, 29);
            this.npcScore.TabIndex = 4;
            this.npcScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 553);
            this.Controls.Add(this.npcScore);
            this.Controls.Add(this.userScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label userScore;
        private System.Windows.Forms.Label npcScore;
    }
}

