using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmQuotation
    {
        public int Id { get; set; }
        public int FkPreviousQuotationRef { get; set; }
        public string Name { get; set; }
        public decimal QuotationVersion { get; set; }
        public string QuotationJson { get; set; }
        public decimal TotalQuote { get; set; }
        public string Remarks { get; set; }
        public DateTime Finalised { get; set; }
        public int SoftDelete { get; set; }
    }
}
