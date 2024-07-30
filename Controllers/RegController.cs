using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Entities;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class RegController : Controller
    {
        public ToDoDbContext _context;
        public RegController(ToDoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserSignupModel userSignupModel)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Reg");
            }


            var existingUser = _context.Users.FirstOrDefault(x => x.Username == userSignupModel.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return RedirectToAction("Index", "Reg");
            }


            if (userSignupModel.Password != userSignupModel.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                return RedirectToAction("Index", "Reg");
            }


            var newUser = new User
            {
                Username = userSignupModel.Username,
                Password = userSignupModel.Password,
                FirstName = userSignupModel.FirstName,
                LastName = userSignupModel.LastName
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();


            return RedirectToAction("Login", "Start");
        }
    }
}
