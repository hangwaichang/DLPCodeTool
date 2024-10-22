using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class mergerequest
{
	public int Id { get; set; }
	public int Iid { get; set; }  // 添加 Iid 屬性
	public string Title { get; set; }
	public string SourceBranch { get; set; }
	public string TargetBranch { get; set; }
	public string UserId { get; set; }
	public string BranchValue { get; set; }
}

