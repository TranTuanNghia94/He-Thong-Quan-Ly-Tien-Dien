using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiSo9.Models
{
    class MyEntity:DbContext
    {
        public DbSet<DonGia> DbDonGia { get; set; }
        public DbSet<KhachHang> DbKhachHang { get; set; }
        public DbSet<DienKe> DbDienKe { get; set; }
        public DbSet<HoaDon> DbHoaDon { get; set; }
        public DbSet<KhuVuc> DbKhuvuc { get; set; }
        public DbSet<ChiTietHoadon> DbChiTietHoaDon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonGia>();
            modelBuilder.Entity<KhachHang>();
            modelBuilder.Entity<DienKe>();
            modelBuilder.Entity<HoaDon>();
            modelBuilder.Entity<KhuVuc>();
            modelBuilder.Entity<ChiTietHoadon>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
