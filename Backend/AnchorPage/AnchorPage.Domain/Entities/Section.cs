using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Section : Entity
    {
        public SectionType SectionType { get; set; }
        public bool IsVisible { get; set; } = true;
        public int TemplateId { get; set; }

        public virtual required Template Template { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Button> Buttons { get; set; } = new HashSet<Button>();
    }

    public enum SectionType
    {
        Links,
        AboutMe,
        Comments,
        Contact
    }
}
