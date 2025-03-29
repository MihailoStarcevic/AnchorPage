using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Comment : Entity
    {
        public int? UserId { get; set; }
        public int? SectionId { get; set; }
        public int? ParentCommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public virtual required User User { get; set; }
        public virtual required Section Section { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> ChildComments { get; set; } = new HashSet<Comment>();
    }
}
