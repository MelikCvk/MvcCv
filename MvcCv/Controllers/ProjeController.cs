using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;
using PagedList;
namespace MvcCv.Controllers
{
    public class ProjeController : AuthController
    {
        GenericRepository<TblProjelerim> repo = new GenericRepository<TblProjelerim>();
        public ActionResult Index(int page = 1)
        {
            var projeler = repo.TList().ToPagedList(page, 5);
            return View(projeler);
        }

        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjeEkle(TblProjelerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            TblProjelerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            TblProjelerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult ProjeGetir(TblProjelerim p)
        {
            TblProjelerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Aciklama = p.Aciklama;
            t.Teknolojiler = p.Teknolojiler;
            t.GitHubLink = p.GitHubLink;
            t.DemoLink = p.DemoLink;
            t.Gorsel = p.Gorsel;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}