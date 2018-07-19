using Potatonaut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.ViewModels
{
    public class GoalsViewModel
    {
        public Goal Goal { get; set; }
        public List<Goal> Goals { get; set; }
    }
}
