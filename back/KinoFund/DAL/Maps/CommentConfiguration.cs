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
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Comments);

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Comments);

            builder.HasOne(x => x.RefersToNavigation)
                   .WithMany()
                   .HasForeignKey(x => x.RefersToCommentId);


            builder.Property(p => p.CommentId)
                   .HasColumnName("CommentID");

            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");

            builder.Property(p => p.MovieId)
                   .HasColumnName("MovieID");




        }
    }
}
