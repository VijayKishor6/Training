using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.Models
{ 
    public class Staff_details
    {
       [Key]
        public int Staff_id { get; set; }
        public string Staff_name { get; set; }
        public string Staff_contact { get; set; }
        public int Staff_salary { get; set; }   
        public string Staff_native { get; set; }
        public int Staff_years { get; set; }

        


    }
}