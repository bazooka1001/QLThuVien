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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
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
        private void NXB_Click(object sender, EventArgs e)
        {
            frmNXB frNXB = new frmNXB();
            frNXB.ShowDialog();
            this.Show();
        }
        private void GioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieuPhanMem GioiThieuPM = new frmGioiThieuPhanMem();
            GioiThieuPM.ShowDialog();
            this.Show();
        }
        private void TheLoai_Click(object sender, EventArgs e)
        {
            frmTheLoai theLoai = new frmTheLoai();
            theLoai.ShowDialog();
            this.Show();
        }
        private void TacGia_Click(object sender, EventArgs e)
        {
            frmTacGia tacgia = new frmTacGia();
            tacgia.ShowDialog();
            this.Show();
        }
        private void Sach_Click(object sender, EventArgs e)
        {
            frmSachOfNV SachNV = new frmSachOfNV();
            SachNV.ShowDialog();
            this.Show();
        }
    }
}
