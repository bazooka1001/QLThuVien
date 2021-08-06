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
    class NhanVien
    {
        DBMain db = null;
        public NhanVien()
        {
            db = new DBMain();
        }
        public DataSet LoadNhanVien()
        {
            return db.ExecuteQueryDataSet("exec LoadNhanVien", CommandType.Text);
        }
        public bool AddNhanVien(string MaNV, string HoTenNV, string NgaySinh, string DiaChi,
            string SDT, string Email, string GioiTinh,string Luong)
        {
            string sqlString = "exec AddNhanVien '" + MaNV + "',N'" + HoTenNV + "','" + NgaySinh +
                "',N'" + DiaChi + "','" + SDT + "','" + Email + "',N'" + GioiTinh + "','"+Luong+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteNhanVien(string MaNV)
        {
            string sqlString = "exec DeleteNhanVien '" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public DataSet SearchNhanVienTheoTen(string MaNV)
        {
            return db.ExecuteQueryDataSet("exec SearchNhanVienTheoTen N'"+MaNV+"'", CommandType.Text);
        }
        public DataSet SearchNhanVienTheoMa(string MaNV)
        {
            return db.ExecuteQueryDataSet("exec SearchNhanVienTheoMa N'" + MaNV + "'", CommandType.Text);
        }

    }
}
