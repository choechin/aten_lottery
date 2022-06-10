namespace ATEN_Lottery_Manager.Aten
{
    partial class BatchLottery
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxAward = new System.Windows.Forms.ComboBox();
            this.btnGo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAwardQty = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtAwardName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxAward
            // 
            this.cbxAward.FormattingEnabled = true;
            this.cbxAward.Location = new System.Drawing.Point(39, 117);
            this.cbxAward.Name = "cbxAward";
            this.cbxAward.Size = new System.Drawing.Size(245, 20);
            this.cbxAward.TabIndex = 0;
            this.cbxAward.SelectedIndexChanged += new System.EventHandler(this.cbxAward_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.Depth = 0;
            this.btnGo.Location = new System.Drawing.Point(39, 354);
            this.btnGo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGo.Name = "btnGo";
            this.btnGo.Primary = true;
            this.btnGo.Size = new System.Drawing.Size(115, 48);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "抽獎";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(532, 375);
            this.dataGridView1.TabIndex = 2;
            // 
            // txtAwardQty
            // 
            this.txtAwardQty.Depth = 0;
            this.txtAwardQty.Enabled = false;
            this.txtAwardQty.Hint = "";
            this.txtAwardQty.Location = new System.Drawing.Point(128, 219);
            this.txtAwardQty.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardQty.Name = "txtAwardQty";
            this.txtAwardQty.PasswordChar = '\0';
            this.txtAwardQty.SelectedText = "";
            this.txtAwardQty.SelectionLength = 0;
            this.txtAwardQty.SelectionStart = 0;
            this.txtAwardQty.Size = new System.Drawing.Size(75, 23);
            this.txtAwardQty.TabIndex = 7;
            this.txtAwardQty.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(35, 219);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "獎項名額：";
            // 
            // txtAwardName
            // 
            this.txtAwardName.Depth = 0;
            this.txtAwardName.Enabled = false;
            this.txtAwardName.Hint = "";
            this.txtAwardName.Location = new System.Drawing.Point(128, 175);
            this.txtAwardName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardName.Name = "txtAwardName";
            this.txtAwardName.PasswordChar = '\0';
            this.txtAwardName.SelectedText = "";
            this.txtAwardName.SelectionLength = 0;
            this.txtAwardName.SelectionStart = 0;
            this.txtAwardName.Size = new System.Drawing.Size(199, 23);
            this.txtAwardName.TabIndex = 5;
            this.txtAwardName.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 175);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(89, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "獎項名稱：";
            // 
            // BatchLottery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 607);
            this.Controls.Add(this.txtAwardQty);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtAwardName);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cbxAward);
            this.Name = "BatchLottery";
            this.Load += new System.EventHandler(this.BatchLottery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAward;
        private MaterialSkin.Controls.MaterialRaisedButton btnGo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardQty;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardName;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
