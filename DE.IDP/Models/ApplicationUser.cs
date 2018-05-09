using Microsoft.AspNetCore.Identity;

namespace DE.IDP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string DataEventRecordsRole { get; set; }
        public string SecureFilesRole { get; set; }
    }
}
