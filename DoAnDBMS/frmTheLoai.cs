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
    public partial class frmTheLoai : Form
    {
        DataTable dtTL = null;
        TheLoai dbTL = new TheLoai();
        bool Add=true;
        public frmTheLoai()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtTL = new DataTable();
                dtTL.Clear();
                DataSet dataSet = dbTL.LoadTheLoai();
                dtTL = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataTheLoai.DataSource = dtTL;
                this.txtMaTL.ResetText();
                this.txtTenTL.ResetText();

                this.btnLuu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                dataTheLoai_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataTheLoai.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            txtMaTL.Text = dataTheLoai.Rows[r].Cells[0].Value.ToString();
            txtTenTL.Text = dataTheLoai.Rows[r].Cells[1].Value.ToString();
        }
        private void frmTheLoai_Load(object sender, EventArgs e)
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
            this.txtMaTL.Enabled = true;
            this.txtMaTL.ResetText();
            this.txtTenTL.ResetText();
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtMaTL.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataTheLoai.CurrentCell.RowIndex;
                string strUser = dataTheLoai.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa Thể Loại này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbTL.DeleteTheLoai(strUser);
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
            this.txtMaTL.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            this.txtTenTL.Focus();
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
                    if (txtMaTL.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập Mã Thể Loại");
                        txtMaTL.Focus();
                    }
                    else
                    {
                        dbTL = new TheLoai();
                        dbTL.AddTheLoai(txtMaTL.Text, txtTenTL.Text);
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
                    dbTL = new TheLoai();
                    dbTL.UpdateTheLoai(txtMaTL.Text, txtTenTL.Text);
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
