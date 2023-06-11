using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmTicketImages
    {
        public int Id { get; set; }
        public string TicketImage { get; set; }
        public int FkTicketId { get; set; }
        public bool SoftDelete { get; set; }
    }
}
