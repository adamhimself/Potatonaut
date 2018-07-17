using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
