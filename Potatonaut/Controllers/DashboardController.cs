using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Potatonaut.Models;
using Potatonaut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Controllers
{
    [Authorize]
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

        public IActionResult Dashboard(DashboardViewModel viewModel)
        {
            var loggedUser = _userManager.GetUserAsync(User);
            var userId = _userManager.GetUserIdAsync(loggedUser.Result);

            var userTasks = _context.UserTasks.Where(task => task.UserId == userId.Result.ToString())
                .Include(task => task.Entries).ToList();

            var todaysDate = DateTime.UtcNow.Date;

            var userEntries = _context.Entries.ToList();
            viewModel.UserEntries = userEntries;

            var todayUserEntries = userEntries.Where(entry => entry.DateOfEntry.Date == DateTime.UtcNow.Date).ToList();
            var yesterdayUserEntries = userEntries.Where(entry => entry.DateOfEntry.Date == DateTime.UtcNow.Date.AddDays(-1)).ToList();

            viewModel.TodayUserEntries = todayUserEntries;

            viewModel.UserTasks = userTasks;

            int TodayTotalMinutes = 0;
            int YesterdayTotalMinutes = 0;

            foreach (var entry in yesterdayUserEntries)
            {
                YesterdayTotalMinutes += entry.Duration;
            }

            foreach (var entry in todayUserEntries)
            {
                TodayTotalMinutes += entry.Duration;        
            }

            viewModel.YesterdayProductivityScore = (YesterdayTotalMinutes * 100) / (24 * 60);
            viewModel.TodayProductivityScore = (TodayTotalMinutes * 100) / (24 * 60);


            return View(viewModel);
        }

        public IActionResult Goals(GoalsViewModel viewModel)
        {
            viewModel.Goals = new List<Goal>();
            return View(viewModel);
        }

        public async Task<IActionResult> DeleteEntry(int id)
        {
            var entry = await _context.Entries.FirstOrDefaultAsync(m => m.Id == id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            userTask.Entries = new List<Entry>();

            var user = await _userManager.GetUserAsync(User);
            userTask.User = user;
            userTask.UserId = user.Id;

            var result = await _context.UserTasks.AddAsync(userTask);

            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Dashboard");            
        }

        [HttpPost]
        public async Task<IActionResult> AddMinutes(Entry entry)
        {
            entry.DateOfEntry = DateTime.UtcNow;
            await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}
