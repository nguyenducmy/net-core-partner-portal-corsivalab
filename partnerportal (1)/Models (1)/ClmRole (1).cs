using Microsoft.AspNetCore.Identity;

namespace partnerportal.Models
{
    public class ClmRole : IdentityRole
    {
        /*public int Id { get; set; }*/
        public bool SoftDelete { get; set; }
        public bool IsCorsivaRole { get; set; }
        
    }
    
}
