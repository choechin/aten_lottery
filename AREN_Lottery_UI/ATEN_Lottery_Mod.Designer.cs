namespace AREN_Lottery_UI
{
    partial class ATEN_Lottery_Mod
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAward = new System.Windows.Forms.Label();
            this.pbx_Star = new System.Windows.Forms.PictureBox();
            this.lblLuckyList = new System.Windows.Forms.Label();
            this.bkw_gif = new System.ComponentModel.BackgroundWorker();
            this.lblWinnerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Star)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAward
            // 
            this.lblAward.BackColor = System.Drawing.Color.Transparent;
            this.lblAward.Font = new System.Drawing.Font("微軟正黑體", 34.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAward.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblAward.Location = new System.Drawing.Point(211, 25);
            this.lblAward.Name = "lblAward";
            this.lblAward.Size = new System.Drawing.Size(984, 69);
            this.lblAward.TabIndex = 23;
            this.lblAward.Text = "獎項名稱";
            this.lblAward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbx_Star
            // 
            this.pbx_Star.BackColor = System.Drawing.Color.Transparent;
            this.pbx_Star.Location = new System.Drawing.Point(139, 97);
            this.pbx_Star.Name = "pbx_Star";
            this.pbx_Star.Size = new System.Drawing.Size(994, 460);
            this.pbx_Star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Star.TabIndex = 24;
            this.pbx_Star.TabStop = false;
            // 
            // lblLuckyList
            // 
            this.lblLuckyList.BackColor = System.Drawing.Color.Transparent;
            this.lblLuckyList.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLuckyList.ForeColor = System.Drawing.Color.White;
            this.lblLuckyList.Location = new System.Drawing.Point(3, 508);
            this.lblLuckyList.Name = "lblLuckyList";
            this.lblLuckyList.Size = new System.Drawing.Size(1177, 144);
            this.lblLuckyList.TabIndex = 25;
            this.lblLuckyList.Text = "lblLuckyList";
            this.lblLuckyList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblWinnerName.Font = new System.Drawing.Font("微軟正黑體", 40.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWinnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWinnerName.Location = new System.Drawing.Point(325, 185);
            this.lblWinnerName.Name = "lblWinnerName";
            this.lblWinnerName.Size = new System.Drawing.Size(558, 86);
            this.lblWinnerName.TabIndex = 26;
            this.lblWinnerName.Text = "lblWinnerName";
            this.lblWinnerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ATEN_Lottery_Mod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 641);
            this.Controls.Add(this.lblAward);
            this.Controls.Add(this.lblWinnerName);
            this.Controls.Add(this.lblLuckyList);
            this.Controls.Add(this.pbx_Star);
            this.Name = "ATEN_Lottery_Mod";
            this.Text = "ATEN_Lottery_Mod";
            this.Load += new System.EventHandler(this.ATEN_Lottery_Mod_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ATEN_Lottery_Mod_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Star)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAward;
        private System.Windows.Forms.PictureBox pbx_Star;
        private System.Windows.Forms.Label lblLuckyList;
        private System.ComponentModel.BackgroundWorker bkw_gif;
        private System.Windows.Forms.Label lblWinnerName;
    }
}

