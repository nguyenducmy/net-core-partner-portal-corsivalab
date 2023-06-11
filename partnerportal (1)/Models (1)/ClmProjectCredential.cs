using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProjectCredential
    {
        public int Id { get; set; }
        public int FkProjectId { get; set; }
        public string CredentialInfos { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool SoftDelete { get; set; }
    }
}
