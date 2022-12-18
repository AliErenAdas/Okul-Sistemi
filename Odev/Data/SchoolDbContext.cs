using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Odev.Data.Config;
using Odev.Models;

namespace Odev.Data
{
    public class SchoolDbContext: DbContext
    {
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ClassRoom>(new ClassRoomConfig())
            .ApplyConfiguration<Course>(new CourseConfig())
            .ApplyConfiguration<Lesson>(new LessonConfig())
            .ApplyConfiguration<School>(new SchoolConfig())
            .ApplyConfiguration<Student>(new StudentConfig())
            .ApplyConfiguration<Teacher>(new TeacherConfig());
        }
        public SchoolDbContext(): base()
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-72MJDUFP;Database=Odev;Trusted_Connection=True");

        }


        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

}
