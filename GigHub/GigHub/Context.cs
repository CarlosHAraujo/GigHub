using GigHub.Models;
using System.Data.Entity;

namespace GigHub
{
    public class Context : DbContext
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}