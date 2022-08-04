using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineOtomasyonSystem.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "varChar")]
        [StringLength(10)]
        public string KullaniciAD { get; set; }

        [Column(TypeName = "varChar")]
        [StringLength(10)]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}