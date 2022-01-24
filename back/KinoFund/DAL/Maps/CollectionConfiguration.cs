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
    class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Collections);

            builder.HasMany(x => x.Movies)
                   .WithMany(x => x.Collections);

            builder.Property(p => p.CollectionId)
                   .HasColumnName("CollectionID");

            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");
        }
    }
}
