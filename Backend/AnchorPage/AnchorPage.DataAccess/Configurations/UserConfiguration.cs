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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ProfilePicture).HasMaxLength(200);
            builder.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(60).IsRequired();

            builder.HasMany(u => u.Templates).WithOne(t => t.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.VerificationTokens).WithOne(vt => vt.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);          
            builder.HasMany(u => u.VerificationTokens).WithOne(vt => vt.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);            

        }
    }
}
