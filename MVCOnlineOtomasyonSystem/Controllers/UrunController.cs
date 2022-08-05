using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineOtomasyonSystem.Models.Siniflar;

namespace MVCOnlineOtomasyonSystem.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            //Dropdown için oluşturuyoruz. 
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int Id)
        {
            //Dropdown için oluşturuyoruz. 
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var ktg = c.Uruns.Find(Id);
            return View("UrunGetir", ktg);
        }

        public ActionResult UrunGuncelle(Urun k)
        {
            var ktg = c.Uruns.Find(k.UrunID);
            ktg.UrunAd = k.UrunAd;
            ktg.UrunMarka = k.UrunMarka;
            ktg.Stok = k.Stok;
            ktg.AlisFiyat = k.AlisFiyat;
            ktg.SatisFiyat = k.SatisFiyat;
            ktg.Durum = k.Durum;
            ktg.UrunGorsel = k.UrunGorsel;
            ktg.KategoriId = k.KategoriId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}