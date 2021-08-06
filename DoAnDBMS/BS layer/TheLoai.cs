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
    class TheLoai
    {
        DBMain db = null;
        public TheLoai()
        {
            db = new DBMain();
        }
        public DataSet LoadTheLoai()
        {
            return db.ExecuteQueryDataSet("exec LoadTheLoai", CommandType.Text);
        }
        public bool AddTheLoai(string MaTheLoai,string TenTheLoai)
        {
            string sqlString = "exec AddTheLoai '" + MaTheLoai + "',N'" + TenTheLoai + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteTheLoai(string MaTheLoai)
        {
            string sqlString = "exec DeleteTheLoai '" + MaTheLoai + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateTheLoai(string MaTheLoai,string TenTheLoai)
        {
            string sqlString = "exec UpdateTheLoai '" + MaTheLoai + "',N'" + TenTheLoai + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
