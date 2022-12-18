namespace Odev.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }
        public Teacher()
        {
            Courses = new HashSet<Course>();
            Lessons = new HashSet<Lesson>();
        }
    }
}
