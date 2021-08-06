using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnDBMS.BS_layer;

namespace DoAnDBMS
{
    public partial class frmTraSach : Form
    {
        public int MaMuon;
        public string MaDG;
        DataTable dtSach = null;
        SachUser dbSach = new SachUser();
        public frmTraSach()
        {
            InitializeComponent();
        }
        public frmTraSach(string user) : this()
        {
            MaDG = user;
        }
        public void Load_Sach()
        {
            try
            {
                this.txtMaDG.Text = MaDG;
                this.txtMaDG.Enabled = false;
                this.txtTongSach.Enabled = false;
                this.txtTongSach.Text = dbSach.SoLuongSachMuon(MaDG).ToString();
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadSachDaMuon(MaDG);
                dtSach = dataSet.Tables[0];
                dataSachMuon.DataSource = dtSach;
            }
            catch
            {
                dataSachMuon.DataSource = null;
                MessageBox.Show("Bạn đã trả hết sách!");
            }
         
           
        }
        private void frmTraSach_Load(object sender, EventArgs e)
        {
            Load_Sach();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void btnTra_Click(object sender, EventArgs e)
        {
            int r = dataSachMuon.CurrentCell.RowIndex;
            string MaMuon = dataSachMuon.Rows[r].Cells[0].Value.ToString();
            string MaCuon = dataSachMuon.Rows[r].Cells[1].Value.ToString();
            string TenCuon = dataSachMuon.Rows[r].Cells[2].Value.ToString();
            string NgayMuon = dataSachMuon.Rows[r].Cells[3].Value.ToString();
            string NgayTra = dataSachMuon.Rows[r].Cells[4].Value.ToString();
            string SoLuong = dataSachMuon.Rows[r].Cells[5].Value.ToString();
            int SLMuon = int.Parse(SoLuong);
            int SLTra = int.Parse(txtSoLuong.Text);
            DateTime Temp= DateTime.Parse(NgayTra);
            int value = DateTime.Compare(dateNgayTra.Value,Temp);
            if (SLTra > SLMuon)
            {
                MessageBox.Show("Số lượng trả không được lớn hơn số lượng mượn");
            }
            if (SLTra == SLMuon)
            {
                dbSach = new SachUser();
                dbSach.DeleteSachMuon(int.Parse(MaMuon), MaCuon);
                dbSach.AddQLTraSach(MaDG, TenCuon, dateNgayTra.Text, SLTra);
                Load_Sach();
            }
            if (SLTra < SLMuon)
            {
                int ConLai = SLMuon - SLTra;
                dbSach = new SachUser();
                dbSach.UpdateSachMuon(int.Parse(MaMuon), MaCuon, NgayMuon, NgayTra, ConLai);
                dbSach.AddQLTraSach(MaDG, TenCuon, dateNgayTra.Text, SLTra);
                Load_Sach();
            }
            if(value>0)
            {
                MessageBox.Show("Bạn đã trả sách trể vui lòng đóng phạt:10000");
            }
        }
    }
}
