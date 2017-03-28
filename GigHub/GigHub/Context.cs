using GigHub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub
{
    public class Context : IdentityDbContext<User>
    {
        public Context()
            : base("GigHub")
        {
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}