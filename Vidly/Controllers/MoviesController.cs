using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.BusinessLogic;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class MoviesController : Controller
   {
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

      public ActionResult Edit(int movieId)
      {
         return Content($"You're going to edit movie #{movieId}");
      }

      [Route(@"movies/released/{year:regex(\d{4}):range(1920, 2100)}/{month:regex(\d{2}):range(1, 12)}")]
      public ActionResult ByReleaseDate(int year, int month)
      {
         return Content($"{year} / {month:D2}");
      }

      public ActionResult Index()
      {
         var movies = MoviesDataBase.Instance.GetActualMovies();
         return View(movies);
      }
   }
}