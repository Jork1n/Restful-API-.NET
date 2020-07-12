using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Requests.Movie;

namespace Movies.Controllers
{
    [Route("api/MovieController")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDBContext db;
        public MovieController(MoviesDBContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("getMovieList")]
        public List<GetMovieListResponse> getMovieLists()
        {
            return db.Movies.Select(x => new GetMovieListResponse
            {
                Id = x.Id,
                Name = x.MovieTitle,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate,
            }).ToList();
        }
        [HttpPost]
        [Route("postMovie")]
        public string PostMovie([FromBody] PostMovieRequest message)
        {
            db.Movies.Add(new Movie
            {
                MovieTitle = message.Name,
                Description = message.Description,
                ReleaseDate = message.ReleaseDate,
                Actors = message.Actors.Select(x => new Models.Actor
                {
                    MovieActor = x.Name
                }).ToList(),
                Genres = message.Genres.Select(x => new Models.Genre
                {
                    MovieGenre = x.Name
                }).ToList(),
            });
            db.SaveChanges();
            return "Posted";
        }
        [HttpGet]
        [Route("getMovie")]
        public GetMovieResponse GetMovie([FromBody] GetMovieRequest message)
        {
            var genres = db.Genres.ToList();
            var actors = db.Actors.ToList();
            var movie = db.Movies.FirstOrDefault(x => x.Id == message.Id);
            var response = new GetMovieResponse();
            response.Name = movie.MovieTitle;
            response.Description = movie.Description;
            response.ReleaseDate = movie.ReleaseDate;
            response.Actors = movie.Actors.Select(x => new Requests.Movie.Actor
            {
                Name = x.MovieActor
            }).ToList();
            response.Genres = movie.Genres.Select(x => new Requests.Movie.Genre
            {
                Name = x.MovieGenre
            }).ToList();
            return response;

        }
        //db.movies.where(s=>s.actors.contains(x=>x.name == message.actorName))
        //[HttpGet]
        //[Route("PutMovie")]
        //public string PutMovie([FromBody] PutMovieRequest message)
        //{
        //    var update = db.Movies.FirstOrDefault(x => x.Id == message.Id);
        //    if (update != null)
        //    {
        //        update.Description = message.Description;
        //        foreach (i in update.Actors)
        //        {
        //            if (update.Actors.Any(x => x.MovieActor == i.MovieActor))
        //            {

        //            }
        //            else
        //        }
        //    }
        //}
    }
}
