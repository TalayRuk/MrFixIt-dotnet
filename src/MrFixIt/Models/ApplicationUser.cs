using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MrFixIt.Models
{
    //set up ApplicationUser to extend IdentityUser classes and properties
    //IdentityUser will create 6 new tables in our database and store information about our app's users. The AspNetUsers tables (1 of 6 tables) comes from ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

    }
}