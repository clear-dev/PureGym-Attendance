namespace PureGym_Attendance_Tracker.Models
{
    public class Gym
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Attendees { get; set; }
        public Gym(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
