using ATEN_Util;
using ATEN_Util.Service;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AREN_Lottery_UI
{
    public partial class ATEN_Lottery_Mod : Form
    {
        private LotteryProcess lotteryProcess = new LotteryProcess();
        private EmployeeModel currentWinner;
        private List<string> winnerNames;
        private float fWidth; //視窗大小 寬
        private float fHeight;//視窗大小 高
        bool isLoaded;  // 是否已設定各控制的尺寸資料到Tag屬性
        private int GIF_WAIT_MILLISECONDS; //Gif顯示時間
        private int NUMBER_OF_WINNER; //得獎人每列人數
        private int FontSize_OF_WINNER; //得獎人清單字型大小
        private readonly HashSet<Keys> NEXT_AWARD_KEYS = new HashSet<Keys>();// Hit these buttons and get next member for the same award.

        public ATEN_Lottery_Mod()
        {
            InitializeComponent();
            try
            {
                isLoaded = false;
                fWidth = this.Width;//獲取窗體的寬度
                fHeight = this.Height;//獲取窗體的高度
                BasicSet();//設定抽獎基本參數
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ATEN_Lottery_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                SetTag(this);
                isLoaded = true;// 已設定各控制項的尺寸到Tag屬性中
                MaxScreen();
                ChangeSize();
                pbx_Star.Visible = false;
                lblWinnerName.Hide();
                lblLuckyList.Hide();
                lotteryProcess.ValidatePreRequirements();//設定獎項清單
                lblAward.Text = lotteryProcess.AwardList[0].name;//取得獎項名稱
                winnerNames = lotteryProcess.RecoverWinnerNameList(lotteryProcess.AwardList[0]);//取得得獎名單
                FillLuckyListLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ATEN_Lottery_Mod_KeyDown(object sender, KeyEventArgs e)
        {
            if (!bkw_gif.IsBusy)//避免多按
            {
                try
                {
                    if (NEXT_AWARD_KEYS.Contains(e.KeyCode))//開始抽獎
                    {
                        if (lotteryProcess.AwardList[0].IsAvailable())
                        {
                            pbx_Star.Visible = true;
                            lblWinnerName.Text = string.Empty;
                            //return;
                            bkw_gif.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("該獎項已經無任何名額!!");
                        }
                    }
                    else if (e.Alt && e.Control && e.KeyCode == Keys.D)//移除缺席人員
                    {
                        DisableAbsentEmployee();
                    }
                    else if (e.Alt && e.Control && e.KeyCode == Keys.N)
                    {
                        NextAward();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void bkw_gif_DoWork(object sender, DoWorkEventArgs e)
        {
            currentWinner = lotteryProcess.GetOneWinner(lotteryProcess.AwardList[0]);
            Thread.Sleep(GIF_WAIT_MILLISECONDS);
        }

        private void bkw_gif_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblWinnerName.Show();
            pbx_Star.Visible = false;
            FillCurrentWinner();
            winnerNames.Add(currentWinner.name);
            FillLuckyListLabel();
        }

        /// <summary>
        /// 調整視窗大小
        /// </summary>
        private void ChangeSize()
        {
            float fX;
            float fY;
            fX = this.Size.Width / fWidth;
            fY = this.Size.Height / fHeight;
            //控制項相對位置
            SetControls(fX, fY, this);
            SetTag(this);
            fWidth = this.Size.Width;
            fHeight = this.Size.Height;
        }

        /// <summary>
        /// 將控制項的寬，高，左邊距，頂邊距和字體大小暫存到tag屬性中
        /// </summary>
        /// <param name="cons">遞歸控制項中的控制項</param>
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }

        /// <summary>
        /// 控制項重新設定位置、大小
        /// </summary>
        /// <param name="Xr">寬的放大縮小率</param>
        /// <param name="Yr">高的放大縮小率</param>
        /// <param name="cons">From視窗</param>
        private void SetControls(float Xr, float Yr, Control cons)
        {
            if (isLoaded)
            {
                //遍歷窗體中的控制項，重新設置控制項的值
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//獲取控制項的Tag屬性值，並分割後存儲字元串數組
                    double dW = Convert.ToDouble(mytag[0]);
                    double dH = Convert.ToDouble(mytag[1]);
                    double dL = Convert.ToDouble(mytag[2]);
                    double dT = Convert.ToDouble(mytag[3]);
                    double dF = Convert.ToDouble(mytag[4]);
                    con.Width = (int)(dW * Xr);
                    con.Height = (int)(dH * Yr);
                    con.Left = (int)(dL * Xr);
                    con.Top = (int)(dT * Yr);
                    Single currentSize = System.Convert.ToSingle(dF) * Yr;//字體大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(Xr, Yr, con);
                    }
                }
                SetTag(this);
            }
        }

        /// <summary>
        /// 基本設定
        /// </summary>
        private void BasicSet()
        {
            //設定背景
            string path = Application.StartupPath;
            Image imgBg = new Bitmap(path + "\\bg.gif");
            this.BackgroundImage = imgBg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //設定特效
            Image imgEf = new Bitmap(path + "\\effect.gif");
            pbx_Star.Image = imgEf;

            //取得Gif顯示時間
            string gifWaitMilliseconds = ConfigurationManager.AppSettings["GifWaitMilliseconds"];
            GIF_WAIT_MILLISECONDS = string.IsNullOrEmpty(gifWaitMilliseconds) ? 3000 : Convert.ToInt32(gifWaitMilliseconds);
            
            //取得得獎人員人數顯示
            string numOfWin= ConfigurationManager.AppSettings["NumberOfWinner"];
            NUMBER_OF_WINNER= string.IsNullOrEmpty(numOfWin) ? 5 : Convert.ToInt32(numOfWin);

            //得獎人清單字型大小
            string strFontSizeOfWin= ConfigurationManager.AppSettings["FontSizeOfWinner"];
            FontSize_OF_WINNER = string.IsNullOrEmpty(strFontSizeOfWin) ? 16 : Convert.ToInt32(strFontSizeOfWin);
            Font f = new Font("標楷體", FontSize_OF_WINNER, FontStyle.Bold);
            lblLuckyList.Font = f;

            //取得熱鍵設定
            KeysConverter keysConverter = new KeysConverter();
            string SpinKey = string.IsNullOrEmpty(ConfigurationManager.AppSettings["SpinKey"]) ? "Enter" : ConfigurationManager.AppSettings["SpinKey"];
            foreach (string key in ConfigurationManager.AppSettings["SpinKey"].Split(','))
            {
                NEXT_AWARD_KEYS.Add((Keys)keysConverter.ConvertFromString(key)); ;
            }
        }

        /// <summary>
        /// 全螢幕
        /// </summary>
        private void MaxScreen()
        {
            //全螢幕
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }

        /// <summary>
        /// 顯示得獎人員
        /// </summary>
        private void FillCurrentWinner()
        {
            if (currentWinner != null)
            {
                lblWinnerName.Text = new StringBuilder()
                    .Append(currentWinner.department) //部門
                    .AppendLine()
                    .Append(currentWinner.job) //職級
                    .AppendLine()
                    .Append(currentWinner.name) //名子
                    .ToString();

                //lblWinnerName.Show();
            }
            else
            {
                lblWinnerName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 填入得獎名單
        /// </summary>
        private void FillLuckyListLabel()
        {
            StringBuilder builder = new StringBuilder();
            if (winnerNames.Count > 0)
            {
                for (int i = 0; i < winnerNames.Count; i++)
                {
                    if (i != 0 && i % NUMBER_OF_WINNER == 0)
                    {
                        builder.AppendLine();
                    }
                    builder.AppendFormat("[{0}]{1} ", i + 1, winnerNames[i]);
                }
            }
            lblLuckyList.Text = builder.ToString();
            lblLuckyList.Show();
        }

        /// <summary>
        /// 移除缺席員工
        /// </summary>
        private void DisableAbsentEmployee()
        {
            // we will confirm if the employee is presented then continue the lottery.
            // if that employee is absent, only revoke that employee and stop.
            if (currentWinner == null)
            {
                MessageBox.Show("已移除缺席員工");
            }
            else
            {
                lotteryProcess.RevokeWinner(lotteryProcess.AwardList[0], currentWinner);
                winnerNames.Remove(currentWinner.name);
                currentWinner = null;
                //lblWinnerName.Hide();
                lblWinnerName.Text = string.Empty;
                FillLuckyListLabel();
            }
        }

        /// <summary>
        /// 進入項下一獎項
        /// </summary>
        private void NextAward()
        {
            if (lotteryProcess.AwardList[0].IsAvailable())
            {
                MessageBox.Show("獎項尚未抽完");
            }
            else if (lotteryProcess.AwardList.Count == 1)
            {
                MessageBox.Show("抽獎已完成，已無任何獎項!!");
            }
            else
            {
                // clear winners
                currentWinner = null;
                winnerNames.Clear();
                lblWinnerName.Text = string.Empty;
                lblLuckyList.Text = string.Empty;

                // change award
                lotteryProcess.AwardList.RemoveAt(0);
                lblAward.Text = lotteryProcess.AwardList[0].name;
            }
        }
    }
}
