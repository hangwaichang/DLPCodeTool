using Classes;
using DLPCodeCreater;
using Oracle.ManagedDataAccess.Client;

public interface IDbContext
{
    string Server { get; set; }
    string ConnectionStr { get; set; }
    void Connect();
    //void Inesrt(string sql, MultiLanguage ml, string program);
}

public class DGDbContext : IDbContext
{
    public string Server { get; set; } = "DGDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.29.1.3)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = dgdbt)));password=dgtoadba;user id=oadba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        try
        {
            DBHelper.dbConn(ConnectionStr);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public OracleDataReader Query(string sql)
    {
        try
        {
            return DBHelper.QueryDB(sql);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}

public class VNDbContext : IDbContext
{
    public string Server { get; set; } = "VNDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.32.1.199)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = vndbt)));password=vntoadba;user id=oadba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        try
        {
            DBHelper.dbConn(ConnectionStr);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public OracleDataReader Query(string sql)
    {
        try
        {
            return DBHelper.QueryDB(sql);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}

public class VGDbContext : IDbContext
{
    public string Server { get; set; } = "VGDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.32.1.199)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = vgdbt)));password=vgtoadba;user id=oadba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        try
        {
            DBHelper.dbConn(ConnectionStr);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public OracleDataReader Query(string sql)
    {
        try
        {
            return DBHelper.QueryDB(sql);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}

public class TCDbContext : IDbContext
{
    public string Server { get; set; } = "TCDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.10.110)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = tcdbt)));password=tctdlpdba;user id=dlpdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        try
        {
            DBHelper.dbConn(ConnectionStr);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public OracleDataReader Query(string sql)
    {
        try
        {
            return DBHelper.QueryDB(sql);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}


public class EipDGDbContext : IDbContext
{
    public string Server { get; set; } = "DGDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.29.1.3)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DGPORTAL)));password=eipdba;user id=eipdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        try
        {
            DBHelper.dbConn(ConnectionStr);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void Inesrt(string sql, MultiLanguage ml, string program)
    {
        try
        {
            DBHelper.insertDB(sql, ml, program);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}
public class EipVSDbContext : IDbContext
{
    public string Server { get; set; } = "VSDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.32.1.199)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=VSPORTAL)));password=eipdba;user id=eipdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        DBHelper.dbConn(ConnectionStr);
    }
    public void Inesrt(string sql, MultiLanguage ml, string program)
    {
        DBHelper.insertDB(sql, ml, program);
    }
}
public class EipVGDbContext : IDbContext
{
    public string Server { get; set; } = "VGDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.32.1.199)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=VGPORTAL)));password=eipdba;user id=eipdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        DBHelper.dbConn(ConnectionStr);
    }
    public void Inesrt(string sql, MultiLanguage ml, string program)
    {
        DBHelper.insertDB(sql, ml, program);
    }
}
public class EipVNDbContext : IDbContext
{
    public string Server { get; set; } = "VNDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.32.1.199)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=VNPORTAL)));password=eipdba;user id=eipdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        DBHelper.dbConn(ConnectionStr);
    }
    public void Inesrt(string sql, MultiLanguage ml, string program)
    {
        DBHelper.insertDB(sql, ml, program);
    }
}
public class EipTCDbContext : IDbContext
{
    public string Server { get; set; } = "TCDB";
    public string ConnectionStr { get; set; } = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.10.108)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=k8sdb)));password=eipdba;user id=eipdba;";
    DBHelper DBHelper { get; set; } = new DBHelper();
    public void Connect()
    {
        DBHelper.dbConn(ConnectionStr);
    }
    public void Inesrt(string sql, MultiLanguage ml, string program)
    {
        DBHelper.insertDB(sql, ml, program);
    }
}



//泛型工廠
public static class GenericDbFactory<T> where T : IDbContext, new()
{
    public static T Create()
    {
        return new T();
    }
}