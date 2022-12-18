using Microsoft.AspNetCore.Mvc;
using Odev.Data;
using Odev.Models;

namespace Odev.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolDbContext _context;
        public SchoolController(SchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<School> schoolList = _context.Set<School>().ToList();
            return View(schoolList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(School school)
        {
            _context.Set<School>().Add(school);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            School school = _context.Set<School>().FirstOrDefault(i => i.Id == id);
            _context.Set<School>().Remove(school);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            School school = _context.Set<School>().FirstOrDefault(i => i.Id == id);
            return View(school);
        }
        [HttpPost]
        public IActionResult Update(School school)
        {
            School updatedSchool = _context.Set<School>().FirstOrDefault(i => i.Id == school.Id);
            updatedSchool.Name=school.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
