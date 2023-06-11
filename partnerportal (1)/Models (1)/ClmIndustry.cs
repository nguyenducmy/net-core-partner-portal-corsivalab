using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmIndustry
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }
        public bool SoftDelete { get; set; }
    }
}
