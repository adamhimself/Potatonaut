﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Potatonaut.Controllers
{
    public class AppController : Controller
    {        
        public IActionResult Welcome()
        {
            return View();
        }        

        public IActionResult Dashboard()
        {
            return View();
        }

        
    }
}
