using PureGym_Attendance_Tracker.Forms;

namespace PureGym_Attendance_Tracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            string inputEmail = emailTextBox.Text;
            string inputPin = pinTextBox.Text;
            if (inputEmail.Length <= 1 || inputPin.Length <= 1)
                SetNotifyLabel("Please enter an email and pin");
            if (!await Program.API.Login(inputEmail, inputPin))
                SetNotifyLabel("Failed to login!");
            else
            {
                Hide();
                GymListForm gymForm = new(this);
                gymForm.Show();
            }

        }

        private void SetNotifyLabel(string notificationText)
        {
            notifyLabel.Text = notificationText;
            notifyLabel.Visible = true;
        }
    }
}
