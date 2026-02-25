using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0109.Models
{
    public class EfTaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public EfTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IQueryable<TaskItem> Tasks => _context.Tasks.Include(t => t.Category);
        public IQueryable<Category> Categories => _context.Categories;
        
        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
        }
        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
        }
        public void DeleteTask(TaskItem task)
        {
            _context.Tasks.Remove(task);
        }
        public void SaveTask()
        {
            _context.SaveChanges();
        }
    }
}
