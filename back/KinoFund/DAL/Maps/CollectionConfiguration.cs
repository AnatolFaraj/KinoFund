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
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.HasKey(x => x.CollectionId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Collections)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Movies)
                   .WithMany(x => x.Collections);

            builder.Property(p => p.CollectionId)
                   .HasColumnName("CollectionID");

            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");
        }
    }
}
