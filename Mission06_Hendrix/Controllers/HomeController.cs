using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Hendrix.Data;
using Mission06_Hendrix.Models;

namespace Mission06_Hendrix.Controllers
{
    public class HomeController : Controller
    {
        // Dependency Injection: ASP.NET creates MovieFormContext and passes it here.
        // We don't "new" it ourselves; the framework manages creation/lifetime.
        private readonly MovieFormContext _context;

        public HomeController(MovieFormContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        // Same action name, different HTTP method: GET shows form, POST handles submit (method overloading by attribute)
        [HttpGet]
        public IActionResult Movies()
        {
            return View("movies");
        }

        // Model binding: form fields automatically map to Movie properties based on name/asp-for
        [HttpPost]
        public IActionResult Movies(Movie movie)
        {
            if (ModelState.IsValid)  // Checks [Required], [StringLength], etc.
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();  // Persists to SQLite
                return View("MovieConfirmation", movie);
            }
            // Validation failed: redisplay form with error messages
            return View("movies", movie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>GET: Displays all movies in the collection (Mission 7 - Movie List).</summary>
        public IActionResult MovieList()
        {
            var movies = _context.Movies.OrderBy(m => m.Title).ToList();
            return View(movies);
        }

        /// <summary>GET: Shows the Edit Movie form with the selected movie's data loaded.</summary>
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        /// <summary>POST: Saves changes to the movie and redirects to Movie List.</summary>
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(MovieList));
            }
            return View(movie);
        }

        /// <summary>GET: Shows the Delete confirmation page for the selected movie.</summary>
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        /// <summary>POST: Permanently deletes the movie and redirects to Movie List.</summary>
        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            var toDelete = _context.Movies.Find(movie.MovieId);
            if (toDelete != null)
            {
                _context.Movies.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(MovieList));
        }
    }
}
