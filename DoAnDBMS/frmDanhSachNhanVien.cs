using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnDBMS.BS_layer;

namespace DoAnDBMS
{
    public partial class frmDanhSachNhanVien : Form
    {
        DataTable dtNV = null;
        NhanVien dbNV = new NhanVien();
        public frmDanhSachNhanVien()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                radioNam.Checked = true;
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet dataSet = dbNV.LoadNhanVien();
                dtNV = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataNhanVien.DataSource = dtNV;
                this.txtMa.ResetText();
                this.txtHoTen.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDiaChi.ResetText();
                this.txtLuong.ResetText();
                this.txtEmail.ResetText();
                this.txtSDT.ResetText();

                this.btnLưu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                this.radTheoMa.Checked = true;
                dataNhanVien_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataNhanVien.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            if (dataNhanVien.Rows[r].Cells[6].Value.ToString() == "Nam")
                radioNam.Checked = true;
            else
                radioNu.Checked = true;
            txtMa.Text = dataNhanVien.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text = dataNhanVien.Rows[r].Cells[1].Value.ToString();
            dateNgaySinh.Text = dataNhanVien.Rows[r].Cells[2].Value.ToString();
            txtDiaChi.Text = dataNhanVien.Rows[r].Cells[3].Value.ToString();
            txtSDT.Text = dataNhanVien.Rows[r].Cells[4].Value.ToString();
            txtEmail.Text = dataNhanVien.Rows[r].Cells[5].Value.ToString();
            txtLuong.Text = dataNhanVien.Rows[r].Cells[7].Value.ToString();
        }
        private void frmDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }  
        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtMa.ResetText();
            this.txtHoTen.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDiaChi.ResetText();
            this.txtLuong.ResetText();
            this.txtEmail.ResetText();
            this.txtSDT.ResetText();
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            txtMa.Focus();
        }
        private void btnLưu_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (txtMa.Text == "")
                    MessageBox.Show("Mã nhân viên không được trống!!");
                else
                {
                    string GioiTinh;
                    if (radioNam.Checked == true)
                        GioiTinh = "Nam";
                    else
                        GioiTinh = "Nữ";
                    NhanVien NV = new NhanVien();
                    NV.AddNhanVien(txtMa.Text, txtHoTen.Text, dateNgaySinh.Text, txtDiaChi.Text, txtSDT.Text,
                        txtEmail.Text, GioiTinh, txtLuong.Text);
                    Load_Data();
                    MessageBox.Show("Đã thêm xong!!");
                }
            }
            catch
            {
                MessageBox.Show("Thao tác không hợp lệ!");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataNhanVien.CurrentCell.RowIndex;
                string strNhanVien = dataNhanVien.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa Nhân Viên này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbNV.DeleteNhanVien(strNhanVien);
                    Load_Data();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được.Lỗi rồi!");
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(radTheoTen.Checked==true)
            {
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet dataSet = dbNV.SearchNhanVienTheoTen(txtTimKiem.Text);
                dtNV = dataSet.Tables[0]; 
                dataNhanVien.DataSource = dtNV;
            }
            else
            {
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet dataSet = dbNV.SearchNhanVienTheoMa(txtTimKiem.Text);
                dtNV = dataSet.Tables[0];
                dataNhanVien.DataSource = dtNV;
            }
        }
    }
}
