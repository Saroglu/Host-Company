using HostingFirmasıProje.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje
{
    public class UrunViewModel
    {
        public string DomainAdi { get; set; }

        public int? MusteriId { get; set; }

        public DateTime DomainBasTarihi { get; set; }

        public DateTime DomainBitisTarihi { get; set; }

        public string PanelFtpBilgi { get; set; }

        public DateTime HostingBasTarihi { get; set; }

        public DateTime HostingBitisTarihi { get; set; }

        public int? Kalan { get; set; }

        public string BayiAdi { get; set; }

        public virtual Musteri Musteri { get; set; }

    }
}
