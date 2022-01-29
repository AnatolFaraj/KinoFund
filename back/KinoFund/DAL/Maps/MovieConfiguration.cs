using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Maps
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Movies)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.MovieDetail)
                   .WithOne(x => x.Movie);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.Movie);

            builder.HasMany(x => x.Collections)
                   .WithMany(x => x.Movies);

            builder.HasMany(x => x.Ratings)
                   .WithOne(x => x.Movie);

            builder.Property(p => p.MovieId)
                   .HasColumnName("MovieID");

            builder.Property(p => p.CategoryId)
                   .HasColumnName("CategoryID");

            builder.HasData(
                new Movie
                { 
                    MovieId = 1L,
                    Title = "Pulp Fiction",
                    CategoryId = 1L
                },
                new Movie
                { 
                    MovieId = 2L,
                    Title = "Friday the 13th",
                    CategoryId = 2L
                });
        }
    }
}
