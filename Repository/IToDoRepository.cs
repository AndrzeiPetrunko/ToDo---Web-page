using ToDo.Entities;
using ToDo.Models;
namespace ToDo.Repository
{
    public interface IToDoRepository
    {
        public IEnumerable<Tasks> GetAllTasksById(string user_id);
        public void NewTask(Tasks t);
        public void DeleteTask(int task_id);
        public User GetUserData(string user_id);
        public string GetCategoryById(int cat_id);
    }
}
