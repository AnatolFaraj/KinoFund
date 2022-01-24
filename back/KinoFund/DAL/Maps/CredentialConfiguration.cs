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
    class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Credential)
                   .HasForeignKey<User>(x => x.UserId);



            builder.Property(x => x.UserId)
                   .HasColumnName("UserID");
        }
    }
}
