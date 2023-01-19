using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using Classes;
using Oracle.ManagedDataAccess.Client;

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

        public string tModulepath = "";
        public string tAreapath = "";
        public string tProgrampath = "";

        public int rowIndex = 0;


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
            //������
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
                //���o�ҲզC��
                List<string> ds = fhelper.DirSearch(this.tbx_projectpath.Text + AppPortalpath);

                BindingSource bs = new BindingSource();
                //��Jfrom_module
                this.cbx_frommodule.DataSource = ds;
                //��Jtarget_module
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
            //���o�a�ϦC��
            List<string> ds = fhelper.DirSearch(fModulepath);
            //��Jfrom_area
            BindingSource bs = new BindingSource();
            this.cbx_fromarea.DataSource = ds;
        }

        private void cbx_fromarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            fAreapath = fModulepath + @"\" + this.cbx_fromarea.Text;
            //���o�{���C��
            List<string> ds = fhelper.DirSearch(fAreapath);
            //��Jfrom_program
            BindingSource bs = new BindingSource();
            this.cbx_fromprogram.DataSource = ds;
        }


        //Target
        private void cbx_targetmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            tModulepath = this.tbx_projectpath.Text + AppPortalpath + this.cbx_targetmodule.Text;
            //���o�a�ϦC��
            List<string> ds = fhelper.DirSearch(tModulepath);
            //��Jfrom_area
            BindingSource bs = new BindingSource();
            this.cbx_targetarea.DataSource = ds;
        }

        private void cbx_targetarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            tAreapath = tModulepath + @"\" + this.cbx_targetarea.Text;
            //���o�{���C��
            List<string> ds = fhelper.DirSearch(tAreapath);
            //��Jfrom_program
            BindingSource bs = new BindingSource();
            this.cbx_targetprogram.DataSource = ds;
        }

        //�h���ɮ�
        private void btn_Move_Click(object sender, EventArgs e)
        {
            ResultMessage("===============1.�e���ɮ׷h���}�l================");
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
            ResultMessage("===============�e���ɮ׷h������================");
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
                    ResultMessage("�ɮ׷h�����\" + tpath);
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
                ResultMessage("�ɮ׷h�����\" + tpath);
            }

        }

        public void FileMoveAndReplace(string frompath, string targetpath, string filename, List<string> replace_first, List<string> replace_second = null)
        {
            fhelper.CheckDir(targetpath);

            string fpath = frompath + @"\" + filename;
            string tpath = targetpath + @"\" + filename;
            if (fhelper.FileMove(fpath, tpath))
            {
                ResultMessage("�ɮ׷h�����\" + tpath);
                if (fhelper.FileReplace(tpath, replace_first[0], replace_first[1]))
                {
                    if (replace_second != null)
                    {
                        if (fhelper.FileReplace(tpath, replace_second[0], replace_second[1]))
                        {
                            ResultMessage("�a�ϦW�٨��N���\!");
                        }
                    }
                    else
                    {
                        ResultMessage("�a�ϦW�٨��N���\!");
                    }

                }
            }

        }

        //�T�����G
        public void ResultMessage(string msg)
        {
            tbx_resultMsg.Text += Environment.NewLine;
            tbx_resultMsg.Text += msg;
        }

        private void btn_webapicopy_Click(object sender, EventArgs e)
        {
            ResultMessage("===============2.�e��web-apiŪ���}�l================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            var serviceText = fhelper.FileRead(fAreapath + @"\services\web-api.service.ts", program, "}");

            string fromPath = "/" + cbx_fromarea.Text + "/" + cbx_fromprogram.Text;
            string tragetPath = "/" + cbx_targetarea.Text + "/" + cbx_targetprogram.Text;
            List<string> repalceServiceText = serviceText.Select(s => s.Replace(fromPath.ToUpper(), tragetPath.ToUpper())).ToList();

            fhelper.FileWrite(repalceServiceText, false, "web-api.service");
            var modelText = fhelper.FileRead(fAreapath + @"\models\web-api.model.ts", program, "}");
            fhelper.FileWrite(modelText, true, "web-api.model");

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");

            //�}�ҥؼ�web-api.service web-api.model
            System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\services\web-api.service.ts");
            System.Diagnostics.Process.Start("explorer.exe", tAreapath + @"\models\web-api.model.ts");
            ResultMessage("�}���ɮ�:" + tAreapath + @"\services\web-api.service.ts");
            ResultMessage("�}���ɮ�:" + tAreapath + @"\models\web-api.model.ts");

            ResultMessage("===============�e��web-apiŪ������================");
        }

        private void btn_modulecopy_Click(object sender, EventArgs e)
        {
            ResultMessage("===============3.�e��routing.moduleŪ���}�l================");
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

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
            //�}�ҥؼ�.module routing.module
            System.Diagnostics.Process.Start("explorer.exe", tModulepath + @"\" + module + ".module.ts");
            System.Diagnostics.Process.Start("explorer.exe", tModulepath + @"\" + module + "-routing.module.ts");
            ResultMessage("�}���ɮ�:" + tModulepath + @"\" + module + ".module.ts");
            ResultMessage("�}���ɮ�:" + tModulepath + @"\" + module + "-routing.module.ts");

            ResultMessage("===============�e��routing.moduleŪ������================");
        }

        private void btn_backendmove_Click(object sender, EventArgs e)
        {
            ResultMessage("===============4.����ɮ׷h��&�a�ϭק�}�l================");
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
            ResultMessage("===============����ɮ׷h��&�a�ϭקﵲ��================");
        }

        private void btn_spname_Click(object sender, EventArgs e)
        {
            ResultMessage("===============5.�e��SPNameŪ���}�l================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            string FromStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_frommodule.Text, cbx_fromarea.Text);
            string TargetStoreProcedureFile = this.tbx_projectpath.Text + String.Format(StoreProcedurepath, cbx_targetmodule.Text, cbx_targetarea.Text);
            var serviceText = fhelper.FileRead(FromStoreProcedureFile, program, "#endregion");

            fhelper.FileWrite(serviceText, false, "SPName");

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
            //SPName.cs
            System.Diagnostics.Process.Start("explorer.exe", TargetStoreProcedureFile);
            ResultMessage("�}���ɮ�:" + TargetStoreProcedureFile);
            ResultMessage("===============�e��SPNameŪ������================");
        }

        private void btn_getrepository_Click(object sender, EventArgs e)
        {
            ResultMessage("===============6.��Repository���Ӷ}�l================");

            btn_dto.Enabled = true;
            repository.Clear();

            //�qTargetServices�� Repository����
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

            ResultMessage("===============��Repository���ӵ���================");
        }

        private void btn_dto_Click(object sender, EventArgs e)
        {
            ResultMessage("===============7.�B�zDTO�@�~�}�l================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            List<string> replace = new List<string>();
            List<string> openfiles = new List<string>();
            List<string> replace_udt = new List<string>();

            replace.Add('.' + cbx_fromarea.Text.ToUpper());
            replace.Add('.' + cbx_targetarea.Text.ToUpper());


            replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
            replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

            //�B�zDTO
            string FromDTOFile = this.tbx_projectpath.Text + String.Format(DTOpath, cbx_frommodule.Text, cbx_fromarea.Text);
            string TargetDTOFile = this.tbx_projectpath.Text + String.Format(DTOpath, cbx_targetmodule.Text, cbx_targetarea.Text);

            //�M��copy.text
            fhelper.FileWrite(new List<string>(), false, "Start");

            foreach (var repo in repository)
            {
                int repoIndex = repo.Length - 10;//Repository Length
                repoIndex -= 1; //�_�l 'I' �r������

                string filename = repo.Substring(1, repoIndex) + "DTO.cs";
                if (File.Exists(TargetDTOFile + @"\" + filename))
                {
                    openfiles.Add(TargetDTOFile + @"\" + filename);
                    //�w�s�b ������r
                    var dtoText = fhelper.FileRead(FromDTOFile + @"\" + filename, "#region " + program, "#endregion");

                    //UDT����W�٭ץ�
                    dtoText = dtoText.Select(s => s.Replace(replace_udt[0], replace_udt[1])).ToList();

                    fhelper.FileWrite(dtoText, true, filename);
                }
                else
                {
                    //���s�b����copy
                    FileMoveAndReplace(FromDTOFile, TargetDTOFile, filename, replace);
                }
            }

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
            //DTO.cs
            foreach (var of in openfiles)
            {
                System.Diagnostics.Process.Start("explorer.exe", of);
            }

            ResultMessage("�}���ɮ�:DTO.cs");
            ResultMessage("===============�B�zDTO�@�~����================");
        }

        private void btn_interface_Click(object sender, EventArgs e)
        {
            ResultMessage("===============8.�B�zINTERFACE�@�~�}�l================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            List<string> replace = new List<string>();
            List<string> replace_udt = new List<string>();
            List<string> openfiles = new List<string>();

            replace.Add('.' + cbx_fromarea.Text.ToUpper());
            replace.Add('.' + cbx_targetarea.Text.ToUpper());

            replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
            replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

            //�B�zInterface
            string FromInterfaceFile = this.tbx_projectpath.Text + String.Format(Interfacepath, cbx_frommodule.Text, cbx_fromarea.Text);
            string TargetInterfaceFile = this.tbx_projectpath.Text + String.Format(Interfacepath, cbx_targetmodule.Text, cbx_targetarea.Text);

            //�M��copy.text
            fhelper.FileWrite(new List<string>(), false, "Start");

            foreach (var repo in repository)
            {
                string filename = repo + ".cs";
                if (File.Exists(TargetInterfaceFile + @"\" + filename))
                {
                    openfiles.Add(TargetInterfaceFile + @"\" + filename);
                    //�w�s�b ������r
                    var dtoText = fhelper.FileRead(FromInterfaceFile + @"\" + filename, "#region " + program, "#endregion");
                    fhelper.FileWrite(dtoText, true, filename);
                }
                else
                {
                    //���s�b����copy
                    FileMoveAndReplace(FromInterfaceFile, TargetInterfaceFile, filename, replace, replace_udt);
                }
            }

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
            //Interface.cs
            foreach (var of in openfiles)
            {
                System.Diagnostics.Process.Start("explorer.exe", of);
            }

            ResultMessage("�}���ɮ�:Interface.cs");
            ResultMessage("===============�B�zINTERFACE�@�~����================");
        }

        private void btn_repositories_Click(object sender, EventArgs e)
        {
            ResultMessage("===============9.�B�zREPOSITORIES�@�~�}�l================");
            string program = this.cbx_fromprogram.Text.ToUpper();
            List<string> replace = new List<string>();
            List<string> replace_udt = new List<string>();
            List<string> openfiles = new List<string>();

            replace.Add('.' + cbx_fromarea.Text.ToUpper());
            replace.Add('.' + cbx_targetarea.Text.ToUpper());

            replace_udt.Add('_' + cbx_fromarea.Text.ToUpper());
            replace_udt.Add('_' + cbx_targetarea.Text.ToUpper());

            //�B�zInterface
            string FromRepositoriesFile = this.tbx_projectpath.Text + String.Format(Repositoriespath, cbx_frommodule.Text, cbx_fromarea.Text);
            string TargetRepositoriesFile = this.tbx_projectpath.Text + String.Format(Repositoriespath, cbx_targetmodule.Text, cbx_targetarea.Text);

            //�M��copy.text
            fhelper.FileWrite(new List<string>(), false, "Start");

            foreach (string repo in repository)
            {
                string filename = repo.Substring(1, repo.Length - 1) + ".cs";
                if (File.Exists(TargetRepositoriesFile + @"\" + filename))
                {
                    openfiles.Add(TargetRepositoriesFile + @"\" + filename);
                    //�w�s�b ������r
                    var dtoText = fhelper.FileRead(FromRepositoriesFile + @"\" + filename, "#region " + program, "#endregion");
                    fhelper.FileWrite(dtoText, true, filename);
                }
                else
                {
                    //���s�b����copy
                    FileMoveAndReplace(FromRepositoriesFile, TargetRepositoriesFile, filename, replace, replace_udt);
                }
            }

            //�}��copy.txt
            System.Diagnostics.Process.Start("explorer.exe", "copy.txt");
            //Repositories.cs
            foreach (var of in openfiles)
            {
                System.Diagnostics.Process.Start("explorer.exe", of);
            }

            ResultMessage("�}���ɮ�:Repositories.cs");
            ResultMessage("===============�B�zREPOSITORIES�@�~����================");
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
                //�h���{���W�ٻݬۦP
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

        //�u���ܩ�
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
            //���o�a�ϦC��
            List<string> ds = fhelper.DirSearch(fModulepath);
            //��Jfrom_area
            BindingSource bs = new BindingSource();
            this.cbx_tab2_fromarea.DataSource = ds;
        }

        private void cbx_tab2_fromarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            fAreapath = fModulepath + @"\" + this.cbx_tab2_fromarea.Text;
            //���o�{���C��
            List<string> ds = fhelper.DirSearch(fAreapath);
            //��Jfrom_program
            BindingSource bs = new BindingSource();
            this.cbx_tab2_fromprogram.DataSource = ds;
        }

        //�j�M�c�餤��
        private void btn_gettranslate_Click(object sender, EventArgs e)
        {
            ResultMessageTab2("------------------�}�l���o�{���������!------------------");
            //clear dgv_tab2_languagetranslate
            dgv_tab2_languagetranslate.DataSource = null;
            dgv_tab2_languagetranslate.Rows.Clear();
            ResultMessageTab2("�e���M��");

            string fileName = "";
            thelper.languageTranslates_merge = new List<LanguageTranslate>();

            DirectoryInfo Dir;
            FileInfo[] files;


            //ts,css,html
            ResultMessageTab2("1.���yts,css,html");
            fProgrampath = fAreapath + @"\" + this.cbx_tab2_fromprogram.Text;
            Dir = new DirectoryInfo(fProgrampath);
            files = Dir.GetFiles();
            thelper.mergeTranslate(thelper.getTranslate(files));

            //services
            ResultMessageTab2("2.���yservices");
            fileName = this.cbx_tab2_fromprogram.Text + ".service.ts";
            thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
            //pop-up.service.ts
            ResultMessageTab2("3.���ypop-up.service.ts");
            fileName = this.cbx_tab2_fromprogram.Text + "-pop-up.service.ts";
            if (File.Exists(fAreapath + @"\services\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\services\" + fileName));
            }
            //states
            ResultMessageTab2("4.���ystates");
            fileName = this.cbx_tab2_fromprogram.Text + ".state.ts";
            thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\states\" + fileName));
            //controls
            ResultMessageTab2("5.���ycontrols");
            fileName = this.cbx_tab2_fromprogram.Text + ".control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
            }
            //form.control
            ResultMessageTab2("6.���yform.control");
            fileName = this.cbx_tab2_fromprogram.Text + "-form.control.ts";
            if (File.Exists(fAreapath + @"\controls\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\controls\" + fileName));
            }
            //validations
            ResultMessageTab2("7.���yvalidations");
            fileName = this.cbx_fromprogram.Text + ".validation.ts";
            if (File.Exists(fAreapath + @"\validations\" + fileName))
            {
                thelper.mergeTranslate(thelper.getTranslate(fAreapath + @"\validations\" + fileName));
            }

            //��J���
            ResultMessageTab2("8.���½Ķ�}�l");
            foreach (var lt in thelper.languageTranslates_merge)
            {
                this.dgv_tab2_languagetranslate.Rows.Add(lt.TW, lt.ZH, lt.EN, lt.VI);
            }
            ResultMessageTab2("------------------���o�{��������Ƨ���------------------");
        }

        private void btn_tab2_selectpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.tbx_tab2_projectpath.Text = path.SelectedPath;
            //���o�ҲզC��
            List<string> ds = fhelper.DirSearch(this.tbx_tab2_projectpath.Text + AppPortalpath);

            BindingSource bs = new BindingSource();
            //��Jfrom_module
            this.cbx_tab2_frommodule.DataSource = ds;
            //��Jfrom_module
            this.cbx_tab2_frommodule.DataSource = ds;
        }

        //�u���ܩ�
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

                ResultMessageTab2("DB-�g�J����!");
            }
            catch (Exception)
            {

                throw;
            }

        }

        //�g�JDB
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
                        ResultMessageTab2("DGDB-�s�u���\!");
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
                        ResultMessageTab2("VSDB-�s�u���\!");
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
                        ResultMessageTab2("VNDB-�s�u���\!");
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
                        ResultMessageTab2("VGDB-�s�u���\!");
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
                        ResultMessageTab2("TCDB-�s�u���\!");
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
            if (cbx_tab2_fromarea.Items.Count>0 && cbx_tab2_frommodule.Items.Count > 0 && cbx_tab2_fromprogram.Items.Count > 0)
            {
                btn_gettranslate.Enabled = true;

            }
            else {
                btn_gettranslate.Enabled = false;
                btn_IMultLanguage.Enabled = false;
            }

            if (cbx_dgdb.Checked || cbx_vsdb.Checked || cbx_vgdb.Checked || cbx_tcdb.Checked || cbx_vndb.Checked)
            {
                btn_IMultLanguage.Enabled = true;
            }
            else {
                btn_IMultLanguage.Enabled = false;
            }

        }

        //�k��R���ƥ�
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

        //�T�����G
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


    }


}