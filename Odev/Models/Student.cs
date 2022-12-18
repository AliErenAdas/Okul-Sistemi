namespace Odev.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        //public int Age { get; set; }
        //public string Adress { get; set; }
        public string IDNumber { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public Student()
        {
            Lessons= new List<Lesson>();
        }
    }
}
