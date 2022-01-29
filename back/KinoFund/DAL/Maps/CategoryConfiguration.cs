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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);

            builder.HasMany(x => x.Movies)
                   .WithOne(x => x.Category);

            builder.Property(p => p.CategoryId)
                   .HasColumnName("CategoryID");

            builder.HasData(
                new Category 
                { 
                    CategoryId = 1,
                    Name = "Comedy"
                },
                new Category
                {   CategoryId = 2,
                    Name = "Horror"
                });
        }
    }
}
