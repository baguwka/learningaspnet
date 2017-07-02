using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class MoviesController : Controller
   {
      private readonly ApplicationDbContext _context;

      public MoviesController()
      {
         _context = new ApplicationDbContext();
      }

      // GET: Movies
      public ActionResult Random()
      {
         var movie = new Movie() {Name = "Yiffing around"};
         var customers = new List<Customer>()
         {
            new Customer{Name = "Customer 1", Id = 1},
            new Customer{Name = "Customer 2", Id = 2},
         };

         var viewModel = new RandomMovieViewModel
         {
            Movie = movie,
            Customers = customers
         };

         return View(viewModel);
      }

      [Route(@"movies/released/{year:regex(\d{4}):range(1920, 2100)}/{month:regex(\d{2}):range(1, 12)}")]
      public ActionResult ByReleaseDate(int year, int month)
      {
         return Content($"{year} / {month:D2}");
      }

      [Route(@"Movies/Details/{id:regex(\d)}")]
      public ActionResult MovieDetails(int id)
      {
         var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
         if (movie == null)
         {
            return HttpNotFound();
         }

         return View(movie);
      }

      public async Task<ActionResult> Index()
      {
         var movies = await _context.Movies.Include(m => m.Genre).ToListAsync();
         return View(movies);
      }

      public ViewResult New()
      {
         var genres = _context.Genres.ToList();

         var viewModel = new MovieFormViewModel
         {
            Genres = genres
         };

         return View("MovieForm", viewModel);
      }

      public ActionResult Edit(int id)
      {
         var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

         if (movie == null)
            return HttpNotFound();

         var viewModel = new MovieFormViewModel
         {
            Movie = movie,
            Genres = _context.Genres.ToList()
         };

         return View("MovieForm", viewModel);
      }

      [HttpPost]
      public ActionResult Save(Movie movie)
      {
         if (!ModelState.IsValid)
         {
            var viewModel = new MovieFormViewModel
            {
               Movie = movie,
               Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
         }

         if (movie.Id == 0)
         {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
         }
         else
         {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
         }

         _context.SaveChanges();

         return RedirectToAction("Index", "Movies");
      }
   }
}