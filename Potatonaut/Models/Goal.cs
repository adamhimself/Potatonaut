using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
