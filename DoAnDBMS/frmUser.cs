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
    public partial class frmUser : Form
    {
        public frmUser()
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
            frmDoiMatKhau UpDateAccount = new frmDoiMatKhau(frmDangNhap.user, frmDangNhap.pass);
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
            frmGioiThieuPhanMem GioiThieu = new frmGioiThieuPhanMem();
            GioiThieu.ShowDialog();
            this.Show();
        }
        private void TTSach_Click(object sender, EventArgs e)
        {
            frmSachOfUser Sach = new frmSachOfUser();
            Sach.ShowDialog();
            this.Show();
        }
        private void MuonSach_Click(object sender, EventArgs e)
        {
            frmMuonSach MSach = new frmMuonSach(frmDangNhap.user);
            MSach.ShowDialog();
            this.Show();
        }
        private void TraSach_Click(object sender, EventArgs e)
        {
            frmTraSach TSach = new frmTraSach(frmDangNhap.user);
            TSach.ShowDialog();
            this.Show();
        }
        private void LichSuMuonSach_Click(object sender, EventArgs e)
        {
            frmLichSuMuonSach LichSu = new frmLichSuMuonSach(frmDangNhap.user);
            LichSu.ShowDialog();
            this.Show();
        }
        private void TTNo_Click(object sender, EventArgs e)
        {
            frmSachNo No = new frmSachNo(frmDangNhap.user);
            No.ShowDialog();
            this.Show();
        }
    }
}
