using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Training.Models   
{
    public class Staff_context : DbContext      
    {
    
        public Staff_context() : base("dbcon")
        {
           // Database.SetInitializer<Staff_context>(new DropCreateDatabaseIfModelChanges<Staff_context>());

        }
        public DbSet<Staff_details> Staff_details{ get; set; }
        public DbSet<Subhandel_detail> Subhandel_Detail{ get; set; }

            

    }
}

