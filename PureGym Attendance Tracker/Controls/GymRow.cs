using PureGym_Attendance_Tracker.Models;

namespace PureGym_Attendance_Tracker.Controls
{
    public class GymRow
    {
        private Panel pnl;
        private Label nameLabel;
        private Label activityLabel;
        private Button attendanceRequestButton;
        public GymRow()
        {
            pnl = new();
            nameLabel = new();
            activityLabel = new();
            attendanceRequestButton = new();
        }

        public void AssignParent(FlowLayoutPanel parent)
        {
            parent.Controls.Add(pnl);
            nameLabel.Parent = pnl;
            activityLabel.Parent = pnl;
            attendanceRequestButton.Parent = pnl;
        }

        public void Invalidate()
        {
            pnl.Size = new(200, 100);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            activityLabel.Dock = DockStyle.Right;
            activityLabel.TextAlign = ContentAlignment.MiddleCenter;

            nameLabel.Size = new(100, 0);
            nameLabel.Dock = DockStyle.Left;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;

            attendanceRequestButton.Dock = DockStyle.Bottom;
            attendanceRequestButton.Text = "Fetch Attendance";
            attendanceRequestButton.Click += AttendanceRequestButton_Click;
        }

        private async void AttendanceRequestButton_Click(object? sender, EventArgs e)
        {
            Button? btn = (Button?)sender;
            Gym? gym = (Gym?)btn!.Tag;
            if (btn is null || gym is null)
                return;
            int? attendees = await Program.API.GymAttendance(gym);
            if (attendees is null)
                return;
            gym.Attendees = (int)attendees;
            SetGym(gym);
        }

        public void SetGym(Gym gym)
        {
            attendanceRequestButton.Tag = gym;
            nameLabel.Text = gym.Name;
            activityLabel.Text = gym.Attendees == 0 ? "" : gym.Attendees.ToString();
        }
    }
}
