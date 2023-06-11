using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmStaffCredentialRequest
    {
        public int Id { get; set; }
        public int FkStaffId { get; set; }
        public int FkProjectId { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool Approved { get; set; }
        public bool SoftDelete { get; set; }
    }
}
