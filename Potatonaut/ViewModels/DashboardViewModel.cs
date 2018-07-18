using Potatonaut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.ViewModels
{
    public class DashboardViewModel
    {
        public ICollection<UserTask> UserTasks { get; set; }

        public ICollection<Entry> UserEntries { get; set; }
        public ICollection<Entry> TodayUserEntries { get; set; }

        public UserTask UserTask { get; set; }
        public AppUser User { get; set; }
        public Entry Entry { get; set; }

        public int TotalMinutes { get; set; }

        public double YesterdayProductivityScore { get; set; }
        public double TodayProductivityScore { get; set; }
    }
}
