using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteBALO.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

namespace websiteBALO.Areas.adminbalo.Controllers
{
    public class khachhangController : Controller
    {
        websitebaloEntities1 db = new websitebaloEntities1();
        // GET: adminbalo/khachhang
        [HttpGet]
        public ActionResult khachhang()
        {
            return View(db.KHACHHANGs.ToList());
        }

        [HttpGet]
        public ActionResult Suakh(int makh)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.maKH == makh);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Suakh(KHACHHANG kh)
        {
            db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("khachhang");
        }
        

        [HttpGet]
        public ActionResult dangnhapad()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangnhapad(FormCollection f)
        {
            string staikhoan = f["txttaikhoan"].ToString();
            string smatkhau = f["txtmatkhau"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.taikhoan == staikhoan && n.matkhau == smatkhau);
            User US = db.Users.SingleOrDefault(n => n.TaiKhoan == staikhoan && n.MatKhau == smatkhau);
            if (kh != null)
            {

                Session["taikhoan"] = kh.taikhoan;
                return RedirectToAction("khachhang", "khachhang");

            }
            if(US != null)
            {

                Session["TaiKhoanUS"] = US.TaiKhoan;
                return RedirectToAction("khachhang", "khachhang");

            }
            ViewBag.thongbao1 = "tên tài khoản và mật khẩu không đúng!";
            return View();
        }
        public ActionResult dangxuat()
        {
            Session.Clear();
            return RedirectToAction("khachhang", "khachhang");
        }
        //DONHANG
        [HttpGet]
        public ActionResult donhang()
        {
            return View(db.DONHANGs.ToList());
        }



        //  XUẤT FILE EXCEL ĐƠN HÀNG
        public ActionResult XuatFileExceldonhang()
        {

            var dh = db.DONHANGs.ToList();
            var tt = db.KHACHHANGs.ToList();
            var gv = new GridView();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            dt.Columns.Add("mã khách hàng", typeof(string));
            dt.Columns.Add("tài khoản", typeof(string));
            dt.Columns.Add("mã đơn hàng", typeof(string));
            dt.Columns.Add("ngày đặt", typeof(string));




            //Add in the datarow


            foreach (var item in dh)
            {
                DataRow newRow = dt.NewRow();

                newRow["mã khách hàng"] = item.maKH;
                newRow["tài khoản"] = item.KHACHHANG.taikhoan;
                newRow["mã đơn hàng"] = item.madonhang;
                newRow["ngày đặt"] = item.ngaydat;

                dt.Rows.Add(newRow);
            }
            gv.DataSource = dt;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            objHtmlTextWriter.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/adminbalo/donhang");
        }

        //CHI TIẾT ĐƠN HÀNG
        [HttpGet]
        public ActionResult chitietdonhang()
        {
            return View(db.CHITIETDONHANGs.ToList());
        }
        //XUẤT FILE EXCEL CHI TIẾT ĐƠN HÀNG

        public ActionResult XuatFileExcel()
        {

            var ds = db.CHITIETDONHANGs.ToList();
            var tt = db.KHACHHANGs.ToList();
            var gv = new GridView();
            //===================================================
            DataTable dt = new DataTable();
            dt.Columns.Add("mã khách hàng", typeof(string));
            dt.Columns.Add("họ tên", typeof(string));
            dt.Columns.Add("địa chỉ", typeof(string));
            dt.Columns.Add("số điện thoại", typeof(string));
            DataColumn workCol = dt.Columns.Add("Mã Đơn Hàng", typeof(String));
            dt.Columns.Add("Mã BaLo", typeof(string));
            dt.Columns.Add("Số Lượng", typeof(string));
            dt.Columns.Add("giá bán", typeof(string));
            //Add in the datarow
            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["mã khách hàng"] = item.DONHANG.KHACHHANG.maKH;
                newRow["họ tên"] = item.DONHANG.KHACHHANG.hoten;
                newRow["địa chỉ"] = item.DONHANG.KHACHHANG.diachi;
                newRow["số điện thoại"] = item.DONHANG.KHACHHANG.dienthoai;
                newRow["Mã Đơn Hàng"] = item.madonhang;
                newRow["Mã BaLo"] = item.Mabalo;
                newRow["Số Lượng"] = item.soluong;
                newRow["giá bán"] = item.SANPHAM.giaban;

                dt.Rows.Add(newRow);
            }
            gv.DataSource = dt;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            objHtmlTextWriter.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/adminbalo/chitietdonhang");
        }



    }
}