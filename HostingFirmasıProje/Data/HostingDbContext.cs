using HostingFirmasıProje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Data
{
    public class HostingDbContext : DbContext
    {
        public HostingDbContext(DbContextOptions<HostingDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Bayi> Bayiler { get; set; }
    }
}
