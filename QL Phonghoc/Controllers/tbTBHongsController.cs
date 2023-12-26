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
    public class tbTBHongsController : Controller
    {
        private QLPhongHocEntities db = new QLPhongHocEntities();

        // GET: tbTBHongs
        public ActionResult Index()
        {
            var tbTBHongs = db.tbTBHongs.Include(t => t.tbThietbi).Include(t => t.tbUser);
            return View(tbTBHongs.ToList());
        }

        public ActionResult DanhSachBaoHong()
        {
            var tbBaoHongTBs = db.tbTBHongs.Include(t => t.tbThietbi).Where(t=>t.TrangThai.Equals(0)).OrderByDescending(t => t.NgayBao);
            List<ClsThietBiBaoHong> lh = new List<ClsThietBiBaoHong>();
            foreach (var h in tbBaoHongTBs)
            {
                ClsThietBiBaoHong tbh = new ClsThietBiBaoHong();
                tbh.ID = h.ID;
                tbh.IDTB = h.IDTB;
                tbh.MoTaBaoHong = h.MoTaBaoHong;
                //tbh.NgayBao = h.NgayBao.HasValue? String.Format("{0:dd/MM/yyyy}", h.NgayBao.Value) : "";
                tbh.NgayBao = String.Format("{0:dd/MM/yyyy}", h.NgayBao);
                tbh.TrangThai = h.TrangThai;
                tbh.TenTTB = h.tbThietbi.TenTTB;
                tbh.SoLuongBao = h.SoLuongBao;
                tbh.NguoiBao = h.tbUser.UserName;
                tbh.PhongHoc = h.tbThietbi.tbPhongHoc.TenPhong + "- " + h.tbThietbi.tbPhongHoc.Toa;
                lh.Add(tbh);
            }
            return View(lh);
        }

        public ActionResult DanhSachThietBiHong()
        {
            var tbBaoHongTBs = db.tbTBHongs.Include(t => t.tbThietbi).Where(t => t.TrangThai.Equals(1)).OrderByDescending(t => t.NgayBao);
            List<ClsThietBiBaoHong> lh = new List<ClsThietBiBaoHong>();
            foreach (var h in tbBaoHongTBs)
            {
                ClsThietBiBaoHong tbh = new ClsThietBiBaoHong();
                tbh.ID = h.ID;
                tbh.IDTB = h.IDTB;
                tbh.MoTaBaoHong = h.MoTaBaoHong;
                //tbh.NgayBao = h.NgayBao.HasValue? String.Format("{0:dd/MM/yyyy}", h.NgayBao.Value) : "";
                tbh.NgayBao = String.Format("{0:dd/MM/yyyy}", h.NgayBao);
                tbh.TrangThai = h.TrangThai;
                tbh.TenTTB = h.tbThietbi.TenTTB;
                tbh.SoLuongHong = h.SoLuongHong;
                tbh.NguoiBao = h.tbUser.UserName;
                tbh.PhongHoc = h.tbThietbi.tbPhongHoc.TenPhong + "- " + h.tbThietbi.tbPhongHoc.Toa;
                lh.Add(tbh);
            }
            return View(lh);
        }

        public ActionResult LichSuSuaChua(int idPhongHoc = 0)
        {
            var tbBaoHongTBs = db.tbTBHongs.Include(t => t.tbThietbi).Where(t => t.TrangThai.Equals(2));
            if (idPhongHoc > 0)
            {
                tbBaoHongTBs = tbBaoHongTBs.Where(t => t.tbThietbi.IDPhongHoc.Equals(idPhongHoc));
                tbPhongHoc tb = db.tbPhongHocs.Find(idPhongHoc);
                ViewBag.TenPhong = tb.TenPhong + " - " + tb.Toa + "(cơ sở " + tb.CoSo + ")";
            }

            tbBaoHongTBs = tbBaoHongTBs.OrderByDescending(t => t.NgayBao);
            List<ClsThietBiBaoHong> lh = new List<ClsThietBiBaoHong>();
            foreach (var h in tbBaoHongTBs)
            {
                ClsThietBiBaoHong tbh = new ClsThietBiBaoHong();
                tbh.ID = h.ID;
                tbh.IDTB = h.IDTB;
                tbh.MoTaBaoHong = h.MoTaBaoHong;
                //tbh.NgayBao = h.NgayBao.HasValue? String.Format("{0:dd/MM/yyyy}", h.NgayBao.Value) : "";
                tbh.NgayBao = String.Format("{0:dd/MM/yyyy}", h.NgayBao);
                tbh.TrangThai = h.TrangThai;
                tbh.TenTTB = h.tbThietbi.TenTTB;
                tbh.SoLuongHong = h.SoLuongHong;
                tbh.NguoiBao = h.tbUser.UserName;
                tbh.PhongHoc = h.tbThietbi.tbPhongHoc.TenPhong + "- " + h.tbThietbi.tbPhongHoc.Toa;
                lh.Add(tbh);
            }

            var ph = db.tbPhongHocs.OrderBy(h => h.TenPhong).OrderBy(h => h.Toa);
            List<SelectListItem> IDPhongHoc = new List<SelectListItem>();
            IDPhongHoc.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
            foreach (var p in ph)
            {
                IDPhongHoc.Add(new SelectListItem { Text = p.TenPhong + "- " + p.Toa, Value = p.ID.ToString() });
            }

            ViewBag.IDPhongHoc = IDPhongHoc;
            return View(lh);
        }
        // GET: tbTBHongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTBHong tbTBHong = db.tbTBHongs.Find(id);
            if (tbTBHong == null)
            {
                return HttpNotFound();
            }
            return View(tbTBHong);
        }

        // GET: tbTBHongs/Create
        public ActionResult BaoHong()
        {
            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB");
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BaoHong([Bind(Include = "ID,IDTB,MoTaBaoHong,NgayBao,IDNguoiBao,TrangThai,SoLuongBao,SoLuongHong,SoLuongSua,NgaySua")] tbTBHong tbTBHong)
        {
            if (ModelState.IsValid)
            {
                tbTBHong.NgayBao = DateTime.Today;
                tbTBHong.TrangThai = 0;
                tbTBHong.IDNguoiBao = 1;
                tbTBHong.NgaySua = DateTime.Today;
                tbTBHong.SoLuongHong = tbTBHong.SoLuongBao;
                tbTBHong.SoLuongSua = tbTBHong.SoLuongBao;
                db.tbTBHongs.Add(tbTBHong);
                db.SaveChanges();
                return RedirectToAction("DanhSachBaoHong");
            }

            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB", tbTBHong.IDTB);
            ViewBag.IDPhongHoc = new SelectList(db.tbPhongHocs, "ID", "TenPhong");
            return View(tbTBHong);
        }


        public JsonResult GetTB(int idPhongHoc)
        {
            var tb = from t in db.tbThietbis
                     where t.IDPhongHoc == idPhongHoc
                     select new { ID = t.ID, Ten = t.TenTTB }; ;
            return Json(tb, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB");
            ViewBag.IDNguoiBao = new SelectList(db.tbUsers, "ID", "UserName");
            return View();
        }

        // POST: tbTBHongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDTB,MoTaBaoHong,NgayBao,IDNguoiBao,TrangThai,SoLuongBao,SoLuongHong,SoLuongSua,NgaySua")] tbTBHong tbTBHong)
        {
            if (ModelState.IsValid)
            {
                db.tbTBHongs.Add(tbTBHong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB", tbTBHong.IDTB);
            ViewBag.IDNguoiBao = new SelectList(db.tbUsers, "ID", "UserName", tbTBHong.IDNguoiBao);
            return View(tbTBHong);
        }

        // GET: tbBaoHongTBs/Details/5
        public ActionResult XacNhanHong(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTBHong tbTBHong = db.tbTBHongs.Find(id);
            if (tbTBHong == null)
            {
                return HttpNotFound();
            }
            return View(tbTBHong);
        }
        [HttpPost]
        public ActionResult XacNhanHong([Bind(Include = "ID,IDTB,MoTaBaoHong,NgayBao,IDNguoiBao,TrangThai,SoLuongBao,SoLuongHong,SoLuongSua,NgaySua")] tbTBHong tbTBHong)
        {
            if (ModelState.IsValid)
            {
                tbTBHong.NgayBao = DateTime.Today;
                tbTBHong.TrangThai = 1;
                db.Entry(tbTBHong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachBaoHong");
            }
            return View(tbTBHong);
        }

        // GET: tbTBHongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTBHong tbTBHong = db.tbTBHongs.Find(id);
            if (tbTBHong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB", tbTBHong.IDTB);
            ViewBag.IDNguoiBao = new SelectList(db.tbUsers, "ID", "UserName", tbTBHong.IDNguoiBao);
            return View(tbTBHong);
        }

        // POST: tbTBHongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDTB,MoTaBaoHong,NgayBao,IDNguoiBao,TrangThai,SoLuongBao,SoLuongHong,SoLuongSua,NgaySua")] tbTBHong tbTBHong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTBHong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTB = new SelectList(db.tbThietbis, "ID", "TenTTB", tbTBHong.IDTB);
            ViewBag.IDNguoiBao = new SelectList(db.tbUsers, "ID", "UserName", tbTBHong.IDNguoiBao);
            return View(tbTBHong);
        }

        // GET: tbTBHongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTBHong tbTBHong = db.tbTBHongs.Find(id);
            if (tbTBHong == null)
            {
                return HttpNotFound();
            }
            return View(tbTBHong);
        }

        // POST: tbTBHongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTBHong tbTBHong = db.tbTBHongs.Find(id);
            db.tbTBHongs.Remove(tbTBHong);
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
