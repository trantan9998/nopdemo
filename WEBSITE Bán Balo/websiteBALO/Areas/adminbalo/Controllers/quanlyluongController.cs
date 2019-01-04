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
    public class quanlyluongController : Controller
    //     public class quanlyluongController : AuthorController
    {
        websitebaloEntities1 db = new websitebaloEntities1();
        //
        // GET: /admin/quanlyluong/
        public ActionResult Index()
        {
            var list = db.LUONGs.ToList();
            return View(list);
        }
        //[HttpGet]
        //public ActionResult SuaBangLuong(String id)
        //{
        //    var luong = db.LUONGs.Where(n => n.MaNhanVien == id).SingleOrDefault();
        //    return View(luong)
        //}
        //[HttpPost]
        //public ActionResult SuaBangLuong(LUONG luong, CapNhatLuong up)
        //{
        //    var l = db.Luongs.Where(n => n.MaNhanVien == luong.MaNhanVien).FirstOrDefault();
        //    if (l != null)
        //    {
        //        //  l.MaNhanVien = luong.MaNhanVien;
        //        if (int.Parse(up.LuongSauCapNhat.ToString()) != 0)
        //        {
        //            l.LuongToiThieu = up.LuongSauCapNhat;
        //        }

        //        l.BHXH = luong.BHXH == null ? 0 : luong.BHXH;
        //        l.BHYT = luong.BHYT == null ? 0 : luong.BHYT;
        //        l.BHTN = luong.BHTN == null ? 0 : luong.BHTN;
        //        //   l.PhuCap = luong.PhuCap;
        //        l.HeSoLuong = luong.HeSoLuong;
        //        l.SoNgayDiLam = luong.SoNgayDiLam;

        //        //tao table luu lai moi lan cap nhat luong
        //        CapNhatLuong capNhat = new CapNhatLuong();
        //        capNhat.NgayCapNhat = DateTime.Now.Date;
        //        capNhat.MaNhanVien = luong.MaNhanVien;
        //        capNhat.LuongHienTai = luong.LuongToiThieu;
        //        capNhat.LuongSauCapNhat = up.LuongSauCapNhat;
        //        capNhat.BHXH = luong.BHXH;
        //        capNhat.BHYT = luong.BHYT;
        //        capNhat.BHTN = luong.BHTN;
        //        capNhat.SoNgayDiLam = luong.SoNgayDiLam;
        //        //  capNhat.PhuCap = luong.PhuCap;
        //        capNhat.HeSoLuong = luong.HeSoLuong;

        //        db.CapNhatLuongs.Add(capNhat);
        //        db.SaveChanges();
        //    }

        //    return Redirect("/admin/quanlyluong");
        //}
        //end update lương

        public ActionResult ThanhToanLuong()
        {
            var ctll = db.LUONGs.ToList();

            db.LUONGs.RemoveRange(ctll);
            db.SaveChanges();

            var nhanvien = db.NHANVIENs.ToList();
            LUONG lu = new LUONG();

            DateTime now = DateTime.Now;
            foreach(var nv in nhanvien)
            {
                lu.BHTN = 10;
                lu.BHXH = 2;
                lu.BHYT = 5;
                if(nv.TrinhDoHocVan_MTDHV == "TD01")
                {
                    lu.LuongToiThieu = 3000;
                    lu.HeSoLuong = 2;
                }
                else
                {
                    lu.LuongToiThieu = 1000;
                    lu.HeSoLuong = 1;
                }
                
                lu.PhuCap = 10;
                lu.SoNgayDiLam = 2;

                float tong = 0;
                lu.TongLuong = (tong + lu.LuongToiThieu - (double)(lu.BHXH + lu.BHYT + lu.BHTN) + (double)lu.PhuCap) / 26 * (int)lu.SoNgayDiLam;

                lu.NhanVien_MNV = nv.MaNV;
                db.LUONGs.Add(lu);
                db.SaveChanges();
            }
            return Redirect("/adminbalo/quanlyluong");
        }


        //public ActionResult ThanhToanMotNhanVien(String id)
        //{
        //    var nv = db.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
        //    if (nv != null)
        //    {
        //        //tim xem da co trong chi tiet lương chưa
        //        //var ctl = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).FirstOrDefault();
        //        //tìm bảng lương tương ứng với nhân viên
        //        var luongthang = db.LUONGs.Where(n => n.MaNhanVien == id).FirstOrDefault();
        //        ChiTietLuong ct = new ChiTietLuong();
        //        DateTime now = DateTime.Now;
        //        double tong = 0, phucap = 0;

        //        ct.MaChiTietBangLuong = "t" + now.Month.ToString();
        //        ct.MaNhanVien = luongthang.MaNhanVien;

        //        ct.LuongCoBan = luongthang.LuongToiThieu * (double)luongthang.HeSoLuong;

        //        luongthang.BHXH = luongthang.BHXH == null ? 0 : luongthang.BHXH;
        //        ct.BHXH = luongthang.BHXH * luongthang.LuongToiThieu / 100;

        //        luongthang.BHYT = luongthang.BHYT == null ? 0 : luongthang.BHYT;
        //        ct.BHYT = luongthang.BHYT * luongthang.LuongToiThieu / 100;

        //        luongthang.BHTN = luongthang.BHTN == null ? 0 : luongthang.BHTN;
        //        ct.BHTN = luongthang.BHTN * luongthang.LuongToiThieu / 100;

        //        luongthang.PhuCap = luongthang.PhuCap == null ? 0 : luongthang.PhuCap;
        //        phucap = (float)(luongthang.LuongToiThieu * (double)luongthang.PhuCap);
        //        ct.PhuCap = phucap;

        //        luongthang.SoNgayDiLam = luongthang.SoNgayDiLam == null ? 1 : luongthang.SoNgayDiLam;
        //        ct.SoNgayDiLam = luongthang.SoNgayDiLam;

        //        ct.NgayNhanLuong = DateTime.Now.Date;
        //        ct.TienThuong = 0;
        //        ct.TienPhat = 0;
        //        tong = (float)((tong + ct.LuongCoBan - (double)(ct.BHXH + ct.BHYT + ct.BHTN) + (double)ct.PhuCap) / 26 * (int)ct.SoNgayDiLam);
        //        ct.TongTienLuong = tong;
        //        if (ctl == null)
        //        {
        //            ViewBag.ok = "thanh toán thành công";
        //            db.ChiTietLuongs.Add(ct);
        //        }
        //        db.SaveChanges();

        //    }
        //    return Redirect("/adminbalo/quanlyluong");
        //    // lag :V
        //}




        public ActionResult DanhSachNhanLuong()
        {
            var list = db.ChiTietLuongs.ToList();
            return View(list);
        }

        //public ActionResult QuaTrinhTangLuong(String id)
        //{
        //    var tangluong = db.CapNhatLuongs.Where(n => n.MaNhanVien == id).ToList();
        //    if (tangluong != null)
        //    {
        //        return View(tangluong);
        //    }
        //    return Redirect("/admin/quanlyluong");
        //}
    }   //end class
}
