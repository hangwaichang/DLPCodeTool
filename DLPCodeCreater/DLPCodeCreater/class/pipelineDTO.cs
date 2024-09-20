using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DLPCodeCreater;
	public class pipelineDTO
{
	public string id {get; set;}
	public string name {get; set;}
	public string order_by { get; set;}
	public string Ref { get; set;}
	public string scope  { get; set; }  //running, pending, finished, branches, tags
	public string sha { get; set; }
	public string sort { get; set; }
	public string source { get; set; }
	public string status { get; set; } //created, waiting_for_resource, preparing, pending, running, success, failed, canceled, skipped, manual, scheduled

}
