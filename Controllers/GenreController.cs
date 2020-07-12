using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Movies.Controllers
{
    [ApiController]
    [Route("genre")]
    public class GenreController : ControllerBase
    {
        private readonly MoviesDBContext db;
        public GenreController(MoviesDBContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("getGenres")]
        public List<Genre> GetGenres()
        {
            return db.Genres.ToList();
        }

    }
}
