using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace partnerportal.Models
{
    public partial class ClmPartner :IdentityUser
    {
        /*public int Id { get; set; }*/
        /*public string UserName { get; set; }*/
        /*public string Password { get; set; }*/
        /*public string Email { get; set; }*/
        /*public string Phone { get; set; }*/
        public string Remarks { get; set; }
        public bool SoftDelete { get; set; }

    }
}