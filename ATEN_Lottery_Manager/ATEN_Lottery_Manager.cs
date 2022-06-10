using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATEN_Util.Model;
using ATEN_Util;
using Dapper;
using System.Data.SQLite;

namespace ATEN_Lottery_Manager
{
    public partial class ATEN_Lottery_Manager : Form
    {
        public ATEN_Lottery_Manager()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version：1.0.0 ; Design By Information Center");
        }

        private void AtenMenu_Click(object sender, EventArgs e)
        {
        }

        private void empEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Aten.EmployeeImport empImport = new Aten.EmployeeImport();
            empImport.Name = "uc";
            empImport.Width = panel1.Width;
            empImport.Height = panel1.Height;
            empImport.TopLevel = false;
            empImport.Show();
            this.panel1.Controls.Add(empImport);

        }

        private void awardEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Aten.AwardManage awardMg = new Aten.AwardManage();
            awardMg.Name = "uc";
            awardMg.Width = panel1.Width;
            awardMg.Height = panel1.Height;
            awardMg.TopLevel = false;
            awardMg.Show();
            this.panel1.Controls.Add(awardMg);
        }

        private void backendLotteryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Aten.BatchLottery bl = new Aten.BatchLottery();
            bl.Name = "uc";
            bl.Width = panel1.Width;
            bl.Height = panel1.Height;
            bl.TopLevel = false;
            bl.Show();
            this.panel1.Controls.Add(bl);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Lottery_List_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                string fileName = saveFile.FileName;
                XSSFWorkbook wk = new XSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                XSSFSheet sheet = (XSSFSheet)wk.CreateSheet("得獎名單");
                XSSFRow header = (XSSFRow)sheet.CreateRow(0);
                sheet.GetRow(0).CreateCell(0).SetCellValue("姓名");
                sheet.GetRow(0).CreateCell(1).SetCellValue("部門");
                sheet.GetRow(0).CreateCell(2).SetCellValue("員工編號");
                sheet.GetRow(0).CreateCell(3).SetCellValue("職級");
                sheet.GetRow(0).CreateCell(4).SetCellValue("獎項");

                List<LuckyListModel> luckyLists = LoadLuckyList();
                for (int i = 1; i <= luckyLists.Count; i++)
                {
                    XSSFRow row = (XSSFRow)sheet.CreateRow(i);
                    sheet.GetRow(i).CreateCell(0).SetCellValue(luckyLists.ElementAt(i - 1).name);
                    sheet.GetRow(i).CreateCell(1).SetCellValue(luckyLists.ElementAt(i - 1).department);
                    sheet.GetRow(i).CreateCell(2).SetCellValue(luckyLists.ElementAt(i - 1).empId);
                    sheet.GetRow(i).CreateCell(3).SetCellValue(luckyLists.ElementAt(i - 1).job);
                    sheet.GetRow(i).CreateCell(4).SetCellValue(luckyLists.ElementAt(i - 1).award);
                }


                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    wk.Write(fs);
                }
                MessageBox.Show("匯出成功!");
            }
        }

        private List<LuckyListModel> LoadLuckyList()
        {
            using (var cn = Conn.ConnDB())
            {
                var output = cn.Query<LuckyListModel>("select * from lucky_list order by id", new DynamicParameters());
                return output.ToList();
            }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定重置中獎資料?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                using (SQLiteConnection cn = Conn.ConnDB())
                {
                    using (SQLiteTransaction trans = cn.BeginTransaction())
                    {
                        string delScript = " DELETE FROM lucky_list; ";
                        string updScript = " UPDATE employee set enable=1; UPDATE award set status=1, new_qty=0; ";
                        cn.Execute(delScript + updScript);
                        trans.Commit();
                    }

                }
                MessageBox.Show("資料重置 OK");
            }
        }
    }
}
