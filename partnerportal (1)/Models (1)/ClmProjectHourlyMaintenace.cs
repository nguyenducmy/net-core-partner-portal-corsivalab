using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectHourlyMaintenace
    {
        public int Id { get; set; }
        public string HourPackge { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public double? HoursSpent { get; set; }
        public int? FkProjectId { get; set; }
        public bool? SoftDelete { get; set; }
    }
}
