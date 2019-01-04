using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;
namespace websiteBALO.Controllers
{
    public class giohangController : Controller
    {
        //lấy giỏ hàng 
        websitebaloEntities1 db = new websitebaloEntities1();
        public List<giohang> laygiohang()
        {
            List<giohang> lstgiohang = Session["giohang"] as List<giohang>;
            if (lstgiohang == null)
            {
                //nếu giỏ hàng chưa tồn tại thì mình tiến hàn khởi tạo
                lstgiohang = new List<giohang>();
                Session["giohang"] = lstgiohang;
            }
            return lstgiohang;

        }
        //thêm giỏ hàng 
        public ActionResult themgiohang(int imasp, string strURL)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.Mabalo == imasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy ra sesion giỏ hàng
            List<giohang> lstgiohang = laygiohang();
            //kiểm tra sản phẩm đã tồn tại trong sesion[giohang] chưa
            giohang sanpham = lstgiohang.Find(n => n.imasp == imasp);
            if (sanpham == null)
            {
                sanpham = new giohang(imasp);
                //sản phẩm mới thêm vào list
                lstgiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.isoluong++;
                return Redirect(strURL);

            }
        }


        //cập nhập giỏ hàng
        public ActionResult capnhapgiohang(int iMasp, FormCollection f)
        {
            //kiểm tra mã sản phẩm
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.Mabalo == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<giohang> lstgiohang = laygiohang();
            giohang gh = lstgiohang.SingleOrDefault(n => n.imasp == iMasp);
            //nếu mà tồn tại thì cho sửa giỏ hàng
            if (gh != null)
            {
                gh.isoluong = int.Parse(f["txtsoluong"].ToString());
            }
            return RedirectToAction("giohang");
        }


        //xóa sản phẩm
        public ActionResult xoasanpham(int iMasp)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.Mabalo == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy ra sesion giỏ hàng
            List<giohang> lstgiohang = laygiohang();
            giohang gh = lstgiohang.SingleOrDefault(n => n.imasp == iMasp);
            //nếu mà tồn tại thì cho sửa giỏ hàng
            if (gh != null)
            {
                lstgiohang.RemoveAll(n => n.imasp == iMasp);
            }
            if (lstgiohang.Count == 0)
            {
                return RedirectToAction("index", "Home");
            }
            return RedirectToAction("giohang");
        }
        //xây dựng trang giỏ hàng
        public ActionResult giohang()
        {
            if (Session["giohang"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            List<giohang> lstgiohang = laygiohang();
            ViewBag.tongthanhtien = tongtien();
            return View(lstgiohang);
        }
        //xây dựng tính tổng số lượng và tổng tiền
        private int tongsoluong()
        {
            int itongsoluong = 0;
            List<giohang> lstgiohang = Session["giohang"] as List<giohang>;
            if (lstgiohang != null)
            {
                itongsoluong = lstgiohang.Sum(n => n.isoluong);
            }
            return itongsoluong;
        }
        // tính tổng thành tiền
        private double tongtien()
        {
            double dtongtien = 0;
            List<giohang> lstgiohang = Session["giohang"] as List<giohang>;
            if (lstgiohang != null)
            {
                dtongtien = lstgiohang.Sum(n => n.Thanhtien);
            }
            return dtongtien;
        }

        // tổng số sản phẩm trong giỏ hàng
        public ActionResult giohangpartial()
        {
            if (tongsoluong() == 0)
            {
                return PartialView();
            }
            ViewBag.tongsoluong = tongsoluong();
            ViewBag.tongtien = tongtien();
            return PartialView();
        }
        //xây dựng 1 view cho user chỉnh sửa cho giỏ hàng
        public ActionResult suagiohang()
        {
            if (Session["giohang"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            List<giohang> lstgiohang = laygiohang();
            return View(lstgiohang);
        }

        //xây dựng chức năng đặt hàng
        public ActionResult dathang()
        {
            //kiểm tra đăng nhập
            if (Session["taikhoan"] == null || Session["taikhoan"].ToString() == "")
            {
                return RedirectToAction("dangnhap", "nguoidung");
            }
            //kiểm tra giỏ hàng
            if (Session["giohang"] == null)
            {
                return RedirectToAction("giohang", "giohang");
            }
            //thêm đơn hàng
            DONHANG dh = new DONHANG();

            KHACHHANG kh = (KHACHHANG)Session["nguoidung"];
            List<giohang> gh = laygiohang();
            dh.madonhang = kh.maKH;
            dh.maKH = kh.maKH;
            dh.ngaydat = DateTime.Now;

            //thêm đơn hàng
            db.DONHANGs.Add(dh);
            db.SaveChanges();
            //thêm chi tiết đơn hàng

            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.Mabalo = item.imasp;
                ctdh.madonhang = dh.madonhang;
                ctdh.soluong = item.isoluong;
                db.CHITIETDONHANGs.Add(ctdh);
                db.SaveChanges();

            }
            return RedirectToAction("ThongTinNguoiDung", "Home", new { @ID = Session["thongtin"] });

        }

    }
}