using System.Collections.Generic;
using System.Web.Mvc;
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

      public ActionResult Index(int? pageIndex, string sortBy)
      {
         if (!pageIndex.HasValue)
            pageIndex = 1;

         if (string.IsNullOrWhiteSpace(sortBy))
            sortBy = "Name";

         return Content($"page index = {pageIndex}, sort by {sortBy}");
      }

      [Route(@"movies/released/{year:regex(\d{4}):range(1920, 2100)}/{month:regex(\d{2}):range(1, 12)}")]
      public ActionResult ByReleaseDate(int year, int month)
      {
         return Content($"{year} / {month:D2}");
      }

      public ActionResult Movies()
      {
         throw new System.NotImplementedException();
      }
   }
}