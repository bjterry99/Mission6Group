using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Group.Models
{
    public class TasksDBContext : DbContext
    {  
        //constructor
        public TasksDBContext (DbContextOptions<TasksDBContext> options) : base(options)
        {
            //blank for now
        }

        public DbSet<TaskResponse> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quadrant> Quadrants { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Church"
                }
            );

            mb.Entity<Quadrant>().HasData(
                new Quadrant
                {
                    QuadrantID = 1,
                    QuadrantName = "Quadrant I: Important / Urgent"
                },
                new Quadrant
                {
                    QuadrantID = 2,
                    QuadrantName = "Quadrant II: Important / Not Urgent"
                },
                new Quadrant
                {
                    QuadrantID = 3,
                    QuadrantName = "Quadrant III: Not Important / Urgent"
                },
                new Quadrant
                {
                    QuadrantID = 4,
                    QuadrantName = "Quadrant IV: Not Important / Not Urgent"
                }
            );

            mb.Entity<TaskResponse>().HasData(
                new TaskResponse
                {
                    TaskID = 1,
                    Task = "Finish mission 6",
                    DueDate = DateTime.Parse("Feb 9, 2022"),
                    CategoryID = 2,
                    QuadrantID = 2,
                    Completed = false
                }
            );
        }
    }
}
