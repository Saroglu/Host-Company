using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Models
{
    public class Musteri : BaseModel
    {
        [Required]
        public string MusteriAdi { get; set; }

        public int BayiId { get; set; }

        public Bayi Bayi { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}
