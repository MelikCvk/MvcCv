using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var t = repo.TList().FirstOrDefault();
            return View(t);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            if (p.ID == 0)
                return RedirectToAction("Index");

            var t = repo.Find(x => x.ID == p.ID);

            if (t == null)
                return RedirectToAction("Index");

            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}