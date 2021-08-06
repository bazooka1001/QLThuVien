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
    public partial class frmQLMuonSach : Form
    {
        DataTable dtSach = null;
        QuanLySach dbSach = new QuanLySach();
        public frmQLMuonSach()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadQLMuonSach();
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataQLMuonSach.DataSource = dtSach;   
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }

        private void frmQLMuonSach_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
