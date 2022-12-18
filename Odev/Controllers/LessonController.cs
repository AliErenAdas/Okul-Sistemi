using Microsoft.AspNetCore.Mvc;
using Odev.Data;
using Odev.Models;

namespace Odev.Controllers
{
    public class LessonController : Controller
    {
        private readonly SchoolDbContext _context;
        public LessonController(SchoolDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<Lesson> LessonList = _context.Set<Lesson>().ToList();
            return View(LessonList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lesson Lesson)
        {
            _context.Set<Lesson>().Add(Lesson);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Lesson Lesson = _context.Set<Lesson>().FirstOrDefault(i => i.ID== id);
            _context.Set<Lesson>().Remove(Lesson);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Lesson Lesson = _context.Set<Lesson>().FirstOrDefault(i => i.ID==id);
            return View(Lesson);
        }
        [HttpPost]
        public IActionResult Update(Lesson Lesson)
        {
            Lesson updatedLesson = _context.Set<Lesson>().FirstOrDefault();
            updatedLesson.Name=Lesson.Name;
            updatedLesson.TeacherId=Lesson.TeacherId;
            updatedLesson.ClassRoomId=Lesson.ClassRoomId;
            updatedLesson.SchoolID=Lesson.SchoolID;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
