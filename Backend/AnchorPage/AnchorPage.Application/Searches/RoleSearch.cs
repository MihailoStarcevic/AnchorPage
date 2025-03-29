using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Application.Searches
{
    public class RoleSearch : PagedSearch
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
