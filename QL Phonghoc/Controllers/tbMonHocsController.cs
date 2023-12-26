using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_Phonghoc.Models;

namespace QL_Phonghoc.Controllers
{
    public class tbMonHocsController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbMonHocs
        public ActionResult Index()
        {
            return View(db.tbMonHocs.ToList());
        }

        // GET: tbMonHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMonHoc tbMonHoc = db.tbMonHocs.Find(id);
            if (tbMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbMonHoc);
        }

        // GET: tbMonHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbMonHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenMH,KiHieuMH")] tbMonHoc tbMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.tbMonHocs.Add(tbMonHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbMonHoc);
        }

        // GET: tbMonHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMonHoc tbMonHoc = db.tbMonHocs.Find(id);
            if (tbMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbMonHoc);
        }

        // POST: tbMonHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenMH,KiHieuMH")] tbMonHoc tbMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbMonHoc);
        }

        // GET: tbMonHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMonHoc tbMonHoc = db.tbMonHocs.Find(id);
            if (tbMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbMonHoc);
        }

        // POST: tbMonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMonHoc tbMonHoc = db.tbMonHocs.Find(id);
            db.tbMonHocs.Remove(tbMonHoc);
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
