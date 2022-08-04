using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineOtomasyonSystem.Models.Siniflar;

namespace MVCOnlineOtomasyonSystem.Controllers
{
    public class KategoriController : Controller
    { 
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int Id)
        {
            var ktg = c.Kategoris.Find(Id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int Id)
        {
            var ktg = c.Kategoris.Find(Id);
            return View("KategoriGetir",ktg);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}