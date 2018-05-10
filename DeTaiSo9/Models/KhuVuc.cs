using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class KhuVuc
    {
        [Key]
        public string MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
        public string QuanHuyen { get; set; }
        public virtual ICollection<DienKe> dienKe { get; set; }

        public KhuVuc()
        {
            MaKhuVuc = TenKhuVuc = QuanHuyen = null;
        }
        public KhuVuc(string maKhuVuc,string tenKhuVuc,string quanHuyen)
        {
            MaKhuVuc = maKhuVuc;
            TenKhuVuc = tenKhuVuc;
            QuanHuyen = quanHuyen;
        }
        

    }
}
