using MvcCv.Models.Entity;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcCv.Controllers
{
    [AllowAnonymous]
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
        public PartialViewResult Projeler()
        {
            var projeler = db.TblProjelerim.ToList();
            return PartialView(projeler);
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
        public ActionResult CvSayfa()
        {
            var model = db.TblHakkimda.FirstOrDefault();

            ViewBag.Deneyimler = db.TblDeneyimlerim.ToList();
            ViewBag.Egitimler = db.TblEgitimlerim.ToList();
            ViewBag.Yetenekler = db.TblYeteneklerim.ToList();
            ViewBag.Projeler = db.TblProjelerim.ToList();
            ViewBag.Sertifikalar = db.TblSertifikalarim.ToList();
            ViewBag.SosyalMedya = db.TblSosyalMedya.ToList();

            return View(model);
        }

        public ActionResult CvIndir()
        {
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 794;

            converter.Options.MarginTop = 0;
            converter.Options.MarginBottom = 0;
            converter.Options.MarginLeft = 0;
            converter.Options.MarginRight = 0;

            converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
            converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;

            string url = Url.Action("CvSayfa", "Default", null, Request.Url.Scheme);

            PdfDocument doc = converter.ConvertUrl(url);
            byte[] pdf = doc.Save();
            doc.Close();

            return File(pdf, "application/pdf", "MelikCevik-CV.pdf");
        }
    }
}