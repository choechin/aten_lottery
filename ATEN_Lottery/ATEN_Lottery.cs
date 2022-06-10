using ATEN_Util;
using ATEN_Util.Model;
using ATEN_Util.Service;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ATEN_Lottery
{
    public partial class ATEN_Lottery : Form
    {
        private EmployeeService employeeService = new EmployeeService();
        private AwardService awardService = new AwardService();
        private LuckyListService luckyListService = new LuckyListService();
        public ATEN_Lottery()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            //sthis.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.Size = new System.Drawing.Size(1024, 768);

            dept1.Parent = picDept;
            dept2.Parent = picDept;
            dept3.Parent = picDept;

            job1.Parent = picJob;
            job2.Parent = picJob;
            job3.Parent = picJob;

            name1.Parent = picName;
            name2.Parent = picName;
            name3.Parent = picName;

            logo.Parent = pictureBox1;
            lblAward.Parent = pictureBox1;
            lblLuckyList.Parent = pictureBox1;
            lblNextAward.Parent = pictureBox1;
            lblLuckyListTitle.Parent = pictureBox1;
            lblByPass.Parent = pictureBox1;
        }

        private int awardQty = 0;
        private string awardId;
        private string finalEmpId;
        private string finalName;
        private string finalJob;
        private string finalDept;
        private const string SCROLL1 = "pic\\scroll_area_01.png";
        private const string SCROLL2 = "pic\\scroll_area_02.png";
        private const string SCROLL3 = "pic\\scroll_area_03.png";
        private int deptSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["Dept_Speed"]);
        private int jobSpeed =  Convert.ToInt32(ConfigurationManager.AppSettings["Job_Speed"]);
        private int nameSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["Name_Speed"]);
        private int massageSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["Message_Speed"]);

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
        public int totalTime = 0;

        private bool isWndMove;
        private int curr_x;
        private int curr_y;


        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TransparencyKey = Color.Red;             //设置默认透明色
            //this.BackColor = this.TransparencyKey;          //设置当前窗体的背景色为透明
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框

            this.pictureBox1.SendToBack();//将背景图片放到最下面
            this.panel1.BackColor = Color.Transparent;//将Panel设为透明
            //this.panel1.Parent = this.pictureBox1;//将panel父控件设为背景图片控件
            this.panel1.BringToFront();//将panel放在前面

            //this.WindowState = FormWindowState.Normal;

            try
            {
                SetAwardLbl();
                SetLuckyLbl();
                SetDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("處理中請稍後!", ex.Message);
            }




        }

        public List<T> RandomSortList<T>(IEnumerable<T> ListT)
        {

            Random random = new Random(DateTime.Now.Second);
            List<T> newList = new List<T>();
            foreach (T item in ListT)
            {
                newList.Insert(random.Next(newList.Count), item);
            }
            return newList;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckAwardEnd())
                {
                    MessageBox.Show("該獎項已經無任何名額!!");
                    return;
                }

                #region 動態拉霸
                DownBar.BringToFront();
                this.Refresh();
                System.Threading.Thread.Sleep(300);
                UpBar.BringToFront();
                this.Refresh();
                #endregion

                using (SQLiteConnection cn = Conn.ConnDB())
                {
                    string queryScript = "SELECT * FROM employee where enable=1";
                    var list = cn.Query<EmployeeModel>(queryScript, new DynamicParameters());
                    list.ToList();

                    Random rnd = new Random(DateTime.Now.Second);
                    var sequence = Enumerable.Range(1, list.Count()).OrderBy(n => rnd.Next());
                    var bingo = sequence.ToList().First();
                    var x = 0;
                    var y = 0;
                    var z = 0;
                    List<EmployeeModel> rndList = RandomSortList<EmployeeModel>(list);

                    dept1.Text = rndList.ElementAt(bingo).department;
                    dept2.Text = rndList.ElementAt(bingo + 1).department;
                    dept3.Text = rndList.ElementAt(bingo + 2).department;

                    job1.Text = rndList.ElementAt(bingo).job;
                    job2.Text = rndList.ElementAt(bingo + 1).job;
                    job3.Text = rndList.ElementAt(bingo + 2).job;

                    name1.Text = rndList.ElementAt(bingo).name;
                    name2.Text = rndList.ElementAt(bingo + 1).name;
                    name3.Text = rndList.ElementAt(bingo + 2).name;

                    string tempDeptUp = dept2.Text;
                    string tempDeptDown = dept3.Text;

                    string tempJobUp = job2.Text;
                    string tempJobDown = job3.Text;

                    string tempNameUp = name2.Text;
                    string tempNameDown = name3.Text;

                    foreach (EmployeeModel str in rndList)
                    {
                        if (x < deptSpeed)
                        {
                            this.picDept.Image = Image.FromFile(SCROLL1);
                            this.picJob.Image = Image.FromFile(SCROLL1);
                            this.picName.Image = Image.FromFile(SCROLL1);
                            this.panel2.Refresh();
                            this.panel3.Refresh();
                            this.panel4.Refresh();
                            this.picDept.Image = Image.FromFile(SCROLL2);
                            this.picJob.Image = Image.FromFile(SCROLL2);
                            this.picName.Image = Image.FromFile(SCROLL2);
                            this.panel2.Refresh();
                            this.panel3.Refresh();
                            this.panel4.Refresh();
                            this.picDept.Image = Image.FromFile(SCROLL3);
                            this.picJob.Image = Image.FromFile(SCROLL3);
                            this.picName.Image = Image.FromFile(SCROLL3);
                            this.panel2.Refresh();
                            this.panel3.Refresh();
                            this.panel4.Refresh();

                            dept1.Text = tempDeptUp;
                            dept2.Text = str.department;
                            dept3.Text = tempDeptDown;

                            job1.Text = tempJobUp;
                            job2.Text = str.job;
                            job3.Text = tempJobDown;

                            name1.Text = tempNameUp;
                            name2.Text = str.name;
                            name3.Text = tempNameDown;

                            tempDeptUp = dept3.Text;
                            tempDeptDown = dept2.Text;

                            tempJobUp = job3.Text;
                            tempJobDown = job2.Text;

                            tempNameUp = name3.Text;
                            tempNameDown = name2.Text;

                            dept1.Location = new Point(dept1.Location.X, dept1.Location.Y - 20);
                            dept2.Location = new Point(dept2.Location.X, dept2.Location.Y - 20);
                            dept3.Location = new Point(dept3.Location.X, dept3.Location.Y - 20);

                            job1.Location = new Point(job1.Location.X, job1.Location.Y - 20);
                            job2.Location = new Point(job2.Location.X, job2.Location.Y - 20);
                            job3.Location = new Point(job3.Location.X, job3.Location.Y - 20);

                            name1.Location = new Point(name1.Location.X, name1.Location.Y - 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y - 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y - 20);

                            this.picDept.Refresh();
                            this.picJob.Refresh();
                            this.picName.Refresh();

                            if (x == deptSpeed - 1)
                            {

                                this.picDept.Image = Image.FromFile(SCROLL1);
                                this.panel2.Refresh();
                            }

                            x++;

                            dept1.Location = new Point(dept1.Location.X, dept1.Location.Y + 20);
                            dept2.Location = new Point(dept2.Location.X, dept2.Location.Y + 20);
                            dept3.Location = new Point(dept3.Location.X, dept3.Location.Y + 20);

                            job1.Location = new Point(job1.Location.X, job1.Location.Y + 20);
                            job2.Location = new Point(job2.Location.X, job2.Location.Y + 20);
                            job3.Location = new Point(job3.Location.X, job3.Location.Y + 20);

                            name1.Location = new Point(name1.Location.X, name1.Location.Y + 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y + 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y + 20);

                            finalEmpId = str.id;
                            finalDept = str.department;
                            finalJob = str.job;
                            finalName = str.name;

                            this.picDept.Refresh();
                            this.picJob.Refresh();
                            this.picName.Refresh();
                        }


                        if (y < jobSpeed)
                        {
                            this.picJob.Image = Image.FromFile(SCROLL1);
                            this.picName.Image = Image.FromFile(SCROLL1);
                            this.panel3.Refresh();
                            this.panel4.Refresh();

                            this.picJob.Image = Image.FromFile(SCROLL2);
                            this.picName.Image = Image.FromFile(SCROLL2);
                            this.panel3.Refresh();
                            this.panel4.Refresh();

                            this.picJob.Image = Image.FromFile(SCROLL3);
                            this.picName.Image = Image.FromFile(SCROLL3);
                            this.panel3.Refresh();
                            this.panel4.Refresh();

                            job1.Text = tempJobUp;
                            job2.Text = str.job;
                            job3.Text = tempJobDown;

                            name1.Text = tempNameUp;
                            name2.Text = str.name;
                            name3.Text = tempNameDown;

                            tempJobUp = job3.Text;
                            tempJobDown = job2.Text;

                            tempNameUp = name3.Text;
                            tempNameDown = name2.Text;

                            job1.Location = new Point(job1.Location.X, job1.Location.Y - 20);
                            job2.Location = new Point(job2.Location.X, job2.Location.Y - 20);
                            job3.Location = new Point(job3.Location.X, job3.Location.Y - 20);

                            name1.Location = new Point(name1.Location.X, name1.Location.Y - 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y - 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y - 20);

                            this.picJob.Refresh();
                            this.picName.Refresh();

                            if (y == jobSpeed - 1)
                            {
                                job2.Text = finalJob;
                                this.picJob.Image = Image.FromFile(SCROLL1);
                                this.panel3.Refresh();
                            }

                            y++;

                            job1.Location = new Point(job1.Location.X, job1.Location.Y + 20);
                            job2.Location = new Point(job2.Location.X, job2.Location.Y + 20);
                            job3.Location = new Point(job3.Location.X, job3.Location.Y + 20);

                            name1.Location = new Point(name1.Location.X, name1.Location.Y + 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y + 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y + 20);

                            this.picJob.Refresh();
                            this.picName.Refresh();
                        }

                        if (z < nameSpeed)
                        {
                            this.picName.Image = Image.FromFile(SCROLL1);
                            this.panel4.Refresh();

                            this.picName.Image = Image.FromFile(SCROLL2);
                            this.panel4.Refresh();

                            this.picName.Image = Image.FromFile(SCROLL3);
                            this.panel4.Refresh();

                            name1.Text = tempNameUp;
                            name2.Text = str.name;
                            name3.Text = tempNameDown;

                            tempNameUp = name3.Text;
                            tempNameDown = name2.Text;

                            name1.Location = new Point(name1.Location.X, name1.Location.Y - 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y - 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y - 20);

                            this.picName.Refresh();

                            if (z == nameSpeed - 1)
                            {
                                name2.Text = finalName;
                                this.picName.Image = Image.FromFile(SCROLL1);
                                this.panel4.Refresh();
                            }

                            z++;

                            name1.Location = new Point(name1.Location.X, name1.Location.Y + 20);
                            name2.Location = new Point(name2.Location.X, name2.Location.Y + 20);
                            name3.Location = new Point(name3.Location.X, name3.Location.Y + 20);

                            this.picName.Refresh();
                        }
                    }

                    //luckyList
                    LuckyListModel luckyList = new LuckyListModel();
                    luckyList.empId = finalEmpId;
                    luckyList.name = finalName;
                    luckyList.department = finalDept;
                    luckyList.job = finalJob;
                    luckyList.award = lblAward.Text;
                    luckyList.updateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

                    employeeService.DisableEmployee(finalEmpId);
                    InsertLuckyList(luckyList);

                    awardService.UpdateAwardQty(awardId);
                    awardService.DisableAwardForSingleLottery(awardId);
                    SetLuckyLbl();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("處理中請稍後!", ex.Message);
            }


            StartKiller();
            MessageBox.Show("抽獎完成!!!!!!", "Done");

        }

        private void StartKiller()
        {
            Timer timer = new Timer();
            timer.Interval = massageSpeed; //3秒啟動
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((Timer)sender).Stop();
        }

        private void KillMessageBox()
        {
            //按照MessageBox的標題，找到MessageBox的視窗
            IntPtr ptr = FindWindow(null, "MessageBox");
            if (ptr != IntPtr.Zero)
            {
                //找到則關閉MessageBox視窗
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }

        private List<AwardModel> GetAward()
        {
            List<AwardModel> awards = null;
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                string queryScript = "SELECT * FROM award WHERE seq<>0 and status=1 ORDER BY seq";
                var output = cn.Query<AwardModel>(queryScript);
                awards = output.ToList();
            }
            return awards;
        }

        private void SetAwardLbl()
        {
            if(this.GetAward().Count != 0)
            {
                List<AwardModel> awards = this.GetAward();
                lblAward.Text = awards.ElementAt(0).name;
                awardQty = Convert.ToInt32(awards.ElementAt(0).qty);
                awardId = awards.ElementAt(0).id;
            }
            else
            {
                MessageBox.Show("獎項全部抽完!!!!!!", "Done");
            }

        }

        private void InsertLuckyList(LuckyListModel luckyList)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (var trans = cn.BeginTransaction())
                {
                    string insertScript = "INSERT INTO lucky_list (empId, name, department, job, award, updateTime) VALUES (@empId, @name, @department, @job, @award, @updateTime)";
                    cn.Execute(insertScript, luckyList, trans);
                    trans.Commit();
                }
            }

        }

        private void SetLuckyLbl()
        {
            List<LuckyListModel> luckyLists= luckyListService.GetLuckyList(lblAward.Text);
            string luckys = string.Empty;
            int count = 1;
            foreach (LuckyListModel val in luckyLists)
            {
                string line = (count % 5)==0?"\r\n":"";
                luckys = ((count % 5) == 0 && count > 60? luckys: luckys + "   ") +  val.name + (count==1?"": line);
                if ((count % 10) == 1 && count > 10) luckys = "   " + val.name;
                count++;

            }
            lblLuckyList.Text = luckys;
        }

        private void lblNextAward_Click(object sender, EventArgs e)
        {
            if (CheckGameEnd())
            {
                MessageBox.Show("抽獎已完成，已無任何獎項!!");
                return;
            }


            SetAwardLbl();
            lblLuckyList.Text = "";
            SetLuckyLbl();
        }

        private bool CheckAwardEnd()
        {
            bool result = false;

            AwardModel award = new AwardModel();
            award.id = awardId;

            List<AwardModel> awards = null;
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                string queryScript = "SELECT * FROM award WHERE id=@id and status=1 ORDER BY seq";
                var output = cn.Query<AwardModel>(queryScript, award);
                awards = output.ToList();
            }

            if (awards.Count > 0) result = true;

            return result;
        }

        private bool CheckGameEnd()
        {
            bool result = false;

            List<AwardModel> awards = null;
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                string queryScript = "SELECT * FROM award WHERE status=1 ";
                var output = cn.Query<AwardModel>(queryScript);
                awards = output.ToList();
            }

            if (awards.Count == 1) result = true;

            return result;
        }

        private void SetDefault()
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                string queryScript = "SELECT * FROM employee where enable=1";
                var list = cn.Query<EmployeeModel>(queryScript, new DynamicParameters());
                list.ToList();

                Random rnd = new Random(DateTime.Now.Second);
                var sequence = Enumerable.Range(1, list.Count()).OrderBy(n => rnd.Next());
                var bingo = sequence.ToList().First();
                List<EmployeeModel> rndList = RandomSortList<EmployeeModel>(list);

                dept1.Text = rndList.ElementAt(bingo).department;
                dept2.Text = rndList.ElementAt(bingo + 1).department;
                dept3.Text = rndList.ElementAt(bingo + 2).department;

                job1.Text = rndList.ElementAt(bingo).job;
                job2.Text = rndList.ElementAt(bingo + 1).job;
                job3.Text = rndList.ElementAt(bingo + 2).job;

                name1.Text = rndList.ElementAt(bingo).name;
                name2.Text = rndList.ElementAt(bingo + 1).name;
                name3.Text = rndList.ElementAt(bingo + 2).name;
            }
        }

        private void lblByPass_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.curr_x = e.X;
                this.curr_y = e.Y;
                this.isWndMove = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isWndMove)
                this.Location = new Point(this.Left + e.X - this.curr_x, this.Top + e.Y - this.curr_y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isWndMove = false;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox2_Click(sender, e);
            }

        }

        private void lblByPass_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                LuckyListModel luckyList = new LuckyListModel();
                luckyList.empId = finalEmpId;

                AwardModel awardModel = new AwardModel();
                awardModel.id = awardId;

                using (SQLiteConnection cn = Conn.ConnDB())
                {
                    string queryScript = "SELECT * FROM lucky_list WHERE empid=@empId and award='X'";
                    var output = cn.Query<LuckyListModel>(queryScript, luckyList);
                    List<LuckyListModel> temp = output.ToList();

                    if (temp.Count == 0)
                    {
                        using (var trans2 = cn.BeginTransaction())
                        {
                            string updateScript2 = " UPDATE award SET new_qty=new_qty-1, status=1 WHERE id=@id; ";
                            cn.Execute(updateScript2, awardModel, trans2);
                            trans2.Commit();
                        }
                    }

                    using (var trans = cn.BeginTransaction())
                    {
                        string updateScript = " UPDATE lucky_list SET award='X' WHERE empid=@empId;";
                        cn.Execute(updateScript, luckyList, trans);
                        trans.Commit();
                    }


                }
                SetLuckyLbl();
            }


        }
    }
 }
