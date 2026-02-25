using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0109.Controllers
{
    public class HomeController : Controller
    {
        // Renders the index and passes in all tasks
        public IActionResult Index()
        {
            var tasks = _context.Tasks
                .Where(x => x.Completed == false).ToList();
            return View(tasks);
        }

        // Gets called to allow the user to add a task
        [HttpGet] 
        public IActionResult AddEditTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddEditTask", new TaskItem());
        }


        [HttpPost]
        public IActionResult AddEditTask(TaskItem response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.addTask(response); // Add record to database
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
        }
        

        
    }
}
