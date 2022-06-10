using ATEN_Util.Model;
using ATEN_Util.Service;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ATEN_Lottery_Manager.Aten
{
    public partial class BatchLottery : MaterialForm
    {
        private LotteryProcess lotteryProcess = new LotteryProcess();
        private AwardModel selectedAward;

        public BatchLottery()
        {
            InitializeComponent();
            MaterialSkinManager bl = MaterialSkinManager.Instance;
            bl.AddFormToManage(this);
            bl.Theme = MaterialSkinManager.Themes.DARK;
            bl.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void BatchLottery_Load(object sender, EventArgs e)
        {
            try
            {
                lotteryProcess.ValidatePreRequirements();

                LoadAwardList();
                btnGo.Enabled = true;
                cbxAward.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                btnGo.Enabled = false;
                cbxAward.Enabled = false;
            }
        }

        private void LoadAwardList()
        {
            List<AwardModel> list = new List<AwardModel>();
            list.AddRange(lotteryProcess.AwardList);
            list.Insert(0, new AwardModel() {
                id = "-1",
                name = "請選擇...."
            });

            cbxAward.DataSource = list;
            cbxAward.DisplayMember = "name";
            cbxAward.ValueMember = "id";
        }

        private void cbxAward_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAward.SelectedIndex > 0)
            {
                selectedAward = lotteryProcess.GetAwardById(cbxAward.SelectedValue.ToString());
                txtAwardName.Text = selectedAward.name;
                txtAwardQty.Text = selectedAward.qty;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cbxAward.SelectedIndex == 0)
            {
                MessageBox.Show("請選擇抽獎獎項!!");
            }
            else
            {
                dataGridView1.DataSource = lotteryProcess.GetWinners(selectedAward);
                dataGridView1.Columns["id"].HeaderText = "員工編號";
                dataGridView1.Columns["name"].HeaderText = "姓名";
                dataGridView1.Columns["department"].HeaderText = "部門";
                dataGridView1.Columns["job"].HeaderText = "職級";
                dataGridView1.Columns["enable"].Visible = false;
                dataGridView1.Columns["updateTime"].Visible = false;
                dataGridView1.Columns["awardGroups"].Visible = false;
                dataGridView1.AutoResizeColumns();
                LoadAwardList();
            }
        }
    }
}
