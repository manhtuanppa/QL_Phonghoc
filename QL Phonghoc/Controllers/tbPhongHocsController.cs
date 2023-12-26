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
    public class tbPhongHocsController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbPhongHocs
        public ActionResult Index()
        {
            return View(db.tbPhongHocs.ToList());
        }

        public ActionResult DanhSachPhongHoc()
        {
            var tbPhongHocs = db.tbPhongHocs.OrderBy(p => p.TenPhong).OrderBy(p=>p.Toa).ToList();
            List<ClsPhongHoccs> lPhongHoc = new List<ClsPhongHoccs>();
            foreach (var p in tbPhongHocs)
            {
                ClsPhongHoccs p1 = new ClsPhongHoccs();
                p1.ID = p.ID;
                p1.TenPhong = p.TenPhong;
                p1.CoSo = p.CoSo;
                p1.DienTich = p.DienTich;
                p1.Toa = p.Toa;
                p1.GhiChu = p.GhiChu;
                var lp = db.tbLop_Phong.Where(l => l.IDPhongHoc.Equals(p.ID)).ToList();
                if (lp.Count() > 0)
                    p1.LopSudung = lp.First().tbLop.TenLop;
                var lh = from lhh in db.tbLich_Hoc
                         where lhh.IDPhongHoc == p.ID
                         select lhh;
                if (lh.Count() > 0)
                {
                    DateTime d = DateTime.Now;
                    foreach (var lh1 in lh)
                    {
                        if (lh1.Ngay == d.Date)
                        {
                            if ((d.Hour <= 12 && lh1.Buoi == 1) || (d.Hour > 12 && lh1.Buoi == 2))
                                p1.TrangThai = db.tbMonHocs.Find(lh1.IDMon).TenMH + " - " + lh1.GiaoVien;
                        }
                    }

                }
                    
                lPhongHoc.Add(p1);
            }
            return View(lPhongHoc);
        }

        // GET: tbPhongHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPhongHoc tbPhongHoc = db.tbPhongHocs.Find(id);
            if (tbPhongHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbPhongHoc);
        }

        // GET: tbPhongHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPhongHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhong,Tang,Toa,CoSo,DienTich,GhiChu")] tbPhongHoc tbPhongHoc)
        {
            if (ModelState.IsValid)
            {
                db.tbPhongHocs.Add(tbPhongHoc);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhongHoc");
            }

            return View(tbPhongHoc);
        }

        // GET: tbPhongHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPhongHoc tbPhongHoc = db.tbPhongHocs.Find(id);
            if (tbPhongHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbPhongHoc);
        }

        // POST: tbPhongHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenPhong,Tang,Toa,CoSo,DienTich,GhiChu")] tbPhongHoc tbPhongHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPhongHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbPhongHoc);
        }

        // GET: tbPhongHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPhongHoc tbPhongHoc = db.tbPhongHocs.Find(id);
            if (tbPhongHoc == null)
            {
                return HttpNotFound();
            }
            return View(tbPhongHoc);
        }

        // POST: tbPhongHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPhongHoc tbPhongHoc = db.tbPhongHocs.Find(id);
            db.tbPhongHocs.Remove(tbPhongHoc);
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
