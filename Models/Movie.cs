using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        [InverseProperty("Movie")]
        public virtual ICollection<Genre> Genres { get; set; }

        [InverseProperty("Movie")]
        public virtual ICollection<Actor> Actors { get; set; }

    }
}