using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineOtomasyonSystem.Models.Siniflar;

namespace MVCOnlineOtomasyonSystem.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            c.Departmen.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int Id)
        {
            var deger = c.Departmen.Find(Id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int Id)
        {
            var ktg = c.Departmen.Find(Id);
            return View("DepartmanGetir", ktg);
        }

        public ActionResult DepartmanGuncelle(Departman k)
        {
            var ktg = c.Departmen.Find(k.DepartmanID);
            ktg.DepartmanAd = k.DepartmanAd;
            ktg.Durum = k.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}