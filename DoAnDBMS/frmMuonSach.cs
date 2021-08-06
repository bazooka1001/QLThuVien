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
    public partial class frmMuonSach : Form
    {
        public int MaMuon;
        public string MaDG;
        DataTable dtSach = null;
        SachUser dbSach = new SachUser();      
        public frmMuonSach()
        {
            InitializeComponent();
        }
        public frmMuonSach(string user) : this()
        {
            MaDG = user;
            dbSach.AddMuon(MaDG);
        }
        public void Load_Sach()
        {
            //Tạo ra 1 Mã Mượn cho người dùng mượn sách
            MaMuon = dbSach.LayMaMuon(MaDG);
            dbSach.DeleteChiTietMuonMacDinh(MaMuon);
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet dataSet = dbSach.LoadSachDaMuon(MaDG);
            dtSach = dataSet.Tables[0];
            dataSachMuon.DataSource = dtSach;
        }
        public void Load_Data()
        {
            try
            {
                this.txtMaDG.Text = MaDG;
                this.txtMaDG.Enabled = false;
                radTheoTen.Checked = true;
                this.txtSoLuong.Focus();
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadSachUser();
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataSach.DataSource = dtSach;
                this.btnThoat.Enabled = true;
                this.dateNgayMuon.Enabled = false;
                this.dateNgayTra.ResetText();
                this.txtSoLuong.ResetText();


            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            Load_Sach();
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
            if (radTheoTen.Checked == true)
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
        private void btnMuon_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataSach.CurrentCell.RowIndex;
                string strMaCuon = dataSach.Rows[r].Cells[0].Value.ToString();
                int SLMuon = int.Parse(txtSoLuong.Text);
                int SLTon = int.Parse(dataSach.Rows[r].Cells[7].Value.ToString());
                int SoLanMuon = int.Parse(dataSach.Rows[r].Cells[8].Value.ToString());
                int SoLuong = SLTon - SLMuon;
                if (SLMuon <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lý");
                }
                else
                {
                    if (SLMuon > SLTon)
                    {
                        MessageBox.Show("Số lượng sách mượn không được lớn hơn số lượng tồn. Vui lòng nhập lại");
                        txtSoLuong.ResetText();
                    }
                    else
                    {                    
                        dbSach = new SachUser();                       
                        dbSach.AddSachMuon(MaMuon, strMaCuon, dateNgayMuon.Text, dateNgayTra.Text, int.Parse(txtSoLuong.Text));
                        dbSach.UpdateSoLuongTon(strMaCuon, SoLuong);
                        dbSach.UpdateSoLanMuon(strMaCuon, SoLanMuon);
                        Load_Sach();
                        Load_Data();
                    }
                }
            }
            catch
            {
                if(txtSoLuong.Text=="")
                    MessageBox.Show("Vui lòng nhập số lượng sách!!");
                else
                    MessageBox.Show("Không được mược sách đã được mượn!");
            }
        }
    }
}
