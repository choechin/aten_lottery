namespace ATEN_Lottery
{
    partial class ATEN_Lottery_Mod
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
            this.pbx_Star = new System.Windows.Forms.PictureBox();
            this.bkw_gif = new System.ComponentModel.BackgroundWorker();
            this.lblWinnerName = new System.Windows.Forms.Label();
            this.lblAward = new System.Windows.Forms.Label();
            this.lblLuckyList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Star)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_Star
            // 
            this.pbx_Star.BackColor = System.Drawing.Color.Transparent;
            this.pbx_Star.Location = new System.Drawing.Point(385, 140);
            this.pbx_Star.Name = "pbx_Star";
            this.pbx_Star.Size = new System.Drawing.Size(472, 307);
            this.pbx_Star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Star.TabIndex = 1;
            this.pbx_Star.TabStop = false;
            // 
            // bkw_gif
            // 
            this.bkw_gif.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkw_gif_DoWork);
            this.bkw_gif.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkw_gif_RunWorkerCompleted);
            // 
            // lblWinnerName
            // 
            this.lblWinnerName.AutoSize = true;
            this.lblWinnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblWinnerName.Font = new System.Drawing.Font("微軟正黑體", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWinnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWinnerName.Location = new System.Drawing.Point(442, 222);
            this.lblWinnerName.Name = "lblWinnerName";
            this.lblWinnerName.Size = new System.Drawing.Size(393, 61);
            this.lblWinnerName.TabIndex = 21;
            this.lblWinnerName.Text = "lblWinnerName";
            this.lblWinnerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAward
            // 
            this.lblAward.BackColor = System.Drawing.Color.Transparent;
            this.lblAward.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblAward.Location = new System.Drawing.Point(65, 88);
            this.lblAward.Name = "lblAward";
            this.lblAward.Size = new System.Drawing.Size(1115, 60);
            this.lblAward.TabIndex = 22;
            this.lblAward.Text = "獎項名稱";
            this.lblAward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLuckyList
            // 
            this.lblLuckyList.BackColor = System.Drawing.Color.Transparent;
            this.lblLuckyList.Font = new System.Drawing.Font("標楷體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLuckyList.ForeColor = System.Drawing.Color.White;
            this.lblLuckyList.Location = new System.Drawing.Point(11, 524);
            this.lblLuckyList.Name = "lblLuckyList";
            this.lblLuckyList.Size = new System.Drawing.Size(1189, 107);
            this.lblLuckyList.TabIndex = 23;
            this.lblLuckyList.Text = "lblLuckyList";
            this.lblLuckyList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ATEN_Lottery_Mod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1207, 641);
            this.Controls.Add(this.lblLuckyList);
            this.Controls.Add(this.lblAward);
            this.Controls.Add(this.lblWinnerName);
            this.Controls.Add(this.pbx_Star);
            this.DoubleBuffered = true;
            this.Name = "ATEN_Lottery_Mod";
            this.Text = "ATEN_Lottery_Mod";
            this.Load += new System.EventHandler(this.ATEN_Lottery_Mod_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ATEN_Lottery_Mod_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Star)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbx_Star;
        private System.ComponentModel.BackgroundWorker bkw_gif;
        private System.Windows.Forms.Label lblWinnerName;
        private System.Windows.Forms.Label lblAward;
        private System.Windows.Forms.Label lblLuckyList;
    }
}