using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmMaintenanceLog
    {
        public int Id { get; set; }
        public int FkProjectId { get; set; }
        public int FkStaffId { get; set; }
        public string Remarks { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool SoftDelete { get; set; }
    }
}
