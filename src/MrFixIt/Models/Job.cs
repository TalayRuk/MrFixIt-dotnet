using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Pending { get; set; }
        public bool Active { get; set; }
        //Need to add WorkerId Column, to set the worker to jobs
        public int WorkerId { get; set; }
        //This is one-to-many relatioship, where this worker can have many jobs, and a job has one worker. 
        public virtual Worker Worker { get; set; }
    }
}
