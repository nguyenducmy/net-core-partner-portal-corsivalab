using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmCustomer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public int FkIndustryId { get; set; }
        public bool SoftDelete { get; set; }
    }
}
