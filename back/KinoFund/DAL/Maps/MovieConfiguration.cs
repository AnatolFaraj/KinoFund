﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Maps
{
    class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Movies);

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
        }
    }
}
