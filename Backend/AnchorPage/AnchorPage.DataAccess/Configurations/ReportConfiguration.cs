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
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(300);
            builder.Property(x => x.Message).HasMaxLength(300);
            builder.Property(x => x.SenderFirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.SenderLastName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.SenderEmail).HasMaxLength(30).IsRequired();
        }
    }
}
