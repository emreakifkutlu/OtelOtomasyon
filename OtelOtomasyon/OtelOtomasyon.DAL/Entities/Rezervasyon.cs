using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
  public  class Rezervasyon:BaseEntity
    {
        public int Id { get; set; }
        public int OdaId { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int MusteriId { get; set; }
        public Boolean RezerveMi { get; set; }
    

        public virtual Oda Odalar { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
