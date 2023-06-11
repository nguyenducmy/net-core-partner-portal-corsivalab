using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectHosting
    {
        public int Id { get; set; }
        public int? Provider { get; set; }
        public int? Owner { get; set; }
        public DateTime? Expiry { get; set; }
        public int? FkProjectId { get; set; }
        public bool? SoftDelete { get; set; }
        public string Cost { get; set; }
    }
}
