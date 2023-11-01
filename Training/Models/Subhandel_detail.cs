using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class Subhandel_detail
    {
        [Key]
      
        public int Staff_id { get; set; }

        public string Staff_sub { get; set; }
        [ForeignKey("Staff_id")]
        public virtual Staff_details Staff { get; set; }
    }
}
