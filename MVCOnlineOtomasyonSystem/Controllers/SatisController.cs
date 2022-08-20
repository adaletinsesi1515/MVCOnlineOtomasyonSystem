using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineOtomasyonSystem.Models.Siniflar;

namespace MVCOnlineOtomasyonSystem.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.SatisHarekets.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
                            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.UrunAd,
                                                    Value = x.UrunID.ToString()
                                                }).ToList();
                ViewBag.dgr1 = urunler;

                List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CariAd + " " + x.CariSoyad,
                                                    Value = x.CariID.ToString()
                                                }).ToList();
                ViewBag.dgr2 = cariler;

                List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                        Value = x.PersonelID.ToString()
                                                    }).ToList();
                ViewBag.dgr3 = personeller;
                return View();
            
            
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket p)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.UrunAd,
                                                    Value = x.UrunID.ToString()
                                                }).ToList();
                ViewBag.dgr1 = urunler;

                List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CariAd + " " + x.CariSoyad,
                                                    Value = x.CariID.ToString()
                                                }).ToList();
                ViewBag.dgr2 = cariler;

                List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                        Value = x.PersonelID.ToString()
                                                    }).ToList();
                ViewBag.dgr3 = personeller;
                return View();
            }


            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ToplamTutar= p.Adet * p.Fiyat;

            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            ViewBag.dgr1 = urunler;

            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            ViewBag.dgr2 = cariler;

            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();
            ViewBag.dgr3 = personeller;

            var bul = c.SatisHarekets.Find(id);
            return View("SatisGetir", bul);
        }

        public ActionResult SatisHareketGuncelle(SatisHareket p)
        {
            var bul = c.SatisHarekets.Find(p.SatisID);
            bul.Tarih = p.Tarih;
            bul.Adet = p.Adet;
            bul.Fiyat = p.Fiyat;
            bul.ToplamTutar = p.Adet * p.Fiyat;           
            bul.UrunId= p.UrunId;
            bul.CariId = p.CariId;
            bul.PersonelId = p.PersonelId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}