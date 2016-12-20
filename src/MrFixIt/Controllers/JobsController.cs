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

        public IActionResult Claim(Job thisJob, int jobId)
           
        {
            //grab jobId from Ajax call class claim-job & hidden input at index saying thisJob id same as jobId by declaring Job thisJob it knows that thisjob has the same properties as Job      
            thisJob = db.Jobs.FirstOrDefault(items => items.JobId == jobId);
            //once grap jobId from Ajax call, go into worker & grap the id by using User.Identity.Name
            thisJob.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            //add workerId then it went into the Worker table(join table) to add workerId to the job  
            db.Entry(thisJob).State = EntityState.Modified;
            /*db.Jobs.Add(job);*/
            db.SaveChanges();
            return Json(thisJob);
            

        }

    }
}
