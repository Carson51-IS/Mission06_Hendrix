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
    }
}
