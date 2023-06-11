using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public DateTime? MaintExpire { get; set; }
        public string ForecastStart { get; set; }
        public int? Forecast { get; set; }
        public DateTime? MaintStart { get; set; }
        public string ForecastAmount { get; set; }
        public DateTime? EmailSystemExpire { get; set; }
        public string EmailSystemOwner { get; set; }
        public int? FkCustomerId { get; set; }
        public string MaintainBy { get; set; }
        public int? FkEmailSystemId { get; set; }
        public bool? SoftDelete { get; set; }
        public string Amemail { get; set; }
        public int? Phase { get; set; }
        public int? ProjectNature { get; set; }
        public string DomainCost { get; set; }
        public string HostingCost { get; set; }
        public string EmailCost { get; set; }
        public string MaintCost { get; set; }
        public string Remarks { get; set; }
        public int? FkdomainProvider { get; set; }
        public string Code { get; set; }
        public string ShortLink { get; set; }
    }
}
