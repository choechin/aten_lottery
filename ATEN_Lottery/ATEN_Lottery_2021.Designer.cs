namespace ATEN_Lottery
{
    partial class ATEN_Lottery_2021
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATEN_Lottery_2021));
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblAward = new System.Windows.Forms.Label();
            this.lblWinnerName = new System.Windows.Forms.Label();
            this.lblLuckyList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblAward
            // 
            this.lblAward.BackColor = System.Drawing.Color.Transparent;
            this.lblAward.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAward.ForeColor = System.Drawing.Color.White;
            this.lblAward.Location = new System.Drawing.Point(12, 539);
            this.lblAward.Name = "lblAward";
            this.lblAward.Size = new System.Drawing.Size(406, 40);
            this.lblAward.TabIndex = 0;
            this.lblAward.Text = "lblAward";
            this.lblAward.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWinnerName
            // 
            this.lblWinnerName.AutoSize = true;
            this.lblWinnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblWinnerName.Font = new System.Drawing.Font("Microsoft JhengHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWinnerName.ForeColor = System.Drawing.Color.Black;
            this.lblWinnerName.Location = new System.Drawing.Point(306, 83);
            this.lblWinnerName.Name = "lblWinnerName";
            this.lblWinnerName.Size = new System.Drawing.Size(393, 61);
            this.lblWinnerName.TabIndex = 1;
            this.lblWinnerName.Text = "lblWinnerName";
            this.lblWinnerName.Visible = false;
            // 
            // lblLuckyList
            // 
            this.lblLuckyList.BackColor = System.Drawing.Color.Transparent;
            this.lblLuckyList.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLuckyList.ForeColor = System.Drawing.Color.White;
            this.lblLuckyList.Location = new System.Drawing.Point(12, 608);
            this.lblLuckyList.Name = "lblLuckyList";
            this.lblLuckyList.Size = new System.Drawing.Size(984, 113);
            this.lblLuckyList.TabIndex = 2;
            this.lblLuckyList.Text = "lblLuckyList";
            this.lblLuckyList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ATEN_Lottery_2021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.lblLuckyList);
            this.Controls.Add(this.lblWinnerName);
            this.Controls.Add(this.lblAward);
            this.MaximizeBox = false;
            this.Name = "ATEN_Lottery_2021";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATEN_Lottery_2021";
            this.Load += new System.EventHandler(this.ATEN_Lottery_2021_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ATEN_Lottery_2021_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblAward;
        private System.Windows.Forms.Label lblWinnerName;
        private System.Windows.Forms.Label lblLuckyList;
    }
}