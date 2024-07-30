using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Entities;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class StartController : Controller
    {
        public ToDoDbContext _context;
        public string user_id;
        public StartController(ToDoDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            User user = _context.Users.FirstOrDefault(x => x.Username == userLoginModel.Username);
            if (user != null && user.Password == userLoginModel.Password)
            {
                MainController.user_id = user.Username;
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Signup(UserSignupModel userSignupModel)
        {

            return RedirectToAction("Index","Reg");
        }
    }
}
