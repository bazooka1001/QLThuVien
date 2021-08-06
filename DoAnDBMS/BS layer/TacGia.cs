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
    class TacGia
    {
        DBMain db = null;
        public TacGia()
        {
            db = new DBMain();
        }
        public DataSet LoadTacGia()
        {
            return db.ExecuteQueryDataSet("exec LoadTacGia", CommandType.Text);
        }
        public bool AddTacGia(string MaTG, string TenTG,string DiaChi,string SDT,string Email)
        {
            string sqlString = "exec AddTacGia '"+MaTG+"',N'"+TenTG+"',N'"+DiaChi+"','"+SDT+"','"+Email+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteTacGia(string MaTG)
        {
            string sqlString = "exec DeleteTacGia '" + MaTG + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateTacGia(string MaTG, string TenTG, string DiaChi, string SDT, string Email)
        {
            string sqlString = "exec UpdateTacGia '" + MaTG + "',N'" + TenTG + "',N'" + DiaChi + "','" + SDT + "','" + Email + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
