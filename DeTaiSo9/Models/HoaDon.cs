using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class HoaDon
    {
        [Key]
        public string SoHoaDon { get; set; }
        public int Thang { get; set; }
        public string MaDienKe { get; set; }
        public double ThanhTien { get; set; }
        [ForeignKey("MaDienKe")]
        public virtual DienKe dienKe { get; set; }
        public virtual ICollection<ChiTietHoadon> chiTietHoaDon { get; set; }
        public HoaDon(string soHoaDon,string maDienKe,int thang,double thanhTien)
        {
            SoHoaDon = soHoaDon;
            MaDienKe = maDienKe;
            Thang = thang;
            ThanhTien = thanhTien;
        }

        public HoaDon()
        {

        }

    }
}
