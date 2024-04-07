using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace MoviesCatalog.Models.DBContext
{

    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships between entities
            modelBuilder.Entity<FilmCategory>()
                .HasKey(fc => new { fc.FilmId, fc.CategoryId });

            modelBuilder.Entity<FilmCategory>()
                .HasOne(fc => fc.Film)
                .WithMany(m => m.FilmCategories)
                .HasForeignKey(fc => fc.FilmId);

            modelBuilder.Entity<FilmCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(c => c.FilmCategories)
                .HasForeignKey(fc => fc.CategoryId);
        }
    }
}
