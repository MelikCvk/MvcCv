using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo= new GenericRepository<TblSertifikalarim> ();
        public ActionResult Index(int? page)
        {
            int sayfa = page ?? 1;

            var sertifika = repo.TList()
                .OrderBy(x => x.ID)
                .ToPagedList(sayfa, 4);

            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {           
            TblSertifikalarim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifikalarim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim se)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            TblSertifikalarim t = repo.Find(x => x.ID == se.ID);
            t.Aciklama = se.Aciklama;
            t.Tarih = se.Tarih;
            t.Görsel= se.Görsel;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}