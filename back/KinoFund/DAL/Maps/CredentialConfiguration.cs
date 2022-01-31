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
    public class CredentialConfiguration : IEntityTypeConfiguration<CredentialModel>
    {
        public void Configure(EntityTypeBuilder<CredentialModel> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Credential)
                   .HasForeignKey<CredentialModel>(x =>  x.UserId);



            builder.Property(x => x.UserId)
                   .HasColumnName("UserID");
        }
    }
}
