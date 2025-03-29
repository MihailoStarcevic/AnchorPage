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
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(x => x.SectionType).HasMaxLength(20).IsRequired();

            builder.HasMany(s => s.Buttons).WithOne(b => b.Section)
                .HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.Cascade);            
            builder.HasMany(s => s.Comments).WithOne(c => c.Section)
                .HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.NoAction);            
        }
    }
}
