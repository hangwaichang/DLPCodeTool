using Classes;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

public class GitBranch
{ 
    public string BranchKey { get; set; }
    public string BranchValue { get; set; }

    public GitBranch(string value, string text)
    {
        BranchKey = value;
        BranchValue = text;
    }
    public override string ToString()
    {
        return BranchValue;
    }
}