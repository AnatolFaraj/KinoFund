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
    public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {
            builder.HasKey(x => x.CommentId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.RefersToNavigation)
                   .WithOne()
                   .HasForeignKey<CommentModel>(x => x.RefersToCommentId);


            builder.Property(p => p.CommentId)
                   .HasColumnName("CommentID");

            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");

            builder.Property(p => p.MovieId)
                   .HasColumnName("MovieID");

            builder.Property(p => p.RefersToCommentId)
                   .HasColumnName("RefersToCommentID");




        }
    }
}
