namespace DLPCodeCreater
{
    public partial class Form1 : Form
    {
        FileHelper fhelper = new FileHelper();
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

        public string tModulepath = "";
        public string tAreapath = "";
        public string tProgrampath = "";


        List<string> repository = new List<string>();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_dto.Enabled = false;
            btn_repositories.Enabled = false;
            btn_interface.Enabled = false;
        }

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
            //ts,css,html
            GetFileandMove(fProgrampath, tProgrampath);
            //services
            fileName = this.cbx_fromprogram.Text + ".service.ts";
            FileMove(fAreapath + @"\services", tAreapath + @"\services", fileName);
            //pop-up.service.ts
            fileName = this.cbx_fromprogram.Text + "-pop-up.service.ts";
            if (File.Exists(fAreapath + @"\services\" + fileName))
            {
                FileMove(fAreapath + @"\services", tAreapath + @"\services", fileName);
            }
            //states
            fileName = this.cbx_fromprogram.Text + ".state.ts";
            FileMove(fAreapath + @"\states", tAreapath + @"\states", fileName);
            //api
            fileName = this.cbx_fromprogram.Text + ".api.ts";
            FileMove(fAreapath + @"\api", tAreapath + @"\api", fileName);
            //controls
            fileName = this.cbx_fromprogram.Text + ".control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                FileMove(fAreapath + @"\controls", tAreapath + @"\controls", fileName);
            }
            //form.control
            fileName = this.cbx_fromprogram.Text + "-form.control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                FileMove(fAreapath + @"\controls", tAreapath + @"\controls", fileName);
            }
            //validations
            fileName = this.cbx_fromprogram.Text + ".validation.ts";
            if (File.Exists(fAreapath + @"\validations\" + fileName))
            {
                FileMove(fAreapath + @"\validations", tAreapath + @"\validations", fileName);
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

        public void FileMove(string frompath, string targetpath, string filename)
        {
            fhelper.CheckDir(targetpath);

            string fpath = frompath + @"\" + filename;
            string tpath = targetpath + @"\" + filename;
            if (fhelper.FileMove(fpath, tpath))
            {
                ResultMessage("檔案搬移成功" + tpath);
            }

        }

        public void FileMoveAndReplace(string frompath, string targetpath, string filename, List<string> replace_first, List<string> replace_second = null)
        {
            fhelper.CheckDir(targetpath);

            string fpath = frompath + @"\" + filename;
            string tpath = targetpath + @"\" + filename;
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

            string fromPath = "/" + cbx_fromarea.Text + "/" + cbx_fromprogram.Text;
            string tragetPath = "/" + cbx_targetarea.Text + "/" + cbx_targetprogram.Text;
            List<string> repalceServiceText = serviceText.Select(s => s.Replace(fromPath.ToUpper(), tragetPath.ToUpper())).ToList();

            fhelper.FileWrite(repalceServiceText, false, "web-api.service");
            var modelText = fhelper.FileRead(fAreapath + @"\models\web-api.model.ts", program, "}");
            fhelper.FileWrite(modelText, true, "web-api.model");

            //開啟copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");

            //開啟目標web-api.service web-api.model
            System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\services\web-api.service.ts");
            System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\models\web-api.model.ts");
            ResultMessage("開啟檔案:" + tAreapath + @"\services\web-api.service.ts");
            ResultMessage("開啟檔案:" + tAreapath + @"\models\web-api.model.ts");

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
            FileMoveAndReplace(FromControllersFile, TargetControllersFile, cbx_fromprogram.Text.ToUpper() + "Controller.cs", replace, route_replace);
            //Service
            FileMoveAndReplace(FromServicesFile, TargetServicesFile, cbx_fromprogram.Text.ToUpper() + "Service.cs", replace);
            ResultMessage("===============後端檔案搬移&地區修改結束================");
        }

        private void btn_spname_Click(object sender, EventArgs e)
        {
            ResultMessage("===============5.前端SPName讀取開始================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            string FromStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_frommodule.Text, cbx_fromarea.Text);
            string TargetStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_targetmodule.Text, cbx_targetarea.Text);
            var serviceText = fhelper.FileRead(FromStoreProcedureFile, program, "#endregion");

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
                string filename = repo.Substring(1, 5) + "DTO.cs";
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
                    FileMoveAndReplace(FromDTOFile, TargetDTOFile, filename, replace);
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
                    fhelper.FileWrite(dtoText, true, filename);
                }
                else
                {
                    //不存在直接copy
                    FileMoveAndReplace(FromInterfaceFile, TargetInterfaceFile, filename, replace, replace_udt);
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
                    fhelper.FileWrite(dtoText, true, filename);
                }
                else
                {
                    //不存在直接copy
                    FileMoveAndReplace(FromRepositoriesFile, TargetRepositoriesFile, filename, replace, replace_udt);
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
                if (string.Compare(cbx_fromprogram.Text, cbx_targetprogram.Text) == 0)
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
        }

        //Test Button
        private void button1_Click(object sender, EventArgs e)
        {
            tbx_projectpath.Text = @"D:\Git\dlp-develop";
            cbx_frommodule.Text = "mg";
            cbx_fromarea.Text = "vs";
            cbx_fromprogram.Text = "mgi100";
            cbx_targetmodule.Text = "mg";
            cbx_targetarea.Text = "vn";
            cbx_targetprogram.Text = "mgi100";
        }

        //滾輪至底
        private void tbx_resultMsg_TextChanged(object sender, EventArgs e)
        {
            this.tbx_resultMsg.SelectionStart = this.tbx_resultMsg.Text.Length;
            this.tbx_resultMsg.SelectionLength = 0;
            this.tbx_resultMsg.ScrollToCaret();
        }
    }
}