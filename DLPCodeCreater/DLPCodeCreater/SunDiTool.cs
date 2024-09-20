using Classes;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using ComboBox = System.Windows.Forms.ComboBox;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;



namespace DLPCodeCreater
{
	public partial class Form1 : Form
	{
		FileHelper fhelper = new FileHelper();
		TranslateHelp thelper = new TranslateHelp();
		SqlanalyzeHelper sahelper = new SqlanalyzeHelper();

		DGDbContext DgDbcontext;
		VNDbContext VnDbcontext;
		VGDbContext VgDbcontext;
		TCDbContext TcDbcontext;
		EipDGDbContext EipDgDbcontext;
		EipVSDbContext EipVsDbcontext;
		EipVNDbContext EipVnDbcontext;
		EipVGDbContext EipVgDbcontext;
		EipTCDbContext EipTcDbcontext;


		public const string AppPortalpath = @"\DLP.Web\DLP.Web.AppPortal\ClientApp\src\app\views\";
		public const string Controllerspath = @"\DLP.WebAPI\DLP.WebAPI.{0}\Controllers\{1}";
		public const string Servicespath = @"\DLP.Model\DLP.Model.{0}Types\Services\{1}";
		public const string StoreProcedurepath = @"\DLP.Model\DLP.Model.{0}\StoreProcedure\{1}\SPName.cs";
		public const string DTOpath = @"\DLP.Model\DLP.Model.{0}Types\DTO\{1}";
		public const string Interfacepath = @"\DLP.Model\DLP.Model.{0}Types\Interface\{1}";
		public const string Repositoriespath = @"\DLP.Model\DLP.Model.{0}\Repositories\{1}";
		public const string Librariespath = @"\DLP.Web\DLP.Web.AppPortal\ClientApp\libraries\{0}";
		public const string Packagepath = @"\DLP.Web\DLP.Web.AppPortal\ClientApp\package.json";



		public const string checkTableSql = "SELECT VIEW_NAME TABLES FROM ALL_VIEWS WHERE OWNER='{0}' AND VIEW_NAME IN ( {1} ) UNION SELECT TABLE_NAME TABLES FROM ALL_TABLES WHERE OWNER='{0}' AND TABLE_NAME IN  ( {1} )";

		public string fModulepath = "";
		public string fAreapath = "";
		public string fProgrampath = "";
		public string fProgram = "";

		public string tModulepath = "";
		public string tAreapath = "";
		public string tProgrampath = "";
		public string tProgram = "";

		public string fCompath = "";
		List<Component> ComponentLists = new List<Component>();


		public int rowIndex = 0;

		public Boolean isdiffprogaram = false;

		List<string> repository = new List<string>();


		#region Tab4 變數宣告

		List<SearchResult> mainFilteredList = new List<SearchResult>();

		List<SearchResult> LOVFilteredList = new List<SearchResult>();

		List<innerObj> list_innerObj = new List<innerObj>();

		List<innerObj> list_CaptionObj = new List<innerObj>();

		List<innerObj> list_LovObj = new List<innerObj>();

		List<innerObj> list_selectObj = new List<innerObj>();

		public int count = 0;

		private string filePath = "";

		private int tempColumnIndex = 0;

		private int tempRowIndex = 0;

		public class innerObj
		{

			public int innerIndex { get; set; }    //內部索引
			public int? index { get; set; }    //分類索引
			public string dbColumn { get; set; }    //* 資料欄名稱
			public string itemEngName { get; set; } //* 名稱
			public string itemChtName { get; set; } //* 標籤 or * 提示(first)
			public string itemType { get; set; }    //* 項目類型

			public string HeaderType { get; set; }    //類型Gird/Form

			public int? SubSeq { get; set; }    //順序索引

			public bool Checked { get; set; }    //選取

			public string canvas { get; set; }    //* 工作區 * canvas

			public string datablock { get; set; }    //* 頁籤頁面 * 資料區塊


		}

		public class SearchResult
		{
			public int Index { get; }
			public string Line { get; }
			public string Header { get; }
			public string Sub { get; }
			public int index { get; }

			public string HeaderType { get; set; }

			public int? SubSeq { get; set; }

			public SearchResult(int index, string line)
			{
				Index = index;
				Line = line;
			}

			public SearchResult(int Counter, string line1, string line2, string type, int? subSeq)
			{
				index = Counter;
				Header = line1;
				Sub = line2;
				HeaderType = type;
				SubSeq = subSeq;
			}

		}

		public class JsonData
		{
			/*GRID部分*/
			public string grid_view_normal { get; set; }
			public string grid_view_number { get; set; }
			public string grid_view_date { get; set; }
			public string grid_confirm { get; set; }
			public string grid_check { get; set; }
			public string grid_select { get; set; }
			public string grid_caption { get; set; }

			/*FORM部分*/
			public string form_normal { get; set; }
			public string form_number { get; set; }
			public string form_date { get; set; }
			public string form_btn { get; set; }
			public string form_radio_btn { get; set; }
			public string form_hidden { get; set; }
			public string form_drop_down_list { get; set; }
			public string form_hidden2 { get; set; }
			public string form_caption { get; set; }
			public string form_checkbox { get; set; }

			/*LOV部分*/
			public string grid_Lovl { get; set; }
			public string form_Lovl { get; set; }
		}
		JsonData jsonData = new JsonData();


		private ContextMenuStrip contextMenu;//宣告一個右鍵選單的物件

		ListViewItem lvi;

		#endregion Tab4 變數宣告

		//public class mergeRequest
		//{
		//	public int Id { get; set; }
		//	public int Iid { get; set; }  // 添加 Iid 屬性
		//	public string Title { get; set; }
		//	public string SourceBranch { get; set; }
		//	public string TargetBranch { get; set; }
		//	public string UserId { get; set; }
		//}

		private const string GitLabApiUrl = "http://172.20.10.106/api/v4/";
		private const int GroupId = 4;  // 群組ID
		private const int ProjectId = 4;  // 項目ID
		private string PrivateToken; // 私人GitLab Token
		private int UserId;  // 用戶ID
		mergerequest MergeRequest = new mergerequest();
		private string pipelineId = null;
		private string LineNotifyToken; // 私人Line Notify Token = "nt5GSBBTbFs0VNprmQVR12x1Fy980EPytPVLezjDUy6"

		public Form1()
		{
			InitializeComponent();

			#region Tab4
			InitialListView();
			InitialContextMenu();
			// 將 TabControl 設置為填滿整個窗體
			tbc_main.Dock = DockStyle.Fill;
			#endregion Tab4

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			btn_dto.Enabled = false;
			btn_repositories.Enabled = false;
			btn_interface.Enabled = false;
			//版本號
			string version = System.Windows.Forms.Application.ProductVersion;
			this.Text = String.Format("SunDiTool {0}", version);

			//讀取紀錄資訊
			PrivateToken = Properties.Settings.Default.UserToken;
			UserId = Properties.Settings.Default.UserId;
			LineNotifyToken = Properties.Settings.Default.LineNotifyToken;

			txtToken.Text = PrivateToken;
			txtUserId.Text = UserId.ToString();
			txtLineNotifyToken.Text = LineNotifyToken;
		}

		#region SunDiRo

		//From
		private void btn_selectpath_Click(object sender, EventArgs e)
		{

			try
			{
				FolderBrowserDialog path = new FolderBrowserDialog();
				path.ShowDialog();
				this.tbx_projectpath.Text = path.SelectedPath;
				//取得模組列表
				List<string> ds = fhelper.DirSearch(this.tbx_projectpath.Text + AppPortalpath);

				BindingSource bs = new BindingSource();
				//放入from_module
				this.cbx_frommodule.DataSource = ds;
				//放入target_module
				this.cbx_targetmodule.DataSource = ds;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void cbx_frommodule_SelectedIndexChanged(object sender, EventArgs e)
		{
			fModulepath = this.tbx_projectpath.Text + AppPortalpath + this.cbx_frommodule.Text;
			//取得地區列表
			List<string> ds = fhelper.DirSearch(fModulepath);
			//放入from_area
			BindingSource bs = new BindingSource();
			this.cbx_fromarea.DataSource = ds;
		}

		private void cbx_fromarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			string programPath = "";
			fAreapath = fModulepath + @"\" + this.cbx_fromarea.Text;

			//WO 程式可能有pages路徑
			if (this.cbx_iswo.Checked)
			{
				programPath = fAreapath + @"\pages";
			}
			else
			{
				programPath = fAreapath;
			}
			//取得程式列表
			List<string> ds = fhelper.DirSearch(programPath);
			//放入from_program
			BindingSource bs = new BindingSource();
			this.cbx_fromprogram.DataSource = ds;
		}


		//Target
		private void cbx_targetmodule_SelectedIndexChanged(object sender, EventArgs e)
		{
			tModulepath = this.tbx_projectpath.Text + AppPortalpath + this.cbx_targetmodule.Text;
			//取得地區列表
			List<string> ds = fhelper.DirSearch(tModulepath);
			//放入from_area
			BindingSource bs = new BindingSource();
			this.cbx_targetarea.DataSource = ds;
		}

		private void cbx_targetarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			string programPath = "";
			tAreapath = tModulepath + @"\" + this.cbx_targetarea.Text;

			//WO 程式可能有pages路徑
			if (this.cbx_iswo.Checked)
			{
				programPath = tAreapath + @"\pages";
			}
			else
			{
				programPath = tAreapath;
			}

			//取得程式列表
			List<string> ds = fhelper.DirSearch(programPath);
			//放入from_program
			BindingSource bs = new BindingSource();
			this.cbx_targetprogram.DataSource = ds;
		}

