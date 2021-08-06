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
    public partial class frmSachOfNV : Form
    {
        DataTable dtSach = null;
        SachOfNV dbSach = new SachOfNV();
        bool Add = true;
        public frmSachOfNV()
        {
            InitializeComponent();
        }
        public void Load_cboxNXB()
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet dataSet = dbSach.LoadNXB();
            dtSach = dataSet.Tables[0];
            cboxMaNXB.DisplayMember = "MaNXB";
            cboxMaNXB.DataSource = dtSach;  
        }
        public void Load_cboxTG()
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet dataSet = dbSach.LoadTacGia();
            dtSach = dataSet.Tables[0];
            cboxMaTacGia.DisplayMember = "MaTG";
            cboxMaTacGia.DataSource = dtSach;
        }
        public void Load_cboxTheLoai()
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet dataSet = dbSach.LoadTheLoai();
            dtSach = dataSet.Tables[0];
            cboxMaTheLoai.DisplayMember = "MaTheLoai";
            cboxMaTheLoai.DataSource = dtSach;
        }
        public void Load_Data()
        {
            try
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadSachNV();
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataSach.DataSource = dtSach;
                this.txtMaCuon.ResetText();
                this.txtTenSach.ResetText();
                this.cboxMaNXB.ResetText();
                this.cboxMaTacGia.ResetText();
                this.txtNamXuatBan.ResetText();
                this.cboxMaTheLoai.ResetText();
                this.dateNgayNhap.ResetText();
                this.txtTon.ResetText();
                this.txtSoLanMuon.ResetText();

                this.btnLuu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                dataSach_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataSach.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            txtMaCuon.Text = dataSach.Rows[r].Cells[0].Value.ToString();
            txtTenSach.Text = dataSach.Rows[r].Cells[1].Value.ToString();
            cboxMaNXB.Text = dataSach.Rows[r].Cells[2].Value.ToString();
            cboxMaTacGia.Text = dataSach.Rows[r].Cells[3].Value.ToString();
            txtNamXuatBan.Text = dataSach.Rows[r].Cells[4].Value.ToString();
            cboxMaTheLoai.Text= dataSach.Rows[r].Cells[5].Value.ToString();
            dateNgayNhap.Text= dataSach.Rows[r].Cells[6].Value.ToString();
            txtTon.Text= dataSach.Rows[r].Cells[7].Value.ToString();
            txtSoLanMuon.Text= dataSach.Rows[r].Cells[8].Value.ToString();
        }
        private void frmSachOfNV_Load(object sender, EventArgs e)
        {
            Load_cboxNXB();
            Load_cboxTG();
            Load_cboxTheLoai();
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
            Add = true;
            this.txtMaCuon.Enabled = true;
            this.txtMaCuon.ResetText();
            this.txtTenSach.ResetText();
            this.cboxMaNXB.ResetText();
            this.cboxMaTacGia.ResetText();
            this.txtNamXuatBan.ResetText();
            this.cboxMaTheLoai.ResetText();
            this.dateNgayNhap.ResetText();
            this.txtTon.ResetText();
            this.txtSoLanMuon.ResetText();
            this.txtSoLanMuon.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtSoLanMuon.Text = "0";
            this.txtMaCuon.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataSach.CurrentCell.RowIndex;
                string strUser = dataSach.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa Sách này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbSach.DeleteSachNV(strUser);
                    Load_cboxNXB();
                    Load_cboxTG();
                    Load_cboxTheLoai();
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            Add = false;
            this.txtMaCuon.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtTenSach.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnSua.Enabled = true;
            if (Add)
            {
                try
                {
                    if (txtMaCuon.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập Mã Tác Giả");
                        txtMaCuon.Focus();
                    }
                    else
                    {
                        dbSach = new SachOfNV();
                        dbSach.AddSachNV(txtMaCuon.Text, txtTenSach.Text, cboxMaNXB.Text, cboxMaTacGia.Text, txtNamXuatBan.Text, cboxMaTheLoai.Text, dateNgayNhap.Text, int.Parse(txtTon.Text), int.Parse(txtSoLanMuon.Text));
                        Load_cboxNXB();
                        Load_cboxTG();
                        Load_cboxTheLoai();
                        Load_Data();
                        MessageBox.Show("Đã thêm xong!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thao tác không hợp lệ");
                }
            }
            else
            {
                try
                {
                    dbSach = new SachOfNV();
                    dbSach.UpdateSachNV(txtMaCuon.Text, txtTenSach.Text, cboxMaNXB.Text, cboxMaTacGia.Text, txtNamXuatBan.Text, cboxMaTheLoai.Text, dateNgayNhap.Text, int.Parse(txtTon.Text), int.Parse(txtSoLanMuon.Text));
                    Load_cboxNXB();
                    Load_cboxTG();
                    Load_cboxTheLoai();
                    Load_Data();
                    MessageBox.Show("Đã sửa xong!!");
                }
                catch
                {
                    MessageBox.Show("Thao tác không hợp lệ");
                }
            }
        }
    }
}
