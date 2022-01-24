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
    class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Ratings);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Ratings);


            builder.HasKey(x => new { x.UserId, x.MovieId });



            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");

            builder.Property(p => p.MovieId)
                   .HasColumnName("MovieID");
        }
    }
}
