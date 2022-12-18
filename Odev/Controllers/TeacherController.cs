using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;
using Odev.Data;
using Odev.Models;
using Odev.ViewModels;

namespace Odev.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolDbContext _context;
        public TeacherController(SchoolDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<TeacherIndex> TeacherList = _context.Set<Teacher>().Select(x => new TeacherIndex
            {
                TeacherID=x.Id,
                Name=x.Name,
                SchoolName=x.School.Name,
                CourseCount=x.Courses.Count
            }).ToList();
            return View(TeacherList);
        }
        public IActionResult Create()
        {
            ViewData["SchoolList"] = new SelectList(_context.Set<School>(), "Id", "Name");
            ViewBag.CourseList = new SelectList(_context.Set<Course>(), "Id", "Name");
            return View(new TeacherCreate());
        }

        [HttpPost]
        public IActionResult Create(TeacherCreate teacher)
        {

            if (ModelState.IsValid)
            {
                Teacher teacher1 = new Teacher()
                {
                    Name = teacher.Name,
                    SchoolID= teacher.SchoolID,
                };
                teacher1.Courses.Add(_context.Courses.FirstOrDefault(x => x.Id==teacher.CourseID));
                _context.Teachers.Add(teacher1);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewData["SchoolList"] = new SelectList(_context.Set<School>(), "Id", "Name");
            ViewBag.CourseList = new SelectList(_context.Set<Course>(), "Id", "Name");
            return View(teacher);
        }

        public IActionResult Delete(int id)
        {
            Teacher Teacher = _context.Set<Teacher>().FirstOrDefault(i => i.Id== id);
            _context.Set<Teacher>().Remove(Teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(string Name)
        {
            TeacherDetail teacherDetail = _context.Set<Teacher>().Select(x=> new TeacherDetail{
                Name = x.Name,
            }).FirstOrDefault(i => i.Name==Name);
            ViewData["SchoolList"] = new SelectList(_context.Set<School>(), "Id", "Name");
            ViewBag.CourseList = new SelectList(_context.Set<Course>(), "Id", "Name");
            return View(teacherDetail);
        }
        [HttpPost]
        public IActionResult Update(TeacherCreate teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher updatedTeacher = _context.Set<Teacher>().FirstOrDefault();
                Teacher teacher1 = new Teacher()
                {
                    Name = teacher.Name,
                    SchoolID= teacher.SchoolID,
                };
                teacher1.Courses.Add(_context.Courses.FirstOrDefault(x => x.Id==teacher.CourseID));
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchoolList"] = new SelectList(_context.Set<School>(), "Id", "Name");
            ViewBag.CourseList = new SelectList(_context.Set<Course>(), "Id", "Name");
            return View(teacher);
        }
    }
}
