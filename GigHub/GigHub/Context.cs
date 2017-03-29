using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using GigHub.Models;

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
        public DbSet<Attendance> Attendances { get; set; }

        public static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}