using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
      private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var studentList = _context.Students.Include(s => s.Department).ToList();
            return View(studentList);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
                       
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _context.Departments.ToList();
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
          
        }


        public IActionResult Delete(int id)
        {
            ViewBag.Departments = _context.Departments.ToList();

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
