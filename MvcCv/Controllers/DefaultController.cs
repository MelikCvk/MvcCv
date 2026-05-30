using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            ViewBag.Gorsel = db.TblHakkimda.FirstOrDefault()?.Görsel;
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var degrlr = db.TblSosyalMedya.ToList();
            return PartialView(degrlr);
        }
        public PartialViewResult Deneyim()
        {
            var degerlr = db.TblDeneyimlerim.ToList();
            return PartialView(degerlr);
        }
        public PartialViewResult Egitim()
        {
            var deger = db.TblEgitimlerim.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Yetenekler()
        {
            var dgr = db.TblYeteneklerim.ToList();
            return PartialView(dgr);
        }
        public PartialViewResult Hobiler()
        {
            var degr = db.TblHobilerim.ToList();
            return PartialView(degr);
        }
        public PartialViewResult Sertifikalar()
        {
            var dger = db.TblSertifikalarim.ToList();
            return PartialView(dger);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}