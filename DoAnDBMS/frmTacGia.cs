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
    public partial class frmTacGia : Form
    {
        DataTable dtTG = null;
        TacGia dbTG = new TacGia();
        bool Add=true;
        public frmTacGia()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtTG = new DataTable();
                dtTG.Clear();
                DataSet dataSet = dbTG.LoadTacGia();
                dtTG = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataTacGia.DataSource = dtTG;
                this.txtMaTG.ResetText();
                this.txtTenTG.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.txtEmail.ResetText();

                this.btnLuu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                dataTacGia_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataTacGia.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            txtMaTG.Text = dataTacGia.Rows[r].Cells[0].Value.ToString();
            txtTenTG.Text = dataTacGia.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text= dataTacGia.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text= dataTacGia.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text= dataTacGia.Rows[r].Cells[4].Value.ToString();
        }
        private void frmTacGia_Load(object sender, EventArgs e)
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
            Add = true;
            this.txtMaTG.Enabled = true;
            this.txtMaTG.ResetText();
            this.txtTenTG.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtMaTG.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataTacGia.CurrentCell.RowIndex;
                string strUser = dataTacGia.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa Tác Giả này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbTG.DeleteTacGia(strUser);
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
            this.txtMaTG.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtTenTG.Focus();
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
                    if (txtMaTG.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập Mã Tác Giả");
                        txtMaTG.Focus();
                    }
                    else
                    {
                        dbTG = new TacGia();
                        dbTG.AddTacGia(txtMaTG.Text, txtTenTG.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
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
                    dbTG = new TacGia();
                    dbTG.UpdateTacGia(txtMaTG.Text, txtTenTG.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
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
