using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}
