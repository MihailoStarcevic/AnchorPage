using AnchorPage.Application;
using System.Diagnostics;

namespace AnchorPage.API.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Identity { get; set; } = string.Empty;

        public IEnumerable<int> AllowedUseCases { get; set; } = new HashSet<int>();
    }
}
