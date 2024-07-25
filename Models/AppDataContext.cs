using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FutureFridgesCW.Models
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        internal readonly object Notification;

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Track> Track { get; set; }

        public DbSet<TrackProducts> TrackProducts { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Order> Order { get; set; }
     

    }
}
