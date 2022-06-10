namespace ATEN_Lottery_Manager.Aten
{
    partial class AwardManage
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
            this.components = new System.ComponentModel.Container();
            this.lblAwardName = new MaterialSkin.Controls.MaterialLabel();
            this.txtAwardName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblAwardQty = new MaterialSkin.Controls.MaterialLabel();
            this.txtAwardQty = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblAwardSeq = new MaterialSkin.Controls.MaterialLabel();
            this.txtAwardSeq = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAdd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.awardModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtAwardId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnDelete = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblAwardGroup = new MaterialSkin.Controls.MaterialLabel();
            this.cbAwardGroup = new System.Windows.Forms.ComboBox();
            this.btn_Cfn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_Cnl = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnImport = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.awardModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAwardName
            // 
            this.lblAwardName.AutoSize = true;
            this.lblAwardName.Depth = 0;
            this.lblAwardName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAwardName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAwardName.Location = new System.Drawing.Point(87, 101);
            this.lblAwardName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAwardName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAwardName.Name = "lblAwardName";
            this.lblAwardName.Size = new System.Drawing.Size(110, 24);
            this.lblAwardName.TabIndex = 0;
            this.lblAwardName.Text = "獎項名稱：";
            // 
            // txtAwardName
            // 
            this.txtAwardName.Depth = 0;
            this.txtAwardName.Hint = "";
            this.txtAwardName.Location = new System.Drawing.Point(211, 101);
            this.txtAwardName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAwardName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardName.Name = "txtAwardName";
            this.txtAwardName.PasswordChar = '\0';
            this.txtAwardName.SelectedText = "";
            this.txtAwardName.SelectionLength = 0;
            this.txtAwardName.SelectionStart = 0;
            this.txtAwardName.Size = new System.Drawing.Size(265, 28);
            this.txtAwardName.TabIndex = 1;
            this.txtAwardName.UseSystemPasswordChar = false;
            // 
            // lblAwardQty
            // 
            this.lblAwardQty.AutoSize = true;
            this.lblAwardQty.Depth = 0;
            this.lblAwardQty.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAwardQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAwardQty.Location = new System.Drawing.Point(87, 156);
            this.lblAwardQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAwardQty.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAwardQty.Name = "lblAwardQty";
            this.lblAwardQty.Size = new System.Drawing.Size(110, 24);
            this.lblAwardQty.TabIndex = 2;
            this.lblAwardQty.Text = "獎項名額：";
            // 
            // txtAwardQty
            // 
            this.txtAwardQty.Depth = 0;
            this.txtAwardQty.Hint = "";
            this.txtAwardQty.Location = new System.Drawing.Point(211, 156);
            this.txtAwardQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAwardQty.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardQty.Name = "txtAwardQty";
            this.txtAwardQty.PasswordChar = '\0';
            this.txtAwardQty.SelectedText = "";
            this.txtAwardQty.SelectionLength = 0;
            this.txtAwardQty.SelectionStart = 0;
            this.txtAwardQty.Size = new System.Drawing.Size(100, 28);
            this.txtAwardQty.TabIndex = 3;
            this.txtAwardQty.UseSystemPasswordChar = false;
            this.txtAwardQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAwardQty_KeyPress);
            // 
            // lblAwardSeq
            // 
            this.lblAwardSeq.AutoSize = true;
            this.lblAwardSeq.Depth = 0;
            this.lblAwardSeq.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAwardSeq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAwardSeq.Location = new System.Drawing.Point(87, 215);
            this.lblAwardSeq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAwardSeq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAwardSeq.Name = "lblAwardSeq";
            this.lblAwardSeq.Size = new System.Drawing.Size(110, 24);
            this.lblAwardSeq.TabIndex = 4;
            this.lblAwardSeq.Text = "獎項順序：";
            // 
            // txtAwardSeq
            // 
            this.txtAwardSeq.Depth = 0;
            this.txtAwardSeq.Hint = "";
            this.txtAwardSeq.Location = new System.Drawing.Point(211, 215);
            this.txtAwardSeq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAwardSeq.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardSeq.Name = "txtAwardSeq";
            this.txtAwardSeq.PasswordChar = '\0';
            this.txtAwardSeq.SelectedText = "";
            this.txtAwardSeq.SelectionLength = 0;
            this.txtAwardSeq.SelectionStart = 0;
            this.txtAwardSeq.Size = new System.Drawing.Size(100, 28);
            this.txtAwardSeq.TabIndex = 5;
            this.txtAwardSeq.UseSystemPasswordChar = false;
            this.txtAwardSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAwardSeq_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Depth = 0;
            this.btnAdd.Location = new System.Drawing.Point(25, 320);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Primary = true;
            this.btnAdd.Size = new System.Drawing.Size(133, 46);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(604, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(748, 606);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Location = new System.Drawing.Point(307, 320);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Primary = true;
            this.btnUpdate.Size = new System.Drawing.Size(133, 46);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAwardId
            // 
            this.txtAwardId.Depth = 0;
            this.txtAwardId.Hint = "";
            this.txtAwardId.Location = new System.Drawing.Point(92, 419);
            this.txtAwardId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAwardId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAwardId.Name = "txtAwardId";
            this.txtAwardId.PasswordChar = '\0';
            this.txtAwardId.SelectedText = "";
            this.txtAwardId.SelectionLength = 0;
            this.txtAwardId.SelectionStart = 0;
            this.txtAwardId.Size = new System.Drawing.Size(265, 28);
            this.txtAwardId.TabIndex = 9;
            this.txtAwardId.UseSystemPasswordChar = false;
            this.txtAwardId.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Depth = 0;
            this.btnDelete.Location = new System.Drawing.Point(448, 320);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Primary = true;
            this.btnDelete.Size = new System.Drawing.Size(133, 46);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblAwardGroup
            // 
            this.lblAwardGroup.AutoSize = true;
            this.lblAwardGroup.Depth = 0;
            this.lblAwardGroup.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAwardGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAwardGroup.Location = new System.Drawing.Point(87, 264);
            this.lblAwardGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAwardGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAwardGroup.Name = "lblAwardGroup";
            this.lblAwardGroup.Size = new System.Drawing.Size(110, 24);
            this.lblAwardGroup.TabIndex = 11;
            this.lblAwardGroup.Text = "獎項分類：";
            // 
            // cbAwardGroup
            // 
            this.cbAwardGroup.FormattingEnabled = true;
            this.cbAwardGroup.Location = new System.Drawing.Point(213, 266);
            this.cbAwardGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAwardGroup.Name = "cbAwardGroup";
            this.cbAwardGroup.Size = new System.Drawing.Size(160, 23);
            this.cbAwardGroup.TabIndex = 13;
            // 
            // btn_Cfn
            // 
            this.btn_Cfn.Depth = 0;
            this.btn_Cfn.Location = new System.Drawing.Point(380, 266);
            this.btn_Cfn.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Cfn.Name = "btn_Cfn";
            this.btn_Cfn.Primary = true;
            this.btn_Cfn.Size = new System.Drawing.Size(75, 23);
            this.btn_Cfn.TabIndex = 14;
            this.btn_Cfn.Text = "確認";
            this.btn_Cfn.UseVisualStyleBackColor = true;
            this.btn_Cfn.Click += new System.EventHandler(this.btn_Cfn_Click);
            // 
            // btn_Cnl
            // 
            this.btn_Cnl.Depth = 0;
            this.btn_Cnl.Location = new System.Drawing.Point(475, 266);
            this.btn_Cnl.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Cnl.Name = "btn_Cnl";
            this.btn_Cnl.Primary = true;
            this.btn_Cnl.Size = new System.Drawing.Size(75, 23);
            this.btn_Cnl.TabIndex = 15;
            this.btn_Cnl.Text = "取消";
            this.btn_Cnl.UseVisualStyleBackColor = true;
            this.btn_Cnl.Click += new System.EventHandler(this.btn_Cnl_Click);
            // 
            // btnImport
            // 
            this.btnImport.Depth = 0;
            this.btnImport.Location = new System.Drawing.Point(166, 320);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnImport.Name = "btnImport";
            this.btnImport.Primary = true;
            this.btnImport.Size = new System.Drawing.Size(133, 46);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // AwardManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 789);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btn_Cnl);
            this.Controls.Add(this.btn_Cfn);
            this.Controls.Add(this.cbAwardGroup);
            this.Controls.Add(this.lblAwardGroup);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtAwardId);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAwardSeq);
            this.Controls.Add(this.lblAwardSeq);
            this.Controls.Add(this.txtAwardQty);
            this.Controls.Add(this.lblAwardQty);
            this.Controls.Add(this.txtAwardName);
            this.Controls.Add(this.lblAwardName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AwardManage";
            this.Load += new System.EventHandler(this.AwardManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.awardModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblAwardName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardName;
        private MaterialSkin.Controls.MaterialLabel lblAwardQty;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardQty;
        private MaterialSkin.Controls.MaterialLabel lblAwardSeq;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardSeq;
        private MaterialSkin.Controls.MaterialRaisedButton btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource awardModelBindingSource;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdate;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAwardId;
        private MaterialSkin.Controls.MaterialRaisedButton btnDelete;
        private MaterialSkin.Controls.MaterialLabel lblAwardGroup;
        private System.Windows.Forms.ComboBox cbAwardGroup;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Cfn;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Cnl;
        private MaterialSkin.Controls.MaterialRaisedButton btnImport;
    }
}
