using System.Collections.Generic;
using JetBrains.Annotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
   public class MoviesViewModel
   {
      [NotNull]
      public List<Movie> Movies { get; set; } = new List<Movie>();
   }
}