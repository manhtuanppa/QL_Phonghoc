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
    public class tbLopsController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbLops
        public ActionResult Index()
        {
            return View(db.tbLops.ToList());
        }

        // GET: tbLops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop tbLop = db.tbLops.Find(id);
            if (tbLop == null)
            {
                return HttpNotFound();
            }
            return View(tbLop);
        }

        // GET: tbLops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbLops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLop,NamNhapHoc,HeDT")] tbLop tbLop)
        {
            if (ModelState.IsValid)
            {
                db.tbLops.Add(tbLop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbLop);
        }

        // GET: tbLops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop tbLop = db.tbLops.Find(id);
            if (tbLop == null)
            {
                return HttpNotFound();
            }
            return View(tbLop);
        }

        // POST: tbLops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLop,NamNhapHoc,HeDT")] tbLop tbLop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbLop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbLop);
        }

        // GET: tbLops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop tbLop = db.tbLops.Find(id);
            if (tbLop == null)
            {
                return HttpNotFound();
            }
            return View(tbLop);
        }

        // POST: tbLops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbLop tbLop = db.tbLops.Find(id);
            db.tbLops.Remove(tbLop);
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
