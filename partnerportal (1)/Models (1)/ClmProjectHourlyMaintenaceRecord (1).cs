using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectHourlyMaintenaceRecord
    {
        public int Id { get; set; }
        public double? HoursSpent { get; set; }
        public string HourResonRequest { get; set; }
        public bool? SoftDelete { get; set; }
        public int FkProjectHourlyMaintenaceId { get; set; }
    }
}
