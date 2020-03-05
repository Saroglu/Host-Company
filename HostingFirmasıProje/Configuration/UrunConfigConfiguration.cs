using HostingFirmasıProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Configuration
{
    public class UrunConfigConfiguration : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasOne<Musteri>(x => x.Musteri)
                .WithMany(c => c.Urunler)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(b=> b.MusteriId)
                .IsRequired();

        }
    }
}
