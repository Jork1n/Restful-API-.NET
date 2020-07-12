using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public String MovieGenre { get; set; }
        public int? MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
