using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace DLPCodeCreater
{

    public class SqlanalyzeHelper
    {
        OracleConnection oralceConnection;


        public List<AllSource> getAllSql(OracleDataReader reader)
        {
            List<AllSource> ASList = new List<AllSource>();
            // 讀取資料
            while (reader.Read())
            {
                AllSource item = new AllSource
                {
                    TEXT = reader.GetString(reader.GetOrdinal("TEXT")).ToUpper(),
                    LINE = reader.GetInt32(reader.GetOrdinal("LINE")),
                };

                ASList.Add(item);
            }

            return ASList;

        }
        public List<string> verifyTable(OracleDataReader reader)
        {
            List<string> tbResult = new List<string>();

            // 讀取資料
            while (reader.Read())
            {
                tbResult.Add(reader.GetString(reader.GetOrdinal("TABLES")));

            }

            return tbResult;

        }
    }
}
