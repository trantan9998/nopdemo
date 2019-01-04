using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;

namespace websiteBALO.Areas.adminbalo.Controllers
{
    public class NHANVIENsController : Controller
    {
        private websitebaloEntities1 db = new websitebaloEntities1();

        // GET: adminbalo/NHANVIENs
        public ActionResult Index()
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");

            var nHANVIENs = db.NHANVIENs.Include(n => n.PHONGBAN).Include(n => n.TRINHDOHOCVAN);
            return View(nHANVIENs.ToList());
        }

        // GET: adminbalo/NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: adminbalo/NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");

            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs, "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDoHocVan_MTDHV = new SelectList(db.TRINHDOHOCVANs, "MaTDHV", "TenTDHV");
            return View();
        }
        // AD MIN LAYOUT ĐÂU MÀ NÓ CHẠY ĐC
        // POST: adminbalo/NHANVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,Ho,Ten,NgaySinh,QueQuan,created_at,updated_at,TrinhDoHocVan_MTDHV,PhongBan_MPB")] NHANVIEN nHANVIEN)
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");

            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs, "MaPhongBan", "TenPhongBan", nHANVIEN.PhongBan_MPB);
            ViewBag.TrinhDoHocVan_MTDHV = new SelectList(db.TRINHDOHOCVANs, "MaTDHV", "TenTDHV", nHANVIEN.TrinhDoHocVan_MTDHV);
            return View(nHANVIEN);
        }

        // GET: adminbalo/NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs, "MaPhongBan", "TenPhongBan", nHANVIEN.PhongBan_MPB);
            ViewBag.TrinhDoHocVan_MTDHV = new SelectList(db.TRINHDOHOCVANs, "MaTDHV", "TenTDHV", nHANVIEN.TrinhDoHocVan_MTDHV);
            return View(nHANVIEN);
        }

        // POST: adminbalo/NHANVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,Ho,Ten,NgaySinh,QueQuan,created_at,updated_at,TrinhDoHocVan_MTDHV,PhongBan_MPB")] NHANVIEN nHANVIEN)
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");

            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs, "MaPhongBan", "TenPhongBan", nHANVIEN.PhongBan_MPB);
            ViewBag.TrinhDoHocVan_MTDHV = new SelectList(db.TRINHDOHOCVANs, "MaTDHV", "TenTDHV", nHANVIEN.TrinhDoHocVan_MTDHV);
            return View(nHANVIEN);
        }

        // GET: adminbalo/NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: adminbalo/NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
