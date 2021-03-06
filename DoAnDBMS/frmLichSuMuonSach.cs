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
    public partial class frmLichSuMuonSach : Form
    {
        public string MaDG;
        DataTable dtSach = null;
        SachUser dbSach = new SachUser();
        public frmLichSuMuonSach()
        {
            InitializeComponent();
        }
        public frmLichSuMuonSach(string user):this()
        {
            MaDG = user;
        }
        public void Load_Data()
        {
            try
            { 
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadLichSuMuonSach(MaDG);
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataLichSuMuonSach.DataSource = dtSach;
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }

        private void frmLichSuMuonSach_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
