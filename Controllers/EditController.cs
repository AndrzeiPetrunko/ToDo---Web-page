using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class EditController : Controller
    {
        public static int task_id;
        private readonly ToDoDbContext toDoDbContext;
        public EditController(ToDoDbContext toDoDbContext)
        {
            this.toDoDbContext = toDoDbContext;
        }
        public IActionResult Index(CategoryViewModel t)
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listOfCategories = toDoDbContext.PriorityCategories.ToList();
            foreach (var item in listOfCategories)
            {
                list.Add(new CategoryViewModel()
                {
                    TaskPriorityCategoryId = item.TaskPriorityCategoryId,
                    CategoryName = item.CategoryName,
                });
            }
            var task = toDoDbContext.Tasks.FirstOrDefault(t => t.TaskId == task_id);
            ViewBag.List = list;
            ViewBag.TaskName = task.TaskName;
            ViewBag.DateFrom = task.DateFrom;
            ViewBag.DateTo = task.DateTo;
            ViewBag.TaskDescription = task.TaskDescription;
            ViewBag.TaskStatus = task.TaskStatus;
            return View();
        }
        public IActionResult EditTask(TaskForm t)
        {
            var tasks = (from p in toDoDbContext.Tasks where p.TaskId == task_id select p).ToList();
            foreach (var task in tasks)
            {
                task.TaskStatus = t.TaskStatus;
                task.TaskName = t.TaskName;
                task.TaskDescription = t.TaskDescription;
                task.DateFrom = t.DateFrom;
                task.DateTo = t.DateTo;
                task.TaskPriorityCategoryId = t.TaskPriorityCategoryId;
            }
            toDoDbContext.SaveChanges();
            return RedirectToAction("Index", "Main");
        }
    }
}
