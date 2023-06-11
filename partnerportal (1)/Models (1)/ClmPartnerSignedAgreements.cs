using System;
using System.Collections.Generic;
namespace partnerportal.Models
{
    public partial class ClmPartnerSignedAgreements
    {
        public int Id { get; set; }
        public string FkPartnerId { get; set; }
        public string SignedAgreementsURL { get; set; }
        public int TypeOfAgreement { get; set; }
        public DateTime DateOfAgreement { get; set; }
        public bool SoftDelete { get; set; }
        
    }
}
