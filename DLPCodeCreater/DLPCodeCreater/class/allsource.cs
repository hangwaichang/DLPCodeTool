using Classes;

public class AllSource
{
    public string OWNER { get; set; }
    public string NAME { get; set; }
    public string TYPE { get; set; }
    public int LINE { get; set; }
    public string TEXT { get; set; }

    public AllSource ShallowCopy()
    {
        return (AllSource)this.MemberwiseClone();
    }
    public AllSource DeepCopy()
    {
        return new AllSource { OWNER = this.OWNER, NAME = this.NAME, TYPE = this.TYPE, LINE = this.LINE, TEXT = this.TEXT };
    }
}