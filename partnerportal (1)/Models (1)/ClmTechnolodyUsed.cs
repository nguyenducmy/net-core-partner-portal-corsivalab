﻿using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmTechnolodyUsed
    {
        public int Id { get; set; }
        public string Technology { get; set; }
        public bool SoftDelete { get; set; }
    }
}
