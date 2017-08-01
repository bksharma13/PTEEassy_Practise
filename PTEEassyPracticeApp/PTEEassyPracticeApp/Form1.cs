using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTEEassyPracticeApp
{
    public partial class Form1 : Form
    {
        private Stopwatch _timeKeeperStopwatch;
        public Form1()
        {
            InitializeComponent();
            TestTimer.Tick += new EventHandler(TestTimer_Tick);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblTimer.ForeColor = Color.Black;
            _timeKeeperStopwatch = Stopwatch.StartNew();
            lblTimer.Text = _timeKeeperStopwatch.Elapsed.ToString(@"mm\:ss");
            lblLength.Text = "0";
            txtBoxEassy.Text = string.Empty;
            TestTimer.Enabled = true;
            TestTimer.Interval = 1000;
            TestTimer.Start();
        }

        void TestTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timetaken = _timeKeeperStopwatch.Elapsed;
            lblTimer.Text = timetaken.ToString(@"mm\:ss");
            if (timetaken.TotalMinutes >= 20)
            {
                lblTimer.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxEassy.Text))
            {
                lblLength.Text = txtBoxEassy.Text.Split(' ').Length + "";
            }
            else
            {
                lblLength.Text = "0";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (TestTimer.Enabled)
            {
                _timeKeeperStopwatch.Stop();
                TestTimer.Stop();
                TestTimer.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxEassy.Text = string.Empty;
        }
    }
}
