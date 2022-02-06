using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6Group.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Group.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private TasksDBContext _blahContext { get; set; }

        ////Constructor
        public HomeController(ILogger<HomeController> logger, TasksDBContext randomName)
        {
            _logger = logger;
            _blahContext = randomName;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _blahContext.Categories.ToList(); //ViewBag is automatically passed around, so we don't have to send it to the view

           var entries = _blahContext.Tasks.OrderBy(x => x.DueDate).ToList();
           return View(entries);
        }

        [HttpGet]
        public IActionResult TaskEntry()
        {
            ViewBag.Categories = _blahContext.Categories.ToList(); //ViewBag is automatically passed around, so we don't have to send it to the view


            return View();
        }

        [HttpPost]
        public IActionResult TaskEntry(TaskResponse en)
        { //Need the below so that it will save all the changes to the database. I wanted to display the database, but the TAs said it was too far ahead
            ViewBag.Categories = _blahContext.Categories.ToList();
            if (ModelState.IsValid)
            {
                _blahContext.Add(en);
                _blahContext.SaveChanges();
                return View("EntryCon", en); //Will probably need to change this based on view name
            }
            else
            {
                return View(en);
            }

        }
        [HttpGet] //This lets us edit the movie entry, and then save the changes with the Post Edit method below
        public IActionResult Edit(int TaskID) //MovieId has to match the name of the thing we're passing through the route so it knows what to grab
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            var entry = _blahContext.Tasks.Single(x => x.TaskID == TaskID);

            return View("TaskEntry", entry); //Will need to change this based on view name

        }
        [HttpPost]
        public IActionResult Edit(TaskResponse blah) //This saves any edited changes from above
        {

            _blahContext.Update(blah);
            _blahContext.SaveChanges();

            return RedirectToAction("Index"); //Now going up to the waitlist action, and running through that code
        }
        [HttpGet]
        public IActionResult Delete(int TaskID) //Pulls up the movie record from above
        {
            var entry = _blahContext.Tasks.Single(x => x.TaskID == TaskID);
            return View(entry);

        }
        [HttpPost]
        public IActionResult Delete(TaskResponse en) //Actually deletes and saves the changes from above
        {
            _blahContext.Tasks.Remove(en);
            _blahContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
