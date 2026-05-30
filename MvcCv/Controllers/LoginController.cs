using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var kullaici = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (kullaici != null)
            {
                Session["KullaniciAdi"] = kullaici.KullaniciAdi;
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre yanlış!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        } 
    }
}