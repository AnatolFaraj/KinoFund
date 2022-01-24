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
                   .HasForeignKey<Movie>(x => x.MovieId);

            builder.Property(x => x.MovieId)
                   .HasColumnName("MovieID");
        }
    }
}
