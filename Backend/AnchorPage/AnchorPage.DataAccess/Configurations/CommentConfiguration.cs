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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ParentCommentId).IsRequired(false);

            builder.HasMany(c => c.ChildComments).WithOne(c => c.ParentComment)
                .HasForeignKey(x => x.ParentCommentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
