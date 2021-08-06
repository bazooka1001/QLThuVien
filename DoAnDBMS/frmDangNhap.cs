using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnDBMS.DB_layer;
using DoAnDBMS.BS_layer;

namespace DoAnDBMS
{
    public partial class frmDangNhap : Form
    {
        public static string user;
        public static string pass;
        public static string type;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private bool Login(string userName, string password, string typeA)
        {
            DataTable dtLogin = new DataTable();
            Account login = new Account();
            DataSet dsLogin = login.LoadAccount();
            dtLogin = dsLogin.Tables[0];

            for (int i = 0; i < dtLogin.Rows.Count; i++)
            {
                if (login.CheckAccount(userName,password,typeA)==true)
                {
                    user = userName;
                    pass = password;
                    type = typeA;
                    return true;
                }
            }
            return false;

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
                string userN = txtID.Text;
                string passW = txtPass.Text;
                string typeAC = "Admin";
                if (rdbEmployee.Checked == true)
                {
                    typeAC = "Employee";
                }
                if(rdbUser.Checked==true)
                {
                    typeAC = "User";
                }
                if (Login(userN, passW, typeAC) == true)
                {
                    if (typeAC == "Admin")
                    {
                        frmMain fMain = new frmMain();
                        this.Hide();
                        fMain.ShowDialog();
                        this.Show();
                        txtID.Clear();
                        txtPass.Clear();
                        txtID.Focus();
                    }
                    if(typeAC== "Employee")
                    {
                        frmNhanVien fMain = new frmNhanVien();
                        this.Hide();
                        fMain.ShowDialog();
                        this.Show();
                        txtID.Clear();
                        txtPass.Clear();
                        txtID.Focus();
                    }
                    if(typeAC== "User")
                    {
                        frmUser fMain = new frmUser();
                        this.Hide();
                        fMain.ShowDialog();
                        this.Show();
                        txtID.Clear();
                        txtPass.Clear();
                        txtID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu hoặc chức vụ không đúng vui lòng nhập lại", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Clear();
                    txtPass.Clear();
                    txtID.Focus();
                }
         
          
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
