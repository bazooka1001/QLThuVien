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
    public partial class frmThongTinCaNhan : Form
    {
        DataTable dtInfo = null;
        Infomation dbInfo = new Infomation();
        public string typeInfo;
        public string InfoUserName;
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }
        public frmThongTinCaNhan(string type,string user) : this()
        {
            typeInfo = type;
            InfoUserName = user;
        }
        public void Load_Data()
        {
            try
            {
                this.btnLưu.Enabled = false;
                if(typeInfo=="Admin")
                {
                    radioNam.Checked = true;
                    dtInfo = new DataTable();
                    dtInfo.Clear();
                    DataSet dataset = dbInfo.LoadInfoQuanLy(InfoUserName);
                    dtInfo = dataset.Tables[0];
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        if (dtInfo.Rows[i][6].ToString() == "Nam")
                            radioNam.Checked = true;
                        else
                            radioNu.Checked = true;
                        txtMa.Text = dtInfo.Rows[i][0].ToString();
                        txtHoTen.Text= dtInfo.Rows[i][1].ToString();
                        dateNgaySinh.Text= dtInfo.Rows[i][2].ToString();
                        txtDiaChi.Text= dtInfo.Rows[i][3].ToString();
                        txtSDT.Text= dtInfo.Rows[i][4].ToString();
                        txtEmail.Text= dtInfo.Rows[i][5].ToString();
                    }
                }
                if(typeInfo== "Employee")
                {
                    radioNam.Checked = true;
                    dtInfo = new DataTable();
                    dtInfo.Clear();
                    DataSet dataset = dbInfo.LoadInfoNhanVien(InfoUserName);
                    dtInfo = dataset.Tables[0];
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        if (dtInfo.Rows[i][6].ToString() == "Nam")
                            radioNam.Checked = true;
                        else
                            radioNu.Checked = true;
                        txtMa.Text = dtInfo.Rows[i][0].ToString();
                        txtHoTen.Text = dtInfo.Rows[i][1].ToString();
                        dateNgaySinh.Text = dtInfo.Rows[i][2].ToString();
                        txtDiaChi.Text = dtInfo.Rows[i][3].ToString();
                        txtSDT.Text = dtInfo.Rows[i][4].ToString();
                        txtEmail.Text = dtInfo.Rows[i][5].ToString();
                    }
                }
                if(typeInfo== "User")
                {
                    radioNam.Checked = true;
                    dtInfo = new DataTable();
                    dtInfo.Clear();
                    DataSet dataset = dbInfo.LoadInfoDocGia(InfoUserName);
                    dtInfo = dataset.Tables[0];
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        if (dtInfo.Rows[i][6].ToString() == "Nam")
                            radioNam.Checked = true;
                        else
                            radioNu.Checked = true;
                        txtMa.Text = dtInfo.Rows[i][0].ToString();
                        txtHoTen.Text = dtInfo.Rows[i][1].ToString();
                        dateNgaySinh.Text = dtInfo.Rows[i][2].ToString();
                        txtDiaChi.Text = dtInfo.Rows[i][3].ToString();
                        txtSDT.Text = dtInfo.Rows[i][4].ToString();
                        txtEmail.Text = dtInfo.Rows[i][5].ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }
        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            Load_Data();
            txtMa.Enabled = false;
            txtHoTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            dateNgaySinh.Enabled = false;
            radioNam.Enabled = false;
            radioNu.Enabled = false;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            dateNgaySinh.Enabled = true;
            radioNam.Enabled = true;
            radioNu.Enabled = true;
            this.btnLưu.Enabled = true;
            txtHoTen.Focus();
        }  
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void btnLưu_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeInfo == "Admin")
                {
                    string GioiTinh;
                    if (radioNam.Checked == true)
                        GioiTinh = "Nam";
                    else
                        GioiTinh = "Nữ";
                    Infomation Info = new Infomation();
                    Info.UpdateInfoQuanLy(InfoUserName, txtHoTen.Text, dateNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, GioiTinh);
                    Load_Data();
                    MessageBox.Show("Đã sửa xong!!");
                }
                if (typeInfo == "Employee")
                {
                    string GioiTinh;
                    if (radioNam.Checked == true)
                        GioiTinh = "Nam";
                    else
                        GioiTinh = "Nữ";
                    Infomation Info = new Infomation();
                    Info.UpdateInfoNhanVien(InfoUserName, txtHoTen.Text, dateNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, GioiTinh);
                    Load_Data();
                    MessageBox.Show("Đã thêm xong!!");
                }
                if (typeInfo == "User")
                {
                    string GioiTinh;
                    if (radioNam.Checked == true)
                        GioiTinh = "Nam";
                    else
                        GioiTinh = "Nữ";
                    Infomation Info = new Infomation();
                    Info.UpdateInfoDocGia(InfoUserName, txtHoTen.Text, dateNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, GioiTinh);
                    Load_Data();
                    MessageBox.Show("Đã thêm xong!!");
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!");
            }
        }
    }
}
