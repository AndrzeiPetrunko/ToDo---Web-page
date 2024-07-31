using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Entities;
using ToDo.Models;
using ToDo.Repository;

namespace ToDo.Controllers
{
    public class NewTaskController : Controller
         
    {
        public readonly IToDoRepository _toDoRepository;
        public readonly ToDoDbContext _toDoDbContext;
        public NewTaskController(IToDoRepository toDoRepository, ToDoDbContext toDoDbContext)
        {
            _toDoRepository = toDoRepository;
            _toDoDbContext = toDoDbContext;
        }
        public IActionResult Index(CategoryViewModel t)
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listOfCategories = _toDoDbContext.PriorityCategories.ToList();
            foreach (var item in listOfCategories)
            {
                list.Add(new CategoryViewModel()
                {
                    TaskPriorityCategoryId = item.TaskPriorityCategoryId,
                    CategoryName = item.CategoryName,
                });
            }
            ViewBag.List = list;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewTask(TaskForm t) 
        {
            if(t.TaskName != null && t.TaskStatus != null && t.TaskDescription != null && t.DateFrom != null && t.DateTo != null){
                var task = new Tasks
                {
                    TaskName = t.TaskName,
                    TaskDescription = t.TaskDescription,
                    TaskPriorityCategoryId = t.TaskPriorityCategoryId,
                    TaskStatus = t.TaskStatus,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    Username = MainController.user_id,
                };
                _toDoRepository.NewTask(task);
                return RedirectToAction("Index", "Main");
            }
            TempData["AlertMessage"] = "Fill all the fields below !!!";
            return RedirectToAction("Index", "NewTask");
            
        }   
    }
}
