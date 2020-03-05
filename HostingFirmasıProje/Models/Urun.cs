using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Models
{
    public class Urun : BaseModel
    {
        [Required]
        public string DomainAdi { get; set; }

        public int MusteriId { get; set; }

        public DateTime DomainBasTarihi { get; set; }

        [Required]
        public DateTime? DomainBitisTarihi { get; set; }

        public string PanelFtpBilgi { get; set; }

        public DateTime HostingBasTarihi { get; set; }

        [Required]
        public DateTime? HostingBitisTarihi { get; set; }

        public int? Kalan { get; set; }

        [Required]
        public string BayiAdi { get; set; }

        public Musteri Musteri { get; set; }
    }
}
