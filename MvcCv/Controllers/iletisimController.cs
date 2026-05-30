using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using PagedList;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();
        public ActionResult Index(int page = 1)
        {
            // 1. Veriyi en yeniye göre sırala
            var siraliMesajlar = repo.TList().OrderByDescending(x => x.Tarih);
            var sayfalanmisMesajlar = siraliMesajlar.ToPagedList(page, 5);

            return View(sayfalanmisMesajlar);
        }
    }
}