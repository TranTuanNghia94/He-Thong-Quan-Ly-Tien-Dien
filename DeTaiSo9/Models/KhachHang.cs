using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class KhachHang
    {
        [Key]
        [Required]
        public string MaKh { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public string SoDT { get; set; }
        public virtual ICollection<DienKe> dienKe { get; set; }

        public KhachHang()
        {
            MaKh = DiaChi = SoDT = null;
        }

        public KhachHang(string maKH,string diaChi,string sdt)
        {
            MaKh = maKH;
            DiaChi = diaChi;
            SoDT = sdt;
        }


    }
}
