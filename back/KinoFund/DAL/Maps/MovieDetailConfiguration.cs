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
    public class MovieDetailConfiguration : IEntityTypeConfiguration<MovieDetail>
    {
        public void Configure(EntityTypeBuilder<MovieDetail> builder)
        {

            builder.HasKey(x => x.MovieId);

            builder.HasOne(x => x.Movie)
                   .WithOne(x => x.MovieDetail)
                   .HasForeignKey<MovieDetail>(x => x.MovieId);

            builder.Property(x => x.MovieId)
                   .HasColumnName("MovieID");

            builder.HasData(
                new MovieDetail
                { 
                    MovieId = 1L,
                    Country = "USA",
                    ReleaseDate = new DateTime(1994, 8, 21),
                    PEGI = "18+",
                    Picture = "someJPG",
                    Description = "someDescription"
                },
                new MovieDetail
                { 
                    MovieId = 2L,
                    Country = "USA",
                    ReleaseDate = new DateTime(1980, 2, 13),
                    PEGI = "16+",
                    Picture = "SomeJPG",
                    Description = "someDescription"
                });
        }
    }
}
