using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Models
{
    public class Urun : BaseModel
    {
        public string DomainAdi { get; set; }

        [ForeignKey("Musteri")]
        [Required]
        public int? MusteriId { get; set; }

        public DateTime? DomainBasTarihi { get; set; }

        public DateTime? DomainBitisTarihi { get; set; }

        public string PanelFtpBilgi { get; set; }

        public DateTime? HostingBasTarihi { get; set; }

        public DateTime? HostingBitisTarihi { get; set; }

        public int? Kalan { get; set; }

        public string BayiAdi { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
