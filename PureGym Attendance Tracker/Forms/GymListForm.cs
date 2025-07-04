using PureGym_Attendance_Tracker.Controls;
using PureGym_Attendance_Tracker.Models;

namespace PureGym_Attendance_Tracker.Forms
{
    public partial class GymListForm : Form
    {
        Form MasterForm { get; set; }
        public GymListForm(Form master)
        {
            InitializeComponent();
            MasterForm = master;
            FetchGyms();
        }

        private async void FetchGyms()
        {
            Gym? homeGym = await Program.API.GetHomeGym();
            List<Gym>? otherGyms = await Program.API.GetGymList();
            if (homeGym is null || otherGyms is null)
                return;
            FillGymLayout(homeGym, otherGyms.Where(gym => gym.ID != homeGym.ID).ToList());
        }

        private void FillGymLayout(Gym homeGym, List<Gym> otherGyms)
        {
            GymRow homeRow = new();
            homeRow.Invalidate();
            homeRow.SetGym(homeGym);
            homeRow.AssignParent(flowLayoutPanel1);
            flowLayoutPanel2.SuspendLayout();
            foreach (var gym in otherGyms)
            {
                GymRow otherRow = new();
                otherRow.Invalidate();
                otherRow.SetGym(gym);
                otherRow.AssignParent(flowLayoutPanel2);
            }
            flowLayoutPanel2.ResumeLayout();
        }

        private void GymListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MasterForm.Close();
        }
    }
}
