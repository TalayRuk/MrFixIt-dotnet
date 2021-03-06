﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class WorkersController : Controller
    {
        private MrFixItContext db = new MrFixItContext();
        // GET: /<controller>/

        //show job of the Login user has claimed
        [Authorize]
        public IActionResult Index()
        {
            var thisWorker = db.Workers.Include(i => i.Jobs).FirstOrDefault(i => i.UserName == User.Identity.Name);

            if (thisWorker != null)
            {
                return View(thisWorker);
            }
            else
            {
                //return to create worker or add worker
                return RedirectToAction("Create");
            }
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            worker.UserName = User.Identity.Name;
            db.Workers.Add(worker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Active(Worker thisWorker, int jobId)
        {
            thisWorker = db.Workers.Include(i => i.Jobs).FirstOrDefault(i => i.UserName == User.Identity.Name);
            foreach (var job in thisWorker.Jobs)
            {
                if (job.JobId == jobId)
                {
                    job.Active = true;
                }
                else
                {
                    job.Active = false;
                }
            }
            //db.Jobs.Add(status?);
            db.SaveChanges();
            return Json(thisWorker); ;
        }
    }
}

