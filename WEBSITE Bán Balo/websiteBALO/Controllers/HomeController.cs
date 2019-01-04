using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;

namespace websiteBALO.Controllers
{
    public class HomeController : Controller
    {

        websitebaloEntities1 db = new websitebaloEntities1();
        public PartialViewResult balomoipartial()
        {
            //tạo biến số sản phẩm trên trang           
            var lstbalomoi = db.SANPHAMs.Take(8).ToList();
            return PartialView(lstbalomoi);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult timkiem(string timkiem)
        {
            return View(db.SANPHAMs.Where(x => x.Tenbalo.Contains(timkiem) || timkiem == null).ToList());
        }

        public ViewResult balolaptop()
        {
            return View();
        }
        public ActionResult balothoitrang()
        {
            return View();
        }
        public ActionResult balothethao()
        {
            return View();
        }

        public ActionResult tuixach()
        {
            return View();
        }
        public ActionResult gioithieu()
        {
            return View();
        }


        public ViewResult xemchitiet(int mabalo = 0)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(m => m.Mabalo == mabalo);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        public ViewResult ThongTinNguoiDung(int? ID)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.maKH == ID);
            return View(kh);
        }
        [HttpGet]
        public ActionResult Sua(int ID)
        {
            KHACHHANG p = db.KHACHHANGs.SingleOrDefault(n => n.maKH == ID);
            return View(p);
        }
        [HttpPost]
        public ActionResult Sua(KHACHHANG c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ThongTinNguoiDung", new { @ID = c.maKH });
        }
    }
}