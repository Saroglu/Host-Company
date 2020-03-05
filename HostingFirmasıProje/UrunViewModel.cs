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
        public int Id { get; set; }

        [Required]
        public string DomainAdi { get; set; }

        public int MusteriId { get; set; }

        public DateTime DomainBasTarihi { get; set; }

        [Required]
        public DateTime? DomainBitisTarihi { get; set; }

        public string PanelFtpBilgi { get; set; }

        public DateTime HostingBasTarihi { get; set; }

        public int? Kalan { get; set; }

        [Required]
        public DateTime? HostingBitisTarihi { get; set; }

        [Required]
        public string BayiAdi { get; set; }


    }
}
