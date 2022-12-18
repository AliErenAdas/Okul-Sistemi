using Microsoft.AspNetCore.Mvc;
using Odev.Data;
using Odev.Models;

namespace Odev.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;
        public StudentController(SchoolDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<Student> studentList = _context.Set<Student>().ToList();
            return View(studentList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Set<Student>().Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Student student = _context.Set<Student>().FirstOrDefault(i => i.Id== id);
            _context.Set<Student>().Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Student student = _context.Set<Student>().FirstOrDefault(i => i.Id==id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            Student updatedStudent = _context.Set<Student>().FirstOrDefault();
            updatedStudent.FirstName=student.FirstName;
            updatedStudent.LastName=student.LastName;
            updatedStudent.IDNumber=student.IDNumber;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
