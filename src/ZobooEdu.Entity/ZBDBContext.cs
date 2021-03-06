using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZobooEdu.Entity
{
    public class ZBDBContext : IdentityDbContext<ZBUser, ZBUserRole, Guid>
    {
        public ZBDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ZBDSoru> Sorular { get; set; }
        public DbSet<ZBDCevap> Cevaplar { get; set; }
        public DbSet<ZBDTest> Testler { get; set; }
        public DbSet<ZBDSonuc> Sonuclar { get; set; }
    }
}