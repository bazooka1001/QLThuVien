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
    class Account
    {
        DBMain db = null;
        public Account()
        {
            db = new DBMain();
        }
        public DataSet LoadAccount()
        {
            return db.ExecuteQueryDataSet("exec LoadAccount", CommandType.Text);
        }
        public bool CheckAccount(string UserName, string PassWord,  string TypeAccount)
        {
            string sqlString = "select dbo.CheckAccount('"+UserName+"','"+PassWord+"','"+TypeAccount+"')";
            bool flag = bool.Parse(db.MyExecuteScalar(sqlString, CommandType.Text).ToString());
            return flag;
        }
        public bool AddAccount(string UserName, string PassWord, string Name, string TypeAccount)
        {
            string sqlString = "exec AddAcount '"+UserName+"','"+PassWord+"',N'"+Name+"','"+TypeAccount+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
        public bool UpdateAccount(string UserName, string NewPassWord)
        {
            string sqlString = "exec UpdateAccount '"+UserName+"','"+NewPassWord+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
