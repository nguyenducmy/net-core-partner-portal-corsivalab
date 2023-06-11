using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmLeadsFromCorsiva
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string AdditionalRemarks { get; set; }
        public DateTime DateAdded { get; set; }
        public string Remarks { get; set; }
        public string ServiceRequired { get; set; }
        public bool SoftDelete { get; set; }
    }
}