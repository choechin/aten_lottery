using ATEN_Lottery_Manager.Utils;
using ATEN_Util;
using ATEN_Util.Service;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ATEN_Lottery_Manager.Aten
{
    public partial class EmployeeImport : MaterialForm
    {
        private EmployeeService employeeService = new EmployeeService();
        private EmployeeExcelParser parser = new EmployeeExcelParser();
        private EmployeeModelComparer comparer = new EmployeeModelComparer();

        public EmployeeImport()
        {
            InitializeComponent();
            MaterialSkinManager msm = MaterialSkinManager.Instance;
            msm.AddFormToManage(this);
            msm.Theme = MaterialSkinManager.Themes.DARK;
            msm.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void EmployeeImport_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            LoadAwardList();
        }

        private void LoadAwardList()
        {
            List<EmployeeModel> employeeList = employeeService.LoadEmployee();
            employeeList.Sort(comparer);

            dataGridView1.DataSource = employeeList;
            dataGridView1.Columns["id"].HeaderText = "員工編號";
            dataGridView1.Columns["name"].HeaderText = "姓名";
            dataGridView1.Columns["department"].HeaderText = "部門";
            dataGridView1.Columns["job"].HeaderText = "職級";
            dataGridView1.Columns["awardGroups"].HeaderText = "群組";
            dataGridView1.Columns["enable"].Visible = false;
            dataGridView1.Columns["updateTime"].Visible = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
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
                    employeeService.ImportEmployeeList(parser.ReadEmployeeList(destPath));
                    LoadAwardList();
                    MessageBox.Show("匯入成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法匯入 Excel: " + ex.Message);
                }
            }
        }
    }
}
