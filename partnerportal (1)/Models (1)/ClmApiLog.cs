using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmApiLog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime LogDateTime { get; set; }
        public bool SoftDelete { get; set; }
    }
}
