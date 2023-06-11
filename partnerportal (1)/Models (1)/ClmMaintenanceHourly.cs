using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmMaintenanceHourly
    {
        public int Id { get; set; }
        public int? FkProjectId { get; set; }
        public string ServiceHourLeft { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public bool SoftDelete { get; set; }
    }
}
