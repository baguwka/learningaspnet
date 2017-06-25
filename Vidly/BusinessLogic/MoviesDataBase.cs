using System.Collections.Generic;
using System.Linq;
using Vidly.Models;

namespace Vidly.BusinessLogic
{
   public class MoviesDataBase
   {
      private static MoviesDataBase _instance;
      private readonly List<Movie> _movies;
      public static MoviesDataBase Instance => _instance ?? (_instance = new MoviesDataBase());

      private MoviesDataBase()
      {
         _movies = new List<Movie>
         {
            new Movie {Id = 0, Name = "Shrek"},
            new Movie {Id = 1, Name = "WALL-E"},
            new Movie {Id = 2, Name = "Yiffing around your sweet butthole 3"},
         };
      }

      public List<Movie> GetActualMovies()
      {
         return _movies.ToList();
      }
   }
}