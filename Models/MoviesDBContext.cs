using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{

    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasOne<Movie>(s => s.Movie)
                .WithMany(g =>g.Genres)
                .HasForeignKey(s => s.MovieId)
                .IsRequired();
            modelBuilder.Entity<Actor>()
                .HasOne<Movie>(s => s.Movie)
                .WithMany(g => g.Actors)
                .HasForeignKey(s => s.MovieId)
                .IsRequired();
        }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }

    }
}
