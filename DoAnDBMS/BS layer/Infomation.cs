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
    class Infomation
    {
        DBMain db = null;
        public Infomation()
        {
            db = new DBMain();
        }
        public DataSet LoadInfoQuanLy(string UserName)
        {
            return db.ExecuteQueryDataSet("exec LoadInfoQuanLy '"+UserName+"'", CommandType.Text);
        }
        public DataSet LoadInfoNhanVien(string UserName)
        {
            return db.ExecuteQueryDataSet("exec LoadInfoNhanVien '"+UserName+"'", CommandType.Text);
        }
        public DataSet LoadInfoDocGia(string UserName)
        {
            return db.ExecuteQueryDataSet("exec LoadInfoDocGia '"+UserName+"'", CommandType.Text);
        }
        public bool UpdateInfoQuanLy(string UserName,string HoTenQL,string NgaySinh,string DiaChi,
            string SDT,string Email,string GioiTinh)
        {
            string sqlString = "exec UpdateInfoQuanLy '"+UserName+"',N'"+HoTenQL+"','"+NgaySinh+
                "',N'"+DiaChi+"','"+SDT+"','"+Email+"',N'"+GioiTinh+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateInfoNhanVien(string UserName, string HoTenNV, string NgaySinh, string DiaChi,
            string SDT, string Email, string GioiTinh)
        {
            string sqlString = "exec UpdateInfoNhanVien '" + UserName + "',N'" + HoTenNV + "','" + NgaySinh +
                "',N'" + DiaChi + "','" + SDT + "','" + Email + "',N'" + GioiTinh + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateInfoDocGia(string UserName, string HoTenDG, string NgaySinh, string DiaChi,
            string SDT, string Email, string GioiTinh)
        {
            string sqlString = "exec UpdateInfoDocGia '" + UserName + "',N'" + HoTenDG + "','" + NgaySinh +
                "',N'" + DiaChi + "','" + SDT + "','" + Email + "',N'" + GioiTinh + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
