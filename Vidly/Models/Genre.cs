using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
   public class Genre
   {
      [Required]
      public short Id { get; set; }

      [Required]
      [StringLength(255)]
      public string Name { get; set; }
   }
}