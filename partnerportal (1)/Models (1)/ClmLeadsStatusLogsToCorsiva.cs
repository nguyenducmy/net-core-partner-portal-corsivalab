using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmLeadsStatusLogsToCorsiva
    {
        public int Id { get; set; }
        public DateTime DateTimeOfChange { get; set; }
        public int FkLeadsId { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public bool SoftDelete { get; set; }
    }
}