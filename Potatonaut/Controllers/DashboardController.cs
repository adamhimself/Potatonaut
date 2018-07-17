﻿using Microsoft.AspNetCore.Identity;
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
            var userResult = loggedUser.Result;
            var userId = _userManager.GetUserIdAsync(userResult).Result.ToString();

            var userEntries = _context.UserTasks.Where(task => task.UserId == userId)                
                .Include(task => task.Entries).ToList();
            viewModel.UserTasks = userEntries;
            return View(viewModel);
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
