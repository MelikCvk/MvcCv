using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyalMedya = repo.TList();
            return View(sosyalMedya);
        }

        [HttpGet]
        public ActionResult YeniSosyalMedya()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSosyalMedya(TblSosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya so = repo.Find(x => x.ID == id);
            repo.TDelete(so);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            TblSosyalMedya s = repo.Find(x => x.ID == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya se)
        {
            if (!ModelState.IsValid)
            {
                return View("SosyalMedyaGetir");
            }
            var sosyalMedya = repo.Find(x => x.ID == se.ID);
            sosyalMedya.Ad = se.Ad;
            sosyalMedya.Link = se.Link;
            sosyalMedya.ikon = se.ikon;
            repo.TUpdate(sosyalMedya);
            return RedirectToAction("Index");
        }
    }
}