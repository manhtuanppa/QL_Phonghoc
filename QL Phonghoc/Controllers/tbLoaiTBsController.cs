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
    public class tbLoaiTBsController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbLoaiTBs
        public ActionResult Index()
        {
            return View(db.tbLoaiTBs.ToList());
        }

        // GET: tbLoaiTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLoaiTB tbLoaiTB = db.tbLoaiTBs.Find(id);
            if (tbLoaiTB == null)
            {
                return HttpNotFound();
            }
            return View(tbLoaiTB);
        }

        // GET: tbLoaiTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbLoaiTBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoaiTB")] tbLoaiTB tbLoaiTB)
        {
            if (ModelState.IsValid)
            {
                db.tbLoaiTBs.Add(tbLoaiTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbLoaiTB);
        }

        // GET: tbLoaiTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLoaiTB tbLoaiTB = db.tbLoaiTBs.Find(id);
            if (tbLoaiTB == null)
            {
                return HttpNotFound();
            }
            return View(tbLoaiTB);
        }

        // POST: tbLoaiTBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoaiTB")] tbLoaiTB tbLoaiTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbLoaiTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbLoaiTB);
        }

        // GET: tbLoaiTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLoaiTB tbLoaiTB = db.tbLoaiTBs.Find(id);
            if (tbLoaiTB == null)
            {
                return HttpNotFound();
            }
            return View(tbLoaiTB);
        }

        // POST: tbLoaiTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbLoaiTB tbLoaiTB = db.tbLoaiTBs.Find(id);
            db.tbLoaiTBs.Remove(tbLoaiTB);
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
