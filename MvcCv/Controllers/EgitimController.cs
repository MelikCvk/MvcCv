using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

        
        public ActionResult Index()
        {
            var egitimler = repo.TList();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            TblEgitimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}