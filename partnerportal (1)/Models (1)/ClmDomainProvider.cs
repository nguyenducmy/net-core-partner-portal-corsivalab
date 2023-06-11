using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmDomainProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? SoftDelete { get; set; }
    }
}
