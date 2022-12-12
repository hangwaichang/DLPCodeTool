using Classes;

public class DbContext
{
    public string Server { get; set; }
    public string ConnectionStr { get; set; }
    public void Connect() { }
    public void Inesrt(string sql, MultiLanguage ml, string program) {}
}