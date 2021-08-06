using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnDBMS.DB_layer;
using System.Data;
using System.Data.SqlClient;

namespace DoAnDBMS.BS_layer
{
    class QuanLySach
    {
        DBMain db = null;
        public QuanLySach()
        {
            db = new DBMain();
        }
        public DataSet LoadQLMuonSach()
        {
            return db.ExecuteQueryDataSet("exec LoadQLMuonSach", CommandType.Text);
        }
        public DataSet LoadQLTra()
        {
            return db.ExecuteQueryDataSet("exec LoadQLTra", CommandType.Text);
        }
    }
}
