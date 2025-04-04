using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Template : Entity
    {
        public string Name { get; set; } = "Default Template";
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? BackgroundColor { get; set; } = "#FFFFFF";
        public string? BackgroundImage { get; set; }
        public int BorderRadius { get; set; } = 25;
        public string MainColor { get; set; } = "#000000";
        public string AccentColor { get; set; } = "#FFFFFF";
        public string? ThirdColor { get; set; }
        public string FontFamily { get; set; } = "Montserrat";
        public int FontWeight { get; set; } = 400;
        public int FontSize { get; set; } = 16;

        public virtual User User { get; set; }
        public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();
    }
}
