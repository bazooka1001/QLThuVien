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
    public partial class frmSachOfUser : Form
    {
        DataTable dtSach = null;
        SachUser dbSach = new SachUser();
        public frmSachOfUser()
        {
            InitializeComponent();
        }
       
        public void Load_Data()
        {
            try
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadSachUser();
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataSach.DataSource = dtSach;

                this.txtMaCuon.ResetText();
                this.txtTenSach.ResetText();
                this.txtTenNXB.ResetText();
                this.txtTenTacGia.ResetText();
                this.txtNamXuatBan.ResetText();
                this.txtTheLoai.ResetText();
                this.dateNgayNhap.ResetText();
                this.txtTon.ResetText();
                this.txtSoLanMuon.ResetText();

                this.radTheoTen.Checked = true;
                this.txtMaCuon.Enabled = false;
                this.txtTenSach.Enabled = false;
                this.txtTenNXB.Enabled =false;
                this.txtTenTacGia.Enabled = false;
                this.txtNamXuatBan.Enabled = false;
                this.txtTheLoai.Enabled = false;
                this.dateNgayNhap.Enabled =false;
                this.txtTon.Enabled = false;
                this.txtSoLanMuon.Enabled = false;
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
            txtTenNXB.Text = dataSach.Rows[r].Cells[2].Value.ToString();
            txtTenTacGia.Text = dataSach.Rows[r].Cells[3].Value.ToString();
            txtNamXuatBan.Text = dataSach.Rows[r].Cells[4].Value.ToString();
            txtTheLoai.Text = dataSach.Rows[r].Cells[5].Value.ToString();
            dateNgayNhap.Text = dataSach.Rows[r].Cells[6].Value.ToString();
            txtTon.Text = dataSach.Rows[r].Cells[7].Value.ToString();
            txtSoLanMuon.Text = dataSach.Rows[r].Cells[8].Value.ToString();
        }
        private void frmSachOfUser_Load(object sender, EventArgs e)
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
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (radTheoMa.Checked == true)
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.SearchSachTheoMa(txtTimKiem.Text);
                dtSach = dataSet.Tables[0];
                dataSach.DataSource = dtSach;
            }
            if(radTheoTen.Checked == true)
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.SearchSachTheoTenSach(txtTimKiem.Text);
                dtSach = dataSet.Tables[0];
                dataSach.DataSource = dtSach;
            }
            if (radTenNXB.Checked == true)
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.SearchSachTheoTenNXB(txtTimKiem.Text);
                dtSach = dataSet.Tables[0];
                dataSach.DataSource = dtSach;
            }
            if (radTenTG.Checked == true)
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.SearchSachTheoTenTG(txtTimKiem.Text);
                dtSach = dataSet.Tables[0];
                dataSach.DataSource = dtSach;
            }
            if (radTenTL.Checked == true)
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.SearchSachTheoTenTheLoai(txtTimKiem.Text);
                dtSach = dataSet.Tables[0];
                dataSach.DataSource = dtSach;
            }
        }
    }
}
