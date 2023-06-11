using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmHostingProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? SoftDelete { get; set; }
    }
}
