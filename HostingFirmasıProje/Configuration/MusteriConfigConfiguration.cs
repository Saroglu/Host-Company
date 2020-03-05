using HostingFirmasıProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Configuration
{
    public class MusteriConfigConfiguration : IEntityTypeConfiguration<Musteri>
    {
        public void Configure(EntityTypeBuilder<Musteri> builder)
        {
            builder.HasOne<Bayi>(x => x.Bayi)
                .WithMany(c => c.Musteriler)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(b=> b.BayiId)
                .IsRequired();
        }
    }
}
