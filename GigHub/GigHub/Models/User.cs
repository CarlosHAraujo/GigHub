using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}