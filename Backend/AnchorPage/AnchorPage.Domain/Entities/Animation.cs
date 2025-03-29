using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Animation : Entity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Button> Buttons { get; set; } = new HashSet<Button>();
    }
}
