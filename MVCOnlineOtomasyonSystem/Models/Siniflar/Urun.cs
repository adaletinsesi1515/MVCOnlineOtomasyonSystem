using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineOtomasyonSystem.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        
        [Column(TypeName = "varChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "varChar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }

        public int Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "varChar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}