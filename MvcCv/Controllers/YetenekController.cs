using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler= repo.TList();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim y)
        {
            repo.TAdd(y);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
         public ActionResult YetenekGetir(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult YetenekGetir(TblYeteneklerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("YetenekGetir");
            }
            var yet = repo.Find(x => x.ID == t.ID);
            yet.Yetenek = t.Yetenek;
            yet.Oran = t.Oran;
            repo.TUpdate(yet);
            return RedirectToAction("Index");
        }
    }
}