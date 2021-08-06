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
    public partial class frmDoiMatKhau : Form
    {
        public string oldPass;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string username,string pass) : this()
        {         
            txtUserName.Text = username;
            oldPass = pass;
            txtUserName.Enabled = false;
            
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
            }
            else
            {
                if (txtMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                }
                else
                {
                    if (txtReMatKhauMoi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập lại mật khẩu");
                    }
                    else
                    {
                        if ((txtMatKhauMoi.Text == txtReMatKhauMoi.Text) && (txtMatKhauCu.Text == oldPass))
                        {
                            Account login = new Account();
                            login.UpdateAccount(txtUserName.Text, txtMatKhauMoi.Text);
                            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cũ không đúng hoặc nhập lại mật khẩu không đúng");
                            txtMatKhauCu.Clear();
                            txtMatKhauMoi.Clear();
                            txtReMatKhauMoi.Clear();
                            txtMatKhauCu.Focus();
                        }
                    }
                }
            }
        }
    }
}
