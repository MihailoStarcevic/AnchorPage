using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class UseCase : Entity
    {
        public string Name { get; set; } = string.Empty;
        public UseType Type { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    }

    public enum UseType
    {
        Query,
        Command
    }
}