		//搬移檔案
		private void btn_Move_Click(object sender, EventArgs e)
		{
			ResultMessage("===============1.前端檔案搬移開始================");
			//WO 程式可能有pages路徑
			if (this.cbx_iswo.Checked)
			{
				fProgrampath = fAreapath + @"\pages\" + this.cbx_fromprogram.Text;
				tProgrampath = tAreapath + @"\pages\" + this.cbx_targetprogram.Text;
			}
			else
			{
				fProgrampath = fAreapath + @"\" + this.cbx_fromprogram.Text;
				tProgrampath = tAreapath + @"\" + this.cbx_targetprogram.Text;
			}

			string fileName = "";
			string tfileName = "";
			//ts,css,html
			if (isdiffprogaram)
			{
				//複製不同程式名稱
				GetFileandMoveAndReplaceContext(fProgrampath, tProgrampath);
			}
			else
			{
				GetFileandMove(fProgrampath, tProgrampath);
			}

			//services
			fileName = this.cbx_fromprogram.Text + ".service.ts";
			if (isdiffprogaram) tfileName = tProgram + ".service.ts";
			FileMove(fAreapath + @"\services", tAreapath + @"\services", fileName, tfileName);
			//pop-up.service.ts
			fileName = this.cbx_fromprogram.Text + "-pop-up.service.ts";
			if (isdiffprogaram) tfileName = tProgram + "-pop-up.service.ts";
			if (File.Exists(fAreapath + @"\services\" + fileName))
			{
				FileMove(fAreapath + @"\services", tAreapath + @"\services", fileName, tfileName);
			}
			//states
			fileName = this.cbx_fromprogram.Text + ".state.ts";
			if (isdiffprogaram) tfileName = tProgram + ".state.ts";
			FileMove(fAreapath + @"\states", tAreapath + @"\states", fileName, tfileName);
			//api
			//20230427 因應前端CRUD新寫法可能沒有api.ts
			fileName = this.cbx_fromprogram.Text + ".api.ts";
			if (isdiffprogaram) tfileName = tProgram + ".api.ts";
			if (File.Exists(fAreapath + @"\api\" + fileName))
			{
				FileMove(fAreapath + @"\api", tAreapath + @"\api", fileName, tfileName);
			}
			//controls
			fileName = this.cbx_fromprogram.Text + ".control.ts";
			if (isdiffprogaram) tfileName = tProgram + ".control.ts";
			if (File.Exists(fAreapath + @"\controls\" + fileName))
			{
				FileMove(fAreapath + @"\controls", tAreapath + @"\controls", fileName, tfileName);
			}
			//form.control
			fileName = this.cbx_fromprogram.Text + "-form.control.ts";
			if (isdiffprogaram) tfileName = tProgram + "-form.control.ts";
			if (File.Exists(fAreapath + @"\controls\" + fileName))
			{
				FileMove(fAreapath + @"\controls", tAreapath + @"\controls", fileName, tfileName);
			}
			//validations
			fileName = this.cbx_fromprogram.Text + ".validation.ts";
			if (isdiffprogaram) tfileName = tProgram + ".validation.ts";
			if (File.Exists(fAreapath + @"\validations\" + fileName))
			{
				FileMove(fAreapath + @"\validations", tAreapath + @"\validations", fileName, tfileName);
			}
			ResultMessage("===============前端檔案搬移結束================");
		}


		public void GetFileandMove(string frompath, string targetpath)
		{
			List<string> filenames = fhelper.GetFiles(frompath);
			fhelper.CheckDir(targetpath);

			foreach (string fname in filenames)
			{
				string fpath = frompath + @"\" + fname;
				string tpath = targetpath + @"\" + fname;
				if (fhelper.FileMove(fpath, tpath))
				{
					ResultMessage("檔案搬移成功" + tpath);
				}
			}

		}

		/// <summary>
		/// 複製前端檔案並修改內容
		/// </summary>
		/// <param name="frompath"></param>
		/// <param name="targetpath"></param>
		public void GetFileandMoveAndReplaceContext(string frompath, string targetpath)
		{
			List<string> filenames = fhelper.GetFiles(frompath);
			fhelper.CheckDir(targetpath);

			foreach (string fname in filenames)
			{

				string fpath = frompath + @"\" + fname;
				string tpath = targetpath + @"\" + fname.Replace(fname.Split('.')[0], tProgram);
				if (fhelper.FileMove(fpath, tpath))
				{
					ResultMessage("檔案搬移成功" + tpath);
				}

				//修改內容
				ReplaceProgramName(tpath, fProgram, tProgram);

			}

		}
		/// <summary>
		/// 檔案搬移
		/// </summary>
		/// <param name="frompath"></param>
		/// <param name="targetpath"></param>
		/// <param name="filename"></param>
		/// <param name="tfilename"> 新的檔名 </param>
		public void FileMove(string frompath, string targetpath, string filename, string tfilename)
		{
			fhelper.CheckDir(targetpath);

			string fpath = frompath + @"\" + filename;

			string tpath = targetpath + @"\";
			tpath += tfilename != "" ? tfilename : filename;

			if (fhelper.FileMove(fpath, tpath))
			{
				ResultMessage("檔案搬移成功" + tpath);
			}

			//如果是新檔就要修改內容
			if (tfilename != "") ReplaceProgramName(tpath, fProgram, tProgram);


		}

		/// <summary>
		/// 取代內文程式代碼
		/// </summary>
		/// <param name="targetpath"></param>
		/// <param name="Oldvalue"></param>
		/// <param name="Newvalue"></param>
		public void ReplaceProgramName(string targetpath, string Oldvalue, string Newvalue)
		{

			string upperOldvalue = char.ToUpper(Oldvalue[0]) + Oldvalue.Substring(1);
			string upperNewvalue = char.ToUpper(Newvalue[0]) + Newvalue.Substring(1);

			//修改內文
			//小寫、大駝峰、大寫
			if (fhelper.FileReplace(targetpath, Oldvalue, Newvalue) && fhelper.FileReplace(targetpath, upperOldvalue, upperNewvalue) && fhelper.FileReplace(targetpath, Oldvalue.ToUpper(), upperNewvalue.ToUpper()))
			{
				ResultMessage("檔案內容取代成功" + targetpath);
			}

		}


		public void FileMoveAndReplace(string frompath, string targetpath, string fromprogram, string targetprogram, string filename, List<string> replace_first, List<string> replace_second = null)
		{
			fhelper.CheckDir(targetpath);

			string fpath = frompath + @"\" + fromprogram + filename;

			string tpath = targetpath + @"\";
			tpath += isdiffprogaram ? targetprogram : fromprogram;
			tpath += filename;

			if (fhelper.FileMove(fpath, tpath))
			{
				ResultMessage("檔案搬移成功" + tpath);
				if (fhelper.FileReplace(tpath, replace_first[0], replace_first[1]))
				{
					if (replace_second != null)
					{
						if (fhelper.FileReplace(tpath, replace_second[0], replace_second[1]))
						{
							ResultMessage("地區名稱取代成功!");
						}
					}
					else
					{
						ResultMessage("地區名稱取代成功!");
					}

				}

				//不同程式要修改內容
				if (isdiffprogaram) fhelper.FileReplace(tpath, fProgram.ToUpper(), tProgram.ToUpper());

			}

		}

		//訊息結果
		public void ResultMessage(string msg)
		{
			tbx_resultMsg.Text += Environment.NewLine;
			tbx_resultMsg.Text += msg;
		}

		private void btn_webapicopy_Click(object sender, EventArgs e)
		{
			ResultMessage("===============2.前端web-api讀取開始================");
			string program = this.cbx_fromprogram.Text.ToUpper();
			var serviceText = fhelper.FileRead(fAreapath + @"\services\web-api.service.ts", program, "}");

			//20230427 因應前端CRUD新寫法可能不需要複製 這兩個檔案
			if (serviceText.Count() > 0)
			{
				List<string> repalceServiceText;
				string fromPath = "/" + cbx_fromarea.Text + "/" + cbx_fromprogram.Text;
				string tragetPath = "/" + cbx_targetarea.Text + "/" + cbx_targetprogram.Text;

				string fromProgram = cbx_fromprogram.Text + ": {";
				string tragetProgram = cbx_targetprogram.Text + ": {";

				if (isdiffprogaram)
				{
					//不同程式要修改內容
					repalceServiceText = serviceText.Select(s => s.Replace(fromPath.ToUpper(), tragetPath.ToUpper())).Select(s => s.Replace(fromProgram.ToUpper(), tragetProgram.ToUpper())).ToList();
				}
				else
				{
					repalceServiceText = serviceText.Select(s => s.Replace(fromPath.ToUpper(), tragetPath.ToUpper())).ToList();
				}


				fhelper.FileWrite(repalceServiceText, false, "web-api.service");
				var modelText = fhelper.FileRead(fAreapath + @"\models\web-api.model.ts", program, "}");
				//不同程式要修改內容
				if (isdiffprogaram) modelText = modelText.Select(s => s.Replace(fromProgram.ToUpper(), tragetProgram.ToUpper())).ToList();

				fhelper.FileWrite(modelText, true, "web-api.model");

				//開啟copy.txt
				System.Diagnostics.Process.Start("explorer.exe", "copy.txt");

				//開啟目標web-api.service web-api.model
				System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\services\web-api.service.ts");
				System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\models\web-api.model.ts");
				ResultMessage("開啟檔案:" + tAreapath + @"\services\web-api.service.ts");
				ResultMessage("開啟檔案:" + tAreapath + @"\models\web-api.model.ts");
			}
			else
			{
				ResultMessage("web-api內沒有程式名稱:" + program + " 不須複製!");
			}


			ResultMessage("===============前端web-api讀取結束================");
		}

		private void btn_modulecopy_Click(object sender, EventArgs e)
		{
			ResultMessage("===============3.前端routing.module讀取開始================");
			List<string> lsmodulecopy = new List<string>();
			//.module
			string program = char.ToUpper(this.cbx_targetprogram.Text[0]) + this.cbx_targetprogram.Text.Substring(1);
			string area = this.cbx_targetarea.Text.ToLower();
			string module = this.cbx_targetmodule.Text.ToLower();
			string program_area = program.ToUpper() + area.ToUpper();
			string componentpath = "";
			if (this.cbx_iswo.Checked)
			{
				componentpath = "./" + area + "/pages/" + program + "/" + program + ".component";
			}
			else
			{
				componentpath = "./" + area + "/" + program + "/" + program + ".component";
			}


			string _importString = "import {{ {0}Component as {1}{2}Component }} from '{3}';";
			string _declarations = "{0}{1}Component,";
			lsmodulecopy.Add(String.Format(_importString, program, program, area, componentpath.ToLower()));
			lsmodulecopy.Add(String.Format(_declarations, program, area));

			fhelper.FileWrite(lsmodulecopy, false, module + ".module");

			//routing.module
			lsmodulecopy.Clear();

			lsmodulecopy.Add(String.Format(_importString, program, program, area, componentpath.ToLower()));

			lsmodulecopy.Add("{");
			lsmodulecopy.Add(String.Format("path: '{0}',", program_area));
			lsmodulecopy.Add(String.Format("component: {0}{1}Component,", program, area));
			lsmodulecopy.Add(String.Format("data: {{ title: '{0}', breadcrumb: '{1}' }},", program_area, program_area));
			lsmodulecopy.Add("},");

			fhelper.FileWrite(lsmodulecopy, true, module + "-routing.module");

			//開啟copy.txt
			System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
			//開啟目標.module routing.module
			System.Diagnostics.Process.Start("explorer.exe", tModulepath + @"\" + module + ".module.ts");
			System.Diagnostics.Process.Start("explorer.exe", tModulepath + @"\" + module + "-routing.module.ts");
			ResultMessage("開啟檔案:" + tModulepath + @"\" + module + ".module.ts");
			ResultMessage("開啟檔案:" + tModulepath + @"\" + module + "-routing.module.ts");

			ResultMessage("===============前端routing.module讀取結束================");
		}

		private void btn_backendmove_Click(object sender, EventArgs e)
		{
			ResultMessage("===============4.後端檔案搬移&地區修改開始================");
			List<string> replace = new List<string>();
			replace.Add('.' + cbx_fromarea.Text.ToUpper());
			replace.Add('.' + cbx_targetarea.Text.ToUpper());

			//Controller Route
			List<string> route_replace = new List<string>();
			route_replace.Add('/' + cbx_fromarea.Text.ToUpper() + '/');
			route_replace.Add('/' + cbx_targetarea.Text.ToUpper() + '/');


			//From
			string FromControllersFile = this.tbx_projectpath.Text + String.Format(Controllerspath, cbx_frommodule.Text, cbx_fromarea.Text);
			string FromServicesFile = this.tbx_projectpath.Text + String.Format(Servicespath, cbx_frommodule.Text, cbx_fromarea.Text);
			//Target
			string TargetControllersFile = this.tbx_projectpath.Text + String.Format(Controllerspath, cbx_targetmodule.Text, cbx_targetarea.Text);
			string TargetServicesFile = this.tbx_projectpath.Text + String.Format(Servicespath, cbx_targetmodule.Text, cbx_targetarea.Text);

			//Controller
			FileMoveAndReplace(FromControllersFile, TargetControllersFile, cbx_fromprogram.Text.ToUpper(), cbx_targetprogram.Text.ToUpper(), "Controller.cs", replace, route_replace);
			//Service
			FileMoveAndReplace(FromServicesFile, TargetServicesFile, cbx_fromprogram.Text.ToUpper(), cbx_targetprogram.Text.ToUpper(), "Service.cs", replace);
			ResultMessage("===============後端檔案搬移&地區修改結束================");
		}

		private void btn_spname_Click(object sender, EventArgs e)
		{
			ResultMessage("===============5.前端SPName讀取開始================");
			string program = this.cbx_fromprogram.Text.ToUpper();
			string FromStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_frommodule.Text, cbx_fromarea.Text);
			string TargetStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_targetmodule.Text, cbx_targetarea.Text);
			var serviceText = fhelper.FileRead(FromStoreProcedureFile, program, "#endregion");

			//不同程式要修改內容
			if (isdiffprogaram) serviceText = serviceText.Select(s => s.Replace(fProgram.ToUpper(), tProgram.ToUpper())).ToList();

			fhelper.FileWrite(serviceText, false, "SPName");

			//開啟copy.txt
			System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
			//SPName.cs
			System.Diagnostics.Process.Start("explorer.exe", TargetStoreProcedureFile);
			ResultMessage("開啟檔案:" + TargetStoreProcedureFile);
			ResultMessage("===============前端SPName讀取結束================");
		}

		private void btn_getrepository_Click(object sender, EventArgs e)
		{
			ResultMessage("===============6.取Repository明細開始================");

			btn_dto.Enabled = true;
			repository.Clear();

			//從TargetServices取 Repository明細
			string TargetServicesFile = this.tbx_projectpath.Text + String.Format(Servicespath, cbx_targetmodule.Text, cbx_targetarea.Text) + @"\" + cbx_targetprogram.Text.ToUpper() + "Service.cs";
			string keyword = cbx_targetprogram.Text.ToUpper() + "Service(";
			List<string> FileText = fhelper.FileRead(TargetServicesFile, keyword, ")");

			for (int i = 1; i < FileText.Count() - 1; i++)
			{
				ResultMessage(i + "-" + FileText[i].Trim().Split(" ")[0]);
				repository.Add(FileText[i].Trim().Split(" ")[0]);
			}

			if (repository.Count > 0)
			{
				btn_dto.Enabled = true;
				btn_repositories.Enabled = true;
				btn_interface.Enabled = true;
			}

			ResultMessage("===============取Repository明細結束================");
		}

		private void btn_dto_Click(object sender, EventArgs e)
		{
			ResultMessage("===============7.處理DTO作業開始================");

			if (string.Compare(cbx_fromarea.Text, cbx_targetarea.Text) != 0)
			{
				//不同區域才需處理DTO
				string program = this.cbx_fromprogram.Text.ToUpper();
				List<string> replace = new List<string>();
				List<string> openfiles = new List<string>();
				List<string> replace_udt = new List<string>();

				replace.Add('.' + cbx_fromarea.Text.ToUpper());
				replace.Add('.' + cbx_targetarea.Text.ToUpper());


				replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
				replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

				//處理DTO
				string FromDTOFile = this.tbx_projectpath.Text + String.Format(DTOpath, cbx_frommodule.Text, cbx_fromarea.Text);
				string TargetDTOFile = this.tbx_projectpath.Text + String.Format(DTOpath, cbx_targetmodule.Text, cbx_targetarea.Text);

				//清空copy.text
				fhelper.FileWrite(new List<string>(), false, "Start");

				foreach (var repo in repository)
				{
					int repoIndex = repo.Length - 10;//Repository Length
					repoIndex -= 1; //起始 'I' 字元長度

					string filename = repo.Substring(1, repoIndex) + "DTO.cs";
					if (File.Exists(TargetDTOFile + @"\" + filename))
					{
						openfiles.Add(TargetDTOFile + @"\" + filename);
						//已存在 抓關鍵字
						var dtoText = fhelper.FileRead(FromDTOFile + @"\" + filename, "#region " + program, "#endregion");

						//UDT物件名稱修正
						dtoText = dtoText.Select(s => s.Replace(replace_udt[0], replace_udt[1])).ToList();

						fhelper.FileWrite(dtoText, true, filename);
					}
					else
					{
						//不存在直接copy
						FileMoveAndReplace(FromDTOFile, TargetDTOFile, repo.Substring(1, repoIndex), repo.Substring(1, repoIndex), "DTO.cs", replace);
					}
				}

				//開啟copy.txt
				System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
				//DTO.cs
				foreach (var of in openfiles)
				{
					System.Diagnostics.Process.Start("explorer.exe", of);
				}

				ResultMessage("開啟檔案:DTO.cs");
			}
			else
			{
				ResultMessage("同一區域不須處理DTO");
			}

			ResultMessage("===============處理DTO作業結束================");
		}

		private void btn_interface_Click(object sender, EventArgs e)
		{
			ResultMessage("===============8.處理INTERFACE作業開始================");
			string program = this.cbx_fromprogram.Text.ToUpper();
			List<string> replace = new List<string>();
			List<string> replace_udt = new List<string>();
			List<string> openfiles = new List<string>();

			replace.Add('.' + cbx_fromarea.Text.ToUpper());
			replace.Add('.' + cbx_targetarea.Text.ToUpper());

			replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
			replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

			//處理Interface
			string FromInterfaceFile = this.tbx_projectpath.Text + String.Format(Interfacepath, cbx_frommodule.Text, cbx_fromarea.Text);
			string TargetInterfaceFile = this.tbx_projectpath.Text + String.Format(Interfacepath, cbx_targetmodule.Text, cbx_targetarea.Text);

			//清空copy.text
			fhelper.FileWrite(new List<string>(), false, "Start");

			foreach (var repo in repository)
			{
				string filename = repo + ".cs";
				if (File.Exists(TargetInterfaceFile + @"\" + filename))
				{
					openfiles.Add(TargetInterfaceFile + @"\" + filename);
					//已存在 抓關鍵字
					var dtoText = fhelper.FileRead(FromInterfaceFile + @"\" + filename, "#region " + program, "#endregion");

					//不同程式要修改內容
					if (isdiffprogaram) dtoText = dtoText.Select(s => s.Replace(fProgram.ToUpper(), tProgram.ToUpper())).ToList();

					fhelper.FileWrite(dtoText, true, filename);
				}
				else
				{
					//不存在直接copy
					FileMoveAndReplace(FromInterfaceFile, TargetInterfaceFile, repo, repo, ".cs", replace, replace_udt);
				}
			}

			//開啟copy.txt
			System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
			//Interface.cs
			foreach (var of in openfiles)
			{
				System.Diagnostics.Process.Start("explorer.exe", of);
			}

			ResultMessage("開啟檔案:Interface.cs");
			ResultMessage("===============處理INTERFACE作業結束================");
		}

		private void btn_repositories_Click(object sender, EventArgs e)
		{
			ResultMessage("===============9.處理REPOSITORIES作業開始================");
			string program = this.cbx_fromprogram.Text.ToUpper();
			List<string> replace = new List<string>();
			List<string> replace_udt = new List<string>();
			List<string> openfiles = new List<string>();

			replace.Add('.' + cbx_fromarea.Text.ToUpper());
			replace.Add('.' + cbx_targetarea.Text.ToUpper());

			replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
			replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

			//處理Interface
			string FromRepositoriesFile = this.tbx_projectpath.Text + String.Format(Repositoriespath, cbx_frommodule.Text, cbx_fromarea.Text);
			string TargetRepositoriesFile = this.tbx_projectpath.Text + String.Format(Repositoriespath, cbx_targetmodule.Text, cbx_targetarea.Text);

			//清空copy.text
			fhelper.FileWrite(new List<string>(), false, "Start");

			foreach (string repo in repository)
			{
				string filename = repo.Substring(1, repo.Length - 1) + ".cs";
				if (File.Exists(TargetRepositoriesFile + @"\" + filename))
				{
					openfiles.Add(TargetRepositoriesFile + @"\" + filename);
					//已存在 抓關鍵字
					var dtoText = fhelper.FileRead(FromRepositoriesFile + @"\" + filename, "#region " + program, "#endregion");
					//不同程式要修改內容
					if (isdiffprogaram) dtoText = dtoText.Select(s => s.Replace(fProgram.ToUpper(), tProgram.ToUpper())).ToList();

					fhelper.FileWrite(dtoText, true, filename);
				}
				else
				{
					//不存在直接copy
					FileMoveAndReplace(FromRepositoriesFile, TargetRepositoriesFile, repo.Substring(1, repo.Length - 1), repo.Substring(1, repo.Length - 1), ".cs", replace, replace_udt);
				}
			}

			//開啟copy.txt
			System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
			//Repositories.cs
			foreach (var of in openfiles)
			{
				System.Diagnostics.Process.Start("explorer.exe", of);
			}

			ResultMessage("開啟檔案:Repositories.cs");
			ResultMessage("===============處理REPOSITORIES作業結束================");
		}

		private void cbx_fromprogram_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbx_targetprogram.Text = cbx_fromprogram.Text;
			fProgram = cbx_targetprogram.Text;
		}

		private void tim_checkinput_Tick(object sender, EventArgs e)
		{
			if (this.Controls.OfType<ComboBox>().Any(t => string.IsNullOrEmpty(t.Text)))
			{
				btn_Move.Enabled = false;
				btn_webapicopy.Enabled = false;
				btn_modulecopy.Enabled = false;

				btn_backendmove.Enabled = false;
				btn_spname.Enabled = false;
				btn_getrepository.Enabled = false;
			}
			else
			{
				//搬移程式名稱需相同
				if (string.Compare(cbx_fromprogram.Text, cbx_targetprogram.Text) == 0 || isdiffprogaram)
				{
					btn_Move.Enabled = true;
					btn_webapicopy.Enabled = true;
					btn_modulecopy.Enabled = true;

					btn_backendmove.Enabled = true;
					btn_spname.Enabled = true;
					btn_getrepository.Enabled = true;
				}
				else
				{
					btn_Move.Enabled = false;
					btn_webapicopy.Enabled = false;
					btn_modulecopy.Enabled = false;

					btn_backendmove.Enabled = false;
					btn_spname.Enabled = false;
					btn_getrepository.Enabled = false;
				}
			}
		}

		private void cbx_targetarea_Leave(object sender, EventArgs e)
		{
			string tempprogram = cbx_targetprogram.Text.ToLower();
			cbx_targetarea.Text = cbx_targetarea.Text.ToLower();
			cbx_targetprogram.Text = tempprogram;
		}

		private void cbx_targetprogram_Leave(object sender, EventArgs e)
		{
			cbx_targetprogram.Text = cbx_targetprogram.Text.ToLower();
			tProgram = cbx_targetprogram.Text;
		}

		//Test Button
		private void button1_Click(object sender, EventArgs e)
		{
			tbx_projectpath.Text = @"D:\Git\dlp-develop";
			cbx_frommodule.Text = "mi";
			cbx_fromarea.Text = "dg";
			cbx_fromprogram.Text = "mii470";
			cbx_targetmodule.Text = "mi";
			cbx_targetarea.Text = "dg";
			cbx_targetprogram.Text = "mii470tzc";
		}

		//滾輪至底
		private void tbx_resultMsg_TextChanged(object sender, EventArgs e)
		{
			this.tbx_resultMsg.SelectionStart = this.tbx_resultMsg.Text.Length;
			this.tbx_resultMsg.SelectionLength = 0;
			this.tbx_resultMsg.ScrollToCaret();
		}
		#endregion

		#region DoGoRo
		private void cbx_tab2_frommodule_SelectedIndexChanged(object sender, EventArgs e)
		{
			fModulepath = this.tbx_tab2_projectpath.Text + AppPortalpath + this.cbx_tab2_frommodule.Text;
			//取得地區列表
			List<string> ds = fhelper.DirSearch(fModulepath);
			//放入from_area
			BindingSource bs = new BindingSource();
			this.cbx_tab2_fromarea.DataSource = ds;
		}

		private void cbx_tab2_fromarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			fAreapath = fModulepath + @"\" + this.cbx_tab2_fromarea.Text;
			//取得程式列表
			List<string> ds = fhelper.DirSearch(fAreapath);
			//放入from_program
			BindingSource bs = new BindingSource();
			this.cbx_tab2_fromprogram.DataSource = ds;
		}

		//搜尋繁體中文
		private void btn_gettranslate_Click(object sender, EventArgs e)
		{
			ResultMessage(TabEnum.DoGoRo, "------------------開始取得程式內部資料!------------------");
			//clear dgv_tab2_languagetranslate
			dgv_tab2_languagetranslate.DataSource = null;
			dgv_tab2_languagetranslate.Rows.Clear();
			ResultMessage(TabEnum.DoGoRo, "畫面清除");

			string fileName = "";
			thelper.languageTranslates_merge = new List<LanguageTranslate>();

			DirectoryInfo Dir;
			FileInfo[] files;


			//ts,css,html
			ResultMessage(TabEnum.DoGoRo, "1.掃描ts,css,html");
			fProgrampath = fAreapath + @"\" + this.cbx_tab2_fromprogram.Text;
			Dir = new DirectoryInfo(fProgrampath);
			files = Dir.GetFiles();
			thelper.mergeTranslate(thelper.getTranslate(files));

			//services
			ResultMessage(TabEnum.DoGoRo, "2.掃描services");
			fileName = this.cbx_tab2_fromprogram.Text + ".service.ts";
			thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
			//pop-up.service.ts
			ResultMessage(TabEnum.DoGoRo, "3.掃描pop-up.service.ts");
			fileName = this.cbx_tab2_fromprogram.Text + "-pop-up.service.ts";
			if (File.Exists(fAreapath + @"\services\" + fileName))
			{
				thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
			}
			//states
			ResultMessage(TabEnum.DoGoRo, "4.掃描states");
			fileName = this.cbx_tab2_fromprogram.Text + ".state.ts";
			thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\states\" + fileName));
			//controls
			ResultMessage(TabEnum.DoGoRo, "5.掃描controls");
			fileName = this.cbx_tab2_fromprogram.Text + ".control.ts";
			if (File.Exists(fAreapath + @"\controls\" + fileName))
			{
				thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
			}
			//form.control
			ResultMessage(TabEnum.DoGoRo, "6.掃描form.control");
			fileName = this.cbx_tab2_fromprogram.Text + "-form.control.ts";
			if (File.Exists(fAreapath + @"\controls\" + fileName))
			{
				thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
			}
			//validations
			ResultMessage(TabEnum.DoGoRo, "7.掃描validations");
			fileName = this.cbx_tab2_fromprogram.Text + ".validation.ts";
			if (File.Exists(fAreapath + @"\validations\" + fileName))
			{
				thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\validations\" + fileName));
			}

			//塞入資料
			ResultMessage(TabEnum.DoGoRo, "8.資料翻譯開始");
			foreach (var lt in thelper.languageTranslates_merge)
			{
				this.dgv_tab2_languagetranslate.Rows.Add(lt.TW, lt.ZH, lt.EN, lt.VI);
			}
			ResultMessage(TabEnum.DoGoRo, "------------------取得程式內部資料完成------------------");
		}

		private void btn_tab2_selectpath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog path = new FolderBrowserDialog();
			path.ShowDialog();
			this.tbx_tab2_projectpath.Text = path.SelectedPath;
			//取得模組列表
			List<string> ds = fhelper.DirSearch(this.tbx_tab2_projectpath.Text + AppPortalpath);

			BindingSource bs = new BindingSource();
			//放入from_module
			this.cbx_tab2_frommodule.DataSource = ds;
			//放入from_module
			this.cbx_tab2_frommodule.DataSource = ds;
		}

		//滾輪至底
		private void tbx_tab2_resultMsg_TextChanged(object sender, EventArgs e)
		{
			this.tbx_tab2_resultMsg.SelectionStart = this.tbx_tab2_resultMsg.Text.Length;
			this.tbx_tab2_resultMsg.SelectionLength = 0;
			this.tbx_tab2_resultMsg.ScrollToCaret();
		}


		private void btn_IMultLanguage_Click(object sender, EventArgs e)
		{
			try
			{
				string sql = "INSERT INTO BASE_MULTI_LANGUAGE(ZH_TW, EN_US, VI_VN, ZH_CN, EXTENSION, IMPORT_TAG)VALUES(:ZH_TW, :EN_US, :VI_VN, :ZH_CN, :EXTENSION, :IMPORT_TAG)";

				foreach (DataGridViewRow row in dgv_tab2_languagetranslate.Rows)
				{
					MultiLanguage ml = new MultiLanguage()
					{
						ZH_TW = row.Cells["tw"].Value.ToString(),
						EN_US = row.Cells["en"].Value.ToString(),
						VI_VN = row.Cells["vi"].Value.ToString(),
						ZH_CN = row.Cells["zh"].Value.ToString(),
					};

					DbInsert(sql, ml, this.cbx_tab2_fromprogram.Text.ToUpper());
				}

				ResultMessage(TabEnum.DoGoRo, "DB-寫入結束!");
			}
			catch (Exception)
			{

				throw;
			}

		}

		//寫入DB
		public void DbInsert(string sql, MultiLanguage ml, string program)
		{
			try
			{
				if (cbx_dgdb.Checked)
				{
					EipDgDbcontext.Inesrt(sql, ml, program);
				}
				if (cbx_vgdb.Checked)
				{
					EipVgDbcontext.Inesrt(sql, ml, program);
				}
				if (cbx_vndb.Checked)
				{
					EipVnDbcontext.Inesrt(sql, ml, program);
				}
				if (cbx_vsdb.Checked)
				{
					EipVsDbcontext.Inesrt(sql, ml, program);
				}
				if (cbx_tcdb.Checked)
				{
					EipTcDbcontext.Inesrt(sql, ml, program);
				}
			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}


		}

		//DB Select
		private void cbx_dgdb_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbx_dgdb.Checked)
				{
					if (EipDgDbcontext == null)
					{
						EipDgDbcontext = GenericDbFactory<EipDGDbContext>.Create();
						EipDgDbcontext.Connect();
						ResultMessage(TabEnum.DoGoRo, "DGDB-連線成功!");
					}
				}
			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}

		}

		private void cbx_vsdb_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbx_vsdb.Checked)
				{
					if (EipVsDbcontext == null)
					{
						EipVsDbcontext = GenericDbFactory<EipVSDbContext>.Create();
						EipVsDbcontext.Connect();
						ResultMessage(TabEnum.DoGoRo, "VSDB-連線成功!");
					}
				}
			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}
		}

		private void cbx_vndb_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbx_vndb.Checked)
				{
					if (EipVnDbcontext == null)
					{
						EipVnDbcontext = GenericDbFactory<EipVNDbContext>.Create();
						EipVnDbcontext.Connect();
						ResultMessage(TabEnum.DoGoRo, "VNDB-連線成功!");
					}
				}
			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}
		}

		private void cbx_vgdb_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbx_vgdb.Checked)
				{
					if (EipVgDbcontext == null)
					{
						EipVgDbcontext = GenericDbFactory<EipVGDbContext>.Create();
						EipVgDbcontext.Connect();
						ResultMessage(TabEnum.DoGoRo, "VGDB-連線成功!");
					}
				}
			}
			catch (Exception ex)
			{
				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}
		}

		private void cbx_tcdb_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbx_tcdb.Checked)
				{
					if (EipTcDbcontext == null)
					{
						EipTcDbcontext = GenericDbFactory<EipTCDbContext>.Create();
						EipTcDbcontext.Connect();
						ResultMessage(TabEnum.DoGoRo, "TCDB-連線成功!");
					}
				}
			}
			catch (Exception ex)
			{
				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}
		}

		private void tim_tab2_Tick(object sender, EventArgs e)
		{
			if (cbx_tab2_fromarea.Items.Count > 0 && cbx_tab2_frommodule.Items.Count > 0 && cbx_tab2_fromprogram.Items.Count > 0)
			{
				btn_gettranslate.Enabled = true;

			}
			else
			{
				btn_gettranslate.Enabled = false;
				btn_IMultLanguage.Enabled = false;
			}

			if (cbx_dgdb.Checked || cbx_vsdb.Checked || cbx_vgdb.Checked || cbx_tcdb.Checked || cbx_vndb.Checked)
			{
				btn_IMultLanguage.Enabled = true;
			}
			else
			{
				btn_IMultLanguage.Enabled = false;
			}

		}

		//右鍵刪除事件
		private void dgv_tab2_languagetranslate_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				dgv_tab2_languagetranslate.Rows[e.RowIndex].Selected = true;
				rowIndex = e.RowIndex;
				dgv_tab2_languagetranslate.CurrentCell = dgv_tab2_languagetranslate.Rows[rowIndex].Cells[1];
				cmt_tab2_deleterow.Show(dgv_tab2_languagetranslate, e.Location);
				cmt_tab2_deleterow.Show(Cursor.Position);
			}
		}

		//Delete Row
		private void cmt_tab2_deleterow_Click(object sender, EventArgs e)
		{
			dgv_tab2_languagetranslate.Rows.RemoveAt(this.rowIndex);
		}





		#endregion

		#region Tab4
		private void InitialListView()
		{

			// Set the view to show details.
			lstVwSubItems.View = View.Details;
			// Allow the user to rearrange columns.
			lstVwSubItems.AllowColumnReorder = true;
			// Display check boxes.
			lstVwSubItems.CheckBoxes = true;
			// Select the item and subitems when selection is made.
			lstVwSubItems.FullRowSelect = true;
			// Display grid lines.
			lstVwSubItems.GridLines = true;
			// Sort the items in the list in ascending order.
			lstVwSubItems.Sorting = SortOrder.Ascending;

			this.comboBox1.Visible = false;

		}


		private void ReadJsonSetting()
		{
			if (this.chk_Gridtype.Checked == true)
				ReadConfiguration(@"Template_DlpGridForm.json", jsonData);
			else
				//ReadConfiguration(@"D:\DLPCodeCreater\DLPCodeCreater\bin\Debug\net6.0-windows\Template.json", jsonData);
				ReadConfiguration(@"Template.json", jsonData);
		}

		//設定右鍵選單
		private void InitialContextMenu()
		{
			// 加載圖像
			System.Drawing.Image image1 = System.Drawing.Image.FromFile(@"delete.png");
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(@"form.png");
			System.Drawing.Image image3 = System.Drawing.Image.FromFile(@"grid.png");

			contextMenu = new ContextMenuStrip();
			// 創建菜單項目
			ToolStripMenuItem item1 = new ToolStripMenuItem("清空", image1);
			ToolStripMenuItem item2 = new ToolStripMenuItem("設定Form", image2);
			ToolStripMenuItem item3 = new ToolStripMenuItem("設定Grid", image3);

			// 將菜單項目添加到ContextMenuStrip
			contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { item1, item2, item3 });

			// 關聯ContextMenuStrip到您的控制元件
			this.dGdVwHeaders.Columns[1].ContextMenuStrip = contextMenu;

			// 設置事件處理程序以處理選項的點擊事件
			item1.Click += Item1_Click;
			item2.Click += Item2_Click;
			item3.Click += Item3_Click;
		}

		//偵測檔案否為BIG5編碼
		public static bool IsBig5Encoding(string file)
		{
			if (!File.Exists(file)) return false;

			Encoding big5 = Encoding.GetEncoding(950);
			byte[] bytes = File.ReadAllBytes(file);
			//將byte[]轉為string再轉回byte[]看位元數是否有變
			return bytes.Length ==
				big5.GetByteCount(big5.GetString(bytes));
		}

		private void btnPath_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();

				// 設定預設的檔案類型篩選器
				//openFileDialog.Filter = "所有檔案|*.*";
				openFileDialog.Filter = "文本檔案 (*.txt), Excel Files(*.xls)|*.txt;*.xls;*.xlsx;*.xlsm";
				openFileDialog.Title = "選擇要打開的檔案";



				// 使用者選擇了檔案
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					list_innerObj.Clear();
					list_LovObj.Clear();

					string selectedFilePath = openFileDialog.FileName;
					this.txtSelectPath.Text = selectedFilePath;

					if (Path.GetExtension(selectedFilePath) != ".txt")  //副檔名
					{
						textBoxResults.AppendText($"副檔名： {Path.GetExtension(selectedFilePath)}]{Environment.NewLine}");

						ReadExcelFile(selectedFilePath, list_innerObj);


						dGV_innerObj.DataSource = list_innerObj;


						List<IGrouping<int?, innerObj>> headerlist2 = list_innerObj.GroupBy(x => x.index).ToList();//取header使用

						headerlist2.ForEach(group =>
						{
							this.dGdVwHeaders.Rows.Add(group.Key, "");  //改用combobox，預設值為空
																		//group.ToList().ForEach(item => textBoxResults.AppendText($"\tindex:{item.index}"));//, Score:{item.Score}  分組後內容取得
						});


						var datarow2 = this.dGdVwHeaders.Rows[0];   // 母表選澤ROW DATA
						this.Fun_Reload_SubDataGridView(datarow2);


						return;
					}


					//textBoxResults.AppendText($" 取得檔名(不包含附檔名)： {Path.GetFileNameWithoutExtension(openFileDialog.FileName)}]{Environment.NewLine}");
					filePath = openFileDialog.FileName; //(全域)

					//// 檢測文件編碼
					Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
					string[] lines;

					// 判斷編碼
					if (!IsBig5Encoding(openFileDialog.FileName))
					{
						//MessageBox.Show("非BIG5編碼");
						textBoxResults.AppendText($"非BIG5編碼{Environment.NewLine}");
						// 讀取文字檔的每一行
						lines = File.ReadAllLines(selectedFilePath);
					}
					else
					{
						// 讀取文字檔的每一行
						lines = File.ReadAllLines(selectedFilePath, Encoding.GetEncoding("BIG5"));
						// 將每行內容從預設編碼轉換為 UTF-8
						for (int i = 0; i < lines.Length; i++)
						{
							Encoding big5Encoding = Encoding.GetEncoding("BIG5");
							byte[] bytes = big5Encoding.GetBytes(lines[i]);

							byte[] encodedBytes = Encoding.Convert(Encoding.GetEncoding("BIG5"), Encoding.UTF8, bytes);
							string utf8Line = Encoding.UTF8.GetString(encodedBytes);
							lines[i] = utf8Line;
						}
					}


					// 要搜尋的多個字串 for select detail-----------------------------------------------
					string[] search_SelectDetail_Strings = new string[]
					{
						"     * 名稱                                          ",
						"     * Name                                          ",
						"項目類型                                      清單項目",   // select/dropDown obj
                        "     * 元素的清單                                    ",
						"     * Elements in List                              ",
						"       * 標籤                                        ",
						"       * Label                                       ",
						"       * 清單項目值                                  ",
						"       * List Item Value                             ",
						"項目類型                                      圓鈕群組",   // redioBtn obj
                        "       * 圓鈕值                                      ",
						"* 清單項目值              ",                               // Caption Need
                        "* List Item Value              ",                          // Caption Need
                        "- Font                  ",                                 // Caption Need
                        "- 字型                  ",                                 // Caption Need
                    };

					// 儲存符合搜尋字串的索引和字串
					var search_SelectDetail_Results = new List<SearchResult>();

					for (int i = 0; i < lines.Length; i++)
					{
						string line = lines[i];
						foreach (string searchString in search_SelectDetail_Strings)
						{
							// 判斷是否有符合搜尋字串的內容
							if (line.Contains(searchString))
							{
								// 建立 SearchResult 物件並將索引和字串儲存起來
								var result = new SearchResult(i, line);
								search_SelectDetail_Results.Add(result);
								break; // 找到符合的字串後跳出迴圈，繼續處理下一行
							}
						}
					}

					//foreach (var result in search_SelectDetail_Results)
					//    textBoxResults.AppendText($"000_SelectDetail 找到符合的字串：內容：[{result.Line}]，索引：{result.Index}{Environment.NewLine}");
					// 要搜尋的多個字串 for select detail-----------------------------------------------


					// 要搜尋的多個字串
					string[] searchStrings = new string[]
					{
					" * 區塊                                              ",
                    //"   * 名稱                                            ", // 資料區塊
                    "   * 項目                                            ",
					"     * 名稱                                          ",
					"     * 項目類型                                      ",
					"     - 項目類型                                      ",
					"     ^ 項目類型                                      ",
					"     * 資料欄名稱                                    ",
					"     * 提示                                          ",
					"   - 關係                                            ",
					"     * 標籤                                          ",
					" * Blocks                                            ",
					"   * Items                                           ",
					"     * Name                                          ",
					"     * Item Type                                     ",
					"     - Item Type                                     ",
					"     ^ Item Type                                     ",
					"     * Column Name                                   ",
					"     * Prompt                                        ",
					"   - Relations                                       ",
					"     ^ Label                                         ",
					" * 值清單                                            ",   // Header
                    " * Lists of Values                                   ",   // Header
                    " - 功能表                                            ",
					" - Menus                                             ",
					"* 來源名稱                                  LOV_ITEM",
					"   * 記錄群組                                        ",
					"     * 值清單                                        LOV_",    //與 * 資料欄名稱 同層
                    "     * List of Values                                LOV_",    //與 * Column Name  同層
                    "* 名稱                                            LOV_",       //與 * 值清單 字串一致
                    "* Name                                            LOV_",       //與 * List of Values 字串一致
                    "     * 名稱                                          ",        // LOV MAPPING
                    "     * 標題                                          ",        // LOV MAPPING
                    "     * 回覆項目                                      ",        // LOV MAPPING
                    "     * 顯示寬度                                      ",        // LOV MAPPING
                    "     * Name                                          ",        // LOV MAPPING
                    "     * Title                                         ",        // LOV MAPPING
                    "     * Return Item                                   ",        // LOV MAPPING
                    "     * Display Width                                 ",        // LOV MAPPING
                    "     * 工作區                                        ",        // 取工作區CANVAS用
                    "     * 頁籤頁面                                      ",        // 取資料區塊用
                    };

					// 儲存符合搜尋字串的索引和字串
					var searchResults = new List<SearchResult>();

					for (int i = 0; i < lines.Length; i++)
					{
						string line = lines[i];


						foreach (string searchString in searchStrings)
						{
							// 判斷是否有符合搜尋字串的內容
							if (line.Contains(searchString))
							{
								// 建立 SearchResult 物件並將索引和字串儲存起來
								var result = new SearchResult(i, line);
								searchResults.Add(result);
								break; // 找到符合的字串後跳出迴圈，繼續處理下一行
							}
						}
					}

					//foreach (var result in searchResults)
					//    textBoxResults.AppendText($"000 找到符合的字串：內容：[{result.Line}]，索引：{result.Index}{Environment.NewLine}");


					// 要搜尋的多個字串 Header
					string[] headerStrings = new string[]
					{
					" * 區塊                                              ",
					"   * 項目                                            ",
					"   - 關係                                            ",
					" * Blocks                                            ",
					"   * Items                                           ",
					"   - Relations                                       ",
					" * 值清單                                            ",
					" * Lists of Values                                   ",
					" - 功能表                                            ",
					" - Menus                                             ",
					};


					// 儲存分類後的結果
					var categorizedResults = new List<SearchResult>();

					// 將搜尋結果顯示在 TextBox 控制項中
					//textBoxResults.Clear();
					string header = null;
					int counter = 0;
					foreach (var result in searchResults)
					{
						//textBoxResults.AppendText($"001 找到符合的字串：內容：[{result.Line}]，索引：{result.Index}{Environment.NewLine}");


						for (int i = 0; i < headerStrings.Length; i++)
						{
							string line = headerStrings[i];


							// 判斷是否有符合搜尋字串的內容
							if (result.Line.Contains(line))
							{
								// 如果是頭分類，則設定目前的分類為該頭分類
								header = result.Line;
								counter++;
							}

						}

						if (!string.IsNullOrEmpty(header) && header != result.Line)
						{
							// 如果是子分類，將該行文字加入到目前的分類中
							// 建立 SearchResult 物件並將索引和字串儲存起來
							categorizedResults.Add(new SearchResult(counter, header, result.Line, "", null));
						}
					}


					//textBoxResults.Clear();
					//foreach (var obj in resultobj)
					//    textBoxResults.AppendText($"003 找到符合的字串：Counter：[{obj.index}]，頭：[{obj.Header}]，子：[{obj.Sub}]{Environment.NewLine}");


					/* 過濾掉'非項目'的分類 */
					// 主層
					this.mainFilteredList = categorizedResults.FindAll(e => e.Header == "   * 項目                                            "
						|| e.Header == "   * Items                                           ");

					// LOV層
					this.LOVFilteredList = categorizedResults.FindAll(e => e.Header == " * 值清單                                            "
						|| e.Header == " * Lists of Values                                   ");




					int temp_index = 0;
					string temp_canvas = "";
					bool flag = false;
					//textBoxResults.Clear();
					string _temp_dbColumn = string.Empty, _temp_itemEngName = string.Empty, _temp_itemChtName = string.Empty, _temp_itemType = string.Empty, _temp_canvas = string.Empty, _temp_datablock = string.Empty;

					string _LOV_dbColumn = string.Empty, _LOV_itemEngName = string.Empty, _LOV_itemChtName = string.Empty, _LOV_key = string.Empty;

					string _select_itemChtName = string.Empty, _select_key = string.Empty, _select_value = string.Empty;


					// select/dropDown層 填值處理
					foreach (var obj in search_SelectDetail_Results.Select((Value, Index) => new { Value, Index }))
					{
						//textBoxResults.AppendText($"select找到符合的字串：Counter：[{obj.Value.Index}]，頭：[{obj.Value.Line}]，子：[{obj.Value.Sub}]{Environment.NewLine}");
						//textBoxResults.AppendText($"select找到符合的字串：[{obj.Value}]");

						if (obj.Value.Line.Contains("* 名稱                                          ")
							|| obj.Value.Line.Contains("* Name                                          "))
						{
							_select_key = getRealValue(obj.Value.Line);
						}

						if (obj.Value.Line.Contains("* 標籤                                        ")
							|| obj.Value.Line.Contains("* Label                                       "))
						{
							_select_itemChtName = getRealValue(obj.Value.Line);
						}


						if (obj.Value.Line.Contains("* 清單項目值                                  ")
							|| obj.Value.Line.Contains("* List Item Value                             "))
						{
							_select_value = getRealValue(obj.Value.Line);

							//加入到list_selectObj
							list_selectObj.Add(new innerObj()
							{
								HeaderType = "",
								SubSeq = null,
								index = flag ? temp_index : obj.Value.index,
								dbColumn = _select_key,
								itemChtName = _select_itemChtName,
								itemType = _select_value,
							});

							//textBoxResults.AppendText($"select 加入到list_LovObj：_select_key：[{_select_key}]，_select_itemChtName：[{_select_itemChtName}]，_select_value : [{_select_value}]{Environment.NewLine}");

						}

						if (obj.Value.Line.Contains("* 圓鈕值                                      "))
						//    || obj.Value.Sub.Contains("* Display Width"))
						{
							_select_value = getRealValue(obj.Value.Line);

							//加入到list_selectObj
							list_selectObj.Add(new innerObj()
							{
								HeaderType = "",
								SubSeq = null,
								index = flag ? temp_index : obj.Value.index,
								dbColumn = _select_key,
								itemChtName = _select_itemChtName,
								itemType = _select_value,
							});

							//textBoxResults.AppendText($"select 加入到list_LovObj：_select_key：[{_select_key}]，_select_itemChtName：[{_select_itemChtName}]，_select_value : [{_select_value}]{Environment.NewLine}");

						}

						// Caption string 收集
						if (obj.Value.Line.Contains("* 清單項目值              ")
							|| obj.Value.Line.Contains("* List Item Value              "))
						{
							_select_value = getRealValue(obj.Value.Line);
						}


						if ((obj.Value.Line.Contains("- 字型                  ")
							|| obj.Value.Line.Contains("- Font                  "))
							&& _select_value != String.Empty)
						{
							//加入 list_CaptionObj
							list_CaptionObj.Add(new innerObj()
							{
								HeaderType = "",
								SubSeq = null,
								index = obj.Value.index,
								dbColumn = null,
								itemEngName = null,
								itemChtName = _select_value,
								itemType = "Caption"
							});

							//textBoxResults.AppendText($"Caption 加入到list_LovObj：_select_value：[{_select_value}]{Environment.NewLine}");
							_select_value = "";
						}



					}

					// LOV層 填值處理
					foreach (var obj in LOVFilteredList.Select((Value, Index) => new { Value, Index }))
					{
						//textBoxResults.AppendText($"LOV找到符合的字串：Counter：[{obj.Value.index}]，頭：[{obj.Value.Header}]，子：[{obj.Value.Sub}]{Environment.NewLine}");

						if (obj.Value.Sub.Contains("     * 名稱                                          ")
							|| obj.Value.Sub.Contains("     * Name                                          "))
							_LOV_itemEngName = getRealValue(obj.Value.Sub);


						if (obj.Value.Sub.Contains("* 回覆項目") || obj.Value.Sub.Contains("* Return Item"))
							_LOV_dbColumn = getRealValue(obj.Value.Sub);


						if (obj.Value.Sub.Contains("* 標題") || obj.Value.Sub.Contains("* Title"))
							_LOV_itemChtName = getRealValue(obj.Value.Sub);


						if (obj.Value.Sub.Contains("* 名稱                                            LOV_")
							|| obj.Value.Sub.Contains("* Name                                            LOV_"))
							_LOV_key = getRealValue(obj.Value.Sub);


						if (obj.Value.Sub.Contains("* 顯示寬度")
							|| obj.Value.Sub.Contains("* Display Width"))
						{
							//加入到list_LovObj
							list_LovObj.Add(new innerObj()
							{
								HeaderType = "",
								SubSeq = null,
								index = flag ? temp_index : obj.Value.index,
								dbColumn = _LOV_dbColumn,
								itemEngName = _LOV_itemEngName,
								itemChtName = _LOV_itemChtName,
								itemType = _LOV_key,
							});
						}

					}

					//// LOV物件列表
					//foreach (var obj in list_LovObj)
					//    textBoxResults.AppendText($"LOV字串：index：[{obj.index}]，itemType：[{obj.itemType}]，dbColumn：[{obj.dbColumn}]，itemEngName：[{obj.itemEngName}]，itemChtName：[{obj.itemChtName}]{Environment.NewLine}");


					// 主層 填值處理
					foreach (var obj in mainFilteredList.Select((Value, Index) => new { Value, Index }))
					{
						textBoxResults.AppendText($"找到符合的字串：Counter：[{obj.Value.index}]，頭：[{obj.Value.Header}]，子：[{obj.Value.Sub}]{Environment.NewLine}");




						if (obj.Value.Sub.Contains("* 名稱")
							|| obj.Value.Sub.Contains("* Name"))
						{

							if (_temp_itemEngName != string.Empty)
							{
								//加入'主要物件'到'主要objectlist'
								list_innerObj.Add(new innerObj()
								{
									HeaderType = "",
									SubSeq = null,
									index = flag ? temp_index : obj.Value.index,
									dbColumn = _temp_dbColumn,
									itemEngName = _temp_itemEngName,
									itemChtName = _temp_itemChtName,
									itemType = _temp_itemType,
									canvas = _temp_canvas == null ? "其他" : _temp_canvas,
									datablock = _temp_datablock == null ? "" : _temp_datablock,
								});

								_temp_dbColumn = string.Empty; _temp_itemEngName = string.Empty; _temp_itemChtName = string.Empty; _temp_itemType = string.Empty;
							}

							_temp_itemEngName = getRealValue(obj.Value.Sub);
						}

						if (obj.Value.Sub.Contains("* 資料欄名稱")
							|| obj.Value.Sub.Contains("* Column Name"))
						{
							_temp_dbColumn = getRealValue(obj.Value.Sub);
						}


						if (obj.Value.Sub.Contains("* 標籤") || obj.Value.Sub.Contains("* 提示")
							|| obj.Value.Sub.Contains("* Prompt") || obj.Value.Sub.Contains("^ Label")
							&& string.Empty == _temp_itemChtName)
						{
							_temp_itemChtName = getRealValue(obj.Value.Sub);
						}


						if (obj.Value.Sub.Contains("* 項目類型")
							|| obj.Value.Sub.Contains("* Item Type")
							|| obj.Value.Sub.Contains("^ 項目類型")
							|| obj.Value.Sub.Contains("^ Item Type")
							|| obj.Value.Sub.Contains("- 項目類型")
							|| obj.Value.Sub.Contains("- Item Type"))
						{
							_temp_itemType = getRealValue(obj.Value.Sub);
						}


						//20231003 add
						if (obj.Value.Sub.Contains("     * 值清單                                        LOV_")
							 || obj.Value.Sub.Contains("     * List of Values                                LOV_"))
						{
							_temp_itemType = getRealValue(obj.Value.Sub);
						}

						//20240417 add 改為用 CANVAS 作為 [分類索引]
						if (obj.Value.Sub.Contains("     * 工作區                                        ")
							 || obj.Value.Sub.Contains("     * 工作區                                        "))
						{
							_temp_canvas = getRealValue(obj.Value.Sub);
						}

						//20240417 add
						if (obj.Value.Sub.Contains("     * 頁籤頁面                                     ")
							 || obj.Value.Sub.Contains("     * 頁籤頁面                                     "))
						{
							_temp_datablock = getRealValue(obj.Value.Sub);
						}

						////分類索引切換之際
						////if (obj.Value.index != temp_index)
						//if (_temp_canvas != temp_canvas)
						//{
						//    //20240109 add Caption string 收集
						//    foreach (var keys in list_CaptionObj)
						//    {
						//        list_innerObj.Add(new innerObj()
						//        {
						//            HeaderType = "",
						//            SubSeq = null,
						//            index = obj.Value.index,
						//            dbColumn = null,
						//            itemEngName = null,
						//            itemChtName = keys.itemChtName,
						//            itemType = keys.itemType,
						//            canvas = _temp_canvas == null ? "其他" : _temp_canvas,
						//            datablock = _temp_datablock == null ? "" : _temp_datablock,
						//            //canvas = keys.canvas,
						//            //datablock = keys.datablock == null ? "" : keys.datablock,
						//        });
						//    }

						//    for (int i = 0; i < 3; i++)
						//        list_innerObj.Add(new innerObj()
						//        {
						//            HeaderType = "",
						//            SubSeq = null,
						//            index = obj.Value.index,
						//            dbColumn = null,
						//            itemEngName = null,
						//            itemChtName = null,
						//            itemType = "Form隱藏格式",
						//            canvas = _temp_canvas == null ? "其他" : _temp_canvas,
						//            datablock = _temp_datablock == null ? "" : _temp_datablock,
						//            //canvas = _temp_canvas,
						//            //datablock = _temp_datablock == null ? "" : _temp_datablock,
						//        });

						//    //temp_index = obj.Value.index;
						//    temp_canvas = _temp_canvas;
						//    flag = true;
						//}



						// 最後一筆額外處理
						if (mainFilteredList.Count == obj.Index + 1)
						{
							//加入 主要objectlist
							list_innerObj.Add(new innerObj()
							{
								HeaderType = "",
								SubSeq = null,
								index = obj.Value.index,
								dbColumn = _temp_dbColumn,
								itemEngName = _temp_itemEngName,
								itemChtName = _temp_itemChtName,
								itemType = _temp_itemType,
								canvas = _temp_canvas == null ? "其他" : _temp_canvas,
								datablock = _temp_datablock == null ? "" : _temp_datablock,
							});
						}



					}


					//多紀錄index
					foreach (var obj in list_innerObj.Select((Value, Index) => new { Value, Index }))
						obj.Value.innerIndex = obj.Index;


					//顯示在另一個datagrid查看(隱藏)
					if (list_innerObj.Count > 0)
						dGV_innerObj.DataSource = list_innerObj;
					//textBoxResults.AppendText($"{JsonConvert.SerializeObject(list_innerObj)}");


					this.dGdVwHeaders.DataSource = null;
					this.dGdVwHeaders.Rows.Clear();


					// List<IGrouping<int, innerObj>> headerlist = list_innerObj.GroupBy(x => x.index).ToList();//取header使用
					List<IGrouping<string, innerObj>> headerlist = list_innerObj.GroupBy(x => x.canvas).ToList();//取header使用   測試

					headerlist.ForEach(group =>
					{
						//textBoxResults.AppendText($"Score:{group.Key}, Count:{group.Count()}{Environment.NewLine}");
						//this.dGdVwHeaders.Rows.Add(group.Key, "Grid/Form");   //改用combobox，取消原先預設值
						this.dGdVwHeaders.Rows.Add(group.Key, "");  //改用combobox，預設值為空

						//group.ToList().ForEach(item => textBoxResults.AppendText($"\tindex:{item.index}"));//, Score:{item.Score}  分組後內容取得


						//    //20240417 add 分類索引切換之際(每個分類都加入)
						//    //----------------------------
						//    //20240109 add Caption string 收集
						//    foreach (var keys in list_CaptionObj)
						//    {
						//        list_innerObj.Add(new innerObj()
						//        {
						//            HeaderType = "",
						//            SubSeq = null,
						//            index = null,
						//            dbColumn = null,
						//            itemEngName = null,
						//            itemChtName = keys.itemChtName,
						//            itemType = keys.itemType,
						//            canvas = group.Key == null ? "其他" : group.Key,
						//            datablock = "",
						//        });
						//    }

						//    for (int i = 0; i < 3; i++)
						//        list_innerObj.Add(new innerObj()
						//        {
						//            HeaderType = "",
						//            SubSeq = null,
						//            index = null,
						//            dbColumn = null,
						//            itemEngName = null,
						//            itemChtName = null,
						//            itemType = "Form隱藏格式",
						//            canvas = group.Key == null ? "其他" : group.Key,
						//            datablock = "",
						//        });

					});


					var datarow = this.dGdVwHeaders.Rows[0];        // 母表選澤ROW DATA
					this.Fun_Reload_SubDataGridView(datarow);







				}




			}
			catch (Exception e1)
			{
				throw e1;
			}
		}

		public string getRealValue(string line)
		{
			string key, value = null;

			string[] parts = line.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length == 2)
			{
				key = parts[0].Trim();
				value = parts[1].Trim();

			}
			return value;
		}

		/// <summary>
		/// 載入細節部分
		/// </summary>
		/// <param name="datarow"></param>
		public void Fun_Reload_SubDataGridView(DataGridViewRow datarow)
		{
			if (datarow == null) return;


			lstVwSubItems.Clear();
			this.count = 0; //全域

			//var templist = this.list_innerObj.Where(x => x.index == Convert.ToInt32(datarow.Cells[0].Value)).ToList();
			var templist = this.list_innerObj.Where(x => x.canvas == Convert.ToString(datarow.Cells[0].Value)).ToList();      // 測試

			lstVwSubItems.Columns.Add("選取順序", 25, HorizontalAlignment.Left);
			lstVwSubItems.Columns.Add("順序", 45, HorizontalAlignment.Left);

			lstVwSubItems.Columns.Add("itemChtName", 150, HorizontalAlignment.Left);
			lstVwSubItems.Columns.Add("dbColumn", 150, HorizontalAlignment.Left);
			lstVwSubItems.Columns.Add("itemEngName", 150, HorizontalAlignment.Left);
			lstVwSubItems.Columns.Add("itemType", 120, HorizontalAlignment.Center);
			lstVwSubItems.Columns.Add("index", 10, HorizontalAlignment.Left);
			lstVwSubItems.Columns.Add("datablock", 10, HorizontalAlignment.Left);


			foreach (var resultstr2 in templist)
			{

				ListViewItem item1 = new ListViewItem(resultstr2.index.ToString().Trim(), 1);
				item1.Checked = resultstr2.Checked;
				item1.SubItems.Add(resultstr2.SubSeq.ToString());

				item1.SubItems.Add(resultstr2.itemChtName);
				item1.SubItems.Add(resultstr2.dbColumn);
				item1.SubItems.Add(resultstr2.itemEngName);
				item1.SubItems.Add(resultstr2.itemType);
				item1.SubItems.Add(resultstr2.innerIndex.ToString());
				item1.SubItems.Add(resultstr2.datablock);//.ToString()
														 //Add the items to the ListView.
				lstVwSubItems.Items.AddRange(new ListViewItem[] { item1 });
			}
		}

		/// <summary>
		/// 轉換成 LOV Detail字串
		/// </summary>
		/// <param name="indexString">擷取字串</param>
		/// <param name="index">0:colDefs部分 1:keyMapping部分</param>
		/// <returns>LOV Detail字串</returns>
		public string Fun_Lov_Detail_String(string indexString, int index)
		{
			var itemObj = this.list_LovObj.Where(x => x.itemType == indexString).ToList();

			string _template_Lovl = "";
			if (this.chk_Gridtype.Checked == true)
				_template_Lovl = "          {{\r\n            headerName: '{0}',\r\n            field: '{1}',\r\n            type: EDlpGridColumnType.text,\r\n          }},\r\n";
			else
				_template_Lovl = "              {{\r\n                headerName: '{0}',\r\n                headerValueGetter: this._agService.headerValueGetter,\r\n                field: '{1}',\r\n                type: 'text',\r\n              }},\r\n";

			string _template_Lov2 = "\r\n              {0}: '{1}',";
			string del_strng = "", map_string = "";

			foreach (var item in itemObj)
			{
				del_strng += String.Format(_template_Lovl, item.itemChtName, item.itemEngName);

				if (item.dbColumn != null && item.dbColumn != string.Empty)
				{
					string[] splitStr = item.dbColumn.Split('.');
					if (splitStr.Length == 1)
						map_string += String.Format(_template_Lov2, splitStr[0], item.itemEngName);     //FORM
					else
						map_string += String.Format(_template_Lov2, splitStr[1], item.itemEngName);     //GRID
				}
			}

			return index is 0 ? del_strng : map_string;
		}

		/// <summary>
		/// 轉換成 select Detail字串
		/// </summary>
		/// <param name="keyString">擷取字串</param>
		/// <param name="index">0:options部分 1:obj部分</param>
		/// <returns>select Detail字串</returns>
		public string Fun_Select_Detail_String(string keyString, int index)
		{
			var itemObj = this.list_selectObj.Where(x => x.dbColumn == keyString).ToList();   //取得KEY值
																							  //"          return { {0}: '{1}', {0}: '{1}' }[displayValue] ?? '';"
																							  //"            options: of([\r\n              { key: '{0}', value: '{1}' },\r\n              { key: '{0}', value: '{1}' },\r\n            ]),\r\n"
			string _template_select1 = "";
			if (this.chk_Gridtype.Checked == true)
				_template_select1 = "              {{ value: '{1}', label: '{0}' }},\r\n";
			else
				_template_select1 = "              {{ value: '{1}', key: '{0}' }},\r\n";
			string _template_select2 = "                '{1}': '{0}',\r\n";
			string options_strng = "", obj_string = "";

			foreach (var item in itemObj)
			{
				options_strng += String.Format(_template_select1, item.itemChtName, item.itemType);
				obj_string += String.Format(_template_select2, item.itemChtName, item.itemType);
			}

			//string _template_select1_DlpGrid = "options: of([\r\n" + options_strng + "            ]),\r\n";
			//string _template_select2_DlpGrid = "return { \r\n" + obj_string + "          }[displayValue] ?? '';\r\n";

			//return index is 0 ?  _template_select2_DlpGrid: _template_select1_DlpGrid;
			return index is 0 ? obj_string : options_strng;
		}

		private void Item1_Click(object sender, EventArgs e)
		{
			// 設定新的值
			dGdVwHeaders.Rows[tempRowIndex].Cells[tempColumnIndex].Value = "";

		}
		//右鍵事件
		private void Item2_Click(object sender, EventArgs e)
		{
			// 設定新的值
			dGdVwHeaders.Rows[tempRowIndex].Cells[tempColumnIndex].Value = "Form";
		}
		//右鍵事件
		private void Item3_Click(object sender, EventArgs e)
		{
			// 設定新的值
			dGdVwHeaders.Rows[tempRowIndex].Cells[tempColumnIndex].Value = "Grid";
		}

		//取得右鍵cell資訊
		private void dGdVwHeaders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			tempColumnIndex = e.ColumnIndex;
			tempRowIndex = e.RowIndex;

			if (e.RowIndex >= 0)
			{
				if (!dGdVwHeaders.Rows[tempRowIndex].Selected)
				{
					dGdVwHeaders.ClearSelection();
					dGdVwHeaders.Rows[tempRowIndex].Selected = true;
				}
			}

		}

		//點擊DataGridView(GRID/FORM)
		private void dGdVwHeaders_SelectionChanged(object sender, EventArgs e)
		{
			var rowsCount = dGdVwHeaders.SelectedRows.Count;
			if (rowsCount == 0 || rowsCount > 1) return;

			var datarow = dGdVwHeaders.SelectedRows[0];     // 母表選澤ROW DATA
			this.Fun_Reload_SubDataGridView(datarow);  // 選擇母表任一行需重載子表資料

		}

		//選細項順序  重新載入也會觸發
		private void lstVwSubItems_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// 反向
			if (e.CurrentValue == CheckState.Unchecked)
			{
				count++;
				if (this.lstVwSubItems.Items[e.Index].SubItems[1].Text is "")
					this.lstVwSubItems.Items[e.Index].SubItems[1].Text = count.ToString();          // [1]:順序
				ListViewItem.ListViewSubItem aaa = this.lstVwSubItems.Items[e.Index].SubItems[2];   // [2]:itemChtName


				int innerindex = Convert.ToInt16(this.lstVwSubItems.Items[e.Index].SubItems[6].Text);   // [6]:index
				if (this.list_innerObj[innerindex].SubSeq is null)
					this.list_innerObj[innerindex].SubSeq = count;  // 指定順序給主要objectlist
				this.list_innerObj[innerindex].Checked = true;

				//取得主要objectlist中符合點擊當行得資料
				var testlist2 = this.list_innerObj.Where(x => x.innerIndex == innerindex).ToList();
				textBoxResults.AppendText($"{JsonConvert.SerializeObject(testlist2)},{Environment.NewLine}");

				////取得對應的LOV OBJ
				//var testlist3 = this.list_LovObj.Where(x => x.itemType == lstVwSubItems.Items[e.Index].SubItems[5].Text).ToList();  // [5]:itemType
				//textBoxResults.AppendText($"{JsonConvert.SerializeObject(testlist3)},{Environment.NewLine}");

			}
			else if ((e.CurrentValue == CheckState.Checked))
			{
				count--;
				this.lstVwSubItems.Items[e.Index].SubItems[1].Text = "";
				int innerindex = Convert.ToInt16(this.lstVwSubItems.Items[e.Index].SubItems[6].Text);
				this.list_innerObj[innerindex].SubSeq = null;  // 指定順序給主要objectlist
				this.list_innerObj[innerindex].Checked = false;
			}

			if (list_innerObj.Count > 0)
				dGV_innerObj.DataSource = list_innerObj;

		}

		public void FileWrite(List<string> Text, Boolean append, string Scope)
		{
			TextWriter txt = new StreamWriter(@".\temp.txt", append);

			if (Scope == "Start")
				txt.Write("");//Clear
			else
			{
				if (Text.Count > 0)
				{
					foreach (string t in Text)
						txt.WriteLine(t);
				}
				else
					txt.WriteLine("");
			}


			txt.Close();
		}

		// 清空訊息框
		private void btn_clearMessege_Click(object sender, EventArgs e)
		{
			textBoxResults.Clear();
		}

		// 執行
		private void btn_run_Click(object sender, EventArgs e)
		{
			// 讀入設定檔
			ReadJsonSetting();

			textBoxResults.Clear();
			List<string> allResultStr = new List<string>();
			List<string> allstrJson = new List<string>();
			foreach (DataGridViewRow row in this.dGdVwHeaders.Rows)
			{
				// 檢查行的類型，以排除 Header 和其他非資料行
				if (row.IsNewRow) continue;

				// 逐列取得每個儲存格的內容值
				//int _dataindex = Convert.ToInt16(row.Cells[0].Value);  //測試
				string _canvasindex = Convert.ToString(row.Cells[0].Value);  //測試
				string _dataType = row.Cells[1].Value?.ToString();

				// 使用取得的值進行後續處理
				//textBoxResults.AppendText($"Row: " + _dataindex + " | " + _dataType + ","+ Environment.NewLine);

				//-----------------------------------------------------------------------------

				// 使用 Where 方法篩選同類的資料
				// 使用 OrderBy 方法依據指定的元素欄位進行重新排序
				//List<innerObj> current_list = this.list_innerObj.Where(x => x.index == _dataindex).OrderBy(obj => obj.SubSeq).ToList().FindAll(e => e.SubSeq != null);      //測試

				List<innerObj> current_list = this.list_innerObj.Where(x => x.canvas == _canvasindex).OrderBy(obj => obj.SubSeq).ToList().FindAll(e => e.SubSeq != null);

				/*標題部分  無變數不需修改*/
				string _templateModel_grid_header_start = "";
				string _templateModel_form_header_start = "";
				if (this.chk_Gridtype.Checked == true)
					_templateModel_grid_header_start = "<<<< Dlp Grid >>>>\r\n//------------------------------------------------\r\n\r\n    return [\r\n";
				else
					_templateModel_grid_header_start = "<<<< Grid >>>>\r\n//------------------------------------------------\r\n\r\n    return [\r\n      {\r\n        headerName: '項目',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: 'ITEM',\r\n      },\r\n";
				string _templateModel_grid_header_end = "    ];\r\n\r\n//------------------------------------------------\r\n\r\n\r\n\r\n";

				if (this.chk_Gridtype.Checked == true)
					_templateModel_form_header_start = "<<<< Dlp Form >>>>\r\n//------------------------------------------------\r\n\r\n    return [\r\n";
				else
					_templateModel_form_header_start = "<<<< Form >>>>\r\n//------------------------------------------------\r\n\r\n    const controls: FormBase<any>[] = [\r\n";
				string _templateModel_form_header_end = "    ];\r\n\r\n//------------------------------------------------\r\n\r\n\r\n\r\n";

				/*GRID部分*/
				string _templateModel_grid_view_normal = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'text',\r\n        editable: false,\r\n        width: 100,\r\n        suppressSizeToFit: true,\r\n      }},\r\n";
				string _templateModel_grid_view_number = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'number',\r\n        editable: false,\r\n        width: 80,\r\n        valueFormatter: this._pubFunction.formatNumber.bind(this, 2), //含 千份位＋顯示小數點後幾位\r\n        cellStyle: this._pubFunction.rightTextAlign,\r\n        floatingFilterComponent: 'numberFilterRenderer',\r\n        suppressSizeToFit: true,\r\n      }},\r\n";
				string _templateModel_grid_view_date = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'date',\r\n        editable: false,\r\n        width: 120,\r\n        suppressSizeToFit: true,\r\n        valueFormatter: this._pubFunction.formatDate,\r\n        // valueFormatter: (params) => {{\r\n        //   return this._pubFunction.formatDate({{ value: params.data?.{1} }}, 'yyyy/MM/dd');\r\n        // }},\r\n      }},\r\n";
				string _templateModel_grid_confirm = "      {{\r\n        headerName: '{0}', //勾選\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        editable: false,\r\n        filter: false,\r\n        sortable: false,\r\n        cellRenderer: 'confirmRenderer',\r\n        width: 50,\r\n        suppressSizeToFit: true,\r\n        cellRendererParams: (params) => {{\r\n          // if (params.data?.ITEM === 0) return {{ disabled: true }};\r\n\r\n          return {{\r\n            checkValueType: EAgGridCheckValueType.booleanType,\r\n            // afterCheckedFunc: (value: boolean) => {{\r\n            //   if (value) {{\r\n            //     //判斷通過，勾選\r\n            //     params.data.{1} = true;\r\n            //   }} else {{\r\n            //     //取消勾選\r\n            //     params.data.{1} = false;\r\n            //   }}\r\n            //   params.node.setData(params.data);\r\n            // }},\r\n          }};\r\n        }},\r\n      }},\r\n";
				string _templateModel_grid_check = "      {{\r\n        headerName: '{0}', \r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: ['wrappingHeader'],\r\n        editable: false,\r\n        filter: false,\r\n        sortable: false,\r\n        cellRenderer: 'checkRenderer',\r\n        width: 50,\r\n        suppressSizeToFit: true,\r\n        valueGetter: (params) => {{\r\n          return params.data?.{1} === 'Y';\r\n        }},\r\n        valueSetter: (params) => {{\r\n          params.data.{1} = params.newValue ? 'Y' : null;\r\n          return true;\r\n        }},\r\n        cellRendererParams: (params) => {{\r\n          // if (params.data?.ITEM === 0) return {{ disabled: true }};\r\n          return {{\r\n            checkValueType: EAgGridCheckValueType.stringType,\r\n            onCheckedFunc: (value: string) => {{\r\n              // if (value == 'Y')\r\n              //   params.data.{1} = 'Y';  //勾選\r\n              // else\r\n              //   params.data.{1} = 'N';  //取消勾選\r\n              // params.node.setData(params.data);\r\n            }},\r\n          }};\r\n        }},\r\n      }},\r\n";
				//string _templateModel_grid_select = "      {{\r\n        headerName: '{1}',\r\n        field: '{0}',\r\n        type: 'text',\r\n        width: 100,\r\n        suppressSizeToFit: true,\r\n        valueFormatter: (params) => {{\r\n          return {{\r\n            // PASS: 'PASS',\r\n            // FAIL: 'FAIL',\r\n          }}[params.data.{0}];\r\n        }},\r\n        cellEditor: 'selectEditor',\r\n        cellEditorParams: {{\r\n          control: {{\r\n            multiple: false,\r\n            field: ['{0}'],\r\n            options: of([\r\n              // {{ key: 'PASS', value: 'PASS' }},\r\n              // {{ key: 'FAIL', value: 'FAIL' }},\r\n            ]),\r\n          }},\r\n        }},\r\n        floatingFilterComponent: 'selectFilterRenderer',\r\n        floatingFilterComponentParams: {{\r\n          options: of([\r\n            // {{ key: 'PASS', value: 'PASS' }},\r\n            // {{ key: 'FAIL', value: 'FAIL' }},\r\n          ]),\r\n        }},\r\n      }},\r\n";
				string _templateModel_grid_select = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'text',\r\n        editable: true, //(params) => {{return params.data?.ITEM === 0;}},// 可新增不可修改\r\n        sortable: true,\r\n        width: 100,\r\n        suppressSizeToFit: true,\r\n        valueFormatter: (params) => {{\r\n          const displayValue = params.node?.data?.{1} ?? '';\r\n          return {{ \r\n            // '1': 'Cosmos/KM3代工', '3': '組底加工' \r\n          }}[displayValue] ?? '';\r\n        }},\r\n        // valueSetter: (params) => {{\r\n        //   const optKey = params.newValue?.[0];\r\n        //   params.data.{1} = optKey;\r\n        //   return true;\r\n        // }},\r\n        cellEditor: 'selectRenderer',\r\n        cellEditorParams: {{\r\n          control: {{\r\n            multiple: false,\r\n            field: ['{1}'],\r\n            options: of([\r\n              // {{ key: '1', value: 'Cosmos/KM3代工' }},\r\n              // {{ key: '3', value: '組底加工' }},\r\n            ]),\r\n          }},\r\n        }},\r\n        floatingFilterComponent: 'selectFilterRenderer',\r\n        floatingFilterComponentParams: {{\r\n          options: of([\r\n            // {{ key: '1', value: 'Cosmos/KM3代工' }},\r\n            // {{ key: '3', value: '組底加工' }},\r\n          ]),\r\n        }},\r\n      }},\r\n";

				/*FORM部分*/
				string _templateModel_form_normal = "      new FormTextBox({{\r\n        key: '{1}',\r\n        label: '{0}',\r\n        // labelWidth: 5,\r\n        flex: '20',\r\n        order: 1,\r\n        class: 'pr-1',\r\n        // readonly: true,\r\n      }}),\r\n";  // textAlign: 'right',\r\n
				string _templateModel_form_number = "";
				string _templateModel_form_date = "";
				string _templateModel_form_btn = "      new FormButtonAuthority({{\r\n        showButtons: [\r\n          <IButtons>{{\r\n            key: 'confirm',\r\n            color: 'primary',\r\n            text: '{0}',\r\n            icon: 'done_all',\r\n            visible: true,\r\n            //visibledAsync: this.State.FormRefs.visibleAsync$,\r\n            clickFunction: () => {{\r\n              //this.Service.pushSave();\r\n            }},\r\n          }},\r\n        ],\r\n        flex: '20',\r\n        order: 1,\r\n        class: 'pr-1',\r\n      }}),\r\n";
				string _templateModel_form_radio_btn = "      new FormRadioButton({{\r\n        key: '{0}',\r\n        label: '',\r\n        options: of([\r\n          // {{ key: 'A', value: '中文顯示A' }},\r\n          // {{ key: 'B', value: '中文顯示B' }},\r\n          // {{ key: 'C', value: '中文顯示C' }},\r\n        ]),\r\n        flex: '45',\r\n        // value: 'A',\r\n        inputChangeFunc: (params) => {{\r\n          // this._Service.query();\r\n        }},\r\n      }}),\r\n";
				string _templateModel_form_hidden = "      new FormHidden({\r\n        key: '',\r\n        label: '',\r\n        order: 1,\r\n        flex: '20',\r\n      }),\r\n";
				string _templateModel_form_drop_down_list = "      new FormDropDownList({{\r\n        key: '{0}',\r\n        label: '{1}',\r\n        labelWidth: 10,\r\n        flex: 25,\r\n        class: 'pr-1',\r\n        options: of([\r\n          // {{ key: 'A', value: '顯示文字A' }},\r\n          // {{ key: 'B', value: '顯示文字B' }},\r\n          // {{ key: 'C', value: '顯示文字C' }},\r\n        ]),\r\n        inputChangeFunc: (value, form) => {{\r\n          //this._Service.update();\r\n        }},\r\n      }}),\r\n";
				string _templateModel_form_hidden2 = "      new FormHidden({{}}),\r\n";
				string _templateModel_form_caption = "      new FormCaption({{\r\n        value: `{0}`,\r\n        order: 1,\r\n        flex: '100',\r\n        //customStyle: {{\r\n        //  color: 'blue',//FormCaption 字體顏色\r\n        //}},\r\n      }}),\r\n";
				string _templateModel_form_checkbox = "";

				/*LOV部分*/
				string _templateModel_grid_Lovl = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        suppressSizeToFit: true,\r\n        editable: true, //(params) => {{ return params.data.ITEM === 0; // 可新增不可修改 }},\r\n        sortable: true,\r\n        width: 120,\r\n        type: 'text',\r\n        cellEditor: 'lovEditor',\r\n        cellEditorParams: (params) => {{\r\n          return <ILovEditorParams>{{\r\n            apiParams: {{\r\n              // sp前綴\r\n              moduleNo: 模組名稱,\r\n              programNo: '{2}',\r\n              commonApiType: ECommonApiType.CallStoreProcedureDataSet,\r\n            }},\r\n            queryAction: sp名稱, // sp名稱\r\n            //payload: {{}}, // input\r\n            refCursorKeys: [v表名稱Info, v表名稱Count], // output\r\n            colDefs: [\r\n{3}            ],\r\n            keyMapping: {{              {4}\r\n            }},\r\n            checkInput: true,\r\n            onPostChange: (params) => {{\r\n              if (params.isValidInput) //this._Service.ServiceFun(params.value);\r\n            }},\r\n          }};\r\n        }},\r\n      }},\r\n";
				string _templateModel_form_Lovl = "      new FormLov({{\r\n        key: '{0}',\r\n        label: '{1}',\r\n        //labelWidth: '10',\r\n        apiParams: {{\r\n          moduleNo: 模組名稱,\r\n          programNo: '{2}',\r\n          commonApiType: ECommonApiType.CallStoreProcedureDataSet,\r\n        }},\r\n        queryAction: SP名稱, // sp名稱\r\n        refCursorKeys: [v表名稱Info, v表名稱Count],\r\n        colDefs: [\r\n{3}        ],\r\n        keyMapping: {{{4}\r\n        }},\r\n        checkInput: true,\r\n        flex: '25',\r\n        class: 'pr-1',\r\n      }}),\r\n";

				/*其他*/
				string resultStr = string.Empty;
				List<string> list_resultStr = new List<string>();

				PropertyInfo[] myPropertyInfo;
				// Get the properties of 'Type' class object.
				myPropertyInfo = jsonData.GetType().GetProperties();
				//for (int row = 0; row < myPropertyInfo.Length; row++)
				//{
				//    Console.WriteLine(myPropertyInfo[row].ToString());
				//    textBoxResults.AppendText(myPropertyInfo[row].ToString());
				//    PropertyInfo aa = myPropertyInfo[row];
				//    textBoxResults.AppendText(aa.GetValue(jsonData));
				//}

				//if (!jsonData.GetType().GetProperties()     // 判斷物件是否所有屬性都為NULL: true則採用程式預設 false則套用JSON檔
				//            .Where(pi => pi.PropertyType == typeof(string))
				//            .Select(pi => (string)pi.GetValue(jsonData))
				//            .Any(value => string.IsNullOrEmpty(value)))
				//{
				_templateModel_grid_view_normal = jsonData.grid_view_normal;
				_templateModel_grid_view_number = jsonData.grid_view_number;
				_templateModel_grid_view_date = jsonData.grid_view_date;
				_templateModel_grid_confirm = jsonData.grid_confirm;
				_templateModel_grid_check = jsonData.grid_check;
				_templateModel_grid_select = jsonData.grid_select;

				_templateModel_form_normal = jsonData.form_normal;
				_templateModel_form_number = jsonData.form_number;
				_templateModel_form_date = jsonData.form_date;
				_templateModel_form_btn = jsonData.form_btn;
				_templateModel_form_radio_btn = jsonData.form_radio_btn;
				_templateModel_form_hidden = jsonData.form_hidden;
				_templateModel_form_drop_down_list = jsonData.form_drop_down_list;
				_templateModel_form_hidden2 = jsonData.form_hidden2;
				_templateModel_form_caption = jsonData.form_caption;
				_templateModel_form_checkbox = jsonData.form_checkbox;

				_templateModel_grid_Lovl = jsonData.grid_Lovl;
				_templateModel_form_Lovl = jsonData.form_Lovl;
				//}




				////用Linq直接組
				//var result = new
				//{
				//    grid_view_normal = _templateModel_grid_view_normal,
				//    grid_view_number = _templateModel_grid_view_number,

				//};

				////物件序列化
				//string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
				//allstrJson.Add(strJson);

				//textBoxResults.AppendText(strJson);
				//File.WriteAllText(@"D:\Users\Wei_Pan\Desktop\DLPCodeTool+ColDef\Template.josn", strJson);



				if (_dataType == "Grid")
					resultStr += _templateModel_grid_header_start;
				else if (_dataType == "Form")
					resultStr += _templateModel_form_header_start;
				else if (_dataType == null || _dataType == "") { }
				else
					MessageBox.Show("Grid/Form 欄位填寫有誤");

				foreach (innerObj obj in current_list)
				{

					if ((obj.dbColumn == null || obj.dbColumn == string.Empty) && obj.itemEngName != null)
						obj.dbColumn = obj.itemEngName.ToUpper();

					if (obj.dbColumn != null)
						obj.dbColumn = obj.dbColumn.ToUpper();

					string _templateModel = "";
					//textBoxResults.AppendText(String.Format(_templateModel2, obj.itemChtName, obj.dbColumn));
					if (_dataType == "Grid")
					{
						//string _templateModel = "";
						// --- OLD ---
						//if (obj.itemType == "文字項目" || obj.itemType == "顯示項目"
						//    || obj.itemType == "Text Item" || obj.itemType == "Display Item")
						//{
						//    _templateModel = Fun_Replace_GridView_String("View", obj, _templateModel_grid_view_number, _templateModel_grid_view_date, _templateModel_grid_view_normal);
						//    list_resultStr.Add(String.Format(_templateModel, obj.itemChtName, obj.dbColumn));
						//}
						//else if (obj.itemType == "控制項目")
						//{
						//    _templateModel = Fun_Replace_GridView_String("noView", obj, _templateModel_grid_view_number, _templateModel_grid_view_date, _templateModel_grid_view_normal);
						//    list_resultStr.Add(String.Format(_templateModel, obj.itemChtName, obj.dbColumn));
						//}

						if (obj.itemType == "文字項目" || obj.itemType == "顯示項目"
							|| obj.itemType == "Text Item" || obj.itemType == "Display Item")
						{
							_templateModel = _templateModel_grid_view_normal;
							list_resultStr.Add(String.Format(_templateModel, obj.itemChtName, obj.dbColumn));
						}
						else if (obj.itemType == "number")
							list_resultStr.Add(String.Format(_templateModel_grid_view_number, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "date")
							list_resultStr.Add(String.Format(_templateModel_grid_view_date, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "核取方塊" || obj.itemType == "Check Box")
							list_resultStr.Add(String.Format(_templateModel_grid_confirm, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "值選擇框")
							list_resultStr.Add(String.Format(_templateModel_grid_check, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType.Contains("LOV_"))
							list_resultStr.Add(String.Format(_templateModel_grid_Lovl, obj.itemChtName, obj.dbColumn, Path.GetFileNameWithoutExtension(filePath), Fun_Lov_Detail_String(obj.itemType, 0), Fun_Lov_Detail_String(obj.itemType, 1)));
						else if (obj.itemType == "清單項目" || obj.itemType == "List Item")
							list_resultStr.Add(String.Format(_templateModel_grid_select, obj.itemChtName, obj.dbColumn, Fun_Select_Detail_String(obj.itemEngName, 0), Fun_Select_Detail_String(obj.itemEngName, 1)));
						else
							list_resultStr.Add(String.Format(_templateModel_grid_view_normal, obj.itemChtName, obj.dbColumn));
					}
					else if (_dataType == "Form")
					{
						if (obj.itemType == "文字項目" || obj.itemType == "顯示項目"
							|| obj.itemType == "Text Item" || obj.itemType == "Display Item")
						//list_resultStr.Add(String.Format(_templateModel_form_normal, obj.itemChtName, obj.dbColumn));
						{
							_templateModel = _templateModel_form_normal;
							list_resultStr.Add(String.Format(_templateModel, obj.itemChtName, obj.dbColumn));
						}
						else if (obj.itemType == "number")
							list_resultStr.Add(String.Format(_templateModel_form_number, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "date")
							list_resultStr.Add(String.Format(_templateModel_form_date, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "按鈕" || obj.itemType == "Push Button")
							list_resultStr.Add(String.Format(_templateModel_form_btn, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType.Contains("LOV_"))
							list_resultStr.Add(String.Format(_templateModel_form_Lovl, obj.itemChtName, obj.dbColumn, Path.GetFileNameWithoutExtension(filePath), Fun_Lov_Detail_String(obj.itemType, 0), Fun_Lov_Detail_String(obj.itemType, 1)));
						else if (obj.itemType == "圓鈕群組" || obj.itemType == "Radio Group") //
							list_resultStr.Add(String.Format(_templateModel_form_radio_btn, obj.itemEngName, Fun_Select_Detail_String(obj.itemEngName, 1)));
						else if (obj.itemType == "核取方塊" || obj.itemType == "Check Box")
							list_resultStr.Add(String.Format(_templateModel_form_checkbox, obj.itemChtName, obj.dbColumn));
						else if (obj.itemType == "清單項目" || obj.itemType == "List Item") //
							list_resultStr.Add(String.Format(_templateModel_form_drop_down_list, obj.itemEngName, obj.itemChtName, Fun_Select_Detail_String(obj.itemEngName, 1)));
						else if (obj.itemType == "Form隱藏格式")
						{
							list_resultStr.Add(_templateModel_form_hidden);
							list_resultStr.Add(_templateModel_form_hidden2);
						}
						else if (obj.itemType == "Caption")
							list_resultStr.Add(String.Format(_templateModel_form_caption, obj.itemChtName));
						else
							list_resultStr.Add(String.Format(_templateModel_form_normal, obj.itemChtName, obj.dbColumn));
					}


				}

				foreach (var resultStr2 in list_resultStr)
					resultStr += resultStr2;

				if (_dataType == "Grid")
					resultStr += _templateModel_grid_header_end;
				else if (_dataType == "Form")
					resultStr += _templateModel_form_header_end;
				else if (_dataType == null) { };

				textBoxResults.AppendText(resultStr);
				allResultStr.Add(resultStr);

				//-----------------------------------------------------------------------------
			}

			FileWrite(allResultStr, false, "");
			//開啟temp.txt
			System.Diagnostics.Process.Start("explorer.exe", "temp.txt");



		}


		/// <summary>
		/// GridView腳本替換細節部分
		/// </summary>
		/// <param name="datarow"></param>
		public string Fun_Replace_GridView_String(string _type_flag, innerObj obj, string _view_number, string _view_date, string _view_normal)
		{
			string _templateModel = "";

			obj.itemEngName = obj.itemEngName is not null ? obj.itemEngName : "";

			if (obj.itemEngName.ToLower().Contains("qty") || obj.itemEngName.ToLower().Contains("price")
				|| obj.itemEngName.ToLower().Contains("gw") || obj.itemEngName.ToLower().Contains("gw"))
			{
				if (_type_flag == "View")
					_templateModel = _view_number;
				else
					_templateModel = _view_number.Replace("      }},\r\n", "        cellEditor: 'textBoxRenderer',\r\n        cellEditorParams: () => ({{\r\n          control: {{\r\n            type: 'number',\r\n            max: '99999',\r\n            min: '0',\r\n            step: '1',\r\n            decimal: 0, //顯示小數點位數\r\n            allowEmpty: true,\r\n          }},\r\n        }}),\r\n      }},\r\n");
			}
			else if (obj.itemEngName.ToLower().Contains("date") || obj.itemEngName.ToLower().Contains("yymm"))
				_templateModel = _view_date;
			else
				_templateModel = _view_normal;

			if (obj.itemChtName == null || obj.itemChtName == string.Empty)
			{
				string _templateModel_grid_noChtName = _templateModel.Replace("headerValueGetter: this._agService.headerValueGetter,", "//headerValueGetter: this._agService.headerValueGetter,");
				_templateModel = _templateModel_grid_noChtName;
			}


			return _templateModel;
		}

		private void lstVwSubItems_MouseUp(object sender, MouseEventArgs e)
		{
			lvi = this.lstVwSubItems.GetItemAt(e.X, e.Y);

			// 使用HitTest方法確定點擊位置的相關資訊
			ListViewHitTestInfo hit = lstVwSubItems.HitTest(e.Location);

			int columnIndex;

			if (hit.SubItem is null) columnIndex = 0;
			else
			{
				// 取得點擊的列索引
				columnIndex = hit.Item.SubItems.IndexOf(hit.SubItem);
				textBoxResults.AppendText($"columnIndex: " + columnIndex + Environment.NewLine);
			}

			// 取得點擊的行索引
			//int rowIndex = hit.Item.Index;

			if (lvi != null && columnIndex == 5)
			{

				string itemType = lvi.SubItems[5].Text;

				if (itemType == "文字項目" || itemType == "顯示項目"
					|| itemType == "Text Item" || itemType == "Display Item"
					//|| itemType == "控制項目" || itemType == "顯示項目"
					|| itemType == "text" || itemType == "number" || itemType == "date"
					)
				{
					this.comboBox1.Items.Clear();
					this.comboBox1.Visible = true;
					this.comboBox1.Items.Add("text");
					this.comboBox1.Items.Add("number");
					this.comboBox1.Items.Add("date");
				}
				else if (itemType == "核取方塊" || itemType == "Check Box"
					|| itemType == "值選擇框" || itemType == "核取方塊"
					)
				{
					this.comboBox1.Items.Clear();
					this.comboBox1.Visible = true;
					this.comboBox1.Items.Add("值選擇框");
					this.comboBox1.Items.Add("核取方塊");
				}
				else
				{
					this.comboBox1.Visible = false;
					return;
				}

				//获取选中行的Bounds 
				Rectangle Rect = lvi.Bounds;

				// Right side of cell is in view.
				Rect.Width = lstVwSubItems.Columns[5].Width + Rect.Left;
				Rect.Y = this.lstVwSubItems.Top + 2 + Rect.Y;
				Rect.X = lstVwSubItems.Left +
					lstVwSubItems.Columns[0].Width +
					lstVwSubItems.Columns[1].Width +
					lstVwSubItems.Columns[2].Width +
					lstVwSubItems.Columns[3].Width +
					lstVwSubItems.Columns[4].Width + 2;

				this.comboBox1.Bounds = Rect;
				this.comboBox1.Text = lvi.SubItems[5].Text;
				this.comboBox1.Visible = true;
				this.comboBox1.BringToFront();
				this.comboBox1.Focus();

			}
		}

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			// Set text of ListView item to match the ComboBox.
			lvi.SubItems[5].Text = comboBox1.Text;

			// 取得點擊的列索引
			int columnIndex = lvi.Index;
			// 取得點擊的行索引
			//int rowIndex = lstVwSubItems.Items.IndexOf(lvi);

			int innerindex = Convert.ToInt16(this.lstVwSubItems.Items[columnIndex].SubItems[6].Text);   // [6]:index => 從ListView畫面取得list_innerObj中真實對應的index
			this.list_innerObj[innerindex].itemType = comboBox1.Text;
			this.comboBox1.Visible = false;
		}

		private void comboBox1_MouseLeave(object sender, EventArgs e)
		{
			// Set text of ListView item to match the ComboBox.
			lvi.SubItems[5].Text = comboBox1.Text;
			this.comboBox1.Visible = false;
		}

		public static void ReadConfiguration(string FilePath, JsonData Data)
		{
			if (!File.Exists(FilePath)) File.WriteAllText(FilePath, JsonConvert.SerializeObject(Data));

			var fileData = File.ReadAllText(FilePath);

			try
			{
				JsonConvert.PopulateObject(fileData, Data);
			}
			catch (Exception e)
			{
				Console.WriteLine("設定檔內容有誤，請確認!\n" + e.Message, "設定檔內容有誤");
			}
		}

		public class IniManager
		{
			private string filePath;
			private StringBuilder lpReturnedString;
			private int bufferSize;

			[DllImport("kernel32")]
			private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

			[DllImport("kernel32")]
			private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

			public IniManager(string iniPath)
			{
				filePath = iniPath;
				bufferSize = 512;
				lpReturnedString = new StringBuilder(bufferSize);
			}

			// read ini date depend on section and key
			public string ReadIniFile(string section, string key, string defaultValue)
			{
				lpReturnedString.Clear();
				GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);
				return lpReturnedString.ToString();
			}

			// write ini data depend on section and key
			public void WriteIniFile(string section, string key, Object value)
			{
				WritePrivateProfileString(section, key, value.ToString(), filePath);
			}
		}

		private DataTable ReadExcelFile(string filePath, List<innerObj> list_innerObj)
		{
			DataTable dataTable = new DataTable();

			Excel.Application excelApp = new Excel.Application();
			Excel.Workbook workbook = excelApp.Workbooks.Open(filePath, ReadOnly: true);
			Excel.Worksheet worksheet = workbook.Worksheets[1];
			Excel.Range range = worksheet.UsedRange;

			try
			{
				// 將Excel資料讀取到DataTable中
				for (int row = 1; row <= range.Rows.Count; row++)
				{
					DataRow dataRow = dataTable.NewRow();
					for (int col = 1; col <= range.Columns.Count; col++)
					{
						if (row == 1)
						{
							// 將第一行作為DataTable的欄位名稱
							Excel.Range cell = worksheet.Cells[row, col];
							string cellValue = cell.Value != null ? cell.Value.ToString() : "";
							dataTable.Columns.Add(cellValue);
						}
						else
						{
							dataRow[col - 1] = worksheet.Cells[row, col].Value;

						}
					}
					if (row != 1 && (dataRow != null && !dataRow.ItemArray.All(x => x is DBNull)))
					{

						list_innerObj.Add(new innerObj()
						{
							HeaderType = "",
							SubSeq = null,
							index = 0,
							dbColumn = dataRow[1].ToString(),
							itemEngName = dataRow[2].ToString(),
							itemChtName = dataRow[0].ToString(),
							itemType = dataRow[3].ToString(),
							innerIndex = row - 2  //去除第一列header跟index由0開始
						});

						dataTable.Rows.Add(dataRow);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error reading Excel file: " + ex.Message);
			}
			finally
			{
				// 釋放Excel相關資源
				workbook.Close(false);
				excelApp.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
			}

			return dataTable;
		}


		private void btn_othercolumn_Click(object sender, EventArgs e)
		{

			var datarow = this.dGdVwHeaders.CurrentRow;        // 母表選澤ROW DATA
			string header_canvas = Convert.ToString(datarow.Cells[0].Value == null ? "其他" : datarow.Cells[0].Value);

			//20240417 add 分類索引切換之際
			//----------------------------
			//20240109 add Caption string 收集
			foreach (var keys in list_CaptionObj)
			{
				list_innerObj.Add(new innerObj()
				{
					HeaderType = "",
					SubSeq = null,
					index = null,
					dbColumn = null,
					itemEngName = null,
					itemChtName = keys.itemChtName,
					itemType = keys.itemType,
					canvas = header_canvas,
					datablock = "",
				});
			}

			for (int i = 0; i < 3; i++)
				list_innerObj.Add(new innerObj()
				{
					HeaderType = "",
					SubSeq = null,
					index = null,
					dbColumn = null,
					itemEngName = null,
					itemChtName = null,
					itemType = "Form隱藏格式",
					canvas = header_canvas,
					datablock = "",
				});


			//多紀錄index
			foreach (var obj in list_innerObj.Select((Value, Index) => new { Value, Index }))
				obj.Value.innerIndex = obj.Index;


			this.Fun_Reload_SubDataGridView(datarow);
		}


		#endregion  --------------------- Tab4 --------------------------

		#region Setting Tab
		private void btn_setting_selectpath_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog path = new FolderBrowserDialog();
				path.ShowDialog();
				this.tbx_setting_projectpath.Text = path.SelectedPath;
				//加入tab1 tab2
				this.tbx_projectpath.Text = path.SelectedPath;
				this.tbx_tab2_projectpath.Text = path.SelectedPath;

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btn_setting_selectfrontendpath_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog path = new FolderBrowserDialog();
				path.ShowDialog();
				this.tbx_setting_frontendpath.Text = path.SelectedPath;

			}
			catch (Exception)
			{
				throw;
			}
		}

		private async void btn_line_notify_test_Click(object sender, EventArgs e)
		{
			line_notify("test");
			//bool aaa = await CheckBrunch("sit_deploy");
			//MessageBox.Show(aaa.ToString());
		}

		#endregion
		private void cbx_copydiff_Click(object sender, EventArgs e)
		{
			if (this.cbx_copydiff.Checked)
			{
				isdiffprogaram = true;
			}
			else
			{
				isdiffprogaram = false;
			}

		}

		//切換Tab執行事件
		private void tbc_main_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((sender as TabControl).SelectedIndex)
			{
				case 1:
					{
						if (this.tbx_projectpath.Text == "")
						{
							break;
						}
						//取得模組列表
						List<string> ds = fhelper.DirSearch(this.tbx_projectpath.Text + AppPortalpath);

						BindingSource bs = new BindingSource();
						//放入from_module
						this.cbx_frommodule.DataSource = ds;
						//放入target_module
						this.cbx_targetmodule.DataSource = ds;
					}

					break;
				case 2:
					{
						if (this.tbx_tab2_projectpath.Text == "")
						{
							break;
						}
						//取得模組列表
						List<string> ds = fhelper.DirSearch(this.tbx_tab2_projectpath.Text + AppPortalpath);

						BindingSource bs = new BindingSource();
						//放入from_module
						this.cbx_tab2_frommodule.DataSource = ds;
						//放入from_module
						this.cbx_tab2_frommodule.DataSource = ds;
					}
					break;
				case 4:
					{
						//AppPortal SingnalR 預設打勾
						this.cbx_AppPortal.Checked = true;
						this.cbx_SingnalR.Checked = true;



						//取得底層元件資訊
						fCompath = tbx_setting_frontendpath.Text + @"\projects";
						List<string> ds = fhelper.DirSearch(fCompath);


						foreach (var com in ds)
						{
							string ver = GetComponentVersion(fCompath, com);
							ComponentLists.Add(new Component { ComponentName = com, NewVersion = ver, OldVersion = ver });

						}
						this.dgv_component_list.DataSource = ComponentLists;
					}
					break;
				case 5:
					{
						cbx_tab6_branch.Items.Add(new GitBranch("sit", "SIT"));
						cbx_tab6_branch.Items.Add(new GitBranch("uat", "UAT"));
						cbx_tab6_branch.Items.Add(new GitBranch("release/v1.3", "PRD"));
					}
					break;
			}
		}




		#region APIGo Tab
		private void btn_base_api_Click(object sender, EventArgs e)
		{
			List<string> killProcessText = new List<string>();
			List<string> startCmdText = new List<string>();


			string killProcess = "DLP.WebAPI.{0}.exe";
			string startCmd = "start cmd /k \"cd /d " + this.tbx_setting_projectpath.Text + "/DLP.WebAPI/DLP.WebAPI.{0} && dotnet run \"";

			if (this.cbx_AppPortal.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_AppPortal.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_AppPortal.Text));
			}
			if (this.cbx_SingnalR.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_SingnalR.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_SingnalR.Text));
			}
			if (this.cbx_WO.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_WO.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_WO.Text));
			}
			if (this.cbx_OA.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_OA.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_OA.Text));
			}
			if (this.cbx_SD.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_SD.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_SD.Text));
			}
			if (this.cbx_MD.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_MD.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_MD.Text));
			}
			if (this.cbx_MP.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_MP.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_MP.Text));
			}
			if (this.cbx_MI.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_MI.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_MI.Text));
			}
			if (this.cbx_MG.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_MG.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_MG.Text));
			}
			if (this.cbx_PM.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_PM.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_PM.Text));
			}
			if (this.cbx_XX.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_XX.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_XX.Text));
			}
			if (this.cbx_DV.Checked)
			{
				killProcessText.Add(String.Format(killProcess, this.cbx_DV.Text));
				startCmdText.Add(String.Format(startCmd, this.cbx_DV.Text));
			}



			//會導致VS code 內的cmd 一起被關閉 所以移除
			//killProcessText.Add("CMD.exe");
			foreach (var cmd in killProcessText)
			{
				KillProcessByName(cmd);
			}
			foreach (var cmd in startCmdText)
			{
				ExecuteCommand(cmd);
				//System.Diagnostics.Process.Start("CMD.exe", cmd);
			}

		}

		static void KillProcessByName(string processName)
		{
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo
				{
					FileName = "taskkill",
					Arguments = $"/F /IM {processName}",
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				};

				using (Process process = new Process { StartInfo = psi })
				{
					process.Start();
					process.WaitForExit();

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		static void ExecuteCommand(string command)
		{
			try
			{

				ProcessStartInfo psi = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardError = true
				};

				using (Process process = new Process { StartInfo = psi })
				{
					process.Start();

					// Pass the command to cmd.exe
					process.StandardInput.WriteLine(command);
					process.StandardInput.Flush();
					process.StandardInput.Close();


					// Read the output
					//string output = process.StandardOutput.ReadToEnd();
					//string error = process.StandardError.ReadToEnd();

					//Console.WriteLine($"Output: {output}");
					//Console.WriteLine($"Error: {error}");

					process.WaitForExit();
					process.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		private void btn_dotnet_close_all_Click(object sender, EventArgs e)
		{
			try
			{
				Process[] processes = Process.GetProcesses();

				foreach (Process process in processes)
				{
					if (process.ProcessName.StartsWith("DLP.WebAPI", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine($"Killing process: {process.ProcessName} (ID: {process.Id})");
						process.Kill();
					}

					KillProcessByName("CMD.exe");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		//底層發粄工具
		private void btn_ng_build_Click(object sender, EventArgs e)
		{
			List<string> buildcom = new List<string>();

			string cmd = "start cmd /k \"cd /d " + tbx_setting_frontendpath.Text + " && ng build {0} && cd ./libraries/{0} && npm pack && cd ../..\"";
			//const string cmd = "cd ng build {0} ; cd ./libraries/{0} ; npm pack ; cd ../..";

			foreach (Component row in ComponentLists)
			{
				if (row.Check)
				{

					var targetpath = fCompath + @"\" + row.ComponentName + @"\" + "package.json";
					if (fhelper.FileReplace(targetpath, row.OldVersion, row.NewVersion))
					{
						ResultMessageAPIGo(row.ComponentName + " 版本號更新成功" + targetpath);
					}

					buildcom.Add(row.ComponentName);
				}

			}

			foreach (string name in buildcom)
			{
				string strbuildcom = String.Format(cmd, name);

				ExecuteCommand(strbuildcom);
				ResultMessageAPIGo("確認 [" + name + "] 是否執行成功!");
			}
		}

		private void btn_com_movekill_Click(object sender, EventArgs e)
		{
			string flibpath = tbx_setting_frontendpath.Text + "\\libraries\\{0}\\{1}.tgz";
			string tlibpath = tbx_setting_frontendpath.Text + "\\libraries\\{0}";


			foreach (Component row in ComponentLists)
			{
				if (row.Check)
				{
					//搬移
					string fpath = String.Format(flibpath, row.ComponentName, row.ComponentName + "-" + row.NewVersion);
					string tpath = String.Format(tlibpath, row.ComponentName + "-" + row.NewVersion + ".tgz");
					if (fhelper.FileMove(fpath, tpath))
					{
						ResultMessageAPIGo("檔案搬移成功" + tpath);
					}

					fhelper.FolderDelete(String.Format(tlibpath, row.ComponentName));
				}

			}


		}

		private void btn_move2develop_Click(object sender, EventArgs e)
		{
			string flibpath = tbx_setting_frontendpath.Text + "\\libraries\\{0}";
			string packagever = "file:libraries/{0}.tgz";

			foreach (Component row in ComponentLists)
			{
				if (row.Check)
				{
					//搬移
					string fpath = String.Format(flibpath, row.ComponentName + "-" + row.NewVersion + ".tgz");
					string tpath = this.tbx_projectpath.Text + String.Format(Librariespath, row.ComponentName + "-" + row.NewVersion + ".tgz");
					if (fhelper.FileMove(fpath, tpath))
					{
						ResultMessageAPIGo("元件搬移成功: " + row.ComponentName + "-" + row.NewVersion + ".tgz");
					}

					//更新 Package
					string beforetext = String.Format(packagever, row.ComponentName + "-" + row.OldVersion);
					string aftertext = String.Format(packagever, row.ComponentName + "-" + row.NewVersion);


					if (fhelper.FileReplace(this.tbx_projectpath.Text + Packagepath, beforetext, aftertext))
					{
						ResultMessageAPIGo("Package 版本號更新成功" + row.ComponentName + "-" + row.NewVersion + ".tgz");
					}
				}

			}
		}

		private void btn_install_component_Click(object sender, EventArgs e)
		{
			try
			{
				string cmd = "start cmd /k \"cd /d D:\\DLP_Git\\dlp-develop\\DLP.Web\\DLP.Web.AppPortal\\ClientApp && npm row \"";
				ExecuteCommand(cmd);
			}
			catch (Exception)
			{

				throw;
			}

		}

		/// <summary>
		/// 取得版本號
		/// </summary>
		/// <param name="compath"></param>
		/// <param name="com"></param>
		/// <returns></returns>
		private string GetComponentVersion(string compath, string com)
		{
			var dtoText = fhelper.FileRead(compath + @"\" + com + @"\" + "package.json", "\"version\": \"", "\",");

			return dtoText[0].Split('"')[3];
		}


		//訊息結果
		public void ResultMessageAPIGo(string msg)
		{
			tbx_APIGo_resultMsg.Text += Environment.NewLine;
			tbx_APIGo_resultMsg.Text += msg;
		}
		#endregion

		#region PokemonGo

		bool reserve_flag = false;	// 是否預約判斷
		//發版計時器
		private async void tim_tab6_reservecheck_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime reserveTime = dtp_checkTime.Value;
			

			if (now > reserveTime)
			{
				ResultMessageTab6("現在時間 [ " + now + " ] 已大於設定時間 [ " + reserveTime + " ]");
				ResultMessageTab6("開始發版");

				GitBranch branch = cbx_tab6_branch.Items[cbx_tab6_branch.SelectedIndex] as GitBranch;
				if ((await CheckBrunch()))
				{
					console_msg_lineNotify($"分支衝突，停止發版", "Failed");
					tim_tab6_reservecheck.Stop();
					OpenUrl("http://172.20.10.106/root/dlp-develop/-/branches");
					return;
				}

				gitprocess();

				if (reserve_flag)
				{
					Thread.Sleep(20 * 1000);
					CallGitlabCreateMR();
					Thread.Sleep(5 * 60 * 1000);
					tim_pipelinecheck.Start();
				}

				reserve_flag = false;
				tim_tab6_reservecheck.Stop();
			}
			else
			{
				reserve_flag = true;
			}

		}

		private void btn_reserve_Click(object sender, EventArgs e)
		{
			if (cbx_tab6_branch.Text == "")
			{
				MessageBox.Show("請先選擇Branch!");
			}
			else if (!this.cbx_tab6_dg.Checked && !this.cbx_tab6_vn.Checked && !this.cbx_tab6_tc.Checked)
			{
				MessageBox.Show("請至少選擇一個廠區!");
			}
			else
			{
				tim_tab6_reservecheck.Start();
				ResultMessageTab6("預約時間 [ " + dtp_checkTime.Value.ToString() + " ]，版本 [ " + cbx_tab6_branch.Text + " ] ");
			}

		}

		private void btn_cancel_reserve_Click(object sender, EventArgs e)
		{
			tim_tab6_reservecheck.Stop();
			ResultMessageTab6("取消預約!");
		}
		//訊息結果
		public void ResultMessageTab6(string msg)
		{
			tbx_tab6_resultMsg.Text += Environment.NewLine;
			tbx_tab6_resultMsg.Text += msg;
		}

		//Git 發版流程
		public void gitprocess()
		{

			string gitcmd = "restore .";
			string commit = "";
			string repositoryPath = this.tbx_setting_projectpath.Text;  // 路徑
			GitBranch branch = cbx_tab6_branch.Items[cbx_tab6_branch.SelectedIndex] as GitBranch;

			if (this.cbx_tab6_dg.Checked)
			{
				commit += "dg_";
			}
			if (this.cbx_tab6_vn.Checked)
			{
				commit += "vn_";
			}
			if (this.cbx_tab6_tc.Checked)
			{
				commit += "tc_";
			}
			var yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
			var HHmm = DateTime.Now.ToString("HHmm");
			commit += "[" + yyyyMMdd.PadLeft(2).Remove(0, 2) + "." + HHmm + "]";
			// 發佈訊息使用
			ResultMessageTab6("=======================");
			ResultMessageTab6(branch.BranchValue);
			ResultMessageTab6(commit);
			ResultMessageTab6("=======================");

			try
			{
				Clipboard.SetText(branch.BranchValue + Environment.NewLine + commit);
			}
			catch (System.Runtime.InteropServices.ExternalException)
			{
				ResultMessageTab6("系統登出鎖定，複製剪貼字串失敗");
			}

			//return;
			//restore clean
			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);
			gitcmd = "clean -f";
			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);

			// 切換分支
			gitcmd = "switch " + branch.BranchKey;

			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);

			// 拉取最新版本
			gitcmd = "pull origin " + branch.BranchKey;
			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);

			//更新版號
			var oldVersion = fhelper.FileRead(this.tbx_setting_projectpath.Text + Packagepath, "\"version\": \"", "\"")[0].Split(':')[1].Split('\"')[1];
			//版號+1
			var newVersion = oldVersion.Split('.')[0] + "." + oldVersion.Split('.')[1] + "." + (Int32.Parse(oldVersion.Split('.')[2]) + 1).ToString();

			//更新版號
			fhelper.FileReplace(this.tbx_setting_projectpath.Text + Packagepath, oldVersion, newVersion);

			//commit 


			gitcmd = "commit -am \"" + commit + "\"";
			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);

			MergeRequest.Title = commit;



			//Push depoly
			switch (branch.BranchValue)
			{
				case "SIT":
					gitcmd = "push origin " + branch.BranchKey + ":sit_deploy";
					MergeRequest.TargetBranch = branch.BranchKey;
					MergeRequest.SourceBranch = "sit_deploy";
					break;
				case "UAT":
					gitcmd = "push origin " + branch.BranchKey + ":uat_deploy";
					MergeRequest.TargetBranch = branch.BranchKey;
					MergeRequest.SourceBranch = "uat_deploy";
					break;
				case "PRD":
					gitcmd = "push origin " + branch.BranchKey + ":rel_deploy";
					MergeRequest.TargetBranch = branch.BranchKey;
					MergeRequest.SourceBranch = "rel_deploy";
					break;
				default:
					break;
			}

			ResultMessageTab6("Git Cmd> " + gitcmd);
			ExecuteGitCommand(repositoryPath, gitcmd);


		}

		public void ExecuteGitCommand(string repositoryPath, string command)
		{
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo
				{
					FileName = "git",
					WorkingDirectory = repositoryPath,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardError = true
				};

				using (Process process = new Process { StartInfo = psi })
				{
					process.StartInfo.Arguments = command;
					process.Start();

					// 等待命令執行完成
					process.WaitForExit();

					// 讀取輸出和錯誤信息
					string output = process.StandardOutput.ReadToEnd();
					string error = process.StandardError.ReadToEnd();

					ResultMessageTab6(output);
					ResultMessageTab6(error);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}


		private async void btn_getMRinfo_Click(object sender, EventArgs e)
		{
			await TestConnect();

		}

		// 測試連線
		private async Task<bool> TestConnect()
		{
			return await CallGitlabApiGet<List<pipelineDTO>>("merge_requests" + textBox1.Text,
				(reponseObjList, content) =>
				{
					MessageBox.Show(content.ToString());
					MessageBox.Show("連線正常" + reponseObjList);
				});
		}

		// 確認分支
		private async Task<bool> CheckBrunch(string branchName="")
		{
			switch (branchName)
			{
				case "SIT":
					branchName = "sit_deploy";
					break;
				case "UAT":
					branchName = "uat_deploy";
					break;
				case "PRD":
					branchName = "rel_deploy";
					break;
				default:
					break;
			}

			var sit_flag = await CallGitlabApiGet<dynamic>($"projects/{ProjectId}/repository/branches/sit_deploy",
				(reponseObjList, content) =>{});

			var uat_flag = await CallGitlabApiGet<dynamic>($"projects/{ProjectId}/repository/branches/uat_deploy",
				(reponseObjList, content) => { });

			var rel_flag = await CallGitlabApiGet<dynamic>($"projects/{ProjectId}/repository/branches/rel_deploy",
				(reponseObjList, content) => { });

			return sit_flag || uat_flag || rel_flag;
		}

		private void btnCreateMergeRequest_Click(object sender, EventArgs e)
		{
			CallGitlabCreateMR();
		}

		private async void CallGitlabCreateMR()
		{
			PrivateToken = txtToken.Text;
			UserId = Convert.ToInt32(txtUserId.Text);

			if (string.IsNullOrEmpty(PrivateToken) || UserId == 0)
			{
				MessageBox.Show("Please enter your Private Token and User ID.");
				return;
			}

			try
			{
				//發MR
				var mergeRequestCreated = await CreateMergeRequest();
				if (mergeRequestCreated != null)
				{
					//因實測GITLAB反應較慢，有異常狀態報錯，故加延遲
					Thread.Sleep(1000);

					//設定MR參數
					bool updated = await UpdateMergeRequest(mergeRequestCreated.Iid);
					if (updated)
					{
						MessageBox.Show("Merge Request updated successfully!");
					}
					else
					{
						MessageBox.Show("Failed to update Merge Request.");
					}

					//儲存設定檔
					if (!string.IsNullOrEmpty(txtToken.Text) && int.TryParse(txtUserId.Text, out int userId))
					{
						Properties.Settings.Default.UserToken = txtToken.Text;
						Properties.Settings.Default.UserId = Convert.ToInt32(txtUserId.Text);
						Properties.Settings.Default.Save();
					}
					else
					{
						MessageBox.Show("Please enter a valid Token and User ID.");
					}
				}
				else
				{
					MessageBox.Show("Failed or Canceled to create Merge Request.");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}

		}

		// 產MR
		private async Task<mergerequest> CreateMergeRequest()
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(GitLabApiUrl);
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", PrivateToken);

					var mergeRequest = new
					{
						source_branch = MergeRequest.SourceBranch, // "uat_deploy",
						target_branch = MergeRequest.TargetBranch, //"uat",
						title = MergeRequest.Title, //"tc_[240719.1710]",
						assignee_id = UserId,
						remove_source_branch = true
					};

					string json = JsonConvert.SerializeObject(mergeRequest);
					StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync($"projects/{ProjectId}/merge_requests", content);

					var responseContent = await response.Content.ReadAsStringAsync();
					if (response.IsSuccessStatusCode)
					{
						mergerequest createdMergeRequest = JsonConvert.DeserializeObject<mergerequest>(responseContent);
						return createdMergeRequest;
					}
					else
					{
						MessageBox.Show($"Error: {response.IsSuccessStatusCode}\n{responseContent}");
						return null;
					}

				}

			}
			catch (HttpRequestException httpRequestException)
			{
				MessageBox.Show($"Request error: {httpRequestException.Message}");
				return null;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An unexpected error occurred: {ex.Message}");
				return null;
			}
		}

		// 設定MR中merge_when_pipeline_succeeds
		private async Task<bool> UpdateMergeRequest(int mergeRequestIid)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(GitLabApiUrl);
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", PrivateToken);

					var updateRequest = new
					{
						merge_when_pipeline_succeeds = true,
						merge_commit_message = MergeRequest.Title,
					};

					string json = JsonConvert.SerializeObject(updateRequest);
					StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PutAsync($"projects/{ProjectId}/merge_requests/{mergeRequestIid}/merge", content);

					string responseContent = await response.Content.ReadAsStringAsync();
					var statusCode = response.StatusCode;

					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						MessageBox.Show($"Error: {statusCode}\n{responseContent}");
						return false;
					}
				}
			}
			catch (HttpRequestException httpRequestException)
			{
				MessageBox.Show($"Request error: {httpRequestException.Message}");
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An unexpected error occurred: {ex.Message}");
				return false;
			}
		}


		bool detect_timing_flag = true;
		CancellationTokenSource _cancellationTokenSource;
		private async void btn_detect_pipeline_Click(object sender, EventArgs e)
		{

			if (detect_timing_flag)
			{
				_cancellationTokenSource = new CancellationTokenSource();
				var token = _cancellationTokenSource.Token;

				try
				{
					lab_timer_status.Text = "Start to wait ...";
					//MessageBox.Show("前段等待開始");
					detect_timing_flag = detect_timing_flag == true ? false : true;

					await Task.Delay(5  * 1000, token);//* 60

					tim_pipelinecheck.Start(); //MessageBox.Show("後段偵測開始");
					lab_timer_status.Text = "Start to detect ...";
					pipelineId = null;

				}
				catch (TaskCanceledException)
				{
					lab_timer_status.Text = "Cancel";
					//MessageBox.Show("前段等待取消");
				}

			}
			else
			{
				detect_timing_flag = detect_timing_flag == true ? false : true;

				if (_cancellationTokenSource != null)
				{
					_cancellationTokenSource.Cancel();// 取消 Task.Delay 的延遲
				}

				tim_pipelinecheck.Stop(); //MessageBox.Show("後段偵測停止");
				lab_timer_status.Text = "Stop";


			}

		}

		private async void tim_pipelinecheck_Tick(object sender, EventArgs e)
		{
			await DetectPipeline();
		}

		// 偵測Pipeline狀態
		private async Task<bool> DetectPipeline()
		{

			bool flag = true;
			

			if (pipelineId is null)
			{
				//https://docs.gitlab.com/ee/api/pipelines.html
				flag = await CallGitlabApiGet<List<pipelineDTO>>($"projects/{ProjectId}/pipelines",   // 取得pipelines訊息
				(reponseObjList, content) =>
				{
					string messge = "";
					foreach (pipelineDTO reponseObj in reponseObjList)
					{
						if (reponseObj.status == "pending") // 正常只有一個
							pipelineId = pipelineId is null || pipelineId != reponseObj.id ? reponseObj.id : pipelineId;
					}
				});

				if (!flag) pipelineId = null;
			}


			if (pipelineId is not null && flag)
			{
				flag = await CallGitlabApiGet<dynamic>($"projects/{ProjectId}/pipelines/" + pipelineId,   // 取得指定pipelines訊息
					(reponseObj, content) =>
					{
						if (reponseObj.status == "success")
						{
							pipelineId = null;
							lab_timer_status.Text = "Stop";
							tim_pipelinecheck.Stop();
							console_msg_lineNotify($"{MergeRequest.Title} 執行完成且成功。{reponseObj.status}", "PASS");
						}
						else if (reponseObj.status == "failed")
						{
							pipelineId = null;
							lab_timer_status.Text = "Stop";
							tim_pipelinecheck.Stop();
							console_msg_lineNotify($"{MergeRequest.Title} 執行完成但失敗{reponseObj.status}\n\n需自行刪除分支 或 重跑Pokemon", "FAIL");
							OpenUrl("http://172.20.10.106/root/dlp-develop/-/branches");
						}
					});

			}
			else
			{
				detect_timing_flag = detect_timing_flag == true ? false : true;
				lab_timer_status.Text = "Stop";
				tim_pipelinecheck.Stop(); //MessageBox.Show("後段偵測停止(自動)");

			}

			return flag;




		}

		private async Task<bool> CallGitlabApiGet<T>(string Endpoint, Action<T, string> callback)
		{

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", PrivateToken);

				try
				{
					var response = await client.GetAsync("http://172.20.10.106/api/v4/" + Endpoint);   //https://gitlab.com/api/v4/projects");

					if (response.IsSuccessStatusCode)
					{

						var content = await response.Content.ReadAsStringAsync();
						T reponseObjList = JsonConvert.DeserializeObject<T>(content);

						callback?.Invoke(reponseObjList, content);

						return true;
					}
					// 如果回傳 404，表示不存在
					else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
					{
						return false;
					}
					else
					{
						MessageBox.Show("連線失敗，狀態碼：" + response.StatusCode);
						return false;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("連線失敗：" + ex.Message);
					return false;
				}
			}
		}

		// Line 通知
		private void line_notify(string message)
		{
			LineNotifyToken = LineNotifyToken == txtLineNotifyToken.Text ? LineNotifyToken : txtLineNotifyToken.Text;
			if (LineNotifyToken == null || LineNotifyToken == string.Empty) return;

			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.LineNotifyToken);
			var content = new Dictionary<string, string>();
			content.Add("message", message);
			httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));

			if (!string.IsNullOrEmpty(txtLineNotifyToken.Text))
			{
				Properties.Settings.Default.LineNotifyToken = txtLineNotifyToken.Text;
				Properties.Settings.Default.Save();
			}


		}

		// 開網頁
		private void OpenUrl(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = url,
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show("無法開啟網址: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// 置頂彈窗
		private static void msg2top(string message,string title="")
		{
			MessageBox.Show(message, "FAIL",
								MessageBoxButtons.OK, MessageBoxIcon.None,
								MessageBoxDefaultButton.Button1,
								MessageBoxOptions.DefaultDesktopOnly);
		}

		private void console_msg_lineNotify(string message, string title = "")
		{
			ResultMessageTab6(message);
			line_notify(message);
			msg2top(message, "title");
		}

		#endregion


		#region SqlAnalyze


		private void cbx_tab7_fromarea_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btn_dbconnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.cbx_tab7_fromarea.Text == "")
				{
					MessageBox.Show("請先選擇地區!");
					return;
				}

				switch (this.cbx_tab7_fromarea.Text)
				{
					case "DG":
						if (DgDbcontext == null)
						{
							DgDbcontext = GenericDbFactory<DGDbContext>.Create();
							DgDbcontext.Connect();
							ResultMessage(TabEnum.SqlAnalyze, "DGDBT-連線成功!");
						}
						break;
					case "VN":
						if (VnDbcontext == null)
						{
							VnDbcontext = GenericDbFactory<VNDbContext>.Create();
							VnDbcontext.Connect();
							ResultMessage(TabEnum.SqlAnalyze, "VNDBT-連線成功!");
						}
						break;
					case "VG":
						if (VgDbcontext == null)
						{
							VgDbcontext = GenericDbFactory<VGDbContext>.Create();
							VgDbcontext.Connect();
							ResultMessage(TabEnum.SqlAnalyze, "VGDBT-連線成功!");
						}
						break;
					case "TC":
						if (TcDbcontext == null)
						{
							TcDbcontext = GenericDbFactory<TCDbContext>.Create();
							TcDbcontext.Connect();
							ResultMessage(TabEnum.SqlAnalyze, "TCDBT-連線成功!");
						}
						break;
					default:
						ResultMessage(TabEnum.SqlAnalyze, "[" + this.cbx_tab7_fromarea.Text + "]，無此地區DB連線!");
						break;
				}

			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.DoGoRo, ex.Message);
			}
		}

		private void btn_sqlanalyze_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.tbx_tab7_Program.Text == "")
				{
					MessageBox.Show("請先填入Package Name");
					return;
				}

				List<SqlAnalyze> resultList = new List<SqlAnalyze>();

				//string package = "PK_WO_WOR168";//ZZ_TEST//
				string package = this.tbx_tab7_Program.Text;
				ResultMessage(TabEnum.SqlAnalyze, "================開始分析：" + package.ToUpper() + "================");

				string sql = "SELECT * FROM ALL_SOURCE WHERE TYPE = 'PACKAGE BODY' AND NAME = '" + package.ToUpper() + "'";

				List<AllSource> ASList = new List<AllSource>();

				switch (this.cbx_tab7_fromarea.Text)
				{
					case "DG":
						ASList = sahelper.getAllSql(DgDbcontext.Query(sql));
						break;
					case "VN":
						ASList = sahelper.getAllSql(VnDbcontext.Query(sql));
						break;
					case "VG":
						ASList = sahelper.getAllSql(VgDbcontext.Query(sql));
						break;
					case "TC":
						ASList = sahelper.getAllSql(TcDbcontext.Query(sql));
						break;
					default:
						ResultMessage(TabEnum.SqlAnalyze, "[" + this.cbx_tab7_fromarea.Text + "]，無此地區DB連線!");
						break;
				}

				//處理query資料
				mergeData_out("Q", getQueryData(ASList), resultList);
				//處理insert資料
				mergeData_out("I", getInsertData(ASList), resultList);
				//處理update資料
				mergeData_out("U", getUpdateData(ASList), resultList);
				//處理delete資料
				mergeData_out("D", getDeleteData(ASList), resultList);
				//處理join資料
				mergeData_out("J", getJoinData(ASList), resultList);

				this.dgv_tab7_sqlanalyze.DataSource = resultList;

				ResultMessage(TabEnum.SqlAnalyze, "================完成分析：" + package.ToUpper() + "================");
			}
			catch (Exception)
			{

				throw;
			}
		}

		static void mergeData_out(string method, List<string> listData, in List<SqlAnalyze> resultList)
		{
			if (listData == null) return;

			foreach (var item in listData)
			{
				if (resultList.Count(x => x.Table == item) > 0)
				{
					//已存在
					switch (method)
					{
						case "Q":
							resultList.Find(x => x.Table == item).Query = true;
							break;
						case "U":
							resultList.Find(x => x.Table == item).Update = true;
							break;
						case "D":
							resultList.Find(x => x.Table == item).Delete = true;
							break;
						case "I":
							resultList.Find(x => x.Table == item).Insert = true;
							break;
						case "J":
							resultList.Find(x => x.Table == item).Join = true;
							break;
						default:
							break;
					}

				}
				else
				{
					//新增
					SqlAnalyze sa = new SqlAnalyze();
					sa.Table = item;
					switch (method)
					{
						case "Q":
							sa.Query = true;
							break;
						case "U":
							sa.Update = true;
							break;
						case "D":
							sa.Delete = true;
							break;
						case "I":
							sa.Insert = true;
							break;
						case "J":
							sa.Join = true;
							break;
						default:
							break;
					}

					resultList.Add(sa);
				}

			}
		}

		public List<string> getJoinData(List<AllSource> aslist)
		{
			ResultMessage(TabEnum.SqlAnalyze, "5.Join");

			List<AllSource> list_from = aslist.FindAll(x => x.TEXT.Contains("JOIN"));
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PK_LOG_UTILITY")).ToList();

			if (list_from.Count == 0) return null;

			//list_from = list_from.Where(x => !x.TEXT.Contains("DUAL")).ToList();

			List<string> ls_st1 = new List<string>();
			List<string> ls_st2 = new List<string>();
			List<string> ls_st3 = new List<string>();

			try
			{

				//step1 組合語法
				foreach (AllSource strfrom in list_from)
				{
					string strsql = "";

					for (int i = strfrom.LINE - 1; i < aslist.Count(); i++)
					{
						//所有可能的結尾
						if (aslist[i].TEXT.Contains("ON"))
						{
							strsql += aslist[i].TEXT;
							break;
						}
						strsql += aslist[i].TEXT;
					}
					ls_st1.Add(strsql);
				}

				//step2 擷取字段
				foreach (string str in ls_st1)
				{
					int fromIndex = str.IndexOf("JOIN");

					// 获取 "JOIN" 之前的子字符串
					string before = str.Substring(0, fromIndex);

					// 检查 "--" 是否出现在这个子字符串中
					//如果沒有-- 才處理
					if (!before.Contains("--"))
					{
						int endIndex = 0;
						string result = "";
						if (str.IndexOf("ON") > 0)
						{
							endIndex = str.IndexOf("ON");
						}
						result = str.Substring(fromIndex + "JOIN".Length, endIndex - (fromIndex + "JOIN".Length)).Trim();

						ls_st2.Add(result);
					}

				}

				//檢核table是否存在
				string sqlIn = "";

				//step3 檢驗table
				foreach (string str in ls_st2)
				{
					var data = str.Split(' ')[0];

					sqlIn += "'" + data + "',";

				}

				if (sqlIn != "")
				{
					sqlIn = sqlIn.Substring(0, sqlIn.Length - 1);

					// 移除所有的換行符號 (\r 和 \n)
					sqlIn = sqlIn.Replace("\r", "").Replace("\n", "");
				}
				else
				{
					sqlIn = "''";
				}

				//檢核table是否存在
				List<string> dataResult = checkTable(checkTableSql, sqlIn.ToUpper());

				var printResult = "";
				//輸出結果
				foreach (var item in dataResult)
				{
					printResult += item + ',';
				}

				if (printResult != "")
				{
					ResultMessage(TabEnum.SqlAnalyze, printResult.Substring(0, printResult.Length - 1));
				}


				//ResultMessage(TabEnum.SqlAnalyze, "===============分析Join資料結束================");

				return dataResult;


			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.SqlAnalyze, ex.Message);
				return null;
			}
		}



		public List<string> getDeleteData(List<AllSource> aslist)
		{
			ResultMessage(TabEnum.SqlAnalyze, "4.Delet");

			List<AllSource> list_from = aslist.FindAll(x => x.TEXT.Contains("DELETE"));
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PK_LOG_UTILITY")).ToList();

			//移除PacKage名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PROCEDURE")).ToList();
			//移除PacKage名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("_DELETE_")).ToList();

			if (list_from.Count == 0) return null;

			//list_from = list_from.Where(x => !x.TEXT.Contains("DUAL")).ToList();

			List<string> ls_st1 = new List<string>();
			List<string> ls_st2 = new List<string>();
			List<string> ls_st3 = new List<string>();

			try
			{

				//step1 組合語法
				foreach (AllSource strfrom in list_from)
				{
					string strsql = "";

					for (int i = strfrom.LINE - 1; i < aslist.Count(); i++)
					{
						//所有可能的結尾
						if (aslist[i].TEXT.Contains("WHERE"))
						{
							strsql += aslist[i].TEXT;
							break;
						}
						strsql += aslist[i].TEXT;
					}
					ls_st1.Add(strsql);
				}

				//step2 擷取字段
				foreach (string str in ls_st1)
				{
					//换行符替换为空白
					var query = str.Replace(Environment.NewLine, " ").Replace("\n", " ").Replace("\r", " ");
					// 移除多余的空白字符
					query = System.Text.RegularExpressions.Regex.Replace(query, @"\s+", " ");

					int fromIndex = query.IndexOf("DELETE FROM") == -1 ? query.IndexOf("DELETE") : query.IndexOf("DELETE FROM");

					// 获取 "DELETE FROM" 之前的子字符串
					string before = query.Substring(0, fromIndex);

					// 检查 "--" 是否出现在这个子字符串中
					//如果沒有-- 才處理
					if (!before.Contains("--"))
					{
						int endIndex = 0;
						string result = "";
						if (query.IndexOf("WHERE") > 0)
						{
							endIndex = query.IndexOf("WHERE");
						}
						result = query.Substring(fromIndex + "DELETE FROM".Length, endIndex - (fromIndex + "DELETE FROM".Length)).Trim();

						ls_st2.Add(result);
					}
				}

				//檢核table是否存在
				string sqlIn = "";

				//step3 檢驗table
				foreach (string str in ls_st2)
				{
					sqlIn += "'" + str + "',";

				}

				if (sqlIn != "")
				{
					sqlIn = sqlIn.Substring(0, sqlIn.Length - 1);

					// 移除所有的換行符號 (\r 和 \n)
					sqlIn = sqlIn.Replace("\r", "").Replace("\n", "");
				}
				else
				{
					sqlIn = "''";
				}



				//檢核table是否存在
				List<string> dataResult = checkTable(checkTableSql, sqlIn.ToUpper());

				var printResult = "";
				//輸出結果
				foreach (var item in dataResult)
				{
					printResult += item + ',';
				}
				if (printResult != "")
				{
					ResultMessage(TabEnum.SqlAnalyze, printResult.Substring(0, printResult.Length - 1));
				}


				//ResultMessage(TabEnum.SqlAnalyze, "===============分析Delet資料結束================");

				return dataResult;


			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.SqlAnalyze, ex.Message);
				return null;
			}
		}


		public List<string> getUpdateData(List<AllSource> aslist)
		{
			ResultMessage(TabEnum.SqlAnalyze, "3.Update");

			List<AllSource> list_from = aslist.FindAll(x => x.TEXT.Contains("UPDATE "));

			if (list_from.Count == 0) return null;

			//移除PacKage名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PROCEDURE")).ToList();
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PK_LOG_UTILITY")).ToList();
			//移除FOR UPDATE OF
			//PK_WO_WOR168 出現此語句
			list_from = list_from.Where(x => !x.TEXT.Contains("FOR UPDATE OF")).ToList();

			List<string> ls_st1 = new List<string>();
			List<string> ls_st2 = new List<string>();
			List<string> ls_st3 = new List<string>();

			try
			{

				//step1 組合語法
				foreach (AllSource strfrom in list_from)
				{
					string strsql = "";

					for (int i = strfrom.LINE - 1; i < aslist.Count(); i++)
					{
						//所有可能的結尾
						if (aslist[i].TEXT.Contains("SET"))
						{
							strsql += aslist[i].TEXT;
							break;
						}
						strsql += aslist[i].TEXT;
					}
					ls_st1.Add(strsql);
				}

				//step2 擷取字段
				foreach (string str in ls_st1)
				{
					int fromIndex = str.IndexOf("UPDATE ");

					// 获取 "UPDATE" 之前的子字符串
					string before = str.Substring(0, fromIndex);

					// 检查 "--" 是否出现在这个子字符串中
					//如果沒有-- 才處理
					if (!before.Contains("--"))
					{
						int endIndex = 0;
						string result = "";
						if (str.IndexOf("SET") > 0)
						{
							endIndex = str.IndexOf("SET");
						}
						result = str.Substring(fromIndex + "UPDATE ".Length, endIndex - (fromIndex + "UPDATE ".Length)).Trim();

						ls_st2.Add(result);
					}


				}

				//檢核table是否存在
				string sqlIn = "";

				//step3 檢驗table
				foreach (string str in ls_st2)
				{
					sqlIn += "'" + str + "',";

				}
				if (sqlIn != "")
				{
					sqlIn = sqlIn.Substring(0, sqlIn.Length - 1);

					// 移除所有的換行符號 (\r 和 \n)
					sqlIn = sqlIn.Replace("\r", "").Replace("\n", "");
				}
				else
				{
					sqlIn = "''";
				}


				//檢核table是否存在
				List<string> dataResult = checkTable(checkTableSql, sqlIn.ToUpper());

				var printResult = "";
				//輸出結果
				foreach (var item in dataResult)
				{
					printResult += item + ',';
				}
				if (printResult != "")
				{
					ResultMessage(TabEnum.SqlAnalyze, printResult.Substring(0, printResult.Length - 1));
				}


				//ResultMessage(TabEnum.SqlAnalyze, "===============分析Update資料結束================");

				return dataResult;


			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.SqlAnalyze, ex.Message);
				return null;
			}
		}

		public List<string> getInsertData(List<AllSource> aslist)
		{
			ResultMessage(TabEnum.SqlAnalyze, "2.Insert");

			List<AllSource> list_from = aslist.FindAll(x => x.TEXT.Contains("INSERT INTO"));
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PK_LOG_UTILITY")).ToList();
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("EXECUTE IMMEDIATE")).ToList();

			if (list_from.Count == 0) return null;

			List<string> ls_st1 = new List<string>();
			List<string> ls_st2 = new List<string>();
			List<string> ls_st3 = new List<string>();

			try
			{

				//step1 組合語法
				foreach (AllSource strfrom in list_from)
				{
					string strsql = "";

					for (int i = strfrom.LINE - 1; i < aslist.Count(); i++)
					{
						//所有可能的結尾
						if (aslist[i].TEXT.Contains("("))
						{
							strsql += aslist[i].TEXT;
							break;
						}
						strsql += aslist[i].TEXT;
					}
					ls_st1.Add(strsql);
				}

				//step2 擷取字段
				foreach (string str in ls_st1)
				{
					int fromIndex = str.IndexOf("INSERT INTO");

					// 获取 "INSERT INTO" 之前的子字符串
					string before = str.Substring(0, fromIndex);

					// 检查 "--" 是否出现在这个子字符串中
					//如果沒有-- 才處理
					if (!before.Contains("--"))
					{
						int endIndex = 0;
						string result = "";
						if (str.IndexOf("(") > 0)
						{
							endIndex = str.IndexOf("(");
						}
						result = str.Substring(fromIndex + "INSERT INTO".Length, endIndex - (fromIndex + "INSERT INTO".Length)).Trim();

						ls_st2.Add(result);
					}

				}

				//檢核table是否存在
				string sqlIn = "";

				//step3 檢驗table
				foreach (string str in ls_st2)
				{
					sqlIn += "'" + str + "',";

				}

				sqlIn = sqlIn.Substring(0, sqlIn.Length - 1);

				// 移除所有的換行符號 (\r 和 \n)
				sqlIn = sqlIn.Replace("\r", "").Replace("\n", "");

				//檢核table是否存在
				List<string> dataResult = checkTable(checkTableSql, sqlIn.ToUpper());

				var printResult = "";
				//輸出結果
				foreach (var item in dataResult)
				{
					printResult += item + ',';
				}
				ResultMessage(TabEnum.SqlAnalyze, printResult.Substring(0, printResult.Length - 1));

				//ResultMessage(TabEnum.SqlAnalyze, "===============分析Insert資料結束================");

				return dataResult;


			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.SqlAnalyze, ex.Message);
				return null;
			}
		}

		public static string RemoveBeforeFrom(string input)
		{
			// 找到 "FROM" 的位置
			int index = input.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);

			// 如果找到了 "FROM"，则返回从 "FROM" 开始的子字符串
			if (index >= 0)
			{
				return input.Substring(index);
			}

			// 如果没有找到 "FROM"，返回原始字符串
			return input;
		}

		public List<string> getQueryData(List<AllSource> aslist)
		{
			ResultMessage(TabEnum.SqlAnalyze, "1.Query");

			List<AllSource> list_from = aslist.FindAll(x => x.TEXT.Contains("FROM"));

			if (list_from.Count == 0) return null;

			//第一階段排除
			//排除DUAL
			list_from = list_from.Where(x => !x.TEXT.Contains("DUAL")).ToList();
			//移除 || 的case
			//FROM ( ' || vSQLStmt || ' ) 
			list_from = list_from.Where(x => !x.TEXT.Contains("||")).ToList();
			//排除delete
			list_from = list_from.Where(x => !x.TEXT.Contains("DELETE")).ToList();
			//排除XXX_FROM的欄位
			list_from = list_from.Where(x => !x.TEXT.Contains("_FROM")).ToList();
			//移除PacKage名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PROCEDURE")).ToList();
			//移除PK_LOG_UTILITY名稱
			list_from = list_from.Where(x => !x.TEXT.Contains("PK_LOG_UTILITY")).ToList();

			List<string> ls_st1 = new List<string>();
			List<string> ls_st2 = new List<string>();
			List<string> ls_st3 = new List<string>();

			try
			{

				// 深拷贝整个列表
				List<AllSource> copiedList = new List<AllSource>();
				foreach (AllSource item in list_from)
				{
					copiedList.Add(item.DeepCopy());
				}


				//step1 組合語法
				foreach (var strfrom in copiedList)
				{
					// 排除FROM關鍵字前面有註解 --
					int fromIndex = strfrom.TEXT.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
					if (!strfrom.TEXT.Substring(0, fromIndex).Contains("--"))
					{

						string strsql = "";

						//移除FROM 前面的文字,下方case
						//SELECT MAX(MI370_ACC_MONTHS) INTO VYYMM FROM MI370
						strfrom.TEXT = strfrom.TEXT.Substring(fromIndex);

						for (int i = strfrom.LINE - 1; i < aslist.Count(); i++)
						{
							//第一次要特別處理
							//要將處理過FROM前面的字串塞進去
							//第4292行處理
							if (i == strfrom.LINE - 1)
							{
								//所有可能的結尾
								if (strfrom.TEXT.Contains("WHERE") || strfrom.TEXT.Contains("JOIN") || strfrom.TEXT.Contains(";") || strfrom.TEXT.Contains(")"))
								{
									strsql = strfrom.TEXT;
									break;
								}
								strsql = strfrom.TEXT;
							}
							else
							{

								//所有可能的結尾
								if (aslist[i].TEXT.Contains("WHERE") || aslist[i].TEXT.Contains("JOIN") || aslist[i].TEXT.Contains(";") || aslist[i].TEXT.Contains(")"))
								{
									strsql += aslist[i].TEXT;
									break;
								}

								strsql += aslist[i].TEXT;
							}

						}
						ls_st1.Add(strsql);
					}
				}


				//第二階段排除
				//排除JSON_TABLE
				ls_st1 = ls_st1.Where(x => !x.Contains("JSON")).ToList();

				//step2 擷取字段
				foreach (string str in ls_st1)
				{
					//排除 (
					//FROM ( SELECT OS681_VENDOR_NO,
					var input = str.ToUpper();
					// 正则表达式匹配 "FROM" 后面紧跟 "(" 和 "SELECT"，中间可以有任意数量的空格
					Regex regex = new Regex(@"FROM\s*\(\s*SELECT");
					if (!regex.IsMatch(input))
					{
						int fromIndex = str.IndexOf("FROM");
						int endIndex = 0;
						string result = "";
						if (str.IndexOf("WHERE") > 0)
						{
							endIndex = str.IndexOf("WHERE");
						}
						else if (str.IndexOf("JOIN") > 0)
						{
							endIndex = str.IndexOf("JOIN");
						}
						else if (str.IndexOf(";") > 0)
						{
							endIndex = str.IndexOf(";");
						}
						else if (str.IndexOf(")") > 0)
						{
							endIndex = str.IndexOf(")");
						}

						//from end index錯誤
						if (fromIndex >= endIndex)
						{
							ResultMessage(TabEnum.SqlAnalyze, "錯誤資料:" + input);

						}
						else
						{
							result = str.Substring(fromIndex + "FROM".Length, endIndex - (fromIndex + "FROM".Length)).Trim();

							//移除單引號
							ls_st2.Add(result.Replace("'", ""));
						}


					}

				}

				//檢核table是否存在
				string sqlIn = "";

				//step3 檢驗table
				foreach (string str in ls_st2)
				{
					// 去除所有的注释部分，即 "--" 后面的内容
					string withoutComments = Regex.Replace(str, @"--.*", "");

					string[] result = withoutComments.Split(',');


					foreach (var item in result)
					{
						//解決下方case
						//MI141 A)
						var data = item.Split(' ')[0];

						sqlIn += "'" + data + "',";
					}

				}

				sqlIn = sqlIn.Substring(0, sqlIn.Length - 1);

				// 移除所有的換行符號 (\r 和 \n)
				sqlIn = sqlIn.Replace("\r", "").Replace("\n", "");

				//檢核table是否存在
				List<string> dataResult = checkTable(checkTableSql, sqlIn.ToUpper());

				var printResult = "";
				//輸出結果
				foreach (var item in dataResult)
				{
					printResult += item + ',';
				}
				ResultMessage(TabEnum.SqlAnalyze, printResult == "" ? "" : printResult.Substring(0, printResult.Length - 1));

				//ResultMessage(TabEnum.SqlAnalyze, "===============分析Query資料結束================");

				return dataResult;



			}
			catch (Exception ex)
			{

				ResultErrorMessage(TabEnum.SqlAnalyze, ex.Message);
				return null;
			}
		}


		public List<string> checkTable(string sql, string sqlIn)
		{
			List<string> listCheck = new List<string>();

			switch (this.cbx_tab7_fromarea.Text)
			{
				case "DG":
					listCheck = sahelper.verifyTable(DgDbcontext.Query(String.Format(sql, "OADBA", sqlIn)));
					break;
				case "VN":
					listCheck = sahelper.verifyTable(VnDbcontext.Query(String.Format(sql, "OADBA", sqlIn)));
					break;
				case "VG":
					listCheck = sahelper.verifyTable(VgDbcontext.Query(String.Format(sql, "OADBA", sqlIn)));
					break;
				case "TC":
					listCheck = sahelper.verifyTable(TcDbcontext.Query(String.Format(sql, "DLPDBA", sqlIn)));
					break;
				default:
					listCheck = sahelper.verifyTable(DgDbcontext.Query(String.Format(sql, "OADBA", sqlIn)));
					break;
			}

			return listCheck;
		}

		#endregion

		//ResultErrorMessage
		public void ResultMessage(TabEnum tab, string msg)
		{
			switch (tab)
			{
				case TabEnum.Setting:
					break;
				case TabEnum.SunDiRo:
					break;
				case TabEnum.DoGoRo:
					tbx_tab2_resultMsg.Text += Environment.NewLine;
					tbx_tab2_resultMsg.Text += msg;
					break;
				case TabEnum.ColDef:
					break;
				case TabEnum.APIGo:
					break;
				case TabEnum.PokemonGo:
					break;
				case TabEnum.SqlAnalyze:
					tbx_tab7_resultMsg.Text += Environment.NewLine;
					tbx_tab7_resultMsg.Text += msg;

					tbx_tab7_resultMsg.SelectionStart = tbx_tab7_resultMsg.Text.Length;  // 將光標位置設置到最後
					tbx_tab7_resultMsg.ScrollToCaret();  // 滾動到光標位置

					break;
				default:
					break;
			}

		}

		//訊息結果
		public void ResultErrorMessage(TabEnum tab, string msg)
		{
			ResultMessage(tab, "=============Error Meg Start=============");
			ResultMessage(tab, msg);
			ResultMessage(tab, "=============Error Meg End=============");
		}


	}






}