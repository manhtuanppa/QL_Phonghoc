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
    public class tbThietbisController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbThietbis
        public ActionResult Index()
        {
            var tbThietbis = db.tbThietbis.Include(t => t.tbLoaiTB).Include(t => t.tbPhongHoc);
            tbThietbis = tbThietbis.OrderBy(t => t.tbPhongHoc.TenPhong);
            //tbThietbis = tbThietbis.Where(t => t.tbPhongHoc.TenPhong.Equals("501")).ToList();
            //var tbPhongHocs = db.tbPhongHocs.ToList();
            //foreach (var p in tbPhongHocs)
            //{
            //    if (p.TenPhong != "501")
            //        foreach (var tb in tbThietbis)
            //        {
            //            tbThietbi tb1 = new tbThietbi();
            //            tb1.TenTTB = tb.TenTTB;
            //            tb1.IDLoaiTB = tb.IDLoaiTB;
            //            tb1.GhiChu = tb.GhiChu;
            //            tb1.SoLuong = tb.SoLuong;
            //            tb1.IDPhongHoc = p.ID;
            //            db.tbThietbis.Add(tb);
            //            db.SaveChanges();
            //        }
            //}

            return View(tbThietbis.ToList());
        }

        public ActionResult DanhSachThietBi(int idPhongHoc = 2)
        {
            var tbThietbis = db.tbThietbis.Include(t => t.tbLoaiTB).Include(t => t.tbPhongHoc);
            if (idPhongHoc >= 0)
            {
                tbThietbis = tbThietbis.Where(t => t.IDPhongHoc.Equals(idPhongHoc));
                tbPhongHoc tb = db.tbPhongHocs.Find(idPhongHoc);
                ViewBag.TenPhong = tb.TenPhong + " - " + tb.Toa + "(cơ sở " + tb.CoSo + ")";
            }

            List<ClsThietBi> Ltb = new List<ClsThietBi>();
            foreach (var p in tbThietbis)
            {
                ClsThietBi tb1 = new ClsThietBi();
                tb1.ID = p.ID;
                tb1.TenTTB = p.TenTTB;
                tb1.IDLoaiTB = p.IDLoaiTB;
                tb1.GhiChu = p.GhiChu;
                tb1.SoLuong = p.SoLuong;
                tb1.IDPhongHoc = p.ID;
                tb1.TinhTrang = "";
                var tt = db.tbTBHongs.Where(t => t.IDTB.Equals(tb1.ID)).Where(t=>t.TrangThai.Equals(1));
                foreach (var i in tt)
                {
                    tb1.TinhTrang += i.SoLuongHong.ToString() + " (" + i.MoTaBaoHong + "); ";
                }
                Ltb.Add(tb1);
            }
            var ph = db.tbPhongHocs.OrderBy(h=>h.TenPhong).OrderBy(h=>h.Toa);
            List<SelectListItem> IDPhongHoc = new List<SelectListItem>();
            foreach (var p in ph)
            {
                IDPhongHoc.Add(new SelectListItem { Text = p.TenPhong + "- " + p.Toa, Value = p.ID.ToString() });
            }
            
            ViewBag.IDPhongHoc = IDPhongHoc;
            return View(Ltb);
        }

        // GET: tbThietbis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbThietbi tbThietbi = db.tbThietbis.Find(id);
            if (tbThietbi == null)
            {
                return HttpNotFound();
            }
            return View(tbThietbi);
        }

        // GET: tbThietbis/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaiTB = new SelectList(db.tbLoaiTBs, "ID", "TenLoaiTB");
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong");
            return View();
        }

        // POST: tbThietbis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenTTB,SoLuong,IDLoaiTB,IDPhongHoc,GhiChu")] tbThietbi tbThietbi)
        {
            if (ModelState.IsValid)
            {
                db.tbThietbis.Add(tbThietbi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoaiTB = new SelectList(db.tbLoaiTBs, "ID", "TenLoaiTB", tbThietbi.IDLoaiTB);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbThietbi.IDPhongHoc);
            return View(tbThietbi);
        }

        // GET: tbThietbis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbThietbi tbThietbi = db.tbThietbis.Find(id);
            if (tbThietbi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaiTB = new SelectList(db.tbLoaiTBs, "ID", "TenLoaiTB", tbThietbi.IDLoaiTB);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbThietbi.IDPhongHoc);
            return View(tbThietbi);
        }

        // POST: tbThietbis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenTTB,SoLuong,IDLoaiTB,IDPhongHoc,GhiChu")] tbThietbi tbThietbi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbThietbi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoaiTB = new SelectList(db.tbLoaiTBs, "ID", "TenLoaiTB", tbThietbi.IDLoaiTB);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbThietbi.IDPhongHoc);
            return View(tbThietbi);
        }

        // GET: tbThietbis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbThietbi tbThietbi = db.tbThietbis.Find(id);
            if (tbThietbi == null)
            {
                return HttpNotFound();
            }
            return View(tbThietbi);
        }

        // POST: tbThietbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbThietbi tbThietbi = db.tbThietbis.Find(id);
            db.tbThietbis.Remove(tbThietbi);
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
