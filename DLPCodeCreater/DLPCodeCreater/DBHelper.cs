using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Collections;

namespace DLPCodeCreater
{

    public class DBHelper
    {
        OracleConnection oralceConnection;

        public void dbConn(string conn_str)
        {
            oralceConnection = new OracleConnection(conn_str);
            if (oralceConnection.State == ConnectionState.Closed)
            {
                try
                {
                    oralceConnection.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public OracleDataReader QueryDB(string sql)
        {

            try
            {

                OracleCommand cmd = new OracleCommand(sql, oralceConnection);

                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                return reader;

                //using (OracleDataReader reader = cmd.ExecuteReader())
                //{

                //    return reader;

                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void insertDB(string sql, MultiLanguage ml,string program)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(sql, oralceConnection);
                cmd.Parameters.Add(":ZH_TW", ml.ZH_TW); // 使用參數化填值
                cmd.Parameters.Add(":EN_US", ml.EN_US); // 使用參數化填值
                cmd.Parameters.Add(":VI_VN", ml.VI_VN); // 使用參數化填值
                cmd.Parameters.Add(":ZH_CN", ml.ZH_CN); // 使用參數化填值
                cmd.Parameters.Add(":EXTENSION", "N"); // 使用參數化填值
                cmd.Parameters.Add(":IMPORT_TAG", "Y"); // 使用參數化填值

                int Ret = cmd.ExecuteNonQuery(); // 回傳為異動筆數
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
