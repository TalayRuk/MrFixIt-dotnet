using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Pending { get; set; }
        public bool Active { get; set; }
        //Don't Need to add WorkerId Column, to set the worker to jobs join table then run migration and database update b/c virtual already let migrations know to add workerId automatically to the job table
        //public int WorkerId { get; set; }
        //This is one-to-many relatioship, where this worker can have many jobs, and a job has one worker. 
        public virtual Worker Worker { get; set; }
    }
}
