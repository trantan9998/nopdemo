//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace websiteBALO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }
    
        public int Mabalo { get; set; }
        public string Tenbalo { get; set; }
        public Nullable<decimal> giaban { get; set; }
        public string mota { get; set; }
        public string banbia { get; set; }
        public Nullable<System.DateTime> ngaycapnhap { get; set; }
        public Nullable<int> soluongton { get; set; }
        public Nullable<int> maNSX { get; set; }
        public Nullable<int> machude { get; set; }
        public string NhanVien_MNV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual CHUDE CHUDE { get; set; }
        public virtual CHUDE CHUDE1 { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
