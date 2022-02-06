using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Group.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }

        [Required]
        public int QuadrantID { get; set; }
        public Quadrant Quadrant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
