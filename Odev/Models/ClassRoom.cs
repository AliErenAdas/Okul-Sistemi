namespace Odev.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capasity { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ClassRoom()
        {
            Lessons = new HashSet<Lesson>();
        }
    }
}
