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
    class SachOfNV
    {
        DBMain db = null;
        public SachOfNV()
        {
            db = new DBMain();
        }
        public DataSet LoadSachNV()
        {
            return db.ExecuteQueryDataSet("exec LoadSachNV", CommandType.Text);
        }
        public bool AddSachNV(string MaCuon, string TenCuon, string MaNXB, string MaTG, string NamXuatBan,string MaTheLoai,string NgayNhap,int Ton,int SoLanMuon)
        {
            string sqlString = "exec AddSachNV '"+MaCuon+"',N'"+TenCuon+"','"+MaNXB+"','"+MaTG+"','"+NamXuatBan+"','"+MaTheLoai+"','"+NgayNhap+"',"+Ton+","+SoLanMuon;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteSachNV(string MaCuon)
        {
            string sqlString = "exec DeleteSachNV '" + MaCuon + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateSachNV(string MaCuon, string TenCuon, string MaNXB, string MaTG, string NamXuatBan, string MaTheLoai, string NgayNhap, int Ton, int SoLanMuon)
        {
            string sqlString = "exec UpdateSachNV '" + MaCuon + "',N'" + TenCuon + "','" + MaNXB + "','" + MaTG + "','" + NamXuatBan + "','" + MaTheLoai + "','" + NgayNhap + "'," + Ton +","+ SoLanMuon;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public DataSet LoadTheLoai()
        {
            return db.ExecuteQueryDataSet("exec LoadTheLoai", CommandType.Text);
        }
        public DataSet LoadTacGia()
        {
            return db.ExecuteQueryDataSet("exec LoadTacGia", CommandType.Text);
        }
        public DataSet LoadNXB()
        {
            return db.ExecuteQueryDataSet("exec LoadNXB", CommandType.Text);
        }


    }
}
