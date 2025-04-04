using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Button : Entity
    {
        public int SectionId { get; set; }
        public string Link { get; set; } = string.Empty;
        public int NumberInList { get; set; }
        public string? Color { get; set; }
        public string? HoverColor { get; set; }
        public int? AnimationId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string TextColor { get; set; } = "#FFFFFF";
        public string? StrokeColor { get; set; }
        public int? StrokeWeight { get; set; }

        public virtual Section Section { get; set; }
        public virtual Animation Animation { get; set; }
    }
}
