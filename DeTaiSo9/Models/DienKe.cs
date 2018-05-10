using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class DienKe
    {
        [Key]
        public string MaDienKe { get; set; }
        public double HieuDienThe { get; set; }
        public string MaKhachHang { get; set; }
        public string MaKhuVuc { get; set; }
        public string NuocSanXuat { get; set; }
        public string GhiChu { get; set; }
        [ForeignKey("MaKhachHang")]
        public virtual KhachHang khachHang { get; set; }
        [ForeignKey("MaKhuVuc")]
        public virtual KhuVuc khuVuc { get; set; }
        public virtual ICollection<HoaDon> hoaDon { get; set; }


        public DienKe()
        {
       
        }
        public DienKe(string maDienKe,string maKhuVuc,string maKh,string nuocSx,string ghiChu,double hieuDienThe)
        {
            MaDienKe = maDienKe;
            MaKhachHang = maKh;
            MaKhuVuc = maKhuVuc;
            NuocSanXuat = nuocSx;
            GhiChu = ghiChu;
            HieuDienThe = hieuDienThe;
        }

    }
}
