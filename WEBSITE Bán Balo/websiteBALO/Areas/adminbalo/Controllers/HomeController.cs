using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace websiteBALO.Areas.adminbalo.Controllers
{
    public class HomeController : Controller
    {
        websitebaloEntities1 db = new websitebaloEntities1();
        //private object path;

        public ActionResult ADquanlysanpham()
        {
            return View(db.SANPHAMs.ToList());
        }

        [HttpGet]
        public ActionResult Them()
        {
            ViewBag.Machude = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.tenchude), "machude", "tenchude");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tenNSX), "maNSX", "tenNSX");
            return View();
        }

        [HttpPost]
        public ActionResult Them(SANPHAM sp)
        {
            ViewBag.Machude = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.tenchude), "machude", "tenchude");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tenNSX), "maNSX", "tenNSX");
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("ADquanlysanpham");
        }

        [HttpGet]
        public ActionResult Sua(int Mabalo)
        {
            ViewBag.Machude = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.tenchude), "machude", "tenchude");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tenNSX), "maNSX", "tenNSX");
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.Mabalo == Mabalo);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Sua(SANPHAM sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            ViewBag.Machude = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.tenchude), "machude", "tenchude", sp.machude);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tenNSX), "maNSX", "tenNSX", sp.maNSX);
            return RedirectToAction("ADquanlysanpham");
        }
        [HttpGet]
        public ActionResult Xoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(int Mabalo)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.Mabalo == Mabalo);
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("ADquanlysanpham");
        }

    }
}