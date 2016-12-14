﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class HomeController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
            return View(thisWorker);           
        }
    }
}
