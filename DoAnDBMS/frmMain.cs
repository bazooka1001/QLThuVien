using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnDBMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn Đăng xuất không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau UpDateAccount = new frmDoiMatKhau(frmDangNhap.user,frmDangNhap.pass);
            UpDateAccount.ShowDialog();
            this.Show();
        }
        private void ThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan Info = new frmThongTinCaNhan(frmDangNhap.type, frmDangNhap.user);
            Info.ShowDialog();
            this.Show();
        }
        private void GioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieuPhanMem GioiThieuPM = new frmGioiThieuPhanMem();
            GioiThieuPM.ShowDialog();
            this.Show();
        }
        private void NhanVien_Click(object sender, EventArgs e)
        {
            frmDanhSachNhanVien NhanVien = new frmDanhSachNhanVien();
            NhanVien.ShowDialog();
            this.Show();
        }
        private void DocGia_Click(object sender, EventArgs e)
        {
            frmDanhSachUser User = new frmDanhSachUser();
            User.ShowDialog();
            this.Show();
        }
        private void MuonSach_Click(object sender, EventArgs e)
        {
            frmQLMuonSach QlMuonSach = new frmQLMuonSach();
            QlMuonSach.ShowDialog();
            this.Show();
        }
        private void TraSach_Click(object sender, EventArgs e)
        {
            frmQLTraSach Tra = new frmQLTraSach();
            Tra.ShowDialog();
            this.Show();
        }
    }
}
