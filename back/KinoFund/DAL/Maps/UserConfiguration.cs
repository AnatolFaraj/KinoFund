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
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.User);
                   

            builder.HasMany(x => x.Collections)
                   .WithOne(x => x.User);
                   

            builder.HasMany(x => x.Ratings)
                   .WithOne(x => x.User);


            builder.HasOne(x => x.Credential)
                   .WithOne(x => x.User);
                   

            builder.Property(p => p.UserId)
                   .HasColumnName("UserID");
        }
    }
}
