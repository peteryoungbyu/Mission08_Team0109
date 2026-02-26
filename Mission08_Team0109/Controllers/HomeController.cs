using Microsoft.AspNetCore.Mvc;
using Mission08_Team0109.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0109.Controllers
{

    
    public class HomeController : Controller
    {

        private TaskDbContext _context;

        public HomeController(TaskDbContext temp) //Constructor
        {
            _context = temp;
        }


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
                _context.Tasks.Add(response); // Add record to database
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

        public IActionResult UpdateTask(int id) //Brings the task to edit into the add edit task view
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddEditTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskItem updatedInfo) //Actually updates the task then redirects to index
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id) //Deletes the task and then redirects to index
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);

            _context.Tasks.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}

