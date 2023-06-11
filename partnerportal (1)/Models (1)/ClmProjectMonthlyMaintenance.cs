using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectMonthlyMaintenance
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? FkProjectId { get; set; }
        public string Per { get; set; }
        public int? Amount { get; set; }
        public bool? SoftDelete { get; set; }
    }
}
