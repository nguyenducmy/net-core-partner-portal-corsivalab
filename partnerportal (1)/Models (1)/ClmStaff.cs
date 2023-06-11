using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmStaff
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public bool SoftDelete { get; set; }
    }
}
