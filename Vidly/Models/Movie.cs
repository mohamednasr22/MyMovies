using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public DateTime  DateReleased { get; set; }
        public DateTime DateAdd { get; set; }
        public int Quantdy { get; set; }
        public TypeMovie TypeMovie { get; set; }
        public byte TypeMovieId { get; set; }

        public int NumberAvailable { get; set; }
    }
}