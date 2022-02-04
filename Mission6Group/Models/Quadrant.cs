using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Group.Models
{
    public class Quadrant
    {
        [Key]
        [Required]
        public int QuadrantID { get; set; }

        [Required]
        public string QuadrantName { get; set; }
    }
}
