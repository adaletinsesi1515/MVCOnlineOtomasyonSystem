using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineOtomasyonSystem.Models.Siniflar;

namespace MVCOnlineOtomasyonSystem.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            c.Carilers.Add(p);
            p.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var deger = c.Carilers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var getir = c.Carilers.Find(id);
            return View("CariGetir",getir);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            //Validasyon kontrolü yaptık burada
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CariID);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            cari.Durum = p.Durum;            
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatis(int id)
        {
            //Departman adını başlığa taşıyoruz. 
            var dpt1 = c.Carilers.Where(x => x.CariID== id).Select(y => y.CariAd).FirstOrDefault();
            var dpt2 = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariSoyad).FirstOrDefault();
            ViewBag.dpt1 = dpt1;
            ViewBag.dpt2 = dpt2;

            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

    }
}