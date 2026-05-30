using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var t = repo.TList().FirstOrDefault();
            ViewBag.Gorsel = t?.Görsel;
            return View(t);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            if (p.ID == 0)
                return RedirectToAction("Index");

            var t = repo.Find(x => x.ID == p.ID);

            if (t == null)
                return RedirectToAction("Index");
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Görsel = p.Görsel;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}