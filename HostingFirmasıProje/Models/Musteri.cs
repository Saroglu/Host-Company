using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Models
{
    public class Musteri : BaseModel
    {
        public string MusteriAdi { get; set; }

        [ForeignKey("Bayi")]
        public int BayiId { get; set; }

        public virtual Bayi Bayi { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}
