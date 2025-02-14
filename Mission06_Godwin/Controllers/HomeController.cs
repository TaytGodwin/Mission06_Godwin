using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Mission06_Godwin.Models;
using SQLitePCL;

namespace Mission06_Godwin.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context; // Creates a private variable
        public HomeController(MovieContext movie_entry) // constructor
        {
            _context = movie_entry; // allows controller to interact with database
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            _context.Movies.Add(response); // Adds response to table titled Movies in database
            _context.SaveChanges();
            
            return View("Confirmation", response); // Goes to confirmation page
        }
    }
}
