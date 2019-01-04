using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace websiteBALO.Models
{
    [MetadataTypeAttribute(typeof(SANPHAMmetadata))]
    public partial class SANPHAM
    {
        internal sealed  class SANPHAMmetadata
        {

        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "Mã balo")]
        public int Mabalo { get; set; }
        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "Tên balo")]
        public string Tenbalo { get; set; }
        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "giá bán")]
        public Nullable<decimal> giaban { get; set; }
        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "Mô tả")]
        public string mota { get; set; }
        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "ảnh bìa")]
        public string banbia { get; set; }
        [Required(ErrorMessage = "vui lòng nhập dữ liệu")]
        [Display(Name = "Ngày cập nhập")]
        public Nullable<System.DateTime> ngaycapnhap { get; set; }
        [Required(ErrorMessage = "vui lòng nhập số liệu")]
        [Display(Name = "số lượng")]
        public Nullable<int> soluongton { get; set; }
        
        [Display(Name = "nhà sản xuất")]
        public Nullable<int> maNSX { get; set; }
   
        [Display(Name = "chủ đề")]
        public Nullable<int> machude { get; set; }

        }
    }
}