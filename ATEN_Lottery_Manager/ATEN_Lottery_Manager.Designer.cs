namespace ATEN_Lottery_Manager
{
    partial class ATEN_Lottery_Manager
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATEN_Lottery_Manager));
            this.AtenMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.awardEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backendLotteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AtenMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AtenMenu
            // 
            this.AtenMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AtenMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.functionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.AtenMenu.Location = new System.Drawing.Point(0, 0);
            this.AtenMenu.Name = "AtenMenu";
            this.AtenMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.AtenMenu.Size = new System.Drawing.Size(1577, 28);
            this.AtenMenu.TabIndex = 0;
            this.AtenMenu.Text = "menuStrip1";
            this.AtenMenu.Click += new System.EventHandler(this.AtenMenu_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.fileToolStripMenuItem.Text = "檔案";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.closeToolStripMenuItem.Text = "關閉";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empEditToolStripMenuItem,
            this.awardEditToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.backendLotteryToolStripMenuItem,
            this.ResetToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.functionToolStripMenuItem.Text = "功能";
            // 
            // empEditToolStripMenuItem
            // 
            this.empEditToolStripMenuItem.Name = "empEditToolStripMenuItem";
            this.empEditToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.empEditToolStripMenuItem.Text = "員工資料匯入";
            this.empEditToolStripMenuItem.Click += new System.EventHandler(this.empEditToolStripMenuItem_Click);
            // 
            // awardEditToolStripMenuItem
            // 
            this.awardEditToolStripMenuItem.Name = "awardEditToolStripMenuItem";
            this.awardEditToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.awardEditToolStripMenuItem.Text = "獎項資料維護";
            this.awardEditToolStripMenuItem.Click += new System.EventHandler(this.awardEditToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.exportToolStripMenuItem.Text = "匯出得獎名單";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // backendLotteryToolStripMenuItem
            // 
            this.backendLotteryToolStripMenuItem.Name = "backendLotteryToolStripMenuItem";
            this.backendLotteryToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.backendLotteryToolStripMenuItem.Text = "批次抽獎功能";
            this.backendLotteryToolStripMenuItem.Click += new System.EventHandler(this.backendLotteryToolStripMenuItem_Click);
            // 
            // ResetToolStripMenuItem
            // 
            this.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem";
            this.ResetToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.ResetToolStripMenuItem.Text = "重置資料(Test)";
            this.ResetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.aboutToolStripMenuItem.Text = "關於";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1547, 712);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(403, 211);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 291);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ATEN_Lottery_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1577, 769);
            this.Controls.Add(this.AtenMenu);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.AtenMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ATEN_Lottery_Manager";
            this.Text = "ATEN Lottery 後台管理";
            this.AtenMenu.ResumeLayout(false);
            this.AtenMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip AtenMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem awardEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem backendLotteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetToolStripMenuItem;
    }
}

