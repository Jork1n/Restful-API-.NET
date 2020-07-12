using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Requests.Movie
{
    public class PostMovieRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Actor> Actors { get; set; }
    }
    public class Genre
    {
        public string Name { get; set; }
    }
    public class Actor
    {
        public string Name { get; set; }
    }
}
