using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Domain.Entities
{
    public class Report : Entity
    {
        public int ReportTypeId { get; set; }
        public ReportStatus Status { get; set; } = 0;
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SenderFirstName { get; set; } = string.Empty;
        public string SenderLastName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;

        public virtual required ReportType ReportType { get; set; }
    }

    public enum ReportStatus
    {
        NotReviewed,
        Approved,
        Rejected
    }
}
