using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmTickets
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string Subject { get; set; }
        public string Messages { get; set; }
        public int Priority { get; set; }
        public int? StaffAssigned { get; set; }
        public int Status { get; set; }
        public int FkProjectId { get; set; }
        public int FkCustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool SoftDelete { get; set; }
    }
}
