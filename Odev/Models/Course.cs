namespace Odev.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Course()
        {
            Teachers = new List<Teacher>();
        }
    }
}
