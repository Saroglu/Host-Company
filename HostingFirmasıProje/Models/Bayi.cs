using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Models
{
    public class Bayi : BaseModel
    {
        [Required]
        public string BayiAdi { get; set; }

        public virtual ICollection<Musteri> Musteriler { get; set; }
    }
}
