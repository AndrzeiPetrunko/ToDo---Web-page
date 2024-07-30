using ToDo.Entities;
using ToDo.Models;

namespace ToDo.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public readonly ToDoDbContext _context;
        public ToDoRepository(ToDoDbContext context) { _context = context; }
        public IEnumerable<Tasks> GetAllTasksById(string user_id)
        {
            return _context.Tasks.Where(t => t.Username == user_id);
        }
        public User GetUserData(string user_id)
        {

            return _context.Users.FirstOrDefault(u => u.Username == user_id);
        }
        public void NewTask(Tasks t)
        {
            if (t != null)
            {
                _context.Tasks.Add(t);
                _context.SaveChanges();
            }

        }
        public void DeleteTask(int id)
        {
            Tasks task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChangesAsync();
            }

        }
        public string GetCategoryById(int id)
        {
            var category = _context.PriorityCategories.FirstOrDefault(c => c.TaskPriorityCategoryId == id);
            return category?.CategoryName;
            
        }
    }
}
