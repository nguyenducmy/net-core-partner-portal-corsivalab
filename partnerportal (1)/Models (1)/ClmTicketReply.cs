using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmTicketReply
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string Messages { get; set; }
        public string PersonReplyed { get; set; }
        public int FkTicketiId { get; set; }
        public int IsStaff { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Approve { get; set; }
        public bool SoftDelete { get; set; }
    }
}
