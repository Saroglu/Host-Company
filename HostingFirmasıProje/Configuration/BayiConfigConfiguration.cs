using HostingFirmasıProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Configuration
{
    public class BayiConfigConfiguration : IEntityTypeConfiguration<Bayi>
    {
        public void Configure(EntityTypeBuilder<Bayi> builder)
        {
            builder.HasMany<Musteri>(x => x.Musteriler)
                .WithOne(c => c.Bayi)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
