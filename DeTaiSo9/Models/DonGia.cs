using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class DonGia
    {
        [Key]
        public string MaDonGia { get; set; }
        public int SoTien { get; set; }
        public double TuKw { get; set; }
        public double DenKw { get; set; }
        public string GhiChu { get; set; }
        public virtual ICollection<ChiTietHoadon> chitietHoaDon { get; set; }
        public DonGia()
        {

        }

        public DonGia(string maDonGia,int soTien,double tuKw,double denKw,string ghiChu)
        {
            MaDonGia = maDonGia;
            SoTien = soTien;
            TuKw = tuKw;
            DenKw = denKw;
            GhiChu = ghiChu;
        }

    }
}
