using Microsoft.AspNetCore.Mvc;
using Odev.Data;
using Odev.Models;

namespace Odev.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolDbContext _context;
        public CourseController(SchoolDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<Course> CourseList = _context.Set<Course>().ToList();
            return View(CourseList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course Course)
        {
            _context.Set<Course>().Add(Course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Course Course = _context.Set<Course>().FirstOrDefault(i => i.Id== id);
            _context.Set<Course>().Remove(Course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Course Course = _context.Set<Course>().FirstOrDefault(i => i.Id==id);
            return View(Course);
        }
        [HttpPost]
        public IActionResult Update(Course Course)
        {
            Course updatedCourse = _context.Set<Course>().FirstOrDefault();
            updatedCourse.Name=Course.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
