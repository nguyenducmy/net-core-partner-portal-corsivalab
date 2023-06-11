using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmMaintenanceReport
    {
        public int Id { get; set; }
        public int FkProjectId { get; set; }
        public int FkStaffId { get; set; }
        public string Link { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? MonthYear { get; set; }
        public bool SoftDelete { get; set; }
    }
}
