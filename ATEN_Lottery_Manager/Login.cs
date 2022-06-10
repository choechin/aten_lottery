using ATEN_Util;
using ATEN_Util.Model;
using Dapper;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace ATEN_Lottery_Manager
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            MaterialSkinManager msm = MaterialSkinManager.Instance;
            msm.AddFormToManage(this);
            msm.Theme = MaterialSkinManager.Themes.DARK;
            msm.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
            this.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valldation_Account(txtAccount.Text, txtPassword.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("帳號或密碼錯誤!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料異常，請洽資訊中心!!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Valldation_Account(string act, string pwd)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                var output = cn.Query<AccountModel>("select * from account where account=@account and password=@password and enable=1", new { account = act, password = pwd });
                if (output.Count() > 0)
                    return true;
            }

            return false;
        }
    }
}
