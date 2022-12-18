namespace Odev.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public ICollection<Student> Students { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }
        public Lesson()
        {
            Students = new HashSet<Student>();
        }
    }
}
