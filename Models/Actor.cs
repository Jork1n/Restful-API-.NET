using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string MovieActor { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
