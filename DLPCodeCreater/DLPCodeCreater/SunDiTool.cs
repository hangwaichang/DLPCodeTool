using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using Classes;
using Oracle.ManagedDataAccess.Client;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace DLPCodeCreater
{
    public partial class Form1 : Form
    {
        FileHelper fhelper = new FileHelper();
        TranslateHelp thelper = new TranslateHelp();

        DGDbContext DgDbcontext;
        VSDbContext VsDbcontext;
        VNDbContext VnDbcontext;
        VGDbContext VgDbcontext;
        TCDbContext TcDbcontext;


        public const string AppPortalpath = @"\DLP.Web\DLP.Web.AppPortal\ClientApp\src\app\views\";
        public const string Controllerspath = @"\DLP.WebAPI\DLP.WebAPI.{0}\Controllers\{1}";
        public const string Servicespath = @"\DLP.Model\DLP.Model.{0}Types\Services\{1}";
        public const string StoreProcedurepath = @"\DLP.Model\DLP.Model.{0}\StoreProcedure\{1}\SPName.cs";
        public const string DTOpath = @"\DLP.Model\DLP.Model.{0}Types\DTO\{1}";
        public const string Interfacepath = @"\DLP.Model\DLP.Model.{0}Types\Interface\{1}";
        public const string Repositoriespath = @"\DLP.Model\DLP.Model.{0}\Repositories\{1}";

        public string fModulepath = "";
        public string fAreapath = "";
        public string fProgrampath = "";
        public string fProgram = "";

        public string tModulepath = "";
        public string tAreapath = "";
        public string tProgrampath = "";
        public string tProgram = "";

        public int rowIndex = 0;

        public Boolean isdiffprogaram = false;

        List<string> repository = new List<string>();


        #region Tab3 變數宣告

        List<SearchResult> mainFilteredList = new List<SearchResult>();

        List<SearchResult> LOVFilteredList = new List<SearchResult>();

        List<innerObj> list_innerObj = new List<innerObj>();

        List<innerObj> list_LovObj = new List<innerObj>();

        public int count = 0;

        private string filePath = "";

        private int tempColumnIndex = 0;

        private int tempRowIndex = 0;

        public class innerObj
        {

            public int innerIndex { get; set; }    //內部索引
            public int index { get; set; }    //分類索引
            public string dbColumn { get; set; }    //* 資料欄名稱
            public string itemEngName { get; set; } //* 名稱
            public string itemChtName { get; set; } //* 標籤 or * 提示(first)
            public string itemType { get; set; }    //* 項目類型

            public string HeaderType { get; set; }    //類型Gird/Form

            public int? SubSeq { get; set; }    //順序索引

            public bool Checked { get; set; }    //選取

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

        private ContextMenuStrip contextMenu;//宣告一個右鍵選單的物件

        #endregion Tab3 變數宣告

        public Form1()
        {
            InitializeComponent();

            #region Tab3
            InitialListView();
            InitialContextMenu();
            #endregion Tab3

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_dto.Enabled = false;
            btn_repositories.Enabled = false;
            btn_interface.Enabled = false;
            //版本號
            string version = System.Windows.Forms.Application.ProductVersion;
            this.Text = String.Format("SunDiTool {0}", version);
        }

        #region Tab1

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
            fAreapath = fModulepath + @"\" + this.cbx_fromarea.Text;
            //取得程式列表
            List<string> ds = fhelper.DirSearch(fAreapath);
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
            tAreapath = tModulepath + @"\" + this.cbx_targetarea.Text;
            //取得程式列表
            List<string> ds = fhelper.DirSearch(tAreapath);
            //放入from_program
            BindingSource bs = new BindingSource();
            this.cbx_targetprogram.DataSource = ds;
        }

        //搬移檔案
        private void btn_Move_Click(object sender, EventArgs e)
        {
            ResultMessage("===============1.前端檔案搬移開始================");
            fProgrampath = fAreapath + @"\" + this.cbx_fromprogram.Text;
            tProgrampath = tAreapath + @"\" + this.cbx_targetprogram.Text;
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
            string componentpath = "./" + area + "/" + program + "/" + program + ".component";

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

        #region Tab2
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
            ResultMessageTab2("------------------開始取得程式內部資料!------------------");
            //clear dgv_tab2_languagetranslate
            dgv_tab2_languagetranslate.DataSource = null;
            dgv_tab2_languagetranslate.Rows.Clear();
            ResultMessageTab2("畫面清除");

            string fileName = "";
            thelper.languageTranslates_merge = new List<LanguageTranslate>();

            DirectoryInfo Dir;
            FileInfo[] files;


            //ts,css,html
            ResultMessageTab2("1.掃描ts,css,html");
            fProgrampath = fAreapath + @"\" + this.cbx_tab2_fromprogram.Text;
            Dir = new DirectoryInfo(fProgrampath);
            files = Dir.GetFiles();
            thelper.mergeTranslate(thelper.getTranslate(files));

            //services
            ResultMessageTab2("2.掃描services");
            fileName = this.cbx_tab2_fromprogram.Text + ".service.ts";
            thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
            //pop-up.service.ts
            ResultMessageTab2("3.掃描pop-up.service.ts");
            fileName = this.cbx_tab2_fromprogram.Text + "-pop-up.service.ts";
            if (File.Exists(fAreapath + @"\services\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
            }
            //states
            ResultMessageTab2("4.掃描states");
            fileName = this.cbx_tab2_fromprogram.Text + ".state.ts";
            thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\states\" + fileName));
            //controls
            ResultMessageTab2("5.掃描controls");
            fileName = this.cbx_tab2_fromprogram.Text + ".control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
            }
            //form.control
            ResultMessageTab2("6.掃描form.control");
            fileName = this.cbx_tab2_fromprogram.Text + "-form.control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
            }
            //validations
            ResultMessageTab2("7.掃描validations");
            fileName = this.cbx_fromprogram.Text + ".validation.ts";
            if (File.Exists(fAreapath + @"\validations\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\validations\" + fileName));
            }

            //塞入資料
            ResultMessageTab2("8.資料翻譯開始");
            foreach (var lt in thelper.languageTranslates_merge)
            {
                this.dgv_tab2_languagetranslate.Rows.Add(lt.TW, lt.ZH, lt.EN, lt.VI);
            }
            ResultMessageTab2("------------------取得程式內部資料完成------------------");
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

                ResultMessageTab2("DB-寫入結束!");
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
                    DgDbcontext.Inesrt(sql, ml, program);
                }
                if (cbx_vgdb.Checked)
                {
                    VgDbcontext.Inesrt(sql, ml, program);
                }
                if (cbx_vndb.Checked)
                {
                    VnDbcontext.Inesrt(sql, ml, program);
                }
                if (cbx_vsdb.Checked)
                {
                    VsDbcontext.Inesrt(sql, ml, program);
                }
                if (cbx_tcdb.Checked)
                {
                    TcDbcontext.Inesrt(sql, ml, program);
                }
            }
            catch (Exception ex)
            {

                ResultErrorMessageTab2(ex.Message);
            }


        }

        //DB Select
        private void cbx_dgdb_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_dgdb.Checked)
                {
                    if (DgDbcontext == null)
                    {
                        DgDbcontext = GenericDbFactory<DGDbContext>.Create();
                        DgDbcontext.Connect();
                        ResultMessageTab2("DGDB-連線成功!");
                    }
                }
            }
            catch (Exception ex)
            {

                ResultErrorMessageTab2(ex.Message);
            }

        }

        private void cbx_vsdb_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_vsdb.Checked)
                {
                    if (VsDbcontext == null)
                    {
                        VsDbcontext = GenericDbFactory<VSDbContext>.Create();
                        VsDbcontext.Connect();
                        ResultMessageTab2("VSDB-連線成功!");
                    }
                }
            }
            catch (Exception ex)
            {

                ResultErrorMessageTab2(ex.Message);
            }
        }

        private void cbx_vndb_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_vndb.Checked)
                {
                    if (VnDbcontext == null)
                    {
                        VnDbcontext = GenericDbFactory<VNDbContext>.Create();
                        VnDbcontext.Connect();
                        ResultMessageTab2("VNDB-連線成功!");
                    }
                }
            }
            catch (Exception ex)
            {

                ResultErrorMessageTab2(ex.Message);
            }
        }

        private void cbx_vgdb_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_vgdb.Checked)
                {
                    if (VgDbcontext == null)
                    {
                        VgDbcontext = GenericDbFactory<VGDbContext>.Create();
                        VgDbcontext.Connect();
                        ResultMessageTab2("VGDB-連線成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                ResultErrorMessageTab2(ex.Message);
            }
        }

        private void cbx_tcdb_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_tcdb.Checked)
                {
                    if (TcDbcontext == null)
                    {
                        TcDbcontext = GenericDbFactory<TCDbContext>.Create();
                        TcDbcontext.Connect();
                        ResultMessageTab2("TCDB-連線成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                ResultErrorMessageTab2(ex.Message);
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

        //訊息結果
        public void ResultErrorMessageTab2(string msg)
        {
            ResultMessageTab2("=============Error Meg Start=============");
            ResultMessageTab2(msg);
            ResultMessageTab2("=============Error Meg End=============");
        }

        public void ResultMessageTab2(string msg)
        {
            tbx_tab2_resultMsg.Text += Environment.NewLine;
            tbx_tab2_resultMsg.Text += msg;
        }

        #endregion

        #region Tab3 
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
                openFileDialog.Filter = "文本檔案 (*.txt)|*.txt";
                openFileDialog.Title = "選擇要打開的檔案";

                // 使用者選擇了檔案
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    list_innerObj.Clear();
                    list_LovObj.Clear();

                    string selectedFilePath = openFileDialog.FileName;
                    this.txtSelectPath.Text = selectedFilePath;

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


                    // 要搜尋的多個字串
                    string[] searchStrings = new string[]
                    {
                    " * 區塊                                              ",
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
                    bool flag = false;
                    //textBoxResults.Clear();
                    string _temp_dbColumn = string.Empty, _temp_itemEngName = string.Empty, _temp_itemChtName = string.Empty, _temp_itemType = string.Empty;

                    string _LOV_dbColumn = string.Empty, _LOV_itemEngName = string.Empty, _LOV_itemChtName = string.Empty, _LOV_key = string.Empty;



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
                                    itemType = _temp_itemType
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


                        //分類索引切換之際
                        if (obj.Value.index != temp_index)
                        {
                            for (int i = 0; i < 5; i++)
                                list_innerObj.Add(new innerObj()
                                {
                                    HeaderType = "",
                                    SubSeq = null,
                                    index = obj.Value.index,
                                    dbColumn = null,
                                    itemEngName = null,
                                    itemChtName = null,
                                    itemType = "Form隱藏格式"
                                });

                            temp_index = obj.Value.index;
                            flag = true;
                        }



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
                                itemType = _temp_itemType
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


                    List<IGrouping<int, innerObj>> headerlist = list_innerObj.GroupBy(x => x.index).ToList();//取header使用

                    headerlist.ForEach(group =>
                    {
                        //textBoxResults.AppendText($"Score:{group.Key}, Count:{group.Count()}{Environment.NewLine}");
                        this.dGdVwHeaders.Rows.Add(group.Key, "Grid/Form");
                        //group.ToList().ForEach(item => textBoxResults.AppendText($"\tindex:{item.index}"));//, Score:{item.Score}  分組後內容取得
                    });


                    var datarow = this.dGdVwHeaders.Rows[0];
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
            var templist = this.list_innerObj.Where(x => x.index == Convert.ToInt32(datarow.Cells[0].Value)
                ).ToList();

            lstVwSubItems.Columns.Add("選取順序", 40, HorizontalAlignment.Left);
            lstVwSubItems.Columns.Add("順序", 40, HorizontalAlignment.Left);

            lstVwSubItems.Columns.Add("itemChtName", 120, HorizontalAlignment.Left);
            lstVwSubItems.Columns.Add("dbColumn", 120, HorizontalAlignment.Left);
            lstVwSubItems.Columns.Add("itemEngName", 120, HorizontalAlignment.Left);
            lstVwSubItems.Columns.Add("itemType", 120, HorizontalAlignment.Center);
            lstVwSubItems.Columns.Add("index", 10, HorizontalAlignment.Left);


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

            string _template_Lovl = "              {{\r\n                headerName: '{0}',\r\n                headerValueGetter: this._agService.headerValueGetter,\r\n                field: '{1}',\r\n                type: 'text',\r\n              }},\r\n";
            string _template_Lovl_DlpGrid = "          {{\r\n            headerName: '{0}',\r\n            field: '{1}',\r\n            type: EDlpGridColumnType.text,\r\n          }},\r\n";
            string _template_Lov2 = "\r\n              {0}: '{1}',";
            string del_strng = "", map_string = "";

            foreach (var item in itemObj)
            {
                del_strng += String.Format(_template_Lovl, item.itemChtName, item.itemEngName);

                if (item.dbColumn != string.Empty)
                {
                    string[] splitStr = item.dbColumn.Split('.');
                    map_string += String.Format(_template_Lov2, splitStr[1], item.itemEngName);
                }
            }

            return index is 0 ? del_strng : map_string;
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

            var datarow = dGdVwHeaders.SelectedRows[0];
            this.Fun_Reload_SubDataGridView(datarow);

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
            textBoxResults.Clear();
            List<string> allResultStr = new List<string>();
            foreach (DataGridViewRow row in this.dGdVwHeaders.Rows)
            {
                // 檢查行的類型，以排除 Header 和其他非資料行
                if (row.IsNewRow) continue;

                // 逐列取得每個儲存格的內容值
                int _dataindex = Convert.ToInt16(row.Cells[0].Value);
                string _dataType = row.Cells[1].Value?.ToString();

                // 使用取得的值進行後續處理
                //textBoxResults.AppendText($"Row: " + _dataindex + " | " + _dataType + ","+ Environment.NewLine);

                //-----------------------------------------------------------------------------

                // 使用 Where 方法篩選同類的資料
                // 使用 OrderBy 方法依據指定的元素欄位進行重新排序
                List<innerObj> current_list = this.list_innerObj.Where(x => x.index == _dataindex).OrderBy(obj => obj.SubSeq).ToList().FindAll(e => e.SubSeq != null);

                /*標題部分  無變數不需修改*/
                string _templateModel_grid_header_start = "<<<< Grid >>>>\r\n//------------------------------------------------\r\n\r\n    return [\r\n      {\r\n        headerName: '項目',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: 'ITEM',\r\n      },\r\n";
                string _templateModel_grid_header_end = "    ];\r\n\r\n//------------------------------------------------\r\n\r\n\r\n\r\n";
                string _templateModel_form_header_start = "<<<< Form >>>>\r\n//------------------------------------------------\r\n\r\n    const controls: FormBase<any>[] = [\r\n";
                string _templateModel_form_header_end = "    ];\r\n\r\n//------------------------------------------------\r\n\r\n\r\n\r\n";

                /*GRID部分*/
                string _templateModel_grid_normal = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'text',\r\n        editable: false,\r\n        width: 100,\r\n        suppressSizeToFit: true,\r\n      }},\r\n";
                string _templateModel_grid_confirm = "      {{\r\n        headerName: '{0}', //勾選\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        editable: false,\r\n        filter: false,\r\n        sortable: false,\r\n        cellRenderer: 'confirmRenderer',\r\n        width: 50,\r\n        suppressSizeToFit: true,\r\n        cellRendererParams: (params) => {{\r\n          // if (params.data?.ITEM === 0) return {{ disabled: true }};\r\n\r\n          return {{\r\n            checkValueType: EAgGridCheckValueType.booleanType,\r\n            // afterCheckedFunc: (value: boolean) => {{\r\n            //   if (value) {{\r\n            //     //判斷通過，勾選\r\n            //     params.data.{1} = true;\r\n            //   }} else {{\r\n            //     //取消勾選\r\n            //     params.data.{1} = false;\r\n            //   }}\r\n            //   params.node.setData(params.data);\r\n            // }},\r\n          }};\r\n        }},\r\n      }},\r\n";

                /*FORM部分*/
                string _templateModel_form_normal = "      new FormTextBox({{\r\n        key: '{1}',\r\n        label: '{0}',\r\n        // labelWidth: 5,\r\n        flex: '20',\r\n        order: 1,\r\n        class: 'pr-1',\r\n        // readonly: true,\r\n      }}),\r\n";  // textAlign: 'right',\r\n
                string _templateModel_form_btn = "      new FormButtonAuthority({{\r\n        showButtons: [\r\n          <IButtons>{{\r\n            key: 'confirm',\r\n            color: 'primary',\r\n            text: '{0}',\r\n            icon: 'done_all',\r\n            visible: true,\r\n            //visibledAsync: this.State.FormRefs.visibleAsync$,\r\n            clickFunction: () => {{\r\n              //this.Service.pushSave();\r\n            }},\r\n          }},\r\n        ],\r\n        flex: '20',\r\n        order: 1,\r\n        class: 'pr-1',\r\n      }}),\r\n";
                string _templateModel_form_hidden = "      new FormHidden({\r\n        key: '',\r\n        label: '',\r\n        order: 1,\r\n        flex: '20',\r\n      }),\r\n";
                string _templateModel_form_hidden2 = "      new FormHidden({}),\r\n";


                /*LOV部分*/
                string _templateModel_grid_Lovl = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        suppressSizeToFit: true,\r\n        editable: true, //(params) => {{ return params.data.ITEM === 0; // 可新增不可修改 }},\r\n        sortable: true,\r\n        width: 120,\r\n        type: 'text',\r\n        cellEditor: 'lovEditor',\r\n        cellEditorParams: (params) => {{\r\n          return <ILovEditorParams>{{\r\n            apiParams: {{\r\n              // sp前綴\r\n              moduleNo: '模組名稱',\r\n              programNo: '{2}',\r\n              commonApiType: ECommonApiType.CallStoreProcedureDataSet,\r\n            }},\r\n            queryAction: 'sp名稱', // sp名稱\r\n            //payload: {{}}, // input\r\n            refCursorKeys: ['v表名稱Info', 'v表名稱Count'], // output\r\n            colDefs: [\r\n{3}            ],\r\n            keyMapping: {{              {4}\r\n            }},\r\n            checkInput: true,\r\n            onPostChange: (params) => {{\r\n              if (params.isValidInput) //this._Service.ServiceFun(params.value);\r\n            }},\r\n          }};\r\n        }},\r\n      }},\r\n";
                string _templateModel_form_Lovl = "      new FormLov({{\r\n        key: '{0}',\r\n        label: '{1}',\r\n        //labelWidth: '10',\r\n        apiParams: {{\r\n          moduleNo: '模組名稱',\r\n          programNo: '{2}',\r\n          commonApiType: ECommonApiType.CallStoreProcedureDataSet,\r\n        }},\r\n        queryAction: 'SP名稱', // sp名稱\r\n        refCursorKeys: ['v表名稱Info', 'v表名稱Count'],\r\n        colDefs: [\r\n{3}        ],\r\n        keyMapping: {{{4}\r\n        }},\r\n        checkInput: true,\r\n        flex: '25',\r\n        class: 'pr-1',\r\n      }}),\r\n";

                /*其他*/
                string _templateModel_grid_select = "      {{\r\n        headerName: '{0}',\r\n        headerValueGetter: this._agService.headerValueGetter,\r\n        field: '{1}',\r\n        type: 'text',\r\n        editable: true, //(params) => {{return params.data?.ITEM === 0;}},// 可新增不可修改\r\n        sortable: true,\r\n        width: 100,\r\n        suppressSizeToFit: true,\r\n        valueFormatter: (params) => {{\r\n          const displayValue = params.node?.data?.{1} ?? '';\r\n          return {{ \r\n            // '1': 'Cosmos/KM3代工', '3': '組底加工' \r\n          }}[displayValue] ?? '';\r\n        }},\r\n        // valueSetter: (params) => {{\r\n        //   const optKey = params.newValue?.[0];\r\n        //   params.data.{1} = optKey;\r\n        //   return true;\r\n        // }},\r\n        cellEditor: 'selectRenderer',\r\n        cellEditorParams: {{\r\n          control: {{\r\n            multiple: false,\r\n            field: ['{1}'],\r\n            options: of([\r\n              // {{ key: '1', value: 'Cosmos/KM3代工' }},\r\n              // {{ key: '3', value: '組底加工' }},\r\n            ]),\r\n          }},\r\n        }},\r\n        floatingFilterComponent: 'selectFilterRenderer',\r\n        floatingFilterComponentParams: {{\r\n          options: of([\r\n            // {{ key: '1', value: 'Cosmos/KM3代工' }},\r\n            // {{ key: '3', value: '組底加工' }},\r\n          ]),\r\n        }},\r\n      }},\r\n";
                string resultStr = string.Empty;
                List<string> list_resultStr = new List<string>();



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

                    //textBoxResults.AppendText(String.Format(_templateModel2, obj.itemChtName, obj.dbColumn));
                    if (_dataType == "Grid")
                    {
                        if (obj.itemType == "文字項目" || obj.itemType == "顯示項目"
                            || obj.itemType == "Text Item" || obj.itemType == "Dispaly Item")
                            if (obj.itemChtName == null || obj.itemChtName == string.Empty)
                            {
                                string _templateModel_grid_noChtName = _templateModel_grid_normal.Replace("headerValueGetter: this._agService.headerValueGetter,", "//headerValueGetter: this._agService.headerValueGetter,");
                                list_resultStr.Add(String.Format(_templateModel_grid_noChtName, obj.itemChtName, obj.dbColumn));
                            }
                            else
                                list_resultStr.Add(String.Format(_templateModel_grid_normal, obj.itemChtName, obj.dbColumn));
                        else if (obj.itemType == "核取方塊" || obj.itemType == "Check Box")
                            list_resultStr.Add(String.Format(_templateModel_grid_confirm, obj.itemChtName, obj.dbColumn));
                        else if (obj.itemType.Contains("LOV_"))
                            list_resultStr.Add(String.Format(_templateModel_grid_Lovl, obj.itemChtName, obj.dbColumn, Path.GetFileNameWithoutExtension(filePath), Fun_Lov_Detail_String(obj.itemType, 0), Fun_Lov_Detail_String(obj.itemType, 1)));
                        else if (obj.itemType == "清單項目" || obj.itemType == "List Item")
                            list_resultStr.Add(String.Format(_templateModel_grid_select, obj.itemChtName, obj.dbColumn));
                        else
                            list_resultStr.Add(String.Format(_templateModel_grid_normal, obj.itemChtName, obj.dbColumn));
                    }
                    else if (_dataType == "Form")
                    {
                        if (obj.itemType == "文字項目" || obj.itemType == "顯示項目"
                            || obj.itemType == "Text Item" || obj.itemType == "Dispaly Item")
                            list_resultStr.Add(String.Format(_templateModel_form_normal, obj.itemChtName, obj.dbColumn));
                        else if (obj.itemType == "按鈕" || obj.itemType == "Push Button")
                            list_resultStr.Add(String.Format(_templateModel_form_btn, obj.itemChtName));
                        else if (obj.itemType.Contains("LOV_"))
                            list_resultStr.Add(String.Format(_templateModel_form_Lovl, obj.itemChtName, obj.dbColumn, Path.GetFileNameWithoutExtension(filePath), Fun_Lov_Detail_String(obj.itemType, 0), Fun_Lov_Detail_String(obj.itemType, 1)));
                        else if (obj.itemType == "Form隱藏格式")
                            list_resultStr.Add(_templateModel_form_hidden);
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


        #endregion  --------------------- Tab3 --------------------------

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


    }


}