using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DEEPLAID.Models;
using DEEPLAID.Models.Master;

namespace DEEPLAID.Controllers.Admin
{
    public class SiteMenuController : Controller
    {
        private DeeplaidDbContext db = new DeeplaidDbContext();

        // GET: /SiteMenu/
        public ActionResult Index()
        {
            return View(db.SiteMenus.ToList());
        }

        // GET: /SiteMenu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteMenu sitemenu = db.SiteMenus.Find(id);
            if (sitemenu == null)
            {
                return HttpNotFound();
            }
            return View(sitemenu);
        }

        // GET: /SiteMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SiteMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Group,Name,ControllerName,ControllerAction,MenuPriority,Remarks")] SiteMenu sitemenu)
        {
            if (ModelState.IsValid)
            {
                db.SiteMenus.Add(sitemenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitemenu);
        }

        // GET: /SiteMenu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteMenu sitemenu = db.SiteMenus.Find(id);
            if (sitemenu == null)
            {
                return HttpNotFound();
            }
            return View(sitemenu);
        }

        // POST: /SiteMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Group,Name,ControllerName,ControllerAction,MenuPriority,Remarks")] SiteMenu sitemenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitemenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitemenu);
        }

        // GET: /SiteMenu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteMenu sitemenu = db.SiteMenus.Find(id);
            if (sitemenu == null)
            {
                return HttpNotFound();
            }
            return View(sitemenu);
        }

        // POST: /SiteMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteMenu sitemenu = db.SiteMenus.Find(id);
            db.SiteMenus.Remove(sitemenu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
