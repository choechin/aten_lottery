using ATEN_Lottery_Manager.Utils;
using ATEN_Util.Model;
using ATEN_Util.Service;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace ATEN_Lottery_Manager.Aten
{
    public partial class AwardManage : MaterialForm
    {
        private AwardService awardService = new AwardService();

        public AwardManage()
        {
            InitializeComponent();
            MaterialSkinManager msm = MaterialSkinManager.Instance;
            msm.AddFormToManage(this);
            msm.Theme = MaterialSkinManager.Themes.DARK;
            msm.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);

            // init dropdown list
            for (char i = 'A'; i <= 'Z'; i++)
            {
                cbAwardGroup.Items.Add(i);
            }

            cbAwardGroup.Text = "A";
        }

        public void LoadAwardList()
        {
            dataGridView1.DataSource = awardService.GetAvailableAwards();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["new_qty"].Visible = false;

            dataGridView1.Columns["name"].HeaderText = lblAwardName.Text.Replace("：", "");
            dataGridView1.Columns["qty"].HeaderText = lblAwardQty.Text.Replace("：", "");
            dataGridView1.Columns["seq"].HeaderText = lblAwardSeq.Text.Replace("：", "");
            dataGridView1.Columns["status"].HeaderText = "狀態 (0:不可, 1:可)";
            dataGridView1.Columns["awardGroup"].HeaderText = lblAwardGroup.Text.Replace("：", "");

            //txtAwardId.Text = "";
            //txtAwardName.Text = "";
            //txtAwardQty.Text = "";
            //txtAwardSeq.Text = "";
            //cbAwardGroup.Text = "A";
          
        }

        public void AwardManage_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btn_Cfn.Visible = false;
            btn_Cnl.Visible = false;
            LoadAwardList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                txtAwardId.Text = row.Cells["id"].Value.ToString();
                txtAwardName.Text = row.Cells["name"].Value.ToString();
                txtAwardQty.Text = row.Cells["qty"].Value.ToString();
                txtAwardSeq.Text = row.Cells["seq"].Value.ToString();
                cbAwardGroup.Text = row.Cells["awardGroup"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowCtrl(false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "xls files (*.*)|*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string destPath = string.Empty;

                foreach (string fileName in dialog.FileNames)
                {
                    destPath = "excel\\" + DateTime.Now.ToString("yyyymmddhhmmss") + "_"
                        + Path.GetFileName(fileName);
                    File.Copy(fileName, destPath);
                }
                try
                {
                    AwardService awardService = new AwardService();
                    AwardExcelParser parser = new AwardExcelParser();
                    awardService.ImportAwardList(parser.ReadAwaedList(destPath));
                    LoadAwardList();
                    MessageBox.Show("匯入成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法匯入 Excel: " + ex.Message);
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AwardModel awardModel = new AwardModel()
            {
                id = txtAwardId.Text,
                name = txtAwardName.Text,
                qty = txtAwardQty.Text,
                new_qty = "0",
                seq = txtAwardSeq.Text,
                status = "1",
                awardGroup = cbAwardGroup.Text
            };

            awardService.UpdateAward(awardModel);
            LoadAwardList();
            MessageBox.Show("資料更新完畢!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定刪除該筆資料?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                awardService.DeleteAward(txtAwardId.Text);
                LoadAwardList();
                MessageBox.Show("資料刪除完畢!!");
            }
        }

        private void btn_Cnl_Click(object sender, EventArgs e)
        {
            ShowCtrl(true);
        }

        private void btn_Cfn_Click(object sender, EventArgs e)
        {
            string strMsg = string.Empty;
            if (txtAwardName.Text.Trim() == string.Empty)
            {
                strMsg = "請輸入獎項名稱!!" + "\r\n";
            }
            if (txtAwardQty.Text.Trim() == string.Empty)
            {
                strMsg += "請輸入獎項名額!!" + "\r\n";
            }
            if (txtAwardSeq.Text.Trim() == string.Empty)
            {
                strMsg += "請輸入獎項順序!!" + "\r\n";
            }
            if (cbAwardGroup.Text == string.Empty)
            {
                strMsg += "請選擇獎項分類!!" + "\r\n";
            }
            if (strMsg == string.Empty)
            {
                awardService.AddAward(txtAwardName.Text, txtAwardQty.Text, txtAwardSeq.Text, cbAwardGroup.Text);
                LoadAwardList();
                ShowCtrl(true);
                MessageBox.Show("新增完畢!!");
            }
            else
            {
                MessageBox.Show(strMsg);
            }
        }

        private void txtAwardQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))//限制數字
            {
                e.Handled = true;
            }
        }

        private void txtAwardSeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))//限制數字
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 控制元件顯示
        /// </summary>
        /// <param name="bl_Status">顯示狀態</param>
        private void ShowCtrl(bool bl_Status)
        {
            btnUpdate.Visible = bl_Status;
            btnDelete.Visible = bl_Status;
            btnAdd.Visible = bl_Status;
            txtAwardName.Text = string.Empty;
            txtAwardQty.Text = string.Empty;
            txtAwardSeq.Text = string.Empty;
            cbAwardGroup.Text = string.Empty;
            dataGridView1.Enabled = bl_Status;
            btn_Cfn.Visible = !bl_Status;
            btn_Cnl.Visible = !bl_Status;
            btnImport.Visible = bl_Status;
        }
        
    }
}
