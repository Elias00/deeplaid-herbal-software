using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DEEPLAID.Models.Master;
using DEEPLAID.Models;

namespace DEEPLAID.Controllers.Admin
{
    public class UserProfileController : Controller
    {
        private DeeplaidDbContext db = new DeeplaidDbContext();

        // GET: /UserProfile/
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        // GET: /UserProfile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // GET: /UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Remarks")] UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        // GET: /UserProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // POST: /UserProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Remarks")] UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        // GET: /UserProfile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // POST: /UserProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userprofile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProfileUsers(int id)
        {
            List<User> users = db.Users.ToList();
            var profileUsers = from u in users where u.UserProfileId == id select u;
            UserProfile userprofile = db.UserProfiles.Find(id);
            ViewBag.ProfileName = userprofile.Name;
            return View(profileUsers.ToList());
        }

        // GET: /UserProfile/Create
        [HttpGet]
        public ActionResult AddSiteMenu(int? id)
        {
            ViewBag.UserProfileId = id;
            //ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Name", id);
            ViewBag.SiteMenuId = new SelectList(db.SiteMenus, "Id", "Name");
            return View();
        }

        // GET: /UserProfile/Create
        [HttpPost]
        public ActionResult AddSiteMenu([Bind(Include = "id,SiteMenuId,UserProfileId")] UserProfileSiteMenu userProfileSiteMenu)
        {
            if (ModelState.IsValid)
            {
                db.UserProfileSiteMenus.Add(userProfileSiteMenu);
                db.SaveChanges();
                return RedirectToAction("Details",new {@id=userProfileSiteMenu.UserProfileId});
            }
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Name", userProfileSiteMenu.UserProfileId);
            ViewBag.SiteMenuId = new SelectList(db.SiteMenus, "Id", "Name", userProfileSiteMenu.SiteMenuId);
            return View();
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
