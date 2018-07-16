using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public class Entry
    {
        public int Id { get; set; }
        // Duration is in minutes.
        public int Duration { get; set; }
        public string Note { get; set; }
        public DateTime DateOfEntry { get; set; }

        public UserTask UserTask { get; set; }
    }

    
}
