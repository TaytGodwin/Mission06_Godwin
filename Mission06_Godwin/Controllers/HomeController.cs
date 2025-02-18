using System.Data.Common;
using System.Diagnostics;
using System.Linq;
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

        // Gets the form for the movie
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie());
        }

        // This submits the movie
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            if (ModelState.IsValid) // Check if data is valid
            {
                _context.Movies.Add(response); // Adds response to table titled Movies in database
                _context.SaveChanges();

                return View("Confirmation", response); // Goes to confirmation page
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
            
        }

        // List of movies
        public IActionResult MovieList()
        {
            ViewBag.Movies = _context.Movies // Get all movies
                .OrderBy(x => x.Title)
                .ToList();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        // Get method to edit the movie
        [HttpGet]
        public IActionResult EditMovie(int id) // Matches name of parameter passed
        {
            var movieToEdit = _context.Movies // Retrieve movie from instance
                .Where(x => x.MovieId == id)
                .Single();

            ViewBag.Categories = _context.Categories // Need to get categories to send back to movie application form
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", movieToEdit);

        }

        // Post method to edit the movie in the database
        [HttpPost]
        public IActionResult EditMovie(Movie updatedMovie)
        {
            _context.Update(updatedMovie); // Update movie in database
            _context.SaveChanges();

            return RedirectToAction("MovieList"); // Go back to list of movies
        }

        // Delete get method to go to confirmation page
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Get the record to delete
            var movieToDelete = _context.Movies
                .Where (x => x.MovieId == id)
                .Single();

            return View(movieToDelete);
        }

        // Delete post method that actually deletes the movie
        [HttpPost]
        public IActionResult DeleteMovie(Movie movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
