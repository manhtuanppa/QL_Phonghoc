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
    public class tbLich_HocController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbLich_Hoc
        public ActionResult Index()
        {

            return View(db.tbLich_Hoc.ToList());
        }

        public ActionResult XemLichHoc(int ngay = 0, int thang = 0, int nam = 0)
        {

            DateTime d = DateTime.Today;
            if (ngay == 0) ngay = d.Day;
            if (thang == 0) thang = d.Month;
            if (nam == 0) nam = d.Year;
            DateTime d1;
            try
            {
                d1 = new DateTime(nam, thang, ngay);
            }
            catch
            {
                d1 = d;
            }
            var tbLichHoc = from lh in db.tbLich_Hoc
                            where lh.Ngay.Equals(d1)
                            join l in db.tbLops on lh.IDLop equals l.ID
                            orderby lh.Buoi, l.TenLop
                            select lh;
            ViewBag.ngay = d1.Day;
            ViewBag.thang = d1.Month;
            ViewBag.nam = d1.Year;
            return View(tbLichHoc);
        }
        // GET: tbLich_Hoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLich_Hoc tbLich_Hoc = db.tbLich_Hoc.Find(id);
            if (tbLich_Hoc == null)
            {
                return HttpNotFound();
            }
            return View(tbLich_Hoc);
        }

        // GET: tbLich_Hoc/Create
        public ActionResult Create()
        {
            var l = db.tbLops.OrderBy(h => h.TenLop);
            List<SelectListItem> IDLop = new List<SelectListItem>();
            foreach (var p in l)
            {
                IDLop.Add(new SelectListItem { Text = p.TenLop, Value = p.ID.ToString() });
            }
            IDLop.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDLop = IDLop;

            var ph = db.tbPhongHocs.OrderBy(h => h.TenPhong).OrderBy(h => h.Toa);
            List<SelectListItem> IDPhongHoc = new List<SelectListItem>();
            foreach (var p in ph)
            {
                IDPhongHoc.Add(new SelectListItem { Text = p.TenPhong + " - " + p.Toa, Value = p.ID.ToString() });
            }
            IDPhongHoc.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDPhongHoc = IDPhongHoc;

            var m = db.tbMonHocs.OrderBy(h => h.KiHieuMH);
            List<SelectListItem> IDMon = new List<SelectListItem>();
            foreach (var p in m)
            {
                IDMon.Add(new SelectListItem { Text = p.KiHieuMH +  " - " + p.TenMH, Value = p.ID.ToString() });
            }
            IDMon.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDMon = IDMon;

            return View();
        }

        // POST: tbLich_Hoc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDLop,DonViSuDung,IDPhongHoc,DiaDiemHoc,IDMon,MucDichSuDung,GiaoVien,Ngay,Buoi,SoTiet,TietBD")] tbLich_Hoc tbLich_Hoc)
        {
            if (ModelState.IsValid)
            {
                db.tbLich_Hoc.Add(tbLich_Hoc);
                db.SaveChanges();
                return RedirectToAction("XemLichHoc");
            }
            ViewBag.IDLop = new SelectList(db.tbLops, "ID", "TenLop", tbLich_Hoc.IDLop);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong", tbLich_Hoc.IDPhongHoc);
            ViewBag.IDMon = new SelectList(db.tbMonHocs, "ID", "TenMH", tbLich_Hoc.IDMon);
            return View(tbLich_Hoc);
        }

        // GET: tbLich_Hoc/Create
        public ActionResult NhapLichHoc()
        {
            var l = db.tbLops.OrderBy(h => h.TenLop);
            List<SelectListItem> IDLop = new List<SelectListItem>();
            foreach (var p in l)
            {
                IDLop.Add(new SelectListItem { Text = p.TenLop, Value = p.ID.ToString() });
            }
            IDLop.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDLop = IDLop;

            var ph = db.tbPhongHocs.OrderBy(h => h.TenPhong).OrderBy(h => h.Toa);
            List<SelectListItem> IDPhongHoc = new List<SelectListItem>();
            foreach (var p in ph)
            {
                IDPhongHoc.Add(new SelectListItem { Text = p.TenPhong + " - " + p.Toa, Value = p.ID.ToString() });
            }
            IDPhongHoc.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDPhongHoc = IDPhongHoc;


            var m = db.tbMonHocs.OrderBy(h => h.KiHieuMH);
            List<SelectListItem> IDMon = new List<SelectListItem>();
            foreach (var p in m)
            {
                IDMon.Add(new SelectListItem { Text = p.KiHieuMH + " - " + p.TenMH, Value = p.ID.ToString() });
            }
            IDMon.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDMon = IDMon;

            
            return View();
        }

        // POST: tbLich_Hoc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapLichHoc([Bind(Include = "ID,IDLop,DonViSuDung,IDPhongHoc,DiaDiemHoc,IDMon,MucDichSuDung,GiaoVien,Ngay,Buoi,SoTiet,TietBD")] tbLich_Hoc tbLich_Hoc)
        {
            if (ModelState.IsValid)
            {
                //tbLich_Hoc.DonViSuDung = db.tbLops.Find(tbLich_Hoc.IDLop).TenLop;
                //tbLich_Hoc.DiaDiemHoc = db.tbPhongHocs.Find(tbLich_Hoc.IDPhongHoc).TenPhong +"- "+ db.tbPhongHocs.Find(tbLich_Hoc.IDPhongHoc).Toa;
                //tbLich_Hoc.MucDichSuDung = db.tbMonHocs.Find(tbLich_Hoc.IDMon).TenMH;
                db.tbLich_Hoc.Add(tbLich_Hoc);
                db.SaveChanges();
            }
            var l = db.tbLops.OrderBy(h => h.TenLop);
            List<SelectListItem> IDLop = new List<SelectListItem>();
            foreach (var p in l)
            {
                IDLop.Add(new SelectListItem { Text = p.TenLop, Value = p.ID.ToString() });
            }
            IDLop.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDLop = IDLop;

            var ph = db.tbPhongHocs.OrderBy(h => h.TenPhong).OrderBy(h => h.Toa);
            List<SelectListItem> IDPhongHoc = new List<SelectListItem>();
            foreach (var p in ph)
            {
                IDPhongHoc.Add(new SelectListItem { Text = p.TenPhong + " - " + p.Toa, Value = p.ID.ToString() });
            }
            IDPhongHoc.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDPhongHoc = IDPhongHoc;

            var m = db.tbMonHocs.OrderBy(h => h.KiHieuMH);
            List<SelectListItem> IDMon = new List<SelectListItem>();
            foreach (var p in m)
            {
                IDMon.Add(new SelectListItem { Text = p.KiHieuMH + " - " + p.TenMH, Value = p.ID.ToString() });
            }
            IDMon.Add(new SelectListItem { Text = "Khác", Value = "0" });
            ViewBag.IDMon = IDMon;
            return View(tbLich_Hoc);
        }
        // GET: tbLich_Hoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLich_Hoc tbLich_Hoc = db.tbLich_Hoc.Find(id);
            if (tbLich_Hoc == null)
            {
                return HttpNotFound();
            }
            return View(tbLich_Hoc);
        }

        // POST: tbLich_Hoc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDLop,DonViSuDung,IDPhongHoc,DiaDiemHoc,IDMon,MucDichSuDung,GiaoVien,Ngay,Buoi,SoTiet,TietBD")] tbLich_Hoc tbLich_Hoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbLich_Hoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("XemLichHoc");
            }
            return View(tbLich_Hoc);
        }

        // GET: tbLich_Hoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbLich_Hoc tbLich_Hoc = db.tbLich_Hoc.Find(id);
            if (tbLich_Hoc == null)
            {
                return HttpNotFound();
            }
            return View(tbLich_Hoc);
        }

        // POST: tbLich_Hoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbLich_Hoc tbLich_Hoc = db.tbLich_Hoc.Find(id);
            db.tbLich_Hoc.Remove(tbLich_Hoc);
            db.SaveChanges();
            return RedirectToAction("XemLichHoc");
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
