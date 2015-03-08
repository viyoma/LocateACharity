using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileGmap.Controllers
{
    public class LocationController : Controller
    {
        private NGOMobEntities db = new NGOMobEntities();

        //
        // GET: /Location/

        public ActionResult Index()
        {
            return View(db.NGODetails.ToList());
        }

        //
        // GET: /Location/Details/5

        public ActionResult Details(long id = 0)
        {
            NGODetail ngodetail = db.NGODetails.Single(n => n.ID == id);
            if (ngodetail == null)
            {
                return HttpNotFound();
            }
            return View(ngodetail);
        }

        [HttpGet]
        public JsonResult LoadDetails()
        {
            return Json(db.NGODetails.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(NGODetail ngodetail)
        {
            if (ModelState.IsValid)
            {
                db.NGODetails.AddObject(ngodetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ngodetail);
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(long id = 0)
        {
            NGODetail ngodetail = db.NGODetails.Single(n => n.ID == id);
            if (ngodetail == null)
            {
                return HttpNotFound();
            }
            return View(ngodetail);
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(NGODetail ngodetail)
        {
            if (ModelState.IsValid)
            {
                db.NGODetails.Attach(ngodetail);
                db.ObjectStateManager.ChangeObjectState(ngodetail, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ngodetail);
        }

        //
        // GET: /Location/Delete/5

        public ActionResult Delete(long id = 0)
        {
            NGODetail ngodetail = db.NGODetails.Single(n => n.ID == id);
            if (ngodetail == null)
            {
                return HttpNotFound();
            }
            return View(ngodetail);
        }

        //
        // POST: /Location/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            NGODetail ngodetail = db.NGODetails.Single(n => n.ID == id);
            db.NGODetails.DeleteObject(ngodetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}