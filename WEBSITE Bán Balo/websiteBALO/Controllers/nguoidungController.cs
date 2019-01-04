using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using websiteBALO.Models;
using System.Web.Security;

namespace websiteBALO.Controllers
{
    public class nguoidungController : Controller
    {
        websitebaloEntities1 db = new websitebaloEntities1();
        // GET: nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangky(KHACHHANG kh)
        {
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            ViewBag.thongbao = "chúc mừng bạn đã đăng ký thành công 😃";
            return View();
        }

        [HttpGet]
        public ActionResult dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangnhap(FormCollection f)
        {
            string staikhoan = f["txttaikhoan"].ToString();
            string smatkhau = f["txtmatkhau"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.taikhoan == staikhoan && n.matkhau == smatkhau);

            if (kh != null)
            {
                Session["nguoidung"] = kh;
                Session["taikhoan"] = kh.taikhoan;
                Session["thongtin"] = kh.maKH;
                ViewBag.thongbao = "đăng nhập thành công";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.thongbao1 = "tên tài khoản và mật khẩu không đúng!";
            return View();
        }
        public ActionResult dangxuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}