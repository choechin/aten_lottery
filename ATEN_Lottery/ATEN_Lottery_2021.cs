using ATEN_Util;
using ATEN_Util.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ATEN_Lottery
{
    // Refer to the following links for GIF animation:
    // https://social.msdn.microsoft.com/Forums/en-US/a94b047c-e454-42c3-839b-08fad4ca8bec/stop-and-start-the-animation-of-a-animated-gif-image-using-mouse-events?forum=winforms
    // https://social.msdn.microsoft.com/Forums/windows/en-US/5bd7e5db-32bb-4bb4-912d-1b58ce2fe079/display-animated-gif-image-while-the-background-processing-happens?forum=winforms

    public partial class ATEN_Lottery_2021 : Form
    {
        private LotteryProcess lotteryProcess = new LotteryProcess();

        private EmployeeModel currentWinner;
        private List<string> winnerNames;

        // Hit these buttons and get next member for the same award.
        private readonly HashSet<Keys> NEXT_AWARD_KEYS = new HashSet<Keys>();

        // Whether the animation starts.
        private bool currentlyAnimating = false;

        // Indicate if update the animation.
        private bool isAnimating = false;

        private readonly int GIF_WAIT_MILLISECONDS;

        public ATEN_Lottery_2021()
        {
            InitializeComponent();

            // load spin keys
            KeysConverter keysConverter = new KeysConverter();
            foreach (string key in ConfigurationManager.AppSettings["SpinKey"].Split(','))
            {
                NEXT_AWARD_KEYS.Add((Keys)keysConverter.ConvertFromString(key)); ;
            }

            // load GIF waiting timeout value
            string gifWaitMilliseconds = ConfigurationManager.AppSettings["GifWaitMilliseconds"];
            GIF_WAIT_MILLISECONDS = string.IsNullOrEmpty(gifWaitMilliseconds) ? 3000 : int.Parse(gifWaitMilliseconds);

            // Enable double buffering to reduce flicker.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Enable paint via message to reduce flicker. 
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void ATEN_Lottery_2021_Load(object sender, EventArgs e)
        {
            try
            {
                lotteryProcess.ValidatePreRequirements();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                Close();
                return;
            }

            lblAward.Text = lotteryProcess.AwardList[0].name;

            // recover from crash or closed
            winnerNames = lotteryProcess.RecoverWinnerNameList(lotteryProcess.AwardList[0]);
            FillLuckyListLabel();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (isAnimating)
            {
                // Begin the animation.
                if (!currentlyAnimating)
                {
                    ImageAnimator.Animate(BackgroundImage, new EventHandler(OnFrameChanged));
                    currentlyAnimating = true;
                }

                // Update the frames. The cell would paint the next frame of the image late on.
                ImageAnimator.UpdateFrames();
            }

            base.OnPaintBackground(e);
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            // Force to redraw the form.
            Invalidate();
        }

        private void StartAnimation()
        {
            isAnimating = true;

            // Reset frame and force redraw the form.
            BackgroundImage.SelectActiveFrame(FrameDimension.Time, 0);
            Invalidate();

            ImageAnimator.Animate(BackgroundImage, new EventHandler(OnFrameChanged));
        }

        private void StopAnimation()
        {
            isAnimating = false;
            ImageAnimator.StopAnimate(BackgroundImage, new EventHandler(OnFrameChanged));
        }

        private void ATEN_Lottery_2021_KeyDown(object sender, KeyEventArgs e)
        {
            if (false == backgroundWorker.IsBusy)
            {
                if (e.Alt && e.Control && e.KeyCode == Keys.D)
                {
                    DisableAbsentEmployee();
                }
                else if (e.Alt && e.Control && e.KeyCode == Keys.N)
                {
                    NextAward();
                }
                else if (NEXT_AWARD_KEYS.Contains(e.KeyCode))
                {
                    if (false == lotteryProcess.AwardList[0].IsAvailable())
                    {
                        MessageBox.Show("該獎項已經無任何名額!!");
                    }
                    else
                    {
                        StartAnimation();
                        lblWinnerName.Hide();
                        backgroundWorker.RunWorkerAsync();
                    }
                }
            }
        }

        private void FillLuckyListLabel()
        {
            StringBuilder builder = new StringBuilder();

            if (winnerNames.Count > 0)
            {
                for (int i = 0; i < winnerNames.Count; i++)
                {
                    if (i != 0 && i % 6 == 0)
                    {
                        builder.AppendLine();
                    }

                    builder.AppendFormat("[{0}]{1} ", i + 1, winnerNames[i]);
                }
            }

            lblLuckyList.Text = builder.ToString();
            lblLuckyList.Show();
        }

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
                lblWinnerName.Hide();
                lblLuckyList.Hide();

                // change award
                lotteryProcess.AwardList.RemoveAt(0);
                lblAward.Text = lotteryProcess.AwardList[0].name;
            }
        }

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
                lblWinnerName.Hide();

                FillLuckyListLabel();
            }
        }

        private void FillCurrentWinner()
        {
            if (currentWinner != null)
            {
                lblWinnerName.Text = new StringBuilder()
                    .Append(currentWinner.department)
                    .AppendLine()
                    .Append(currentWinner.job)
                    .AppendLine()
                    .Append(currentWinner.name)
                    .ToString();

                lblWinnerName.Show();
            }
            else
            {
                lblWinnerName.Hide();
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(GIF_WAIT_MILLISECONDS);
            currentWinner = lotteryProcess.GetOneWinner(lotteryProcess.AwardList[0]);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            StopAnimation();
            FillCurrentWinner();
            winnerNames.Add(currentWinner.name);
            FillLuckyListLabel();
        }
    }
}
