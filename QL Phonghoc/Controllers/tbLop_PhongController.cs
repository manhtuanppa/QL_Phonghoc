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
    public class tbLop_PhongController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbLop_Phong
        public ActionResult Index()
        {
            var tbLop_Phong = db.tbLop_Phong.Include(t => t.tbLop).Include(t => t.tbPhongHoc);
            return View(tbLop_Phong.ToList());
        }

        // GET: tbLop_Phong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop_Phong tbLop_Phong = db.tbLop_Phong.Find(id);
            if (tbLop_Phong == null)
            {
                return HttpNotFound();
            }
            return View(tbLop_Phong);
        }

        // GET: tbLop_Phong/Create
        public ActionResult Create()
        {
            ViewBag.IDLop = new SelectList(db.tbLops, "ID", "TenLop");
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong");
            return View();
        }

        // POST: tbLop_Phong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDLop,IDPhongHoc,NgayBanGiao")] tbLop_Phong tbLop_Phong)
        {
            if (ModelState.IsValid)
            {
                db.tbLop_Phong.Add(tbLop_Phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLop = new SelectList(db.tbLops, "ID", "TenLop", tbLop_Phong.IDLop);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbLop_Phong.IDPhongHoc);
            return View(tbLop_Phong);
        }

        // GET: tbLop_Phong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop_Phong tbLop_Phong = db.tbLop_Phong.Find(id);
            if (tbLop_Phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLop = new SelectList(db.tbLops, "ID", "TenLop", tbLop_Phong.IDLop);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbLop_Phong.IDPhongHoc);
            return View(tbLop_Phong);
        }

        // POST: tbLop_Phong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDLop,IDPhongHoc,NgayBanGiao")] tbLop_Phong tbLop_Phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbLop_Phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLop = new SelectList(db.tbLops, "ID", "TenLop", tbLop_Phong.IDLop);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbLop_Phong.IDPhongHoc);
            return View(tbLop_Phong);
        }

        // GET: tbLop_Phong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLop_Phong tbLop_Phong = db.tbLop_Phong.Find(id);
            if (tbLop_Phong == null)
            {
                return HttpNotFound();
            }
            return View(tbLop_Phong);
        }

        // POST: tbLop_Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbLop_Phong tbLop_Phong = db.tbLop_Phong.Find(id);
            db.tbLop_Phong.Remove(tbLop_Phong);
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
