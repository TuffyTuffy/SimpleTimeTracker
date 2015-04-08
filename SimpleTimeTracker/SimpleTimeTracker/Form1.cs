using System;
using System.Diagnostics;
using System.Windows.Forms;
using SimpleTimeTracker.Entities;
using SimpleTimeTracker.Helpers;

namespace SimpleTimeTracker
{
    public partial class Form1 : Form
    {
        private SessionInfo _session;
        private CustomTimer _timer;

        private const int CKeyI = 1;

        public Form1()
        {
            InitializeComponent();

            _session = new SessionInfo();
            _timer = new CustomTimer();
            _timer.OnTick += RefreshTimer;
            _timer.OnStateChanged += OnStateChanged;

            // Register the global hot key
            KeyManagement.RegisterHotKey(this.Handle, CKeyI, 6, (int)Keys.Z);
        }

        private void OnStateChanged(CustomTimer.TimerState timerState)
        {
            switch (timerState)
            {
                case CustomTimer.TimerState.Stopped:
                    textBoxWork.Clear();
                    textBoxWork.Enabled = true;
                    textBoxWork.Focus();
                    buttonActions.Enabled = false;
                    _session.Duration = _timer.Elapsed;
                    GlobalFactory.SessionLogProvider.Log(_session);
                    break;
                case CustomTimer.TimerState.Running:
                    buttonActions.Enabled = true;
                    textBoxWork.Enabled = false;
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == CKeyI)
            {
                ToggleVisibility();
            }

            base.WndProc(ref m);
        }

        private void ToggleVisibility()
        {
            if (Visible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void RefreshTimer(TimeSpan elapsed)
        {
            labelTime.Text = string.Format("{0}h:{1}m:{2}s", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);  
        }

        private void ClearTimer()
        {
            labelTime.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLabels();
            ClearTimer();
        }

        private void LoadLabels()
        {
            comboBoxLabel.DataSource = GlobalFactory.ConfigProvider.GetLabels();
        }

        private void SelectPosition(int position)
        {
            if (comboBoxLabel.Items.Count > position)
            {
                comboBoxLabel.SelectedIndex = position;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Focus on the text field
            textBoxWork.Focus();
        }

        private void ShowActions()
        {
            var actionForm = new ActionForm();
            actionForm.ShowDialog();

            switch (actionForm.ActionStateValue)
            {
                case ActionForm.ActionState.Stop:
                    _timer.Stop();
                    break;
                case ActionForm.ActionState.Continue:
                    _timer.Resume();
                    break;
                case ActionForm.ActionState.Minimize:
                    ToggleVisibility();
                    break;
                case ActionForm.ActionState.Interruption:
                    _session.Interruptions++;
                    _timer.Pause();
                    break;
            }
        }

        private void Start()
        {
            _session = new SessionInfo {Comment = textBoxWork.Text, StartDate = DateTime.Now, Label = comboBoxLabel.SelectedValue.ToString()};
            _timer.ReStart();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ToggleVisibility();
        }

        private void textBoxWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_timer.State == CustomTimer.TimerState.Running)
                {
                    ShowActions();
                }
                else
                {
                    Start();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: SelectPosition(0); break;
                case Keys.F2: SelectPosition(1); break;
                case Keys.F3: SelectPosition(2); break;
                case Keys.F4: SelectPosition(3); break;
                case Keys.F5: SelectPosition(4); break;
                case Keys.F6: SelectPosition(5); break;
                case Keys.F7: SelectPosition(6); break;
                case Keys.F8: SelectPosition(7); break;
                case Keys.F9: SelectPosition(8); break;
                case Keys.F10: SelectPosition(9); break;
                case Keys.F11: SelectPosition(10); break;
                case Keys.F12: SelectPosition(11); break;
                case Keys.A:
                    if (_timer.State == CustomTimer.TimerState.Running)
                    {
                        ShowActions();
                    }
                    break;
            }
        }

        private void buttonActions_Click(object sender, EventArgs e)
        {
            ShowActions();
        }
    }
}
