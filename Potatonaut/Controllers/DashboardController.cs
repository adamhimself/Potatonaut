using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Potatonaut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public DashboardController(AppDbContext context, 
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        [HttpPost]
        public async Task<IActionResult> AddTask(UserTask userTask)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Dashboard", "App");
            }
            userTask.Entries = new List<Entry>();

            var user = await _userManager.GetUserAsync(User);
            userTask.User = user;
            userTask.UserId = user.Id;

            var result = await _context.UserTasks.AddAsync(userTask);

            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "App");
            
        }
    }
}
