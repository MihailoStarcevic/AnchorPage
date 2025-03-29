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
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(80);
            builder.Property(x => x.BackgroundColor).HasMaxLength(7);
            builder.Property(x => x.BackgroundImage).HasMaxLength(300);
            builder.Property(x => x.BorderRadius).HasMaxLength(4);
            builder.Property(x => x.MainColor).HasMaxLength(7).IsRequired();
            builder.Property(x => x.AccentColor).HasMaxLength(7).IsRequired();
            builder.Property(x => x.ThirdColor).HasMaxLength(7);



            builder.HasMany(t => t.Sections).WithOne(s => s.Template).HasForeignKey(x => x.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
