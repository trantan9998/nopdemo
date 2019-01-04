using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;

namespace websiteBALO.Areas.adminbalo.Controllers
{
    public class nhanvienController : Controller
    {
        websitebaloEntities1 db = new websitebaloEntities1();
        //private object path;

        public ActionResult ADquanlysanpham()
        {
            return View(db.NHANVIENs.ToList());
        }

        [HttpGet]
        public ActionResult Them()
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");
            return View();
        }

        [HttpPost]
        public ActionResult Them(NHANVIEN nv)
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
            return RedirectToAction("ADquanlysanpham");
        }

        [HttpGet]
        public ActionResult Sua(string nhanvien)
        {
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");
            NHANVIEN nv = db.NHANVIENs.SingleOrDefault(n => n.MaNV == nhanvien);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Sua(NHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            ViewBag.PhongBan_MPB = new SelectList(db.PHONGBANs.ToList().OrderBy(n => n.TenPhongBan), "MaPhongBan", "TenPhongBan");
            ViewBag.TrinhDo_MTD = new SelectList(db.TRINHDOHOCVANs.ToList().OrderBy(n => n.TenTDHV), "MaTDHV", "TenTDHV");
            return RedirectToAction("ADquanlysanpham");
        }
        [HttpGet]
        public ActionResult Xoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(string nhanvien)
        {
            NHANVIEN nv = db.NHANVIENs.SingleOrDefault(n => n.MaNV == nhanvien);
            db.NHANVIENs.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("ADquanlysanpham");
        }

    }
}