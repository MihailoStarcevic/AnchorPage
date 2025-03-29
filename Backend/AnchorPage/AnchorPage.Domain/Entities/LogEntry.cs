using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class LogEntry : Entity
    {
        public string Actor { get; set; } = string.Empty;
        public int ActorId { get; set; }
        public DateTime CommitedAt { get; set; }
        public string UseCaseName { get; set; } = string.Empty;
        public string UseCaseData { get; set; } = string.Empty;
    }
}
