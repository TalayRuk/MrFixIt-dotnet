using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    //create db as new MrFixItContext() Constructor
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        //if sign in show list of jobs (that can be claimed) else take to Views/Jobs/Public
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

            return View(db.Jobs.Include(i => i.Worker).ToList());
            }
            //move else down
            else
            {
                return RedirectToAction("Public");
            }
        }
        [HttpPost]
        public IActionResult Index(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Content("You have claim this job!", "text/plain");
        }

        public IActionResult Public()
        {
            //error here? since it's public shouldn't it show just a list of job but doesn't show worker .. need to delete create job from the view page 
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //assign to specific user! 
        public IActionResult DisplayJob(int id)
        {
            var DisplayJob = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return Json(DisplayJob);
        }

        
    }
}
