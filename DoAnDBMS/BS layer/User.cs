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
    class User
    {
        DBMain db = null;
        public User()
        {
            db = new DBMain();
        }
        public DataSet LoadUser()
        {
            return db.ExecuteQueryDataSet("exec LoadUser", CommandType.Text);
        }
        public bool AddUser(string MaDG, string HoTenDG, string NgaySinh, string DiaChi,
            string SDT, string Email, string GioiTinh)
        {
            string sqlString = "exec AddUser '" + MaDG + "',N'" + HoTenDG + "','" + NgaySinh +
                "',N'" + DiaChi + "','" + SDT + "','" + Email + "',N'" + GioiTinh +  "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteUser(string MaDG)
        {
            string sqlString = "exec DeleteUser '" + MaDG + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public DataSet SearchUserTheoTen(string MaDG)
        {
            return db.ExecuteQueryDataSet("exec SearchUserTheoTen N'" + MaDG + "'", CommandType.Text);
        }
        public DataSet SearchUserTheoMa(string MaDG)
        {
            return db.ExecuteQueryDataSet("exec SearchUserTheoMa N'" + MaDG + "'", CommandType.Text);
        }
    }
}
