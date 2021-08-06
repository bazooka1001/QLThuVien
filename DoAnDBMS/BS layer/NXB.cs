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
    class NXB
    {
        DBMain db = null;
        public NXB()
        {
            db = new DBMain();
        }
        public DataSet LoadNXB()
        {
            return db.ExecuteQueryDataSet("exec LoadNXB", CommandType.Text);
        }
        public bool AddNXB(string MaNXB, string TenNXB,string DiaChi,string Email)
        {
            string sqlString = "exec AddNXB '"+MaNXB+"',N'"+TenNXB+"',N'"+DiaChi+"','"+ Email + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteNXB(string MaNXB)
        {
            string sqlString = "exec DeleteNXB '" + MaNXB + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateNXB(string MaNXB, string TenNXB, string DiaChi, string Email)
        {
            string sqlString = "exec UpdateNXB '" + MaNXB + "',N'" + TenNXB + "',N'" + DiaChi + "','" + Email + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
