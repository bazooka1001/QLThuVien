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
    public partial class frmNXB : Form
    {
        DataTable dtNXB = null;
        NXB dbNXB = new NXB();
        bool Add=true;
        public frmNXB()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtNXB = new DataTable();
                dtNXB.Clear();
                DataSet dataSet = dbNXB.LoadNXB();
                dtNXB = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataNXB.DataSource = dtNXB;
                this.txtMaNXB.ResetText();
                this.txtTenNXB.ResetText();
                this.txtEmail.ResetText();
                this.txtDiaChi.ResetText();

                this.btnLuu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                dataNXB_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataNXB.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            txtMaNXB.Text = dataNXB.Rows[r].Cells[0].Value.ToString();
            txtTenNXB.Text = dataNXB.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text = dataNXB.Rows[r].Cells[2].Value.ToString();
            txtEmail.Text = dataNXB.Rows[r].Cells[3].Value.ToString();
        }
        private void frmNXB_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Add = true;
            this.txtMaNXB.Enabled = true;
            this.txtMaNXB.ResetText();
            this.txtTenNXB.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtMaNXB.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataNXB.CurrentCell.RowIndex;
                string strUser = dataNXB.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa NXB này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbNXB.DeleteNXB(strUser);
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
            this.txtMaNXB.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtTenNXB.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
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
                    if (txtMaNXB.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập Mã Nhà Xuất Bản");
                        txtMaNXB.Focus();
                    }
                    else
                    {
                        dbNXB = new NXB();
                        dbNXB.AddNXB(txtMaNXB.Text, txtTenNXB.Text, txtDiaChi.Text, txtEmail.Text);
                        Load_Data();
                        MessageBox.Show("Đã thêm xong!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thao tác không hợp lệ!");
                }
            }
            else
            {
                try
                {
                    dbNXB = new NXB();
                    dbNXB.UpdateNXB(txtMaNXB.Text, txtTenNXB.Text, txtDiaChi.Text, txtEmail.Text);
                    Load_Data();
                    MessageBox.Show("Đã sửa xong!!");
                }
                catch
                {
                    MessageBox.Show("Thao tác không hợp lệ!");
                }
            }
        }
    }
}
