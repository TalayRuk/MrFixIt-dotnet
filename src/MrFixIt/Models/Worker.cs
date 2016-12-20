using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Avaliable { get; set; }
        //this comes from Identity.User
        public string UserName { get; set; }
        
        //This is one-to-many relationship, One worker can have many jobs
        public virtual ICollection<Job> Jobs { get; set; }


        public Worker()
        {
            Avaliable = true;
        }
        public Worker(string firstName, string lastName, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            WorkerId = id;
        }

    }
}