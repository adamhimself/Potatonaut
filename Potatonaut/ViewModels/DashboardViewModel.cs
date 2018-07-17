﻿using Potatonaut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.ViewModels
{
    public class DashboardViewModel
    {
        public ICollection<UserTask> UserTasks { get; set; }
        
        public UserTask UserTask { get; set; }
        public AppUser User { get; set; }
        public Entry Entry { get; set; }
    }
}
