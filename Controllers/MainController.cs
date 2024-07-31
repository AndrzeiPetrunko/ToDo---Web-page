using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Entities;
using ToDo.Models;
using ToDo.Repository;

namespace ToDo.Controllers
{
    public class MainController : Controller
    {
        public readonly IToDoRepository _toDoRepository;
        public readonly ToDoDbContext _toDoDbContext;
        public MainController(IToDoRepository toDoRepository, ToDoDbContext toDoDbContext)
        {
            _toDoRepository = toDoRepository;
            _toDoDbContext = toDoDbContext;
        }
        public static string user_id;
        public IActionResult Index()
        {
            var tasks = _toDoRepository.GetAllTasksById(user_id);
            var user = _toDoRepository.GetUserData(user_id);
            ViewBag.FullName = user.FirstName + " " + user.LastName;
            var tasksModel = tasks.Select(t => new TasksModel()
            {
                TaskId = t.TaskId,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                TaskName = t.TaskName,
                TaskDescription = t.TaskDescription,
                TaskStatus = t.TaskStatus,
                TaskPriorityCategoryId = t.TaskPriorityCategoryId,
                CategoryName = _toDoRepository.GetCategoryById(t.TaskPriorityCategoryId),
            }).ToList();
            
            return View(tasksModel);
        }
        public IActionResult Add()
        {
            return RedirectToAction("Index", "NewTask");
        }
        public IActionResult DeleteTask(int id)
        {
            _toDoRepository.DeleteTask(id);
            return RedirectToAction("Index","Main");
        }
        public IActionResult EditTask(int id)
        {
            Console.WriteLine(id);
            EditController.task_id = id;
            return RedirectToAction("Index", "Edit");
        }
    }
}
