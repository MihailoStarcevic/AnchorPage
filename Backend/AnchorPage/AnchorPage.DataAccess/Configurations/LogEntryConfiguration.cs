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
    public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.Property(x => x.Actor).IsRequired();
            builder.Property(x => x.ActorId).IsRequired();
            builder.Property(x => x.CommitedAt).IsRequired();
            builder.Property(x => x.UseCaseName).IsRequired();
            builder.Property(x => x.UseCaseData).IsRequired();
        }
    }
}
