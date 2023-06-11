using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmSolutionBrochures
    {
        public int Id { get; set; }
        public string TitleOfBrochure { get; set; }
        public int TypeOfBrochure { get; set; }
        public double VersionNumber { get; set; }
        public DateTime DateOfBrochure { get; set; }
        public string BrochureURL { get; set; }
        public bool SoftDelete { get; set; }
    }
}