using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectBackUp
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Link { get; set; }
        public int FkProjectId { get; set; }
        public bool SoftDelete { get; set; }
    }
}
