using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineOtomasyonSystem.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }

        [Required]
        public int Adet { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
        [Required]
        public decimal ToplamTutar { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        public int CariId { get; set; }
        public virtual Cariler Cariler { get; set; }

        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
    }
}