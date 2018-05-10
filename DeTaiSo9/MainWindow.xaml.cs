using DeTaiSo9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeTaiSo9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyEntity db = new MyEntity();
        public MainWindow()
        {
            InitializeComponent();
            dgrThongTinKh.ItemsSource = db.DbKhachHang.ToList();
            dgrThongTinKV.ItemsSource = db.DbKhuvuc.ToList();
            dgrThongTinDK.ItemsSource = db.DbDienKe.ToList();
            dgrDonGia.ItemsSource = db.DbDonGia.ToList();
            dgrHoaDon.ItemsSource = db.DbHoaDon.ToList();
            dgrThongTinChiTietHD.ItemsSource = db.DbChiTietHoaDon.ToList();
            cbMaKH.ItemsSource = (from p in db.DbKhachHang select p.MaKh).ToList();
            cbMaKV.ItemsSource = (from p in db.DbKhuvuc select p.MaKhuVuc).ToList();
            cbSoHoaDon.ItemsSource = (from p in db.DbHoaDon select p.SoHoaDon).ToList();
            cbDienKe.ItemsSource = (from p in db.DbDienKe select p.MaDienKe).ToList();
            cbMaDonGia.ItemsSource = (from p in db.DbDonGia select p.MaDonGia).ToList();
        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            gridThongTinKh.Visibility = Visibility.Visible;
            gridDonGia.Visibility = Visibility.Hidden;
            gridChiTietHoaDon.Visibility = Visibility.Hidden;
            gridThongTinKv.Visibility = Visibility.Hidden;
            gridHoaDon.Visibility = Visibility.Hidden;
            gridThongTinDienKe.Visibility = Visibility.Hidden;
        }

        private void btnKhuVuc_Click(object sender, RoutedEventArgs e)
        {
            gridThongTinKv.Visibility = Visibility.Visible;
            gridDonGia.Visibility = Visibility.Hidden;
            gridThongTinKh.Visibility = Visibility.Hidden;
            gridChiTietHoaDon.Visibility = Visibility.Hidden;
            gridHoaDon.Visibility = Visibility.Hidden;
            gridThongTinDienKe.Visibility = Visibility.Hidden;
        }

        private void btnDienKe_Click(object sender, RoutedEventArgs e)
        {
            gridThongTinDienKe.Visibility = Visibility.Visible;
            gridDonGia.Visibility = Visibility.Hidden;
            gridThongTinKh.Visibility = Visibility.Hidden;
            gridChiTietHoaDon.Visibility = Visibility.Hidden;
            gridThongTinKv.Visibility = Visibility.Hidden;
            gridHoaDon.Visibility = Visibility.Hidden;
        }

        private void btnDonGia_Click(object sender, RoutedEventArgs e)
        {
            gridDonGia.Visibility = Visibility.Visible;
            gridThongTinKh.Visibility = Visibility.Hidden;
            gridChiTietHoaDon.Visibility = Visibility.Hidden;
            gridThongTinKv.Visibility = Visibility.Hidden;
            gridHoaDon.Visibility = Visibility.Hidden;
            gridThongTinDienKe.Visibility = Visibility.Hidden;
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            gridHoaDon.Visibility = Visibility.Visible;
            gridDonGia.Visibility = Visibility.Hidden;
            gridThongTinKh.Visibility = Visibility.Hidden;
            gridChiTietHoaDon.Visibility = Visibility.Hidden;
            gridThongTinKv.Visibility = Visibility.Hidden;
            gridThongTinDienKe.Visibility = Visibility.Hidden;
        }

        private void btnChiTietHoaDon_Click(object sender, RoutedEventArgs e)
        {
            gridChiTietHoaDon.Visibility = Visibility.Visible;
            gridDonGia.Visibility = Visibility.Hidden;
            gridThongTinKh.Visibility = Visibility.Hidden;
            gridThongTinKv.Visibility = Visibility.Hidden;
            gridHoaDon.Visibility = Visibility.Hidden;
            gridThongTinDienKe.Visibility = Visibility.Hidden;
        }


        // KHÁCH HÀNG
        private void btnThemKH_Click(object sender, RoutedEventArgs e)
        {
            //if ((txtDiaChi.Text != null && txtMaKh.Text != null && txtSDT.Text != null) || (txtSDT.Text != "" && txtMaKh.Text != "" && txtDiaChi.Text != ""))
            try
            {
                var kh = new KhachHang { MaKh = txtMaKh.Text, DiaChi = txtDiaChi.Text, SoDT = txtSDT.Text };
                db.DbKhachHang.Add(kh);
                db.SaveChanges();
                dgrThongTinKh.ItemsSource = db.DbKhachHang.ToList();
                MessageBox.Show("Lưu Thành Công");
                cbMaKH.ItemsSource = (from p in db.DbKhachHang select p.MaKh).ToList();
                txtMaKh.Text = txtDiaChi.Text = txtSDT.Text = "";
            }
            //else
            catch
            {
                MessageBox.Show("không được bỏ trống thông tin");
            }
        }

        private void btnSuaKH_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kh = (from p in db.DbKhachHang where p.MaKh == txtMaKh.Text select p).Single();
                kh.DiaChi = txtDiaChi.Text;
                kh.SoDT = txtSDT.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrThongTinKh.ItemsSource = db.DbKhachHang.ToList();
                cbMaKH.ItemsSource = (from p in db.DbKhachHang select p.MaKh).ToList();
                txtMaKh.IsEnabled = true;
                txtMaKh.Text = txtDiaChi.Text = txtSDT.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }
        }

        private void btnXoaKH_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kh = (from p in db.DbKhachHang where p.MaKh == txtMaKh.Text select p).Single();
                db.DbKhachHang.Remove(kh);
                db.SaveChanges();
                dgrThongTinKh.ItemsSource = db.DbKhachHang.ToList();
                MessageBox.Show("Xóa Thành Công");
                cbMaKH.ItemsSource = (from p in db.DbKhachHang select p.MaKh).ToList();
                txtMaKh.IsEnabled = true;
                txtSDT.Text = txtDiaChi.Text = txtMaKh.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrThongTinKh_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var kh = (KhachHang)dgrThongTinKh.SelectedItem;
            if(kh != null)
            {
                txtMaKh.IsEnabled = false;
                txtMaKh.Text = kh.MaKh;
                txtSDT.Text = kh.SoDT;
                txtDiaChi.Text = kh.DiaChi;
            }
        }


        // KHU VỰC
        private void btnThemKV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kv = new KhuVuc { MaKhuVuc = txtMaKhuVuc.Text, TenKhuVuc = txtTenKhuVuc.Text, QuanHuyen = txtQuanHuyen.Text };
                db.DbKhuvuc.Add(kv);
                db.SaveChanges();
                dgrThongTinKV.ItemsSource = db.DbKhuvuc.ToList();
                MessageBox.Show("Thêm thành công");
                cbMaKV.ItemsSource = (from p in db.DbKhuvuc select p.MaKhuVuc).ToList();
                txtMaKhuVuc.Text = txtTenKhuVuc.Text = txtQuanHuyen.Text = "";
                
            }
            catch
            {
                MessageBox.Show("Không được bỏ trống thông tin");
            }
        }

        private void btnSuaKV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kv = (from p in db.DbKhuvuc where p.MaKhuVuc == txtMaKhuVuc.Text select p).Single();
                kv.TenKhuVuc = txtTenKhuVuc.Text;
                kv.QuanHuyen = txtQuanHuyen.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrThongTinKV.ItemsSource = db.DbKhuvuc.ToList();
                cbMaKV.ItemsSource = (from p in db.DbKhuvuc select p.MaKhuVuc).ToList();
                txtMaKhuVuc.Text = txtQuanHuyen.Text = txtTenKhuVuc.Text = "";
                txtMaKhuVuc.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }
        }

        private void btnXoaKV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kv = (from p in db.DbKhuvuc where p.MaKhuVuc == txtMaKhuVuc.Text select p).Single();
                db.DbKhuvuc.Remove(kv);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                dgrThongTinKV.ItemsSource = db.DbKhuvuc.ToList();
                cbMaKV.ItemsSource = (from p in db.DbKhuvuc select p.MaKhuVuc).ToList();
                txtMaKhuVuc.IsEnabled = true;
                txtMaKhuVuc.Text = txtTenKhuVuc.Text = txtQuanHuyen.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrThongTinKV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var kv = (KhuVuc)dgrThongTinKV.SelectedItem;
            if(kv != null)
            {
                txtMaKhuVuc.IsEnabled = false;
                txtMaKhuVuc.Text = kv.MaKhuVuc;
                txtQuanHuyen.Text = kv.QuanHuyen;
                txtTenKhuVuc.Text = kv.TenKhuVuc;
            }
        }


        // ĐIỆN KẾ
        private void btnThemDK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dk = new DienKe { MaDienKe = txtMaDienKe.Text, HieuDienThe = Int32.Parse(txtHieuDienThe.Text), GhiChu = txtGhiChu.Text, NuocSanXuat = txtNuocSanXuat.Text, MaKhachHang = cbMaKH.Text, MaKhuVuc = cbMaKV.Text };
                db.DbDienKe.Add(dk);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                dgrThongTinDK.ItemsSource = db.DbDienKe.ToList();
                cbDienKe.ItemsSource = (from p in db.DbDienKe select p.MaDienKe).ToList();
                txtMaDienKe.Text = txtMaKhuVuc.Text = txtHieuDienThe.Text = txtGhiChu.Text = txtNuocSanXuat.Text = "";
            }
            catch
            {
                MessageBox.Show("Không được bỏ trống thông tin");
            }
        }

        private void btnSuaDK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dk = (from p in db.DbDienKe where p.MaDienKe == txtMaDienKe.Text select p).Single();
                dk.GhiChu = txtGhiChu.Text;
                dk.MaKhachHang = cbMaKH.SelectedValue.ToString();
                dk.MaKhuVuc = cbMaKV.SelectedValue.ToString();
                dk.NuocSanXuat = txtNuocSanXuat.Text;
                dk.HieuDienThe = Int32.Parse(txtHieuDienThe.Text);
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrThongTinDK.ItemsSource = db.DbDienKe.ToList();
                cbDienKe.ItemsSource = (from p in db.DbDienKe select p.MaDienKe).ToList();
                txtMaDienKe.IsEnabled = true;
                txtMaDienKe.Text = txtMaKhuVuc.Text = txtHieuDienThe.Text = txtGhiChu.Text = txtNuocSanXuat.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }

        }

        private void btnXoaDK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dk = (from p in db.DbDienKe where p.MaDienKe == txtMaDienKe.Text select p).Single();
                db.DbDienKe.Remove(dk);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                dgrThongTinDK.ItemsSource = db.DbDienKe.ToList();
                cbDienKe.ItemsSource = (from p in db.DbDienKe select p.MaDienKe).ToList();
                txtMaDienKe.IsEnabled = true;
                txtMaDienKe.Text = txtMaKhuVuc.Text = txtHieuDienThe.Text = txtGhiChu.Text = txtNuocSanXuat.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrThongTinDK_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dk = (DienKe)dgrThongTinDK.SelectedItem;
            var tmp = db.DbDienKe.Find(dk.MaDienKe);
            if(dk != null)
            {
                txtMaDienKe.IsEnabled = false;
                txtGhiChu.Text = dk.GhiChu;
                txtMaDienKe.Text = dk.MaDienKe;
                txtNuocSanXuat.Text = dk.NuocSanXuat;
                txtHieuDienThe.Text = dk.HieuDienThe.ToString();
                cbMaKH.SelectedIndex = db.DbDienKe.ToList().IndexOf(tmp);
                cbMaKV.SelectedIndex = db.DbDienKe.ToList().IndexOf(tmp);
            }
        }


        // ĐƠN GIÁ
        private void btnThemDonGia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dg = new DonGia { MaDonGia = txtDonGia.Text, DenKw = Double.Parse(txtDenKw.Text), TuKw = Double.Parse(txtTuKwt.Text), SoTien = Int32.Parse(txtSoTien.Text), GhiChu = txtGhiChuDonGia.Text };
                db.DbDonGia.Add(dg);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                dgrDonGia.ItemsSource = db.DbDonGia.ToList();
                cbMaDonGia.ItemsSource = (from p in db.DbDonGia select p.MaDonGia).ToList();
                txtDonGia.Text = txtDenKw.Text = txtTuKwt.Text = txtSoTien.Text = txtGhiChuDonGia.Text = "";
            }
            catch
            {
                MessageBox.Show("Không được bỏ trống thông tin");
            }

        }

        private void btnSuaDonGia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dg = (from p in db.DbDonGia where p.MaDonGia == txtDonGia.Text select p).Single();
                dg.TuKw = Int32.Parse(txtTuKwt.Text);
                dg.DenKw = Int32.Parse(txtDenKw.Text);
                dg.SoTien = Int32.Parse(txtSoTien.Text);
                dg.GhiChu = txtGhiChuDonGia.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrDonGia.ItemsSource = db.DbDonGia.ToList();
                cbMaDonGia.ItemsSource = (from p in db.DbDonGia select p.MaDonGia).ToList();
                txtDonGia.Text = txtDenKw.Text = txtTuKwt.Text = txtSoTien.Text = txtGhiChuDonGia.Text = "";
                txtDonGia.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }


        }

        private void btnXoaDonGia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dg = (from p in db.DbDonGia where p.MaDonGia==txtDonGia.Text select p).Single();
                db.DbDonGia.Remove(dg);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                dgrDonGia.ItemsSource = db.DbDonGia.ToList();
                cbMaDonGia.ItemsSource = (from p in db.DbDonGia select p.MaDonGia).ToList();
                txtDonGia.Text = txtDenKw.Text = txtTuKwt.Text = txtSoTien.Text = txtGhiChuDonGia.Text = "";
                txtDonGia.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrDonGia_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dg = (DonGia)dgrDonGia.SelectedItem;
            if(dg != null)
            {
                txtDonGia.IsEnabled = false;
                txtDonGia.Text = dg.MaDonGia;
                txtDenKw.Text = dg.DenKw.ToString();
                txtTuKwt.Text = dg.TuKw.ToString();
                txtSoTien.Text = dg.SoTien.ToString();
                txtGhiChuDonGia.Text = dg.GhiChu;
            }
        }


        // HÓA ĐƠN
        private void btnThemHD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hd = new HoaDon { SoHoaDon = txtHoaDon.Text, MaDienKe = cbDienKe.Text, Thang = Int32.Parse(txtThang.Text), ThanhTien = Int32.Parse(txtThanhTien.Text) };
                db.DbHoaDon.Add(hd);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                dgrHoaDon.ItemsSource = db.DbHoaDon.ToList();
                cbSoHoaDon.ItemsSource = (from p in db.DbHoaDon select p.SoHoaDon).ToList();
                txtHoaDon.Text = txtThang.Text = txtThanhTien.Text = "";
            }
            catch
            {
                MessageBox.Show("Không được bỏ trống thông tin");
            }
        }
       
        private void btnSuaHD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hd = (from p in db.DbHoaDon where p.SoHoaDon == txtHoaDon.Text select p).Single();
                hd.Thang = Int32.Parse(txtThang.Text);
                hd.ThanhTien = Int32.Parse(txtThanhTien.Text);
                hd.MaDienKe = cbDienKe.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrHoaDon.ItemsSource = db.DbHoaDon.ToList();
                cbSoHoaDon.ItemsSource = (from p in db.DbHoaDon select p.SoHoaDon).ToList();
                txtThang.Text = txtThanhTien.Text = txtHoaDon.Text = "";
                txtHoaDon.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }
        }

        private void btnXoaHD_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var hd = (from p in db.DbHoaDon where p.SoHoaDon == txtHoaDon.Text select p).Single();
                db.DbHoaDon.Remove(hd);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                dgrHoaDon.ItemsSource = db.DbHoaDon.ToList();
                cbSoHoaDon.ItemsSource = (from p in db.DbHoaDon select p.SoHoaDon).ToList();
                txtHoaDon.Text = txtThang.Text = txtThanhTien.Text = "";
                txtDonGia.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrHoaDon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hd = (HoaDon)dgrHoaDon.SelectedItem;
            var tmp = db.DbHoaDon.Find(hd.SoHoaDon);
            if (hd != null)
            {
                txtHoaDon.IsEnabled = false;
                txtHoaDon.Text = hd.SoHoaDon;
                txtThang.Text = hd.Thang.ToString();
                txtThanhTien.Text = hd.ThanhTien.ToString();
                cbDienKe.SelectedIndex = db.DbHoaDon.ToList().IndexOf(tmp);
            }
        }


        // CHI TIẾT HÓA ĐƠN
        private void btnThemChiTietHD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ct = new ChiTietHoadon { MaDonGia = cbMaDonGia.Text, SoHoaDon = cbSoHoaDon.Text, SoLuongKw = Int32.Parse(txtSoLuongKw.Text) };
                db.DbChiTietHoaDon.Add(ct);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                dgrThongTinChiTietHD.ItemsSource = db.DbChiTietHoaDon.ToList();;
                txtSoLuongKw.Text = "";
            }
            catch
            {
                MessageBox.Show("Không được bỏ trống thông tin");
            }

        }
       
        private void btnSuaChiTietHD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ct = (from p in db.DbChiTietHoaDon where p.MaDonGia == cbMaDonGia.Text && p.SoHoaDon == cbSoHoaDon.Text select p).Single();
                ct.MaDonGia = cbMaDonGia.Text;
                ct.SoHoaDon = cbSoHoaDon.Text;
                ct.SoLuongKw = Int32.Parse(txtSoLuongKw.Text);
                db.SaveChanges();
                MessageBox.Show("Sửa Thành công");
                dgrThongTinChiTietHD.ItemsSource = db.DbChiTietHoaDon.ToList();
                txtSoLuongKw.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để sửa");
            }
        }

        private void btnXoaChiTietHD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ct = (from p in db.DbChiTietHoaDon where p.SoHoaDon == cbSoHoaDon.Text && p.MaDonGia == cbMaDonGia.Text select p).Single();
                db.DbChiTietHoaDon.Remove(ct);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                dgrThongTinChiTietHD.ItemsSource = db.DbChiTietHoaDon.ToList();
                txtSoLuongKw.Text = "";
            }
            catch
            {
                MessageBox.Show("Không có thông tin để xóa");
            }
        }

        private void dgrThongTinChiTietHD_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ct = (ChiTietHoadon)dgrThongTinChiTietHD.SelectedItem;
            var tmp = db.DbChiTietHoaDon.Find(ct.SoHoaDon,ct.MaDonGia);
            if (ct != null)
            {
                txtSoLuongKw.Text = ct.SoLuongKw.ToString();
                cbMaDonGia.SelectedIndex = db.DbChiTietHoaDon.ToList().IndexOf(tmp);
                cbSoHoaDon.SelectedIndex = db.DbChiTietHoaDon.ToList().IndexOf(tmp);
            }
        }

        private void txtSoLuongKw_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtSoLuongKw.Text);
            }
            catch 
            {

                MessageBox.Show("Bạn không được nhập số");
                txtSoLuongKw.Text = "";
            }
        }

        private void txtThang_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtThang.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtThang.Text = "";
            }
        }

        private void txtSDT_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtSDT.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtSDT.Text = "";
            }
        }

        private void txtThanhTien_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtThanhTien.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtThanhTien.Text = "";
            }
        }

        private void txtSoTien_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtSoTien.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtSoTien.Text = "";
            }
        }

        private void txtTuKwt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtTuKwt.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtTuKwt.Text = "";
            }
        }

        private void txtDenKw_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtDenKw.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtDenKw.Text = "";
            }
        }

        private void txtHieuDienThe_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Int32.Parse(txtHieuDienThe.Text);
            }
            catch
            {

                MessageBox.Show("Bạn không được nhập số");
                txtHieuDienThe.Text = "";
            }
        }
    }
}
