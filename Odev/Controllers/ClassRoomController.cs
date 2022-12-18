using Microsoft.AspNetCore.Mvc;
using Odev.Data;
using Odev.Models;

namespace Odev.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly SchoolDbContext _context;
        public ClassRoomController(SchoolDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<ClassRoom> classroomList = _context.Set<ClassRoom>().ToList();
            return View(classroomList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClassRoom classRoom)
        {
            _context.Set<ClassRoom>().Add(classRoom);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ClassRoom classRoom = _context.Set<ClassRoom>().FirstOrDefault(i => i.Id== id);
            _context.Set<ClassRoom>().Remove(classRoom);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            ClassRoom classRoom= _context.Set<ClassRoom>().FirstOrDefault(i=>i.Id==id);
            return View(classRoom);
        }
        [HttpPost]
        public IActionResult Update(ClassRoom classRoom)
        {
            ClassRoom updatedClassRoom = _context.Set<ClassRoom>().FirstOrDefault();
            updatedClassRoom.Name=classRoom.Name;
            updatedClassRoom.Capasity=classRoom.Capasity;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
