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
    public partial class frmDanhSachUser : Form
    {
        DataTable dtUser = null;
        User dbUser = new User();
        public frmDanhSachUser()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                radioNam.Checked = true;
                dtUser = new DataTable();
                dtUser.Clear();
                DataSet dataSet = dbUser.LoadUser();
                dtUser = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataUser.DataSource = dtUser;
                this.txtMa.ResetText();
                this.txtHoTen.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDiaChi.ResetText();
                this.txtEmail.ResetText();
                this.txtSDT.ResetText();

                this.btnLưu.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;
                this.radTheoMa.Checked = true;
                dataUser_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void dataUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dataUser.CurrentCell.RowIndex;
            //Chuyen thong tin len Pannel
            if (dataUser.Rows[r].Cells[6].Value.ToString() == "Nam")
                radioNam.Checked = true;
            else
                radioNu.Checked = true;
            txtMa.Text = dataUser.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text = dataUser.Rows[r].Cells[1].Value.ToString();
            dateNgaySinh.Text = dataUser.Rows[r].Cells[2].Value.ToString();
            txtDiaChi.Text = dataUser.Rows[r].Cells[3].Value.ToString();
            txtSDT.Text = dataUser.Rows[r].Cells[4].Value.ToString();
            txtEmail.Text = dataUser.Rows[r].Cells[5].Value.ToString();
        }
        private void frmDanhSachUser_Load(object sender, EventArgs e)
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
            this.txtEmail.ResetText();
            this.txtSDT.ResetText();
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            txtMa.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataUser.CurrentCell.RowIndex;
                string strUser = dataUser.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc là muốn xóa User này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbUser.DeleteUser(strUser);
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
            if (radTheoTen.Checked == true)
            {
                dtUser = new DataTable();
                dtUser.Clear();
                DataSet dataSet = dbUser.SearchUserTheoTen(txtTimKiem.Text);
                dtUser = dataSet.Tables[0];
                dataUser.DataSource = dtUser;
            }
            else
            {
                dtUser = new DataTable();
                dtUser.Clear();
                DataSet dataSet = dbUser.SearchUserTheoMa(txtTimKiem.Text);
                dtUser = dataSet.Tables[0];
                dataUser.DataSource = dtUser;
            }
        }
        private void btnLưu_Click(object sender, EventArgs e)
        {
          
            this.btnThem.Enabled = true;
            this.btnXoa.Enabled = true;
            try
            {
                if (txtMa.Text == "")
                    MessageBox.Show("Mã User không được trống!!");
                else
                {
                    string GioiTinh;
                    if (radioNam.Checked == true)
                        GioiTinh = "Nam";
                    else
                        GioiTinh = "Nữ";
                    User User = new User();
                    User.AddUser(txtMa.Text, txtHoTen.Text, dateNgaySinh.Text, txtDiaChi.Text, txtSDT.Text,
                        txtEmail.Text, GioiTinh);
                    Load_Data();
                    MessageBox.Show("Đã thêm xong!!");
                }
            }
            catch
            {
                MessageBox.Show("Thao tác không hợp lệ!");
            }
        }
    }
}
