using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websiteBALO.Models
{
    public class giohang
    {
        websitebaloEntities1 db = new websitebaloEntities1();

        public int imasp { get; set; }

        public string stensp { get; set; }

        public string sanhbia { get; set; }

        public double Ddongia { get; set; }

        public int isoluong { get; set; }

        public double Thanhtien
        {
            get
            {
                return isoluong * Ddongia;
            }
        }
        public giohang(int masp)
        {
            imasp = masp;
            SANPHAM sp = db.SANPHAMs.Single(n => n.Mabalo == imasp);
            stensp = sp.Tenbalo;
            sanhbia = sp.banbia;
            Ddongia = double.Parse(sp.giaban.ToString());
            isoluong = 1;
        }
    }
}