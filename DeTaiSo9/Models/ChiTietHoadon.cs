using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class ChiTietHoadon
    {
        [Key]
        [Column(Order = 2)]
        public string SoHoaDon { get; set; }
        [Key]
        [Column(Order = 1)]
        public string MaDonGia { get; set; }
        public double SoLuongKw
        {
            get;
            set;
        }
        [ForeignKey("MaDonGia")]
        public virtual DonGia donGia { get; set; }
        [ForeignKey("SoHoaDon")]
        public virtual HoaDon hoaDon { get; set; }

        public ChiTietHoadon()
        {
            
        }

        public ChiTietHoadon(string soHoaDon,string maHoaDon,double soLuongKw)
        {
            SoHoaDon = soHoaDon;
            MaDonGia = maHoaDon;
            SoLuongKw = soLuongKw;
        }
    }
}
