using System.Windows.Forms;

namespace SimpleTimeTracker
{
    public partial class ActionForm : Form
    {
        public ActionForm()
        {
            InitializeComponent();

            ActionStateValue = ActionState.None;
        }

        public enum ActionState
        {
            Stop,
            Continue,
            Minimize,
            Interruption,
            None
        }

        public ActionState ActionStateValue { get; set; }

        private void ActionForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    ActionStateValue = ActionState.Stop;
                    break;
                case Keys.C:
                    ActionStateValue = ActionState.Continue;
                    break;
                case Keys.M:
                    ActionStateValue = ActionState.Minimize;
                    break;
                case Keys.I:
                    ActionStateValue = ActionState.Interruption;
                    break;
            }

            Close();
        }

        private void labelStop_Click(object sender, System.EventArgs e)
        {
            ActionStateValue = ActionState.Stop;
            Close();
        }

        private void labelContinue_Click(object sender, System.EventArgs e)
        {
            ActionStateValue = ActionState.Continue;
            Close();
        }

        private void labelMinimize_Click(object sender, System.EventArgs e)
        {
            ActionStateValue = ActionState.Minimize;
            Close();
        }

        private void labelInterruption_Click(object sender, System.EventArgs e)
        {
            ActionStateValue = ActionState.Interruption;
            Close();
        }
    }
}
