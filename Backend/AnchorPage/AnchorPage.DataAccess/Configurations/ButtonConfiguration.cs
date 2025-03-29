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
    public class ButtonConfiguration : IEntityTypeConfiguration<Button>
    {
        public void Configure(EntityTypeBuilder<Button> builder)
        {
            builder.Property(x => x.Link).HasMaxLength(300).IsRequired();
            builder.Property(x => x.NumberInList).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(7);
            builder.Property(x => x.HoverColor).HasMaxLength(7);
            builder.Property(x => x.Content).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(7).IsRequired();
        }
    }
}
