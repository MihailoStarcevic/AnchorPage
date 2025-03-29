using AnchorPage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.EfDataAccess.Configurations
{
    public class VerificationTokenConfiguration : IEntityTypeConfiguration<VerificationToken>
    {
        public void Configure(EntityTypeBuilder<VerificationToken> builder)
        {
            builder.HasIndex(x => x.Token).IsUnique();
            builder.Property(x => x.Token).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedAt).HasMaxLength(20).IsRequired();
            builder.Property(x => x.ExpiresAt).HasMaxLength(20).IsRequired();
        }
    }
}
