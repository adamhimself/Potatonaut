using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Potatonaut.Controllers
{
    public class AppController : Controller
    {        
        [HttpGet]
        public string Welcome()
        {
            return ("Hello there!");
        }        
    }
}
