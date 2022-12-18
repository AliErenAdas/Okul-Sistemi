namespace Odev.Models
{
    public class School
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassRoom> Classrooms { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Lesson> Lessons { get; set; }

        public School()
        {
            Classrooms = new HashSet<ClassRoom>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
            Lessons = new HashSet<Lesson>();
        }

    }
}
