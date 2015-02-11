using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Timer
{
    public partial class FormTimer : Form
    {
        public FormTimer()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormTimer_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void TimerCurrentDateTime_Tick(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            lblDate.Text = dt.ToString("dddd, MMMM dd, yyyy");
            lblTime.Text = dt.ToString("h:mm:ss tt");
        }

        #region Stopwatch

        private static bool _isStopwatchRunning;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (_isStopwatchRunning)
            {
                btnStartStop.Text = "Start";
                _stopwatch.Stop();
            }
            else
            {
                btnStartStop.Text = "Stop";
                _stopwatch.Start();
            }

            _isStopwatchRunning = !_isStopwatchRunning;
            timerStopwatch.Enabled = _isStopwatchRunning;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            _stopwatch.Reset();
            lblStopwatchOutput.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", _stopwatch.Elapsed);

            if (_isStopwatchRunning)
            {
                _stopwatch.Start();
            }
        }

        private void TimerStopwatch_Tick(object sender, EventArgs e)
        {
            lblStopwatchOutput.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", _stopwatch.Elapsed);
        }

        #endregion
    }
}
