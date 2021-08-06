using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnDBMS.BS_layer;

namespace DoAnDBMS
{
    public partial class frmQLTraSach : Form
    {
        DataTable dtSach = null;
        QuanLySach dbSach = new QuanLySach();
        public frmQLTraSach()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {

                dtSach = new DataTable();
                dtSach.Clear();
                DataSet dataSet = dbSach.LoadQLTra();
                dtSach = dataSet.Tables[0];
                // Đưa dữ liệu lên DataGridView   
                dataQLTraSach.DataSource = dtSach;
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung");
            }
        }

        private void frmQLTraSach_Load(object sender, System.EventArgs e)
        {
            Load_Data();
        }
    }
}
