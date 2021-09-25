using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public DateTime DateReleased { get; set; }


        public DateTime DateAdd { get; set; }

        [Range(1, 20)]
        public int Quantdy { get; set; }


        public TypeMovieDto TypeMovie { get; set; }
        [Required]
        public byte TypeMovieId { get; set; }

        public int NumberAvailable { get; set; }


    }
}