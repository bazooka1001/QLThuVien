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
    class SachUser
    {
        DBMain db = null;
        public SachUser()
        {
            db = new DBMain();
        }
        public DataSet LoadSachUser()
        {
            return db.ExecuteQueryDataSet("exec LoadSachUser", CommandType.Text);
        }
        public DataSet SearchSachTheoMa(string MaCuon)
        {
            return db.ExecuteQueryDataSet("exec SearchSachTheoMa N'" + MaCuon + "'", CommandType.Text);
        }
        public DataSet SearchSachTheoTenSach(string TenSach)
        {
            return db.ExecuteQueryDataSet("exec SearchSachTheoTenSach N'" + TenSach + "'", CommandType.Text);
        }
        public DataSet SearchSachTheoTenNXB(string TenNXB)
        {
            return db.ExecuteQueryDataSet("exec SearchSachTheoTenNXB N'" + TenNXB + "'", CommandType.Text);
        }
        public DataSet SearchSachTheoTenTG(string TenTG)
        {
            return db.ExecuteQueryDataSet("exec SearchSachTheoTenTG N'" + TenTG + "'", CommandType.Text);
        }
        public DataSet SearchSachTheoTenTheLoai(string TenTheLoai)
        {
            return db.ExecuteQueryDataSet("exec SearchSachTheoTenTheLoai N'" + TenTheLoai + "'", CommandType.Text);
        }
        public bool AddMuon(string MaDG)
        {
            string sqlString = "exec AddMuon '"+MaDG+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public int LayMaMuon(string MaDG)
        {
            string sqlString = "select dbo.LayMaMuon('"+MaDG+"')";
            int flag = int.Parse(db.MyExecuteScalar(sqlString, CommandType.Text).ToString());
            return flag;
        }
        public int SoLuongSachMuon(string MaDG)
        {
            string sqlString = "select dbo.SoLuongSachMuon ('"+MaDG+"')";
            int flag = int.Parse(db.MyExecuteScalar(sqlString, CommandType.Text).ToString());
            return flag;
        }
        public bool UpdateSachMuon(int MaMuon,string MaCuon,string NgayMuon,string NgayTra,int SoLuong)
        {
            string sqlString = "exec UpdateSachMuon " + MaMuon+",'"+MaCuon+"','"+NgayMuon+"','"+NgayTra+"',"+SoLuong;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool DeleteChiTietMuonMacDinh(int MaMuon)
        {
            string sqlString = "exec DeleteChiTietMuonMacDinh "+MaMuon;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool AddSachMuon(int MaMuon, string MaCuon, string NgayMuon, string NgayTra, int SoLuong)
        {
            string sqlString = "exec AddSachMuon " +MaMuon+",'"+MaCuon+"','"+NgayMuon+"','"+NgayTra + "'," + SoLuong;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public DataSet LoadSachDaMuon(string MaDG)
        {
            return db.ExecuteQueryDataSet("exec LoadSachDaMuon '"+MaDG+"'", CommandType.Text);
        }
        public bool DeleteSachMuon(int MaMuon,string MaCuon)
        {
            string sqlString = "exec DeleteSachMuon "+MaMuon+",'"+MaCuon+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public DataSet LoadLichSuMuonSach(string MaDG)
        {
            return db.ExecuteQueryDataSet("exec LoadLichSuMuonSach '"+MaDG+"'", CommandType.Text);
        }
        public DataSet LoadSoSachConNo(string MaDG)
        {
            return db.ExecuteQueryDataSet("exec LoadSoSachConNo '" + MaDG + "'", CommandType.Text);
        }
        public bool UpdateSoLuongTon(string MaCuon,int Ton)
        {
            string sqlString = "exec UpdateSoLuongTon '" + MaCuon + "', " + Ton;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool AddQLTraSach(string MaDG, string TenCuon, string NgayTra, int SoLuong)
        {
            string sqlString = "exec AddQLTraSach '" + MaDG + "',N'" + TenCuon + "','" + NgayTra + "', " + SoLuong;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateSoLanMuon(string MaCuon, int SoLanMuon)
        {
            string sqlString = "exec UpdateSoLanMuon '" + MaCuon + "', " + SoLanMuon;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
