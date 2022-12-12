namespace DLPCodeCreater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tim_checkinput = new System.Windows.Forms.Timer(this.components);
            this.tbc_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl_tab1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_getrepository = new System.Windows.Forms.Button();
            this.btn_repositories = new System.Windows.Forms.Button();
            this.btn_dto = new System.Windows.Forms.Button();
            this.btn_interface = new System.Windows.Forms.Button();
            this.grb_Backend = new System.Windows.Forms.GroupBox();
            this.btn_backendmove = new System.Windows.Forms.Button();
            this.btn_spname = new System.Windows.Forms.Button();
            this.grb_Frontend = new System.Windows.Forms.GroupBox();
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_webapicopy = new System.Windows.Forms.Button();
            this.btn_modulecopy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbx_targetprogram = new System.Windows.Forms.ComboBox();
            this.lab_targetprogram = new System.Windows.Forms.Label();
            this.cbx_targetarea = new System.Windows.Forms.ComboBox();
            this.lab_targetarea = new System.Windows.Forms.Label();
            this.cbx_targetmodule = new System.Windows.Forms.ComboBox();
            this.lab_targetmodule = new System.Windows.Forms.Label();
            this.tbx_resultMsg = new System.Windows.Forms.TextBox();
            this.cbx_fromprogram = new System.Windows.Forms.ComboBox();
            this.lab_fromprogram = new System.Windows.Forms.Label();
            this.cbx_fromarea = new System.Windows.Forms.ComboBox();
            this.lab_fromarea = new System.Windows.Forms.Label();
            this.cbx_frommodule = new System.Windows.Forms.ComboBox();
            this.lab_module = new System.Windows.Forms.Label();
            this.lab_projectpath = new System.Windows.Forms.Label();
            this.btn_selectpath = new System.Windows.Forms.Button();
            this.tbx_projectpath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnl_tab2 = new System.Windows.Forms.Panel();
            this.grb_tab2_dbselect = new System.Windows.Forms.GroupBox();
            this.cbx_eipdg = new System.Windows.Forms.CheckBox();
            this.cbx_eiptc = new System.Windows.Forms.CheckBox();
            this.cbx_eipvs = new System.Windows.Forms.CheckBox();
            this.cbx_eipvn = new System.Windows.Forms.CheckBox();
            this.btn_IMultLanguage = new System.Windows.Forms.Button();
            this.tbx_tab2_resultMsg = new System.Windows.Forms.TextBox();
            this.lab_tab2_projectpath = new System.Windows.Forms.Label();
            this.btn_tab2_selectpath = new System.Windows.Forms.Button();
            this.tbx_tab2_projectpath = new System.Windows.Forms.TextBox();
            this.btn_gettranslate = new System.Windows.Forms.Button();
            this.dgv_tab2_languagetranslate = new System.Windows.Forms.DataGridView();
            this.cbx_tab2_fromprogram = new System.Windows.Forms.ComboBox();
            this.lab_tab2_fromprogram = new System.Windows.Forms.Label();
            this.cbx_tab2_fromarea = new System.Windows.Forms.ComboBox();
            this.lab_atb2_fromarea = new System.Windows.Forms.Label();
            this.cbx_tab2_frommodule = new System.Windows.Forms.ComboBox();
            this.lab_tab2_module = new System.Windows.Forms.Label();
            this.tim_tab2 = new System.Windows.Forms.Timer(this.components);
            this.tw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbc_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnl_tab1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grb_Backend.SuspendLayout();
            this.grb_Frontend.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnl_tab2.SuspendLayout();
            this.grb_tab2_dbselect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tab2_languagetranslate)).BeginInit();
            this.SuspendLayout();
            // 
            // tim_checkinput
            // 
            this.tim_checkinput.Enabled = true;
            this.tim_checkinput.Interval = 1000;
            this.tim_checkinput.Tick += new System.EventHandler(this.tim_checkinput_Tick);
            // 
            // tbc_main
            // 
            this.tbc_main.Controls.Add(this.tabPage1);
            this.tbc_main.Controls.Add(this.tabPage2);
            this.tbc_main.Location = new System.Drawing.Point(2, 3);
            this.tbc_main.Name = "tbc_main";
            this.tbc_main.SelectedIndex = 0;
            this.tbc_main.Size = new System.Drawing.Size(823, 598);
            this.tbc_main.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnl_tab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(815, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SunDi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_tab1
            // 
            this.pnl_tab1.Controls.Add(this.groupBox1);
            this.pnl_tab1.Controls.Add(this.grb_Backend);
            this.pnl_tab1.Controls.Add(this.grb_Frontend);
            this.pnl_tab1.Controls.Add(this.button1);
            this.pnl_tab1.Controls.Add(this.cbx_targetprogram);
            this.pnl_tab1.Controls.Add(this.lab_targetprogram);
            this.pnl_tab1.Controls.Add(this.cbx_targetarea);
            this.pnl_tab1.Controls.Add(this.lab_targetarea);
            this.pnl_tab1.Controls.Add(this.cbx_targetmodule);
            this.pnl_tab1.Controls.Add(this.lab_targetmodule);
            this.pnl_tab1.Controls.Add(this.tbx_resultMsg);
            this.pnl_tab1.Controls.Add(this.cbx_fromprogram);
            this.pnl_tab1.Controls.Add(this.lab_fromprogram);
            this.pnl_tab1.Controls.Add(this.cbx_fromarea);
            this.pnl_tab1.Controls.Add(this.lab_fromarea);
            this.pnl_tab1.Controls.Add(this.cbx_frommodule);
            this.pnl_tab1.Controls.Add(this.lab_module);
            this.pnl_tab1.Controls.Add(this.lab_projectpath);
            this.pnl_tab1.Controls.Add(this.btn_selectpath);
            this.pnl_tab1.Controls.Add(this.tbx_projectpath);
            this.pnl_tab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tab1.Location = new System.Drawing.Point(3, 3);
            this.pnl_tab1.Name = "pnl_tab1";
            this.pnl_tab1.Size = new System.Drawing.Size(809, 564);
            this.pnl_tab1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_getrepository);
            this.groupBox1.Controls.Add(this.btn_repositories);
            this.groupBox1.Controls.Add(this.btn_dto);
            this.groupBox1.Controls.Add(this.btn_interface);
            this.groupBox1.Location = new System.Drawing.Point(6, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 85);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3.Repository";
            // 
            // btn_getrepository
            // 
            this.btn_getrepository.Location = new System.Drawing.Point(6, 22);
            this.btn_getrepository.Name = "btn_getrepository";
            this.btn_getrepository.Size = new System.Drawing.Size(132, 44);
            this.btn_getrepository.TabIndex = 26;
            this.btn_getrepository.Text = "Get Repository";
            this.btn_getrepository.UseVisualStyleBackColor = true;
            this.btn_getrepository.Click += new System.EventHandler(this.btn_getrepository_Click);
            // 
            // btn_repositories
            // 
            this.btn_repositories.Location = new System.Drawing.Point(448, 22);
            this.btn_repositories.Name = "btn_repositories";
            this.btn_repositories.Size = new System.Drawing.Size(132, 44);
            this.btn_repositories.TabIndex = 28;
            this.btn_repositories.Text = "Repositories";
            this.btn_repositories.UseVisualStyleBackColor = true;
            this.btn_repositories.Click += new System.EventHandler(this.btn_repositories_Click);
            // 
            // btn_dto
            // 
            this.btn_dto.Location = new System.Drawing.Point(157, 22);
            this.btn_dto.Name = "btn_dto";
            this.btn_dto.Size = new System.Drawing.Size(132, 44);
            this.btn_dto.TabIndex = 25;
            this.btn_dto.Text = "DTO";
            this.btn_dto.UseVisualStyleBackColor = true;
            this.btn_dto.Click += new System.EventHandler(this.btn_dto_Click);
            // 
            // btn_interface
            // 
            this.btn_interface.Location = new System.Drawing.Point(306, 22);
            this.btn_interface.Name = "btn_interface";
            this.btn_interface.Size = new System.Drawing.Size(132, 44);
            this.btn_interface.TabIndex = 27;
            this.btn_interface.Text = "Interface";
            this.btn_interface.UseVisualStyleBackColor = true;
            this.btn_interface.Click += new System.EventHandler(this.btn_interface_Click);
            // 
            // grb_Backend
            // 
            this.grb_Backend.Controls.Add(this.btn_backendmove);
            this.grb_Backend.Controls.Add(this.btn_spname);
            this.grb_Backend.Location = new System.Drawing.Point(489, 137);
            this.grb_Backend.Name = "grb_Backend";
            this.grb_Backend.Size = new System.Drawing.Size(284, 93);
            this.grb_Backend.TabIndex = 48;
            this.grb_Backend.TabStop = false;
            this.grb_Backend.Text = "2.Backend";
            // 
            // btn_backendmove
            // 
            this.btn_backendmove.Location = new System.Drawing.Point(6, 31);
            this.btn_backendmove.Name = "btn_backendmove";
            this.btn_backendmove.Size = new System.Drawing.Size(132, 44);
            this.btn_backendmove.TabIndex = 20;
            this.btn_backendmove.Text = "Backend Move";
            this.btn_backendmove.UseVisualStyleBackColor = true;
            this.btn_backendmove.Click += new System.EventHandler(this.btn_backendmove_Click);
            // 
            // btn_spname
            // 
            this.btn_spname.Location = new System.Drawing.Point(144, 31);
            this.btn_spname.Name = "btn_spname";
            this.btn_spname.Size = new System.Drawing.Size(132, 44);
            this.btn_spname.TabIndex = 21;
            this.btn_spname.Text = "SPName";
            this.btn_spname.UseVisualStyleBackColor = true;
            this.btn_spname.Click += new System.EventHandler(this.btn_spname_Click);
            // 
            // grb_Frontend
            // 
            this.grb_Frontend.Controls.Add(this.btn_Move);
            this.grb_Frontend.Controls.Add(this.btn_webapicopy);
            this.grb_Frontend.Controls.Add(this.btn_modulecopy);
            this.grb_Frontend.Location = new System.Drawing.Point(6, 137);
            this.grb_Frontend.Name = "grb_Frontend";
            this.grb_Frontend.Size = new System.Drawing.Size(465, 93);
            this.grb_Frontend.TabIndex = 47;
            this.grb_Frontend.TabStop = false;
            this.grb_Frontend.Text = "1.Frontend";
            // 
            // btn_Move
            // 
            this.btn_Move.Location = new System.Drawing.Point(6, 31);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(132, 44);
            this.btn_Move.TabIndex = 16;
            this.btn_Move.Text = "Frontend Move";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // btn_webapicopy
            // 
            this.btn_webapicopy.Location = new System.Drawing.Point(157, 31);
            this.btn_webapicopy.Name = "btn_webapicopy";
            this.btn_webapicopy.Size = new System.Drawing.Size(132, 44);
            this.btn_webapicopy.TabIndex = 17;
            this.btn_webapicopy.Text = "web-api.service  web-api.model";
            this.btn_webapicopy.UseVisualStyleBackColor = true;
            this.btn_webapicopy.Click += new System.EventHandler(this.btn_webapicopy_Click);
            // 
            // btn_modulecopy
            // 
            this.btn_modulecopy.Location = new System.Drawing.Point(306, 31);
            this.btn_modulecopy.Name = "btn_modulecopy";
            this.btn_modulecopy.Size = new System.Drawing.Size(132, 44);
            this.btn_modulecopy.TabIndex = 19;
            this.btn_modulecopy.Text = "routing.module.ts module.ts ";
            this.btn_modulecopy.UseVisualStyleBackColor = true;
            this.btn_modulecopy.Click += new System.EventHandler(this.btn_modulecopy_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbx_targetprogram
            // 
            this.cbx_targetprogram.FormattingEnabled = true;
            this.cbx_targetprogram.Location = new System.Drawing.Point(619, 88);
            this.cbx_targetprogram.Name = "cbx_targetprogram";
            this.cbx_targetprogram.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetprogram.TabIndex = 45;
            this.cbx_targetprogram.Leave += new System.EventHandler(this.cbx_targetprogram_Leave);
            // 
            // lab_targetprogram
            // 
            this.lab_targetprogram.AutoSize = true;
            this.lab_targetprogram.Location = new System.Drawing.Point(518, 96);
            this.lab_targetprogram.Name = "lab_targetprogram";
            this.lab_targetprogram.Size = new System.Drawing.Size(98, 15);
            this.lab_targetprogram.TabIndex = 44;
            this.lab_targetprogram.Text = "Target_Program";
            // 
            // cbx_targetarea
            // 
            this.cbx_targetarea.FormattingEnabled = true;
            this.cbx_targetarea.Location = new System.Drawing.Point(356, 88);
            this.cbx_targetarea.Name = "cbx_targetarea";
            this.cbx_targetarea.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetarea.TabIndex = 43;
            this.cbx_targetarea.SelectedIndexChanged += new System.EventHandler(this.cbx_targetarea_SelectedIndexChanged);
            this.cbx_targetarea.Leave += new System.EventHandler(this.cbx_targetarea_Leave);
            // 
            // lab_targetarea
            // 
            this.lab_targetarea.AutoSize = true;
            this.lab_targetarea.Location = new System.Drawing.Point(283, 96);
            this.lab_targetarea.Name = "lab_targetarea";
            this.lab_targetarea.Size = new System.Drawing.Size(75, 15);
            this.lab_targetarea.TabIndex = 42;
            this.lab_targetarea.Text = "Target_Area";
            // 
            // cbx_targetmodule
            // 
            this.cbx_targetmodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_targetmodule.FormattingEnabled = true;
            this.cbx_targetmodule.Location = new System.Drawing.Point(117, 88);
            this.cbx_targetmodule.Name = "cbx_targetmodule";
            this.cbx_targetmodule.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetmodule.TabIndex = 41;
            this.cbx_targetmodule.SelectedIndexChanged += new System.EventHandler(this.cbx_targetmodule_SelectedIndexChanged);
            // 
            // lab_targetmodule
            // 
            this.lab_targetmodule.AutoSize = true;
            this.lab_targetmodule.Location = new System.Drawing.Point(16, 96);
            this.lab_targetmodule.Name = "lab_targetmodule";
            this.lab_targetmodule.Size = new System.Drawing.Size(94, 15);
            this.lab_targetmodule.TabIndex = 40;
            this.lab_targetmodule.Text = "Target_Module";
            // 
            // tbx_resultMsg
            // 
            this.tbx_resultMsg.Location = new System.Drawing.Point(6, 342);
            this.tbx_resultMsg.Multiline = true;
            this.tbx_resultMsg.Name = "tbx_resultMsg";
            this.tbx_resultMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_resultMsg.Size = new System.Drawing.Size(767, 206);
            this.tbx_resultMsg.TabIndex = 39;
            this.tbx_resultMsg.TextChanged += new System.EventHandler(this.tbx_resultMsg_TextChanged);
            // 
            // cbx_fromprogram
            // 
            this.cbx_fromprogram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_fromprogram.FormattingEnabled = true;
            this.cbx_fromprogram.Location = new System.Drawing.Point(619, 50);
            this.cbx_fromprogram.Name = "cbx_fromprogram";
            this.cbx_fromprogram.Size = new System.Drawing.Size(148, 23);
            this.cbx_fromprogram.TabIndex = 38;
            this.cbx_fromprogram.SelectedIndexChanged += new System.EventHandler(this.cbx_fromprogram_SelectedIndexChanged);
            // 
            // lab_fromprogram
            // 
            this.lab_fromprogram.AutoSize = true;
            this.lab_fromprogram.Location = new System.Drawing.Point(526, 58);
            this.lab_fromprogram.Name = "lab_fromprogram";
            this.lab_fromprogram.Size = new System.Drawing.Size(90, 15);
            this.lab_fromprogram.TabIndex = 37;
            this.lab_fromprogram.Text = "From_Program";
            // 
            // cbx_fromarea
            // 
            this.cbx_fromarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_fromarea.FormattingEnabled = true;
            this.cbx_fromarea.Location = new System.Drawing.Point(356, 50);
            this.cbx_fromarea.Name = "cbx_fromarea";
            this.cbx_fromarea.Size = new System.Drawing.Size(148, 23);
            this.cbx_fromarea.TabIndex = 36;
            this.cbx_fromarea.SelectedIndexChanged += new System.EventHandler(this.cbx_fromarea_SelectedIndexChanged);
            // 
            // lab_fromarea
            // 
            this.lab_fromarea.AutoSize = true;
            this.lab_fromarea.Location = new System.Drawing.Point(283, 58);
            this.lab_fromarea.Name = "lab_fromarea";
            this.lab_fromarea.Size = new System.Drawing.Size(67, 15);
            this.lab_fromarea.TabIndex = 35;
            this.lab_fromarea.Text = "From_Area";
            // 
            // cbx_frommodule
            // 
            this.cbx_frommodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_frommodule.FormattingEnabled = true;
            this.cbx_frommodule.Location = new System.Drawing.Point(117, 50);
            this.cbx_frommodule.Name = "cbx_frommodule";
            this.cbx_frommodule.Size = new System.Drawing.Size(148, 23);
            this.cbx_frommodule.TabIndex = 34;
            this.cbx_frommodule.SelectedIndexChanged += new System.EventHandler(this.cbx_frommodule_SelectedIndexChanged);
            // 
            // lab_module
            // 
            this.lab_module.AutoSize = true;
            this.lab_module.Location = new System.Drawing.Point(16, 58);
            this.lab_module.Name = "lab_module";
            this.lab_module.Size = new System.Drawing.Size(86, 15);
            this.lab_module.TabIndex = 33;
            this.lab_module.Text = "From_Module";
            // 
            // lab_projectpath
            // 
            this.lab_projectpath.AutoSize = true;
            this.lab_projectpath.Location = new System.Drawing.Point(16, 22);
            this.lab_projectpath.Name = "lab_projectpath";
            this.lab_projectpath.Size = new System.Drawing.Size(71, 15);
            this.lab_projectpath.TabIndex = 32;
            this.lab_projectpath.Text = "ProjectPath";
            // 
            // btn_selectpath
            // 
            this.btn_selectpath.Location = new System.Drawing.Point(511, 14);
            this.btn_selectpath.Name = "btn_selectpath";
            this.btn_selectpath.Size = new System.Drawing.Size(75, 23);
            this.btn_selectpath.TabIndex = 31;
            this.btn_selectpath.Text = "Select";
            this.btn_selectpath.UseVisualStyleBackColor = true;
            this.btn_selectpath.Click += new System.EventHandler(this.btn_selectpath_Click);
            // 
            // tbx_projectpath
            // 
            this.tbx_projectpath.Location = new System.Drawing.Point(117, 14);
            this.tbx_projectpath.Name = "tbx_projectpath";
            this.tbx_projectpath.Size = new System.Drawing.Size(388, 23);
            this.tbx_projectpath.TabIndex = 30;
            this.tbx_projectpath.Text = ".\\dlp-develop";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnl_tab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(815, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DoYuSi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnl_tab2
            // 
            this.pnl_tab2.Controls.Add(this.grb_tab2_dbselect);
            this.pnl_tab2.Controls.Add(this.btn_IMultLanguage);
            this.pnl_tab2.Controls.Add(this.tbx_tab2_resultMsg);
            this.pnl_tab2.Controls.Add(this.lab_tab2_projectpath);
            this.pnl_tab2.Controls.Add(this.btn_tab2_selectpath);
            this.pnl_tab2.Controls.Add(this.tbx_tab2_projectpath);
            this.pnl_tab2.Controls.Add(this.btn_gettranslate);
            this.pnl_tab2.Controls.Add(this.dgv_tab2_languagetranslate);
            this.pnl_tab2.Controls.Add(this.cbx_tab2_fromprogram);
            this.pnl_tab2.Controls.Add(this.lab_tab2_fromprogram);
            this.pnl_tab2.Controls.Add(this.cbx_tab2_fromarea);
            this.pnl_tab2.Controls.Add(this.lab_atb2_fromarea);
            this.pnl_tab2.Controls.Add(this.cbx_tab2_frommodule);
            this.pnl_tab2.Controls.Add(this.lab_tab2_module);
            this.pnl_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tab2.Location = new System.Drawing.Point(3, 3);
            this.pnl_tab2.Name = "pnl_tab2";
            this.pnl_tab2.Size = new System.Drawing.Size(809, 564);
            this.pnl_tab2.TabIndex = 0;
            // 
            // grb_tab2_dbselect
            // 
            this.grb_tab2_dbselect.Controls.Add(this.cbx_eipdg);
            this.grb_tab2_dbselect.Controls.Add(this.cbx_eiptc);
            this.grb_tab2_dbselect.Controls.Add(this.cbx_eipvs);
            this.grb_tab2_dbselect.Controls.Add(this.cbx_eipvn);
            this.grb_tab2_dbselect.Location = new System.Drawing.Point(151, 76);
            this.grb_tab2_dbselect.Name = "grb_tab2_dbselect";
            this.grb_tab2_dbselect.Size = new System.Drawing.Size(201, 102);
            this.grb_tab2_dbselect.TabIndex = 60;
            this.grb_tab2_dbselect.TabStop = false;
            this.grb_tab2_dbselect.Text = "Select DB";
            // 
            // cbx_eipdg
            // 
            this.cbx_eipdg.AutoSize = true;
            this.cbx_eipdg.Location = new System.Drawing.Point(6, 22);
            this.cbx_eipdg.Name = "cbx_eipdg";
            this.cbx_eipdg.Size = new System.Drawing.Size(62, 19);
            this.cbx_eipdg.TabIndex = 56;
            this.cbx_eipdg.Text = "EipDG";
            this.cbx_eipdg.UseVisualStyleBackColor = true;
            this.cbx_eipdg.Click += new System.EventHandler(this.cbx_eipdg_Click);
            // 
            // cbx_eiptc
            // 
            this.cbx_eiptc.AutoSize = true;
            this.cbx_eiptc.Location = new System.Drawing.Point(98, 22);
            this.cbx_eiptc.Name = "cbx_eiptc";
            this.cbx_eiptc.Size = new System.Drawing.Size(59, 19);
            this.cbx_eiptc.TabIndex = 59;
            this.cbx_eiptc.Text = "EipTC";
            this.cbx_eiptc.UseVisualStyleBackColor = true;
            this.cbx_eiptc.Click += new System.EventHandler(this.cbx_eiptc_Click);
            // 
            // cbx_eipvs
            // 
            this.cbx_eipvs.AutoSize = true;
            this.cbx_eipvs.Location = new System.Drawing.Point(6, 72);
            this.cbx_eipvs.Name = "cbx_eipvs";
            this.cbx_eipvs.Size = new System.Drawing.Size(59, 19);
            this.cbx_eipvs.TabIndex = 57;
            this.cbx_eipvs.Text = "EipVS";
            this.cbx_eipvs.UseVisualStyleBackColor = true;
            this.cbx_eipvs.Click += new System.EventHandler(this.cbx_eipvs_Click);
            // 
            // cbx_eipvn
            // 
            this.cbx_eipvn.AutoSize = true;
            this.cbx_eipvn.Location = new System.Drawing.Point(6, 47);
            this.cbx_eipvn.Name = "cbx_eipvn";
            this.cbx_eipvn.Size = new System.Drawing.Size(62, 19);
            this.cbx_eipvn.TabIndex = 58;
            this.cbx_eipvn.Text = "EipVN";
            this.cbx_eipvn.UseVisualStyleBackColor = true;
            this.cbx_eipvn.Click += new System.EventHandler(this.cbx_eipvn_Click);
            // 
            // btn_IMultLanguage
            // 
            this.btn_IMultLanguage.Location = new System.Drawing.Point(13, 134);
            this.btn_IMultLanguage.Name = "btn_IMultLanguage";
            this.btn_IMultLanguage.Size = new System.Drawing.Size(132, 44);
            this.btn_IMultLanguage.TabIndex = 55;
            this.btn_IMultLanguage.Text = "Insert MultiLanguage";
            this.btn_IMultLanguage.UseVisualStyleBackColor = true;
            this.btn_IMultLanguage.Click += new System.EventHandler(this.btn_IMultLanguage_Click);
            // 
            // tbx_tab2_resultMsg
            // 
            this.tbx_tab2_resultMsg.Location = new System.Drawing.Point(358, 84);
            this.tbx_tab2_resultMsg.Multiline = true;
            this.tbx_tab2_resultMsg.Name = "tbx_tab2_resultMsg";
            this.tbx_tab2_resultMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_tab2_resultMsg.Size = new System.Drawing.Size(411, 124);
            this.tbx_tab2_resultMsg.TabIndex = 53;
            this.tbx_tab2_resultMsg.TextChanged += new System.EventHandler(this.tbx_tab2_resultMsg_TextChanged);
            // 
            // lab_tab2_projectpath
            // 
            this.lab_tab2_projectpath.AutoSize = true;
            this.lab_tab2_projectpath.Location = new System.Drawing.Point(18, 22);
            this.lab_tab2_projectpath.Name = "lab_tab2_projectpath";
            this.lab_tab2_projectpath.Size = new System.Drawing.Size(71, 15);
            this.lab_tab2_projectpath.TabIndex = 52;
            this.lab_tab2_projectpath.Text = "ProjectPath";
            // 
            // btn_tab2_selectpath
            // 
            this.btn_tab2_selectpath.Location = new System.Drawing.Point(513, 14);
            this.btn_tab2_selectpath.Name = "btn_tab2_selectpath";
            this.btn_tab2_selectpath.Size = new System.Drawing.Size(75, 23);
            this.btn_tab2_selectpath.TabIndex = 51;
            this.btn_tab2_selectpath.Text = "Select";
            this.btn_tab2_selectpath.UseVisualStyleBackColor = true;
            this.btn_tab2_selectpath.Click += new System.EventHandler(this.btn_tab2_selectpath_Click);
            // 
            // tbx_tab2_projectpath
            // 
            this.tbx_tab2_projectpath.Location = new System.Drawing.Point(119, 14);
            this.tbx_tab2_projectpath.Name = "tbx_tab2_projectpath";
            this.tbx_tab2_projectpath.Size = new System.Drawing.Size(388, 23);
            this.tbx_tab2_projectpath.TabIndex = 50;
            this.tbx_tab2_projectpath.Text = ".\\dlp-develop";
            // 
            // btn_gettranslate
            // 
            this.btn_gettranslate.Location = new System.Drawing.Point(13, 84);
            this.btn_gettranslate.Name = "btn_gettranslate";
            this.btn_gettranslate.Size = new System.Drawing.Size(132, 44);
            this.btn_gettranslate.TabIndex = 49;
            this.btn_gettranslate.Text = "Get Translate";
            this.btn_gettranslate.UseVisualStyleBackColor = true;
            this.btn_gettranslate.Click += new System.EventHandler(this.btn_gettranslate_Click);
            // 
            // dgv_tab2_languagetranslate
            // 
            this.dgv_tab2_languagetranslate.AllowUserToAddRows = false;
            this.dgv_tab2_languagetranslate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tab2_languagetranslate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tw,
            this.zh,
            this.en,
            this.vi});
            this.dgv_tab2_languagetranslate.Location = new System.Drawing.Point(3, 214);
            this.dgv_tab2_languagetranslate.Name = "dgv_tab2_languagetranslate";
            this.dgv_tab2_languagetranslate.RowTemplate.Height = 25;
            this.dgv_tab2_languagetranslate.Size = new System.Drawing.Size(803, 353);
            this.dgv_tab2_languagetranslate.TabIndex = 48;
            // 
            // cbx_tab2_fromprogram
            // 
            this.cbx_tab2_fromprogram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_tab2_fromprogram.FormattingEnabled = true;
            this.cbx_tab2_fromprogram.Location = new System.Drawing.Point(621, 47);
            this.cbx_tab2_fromprogram.Name = "cbx_tab2_fromprogram";
            this.cbx_tab2_fromprogram.Size = new System.Drawing.Size(148, 23);
            this.cbx_tab2_fromprogram.TabIndex = 47;
            // 
            // lab_tab2_fromprogram
            // 
            this.lab_tab2_fromprogram.AutoSize = true;
            this.lab_tab2_fromprogram.Location = new System.Drawing.Point(528, 55);
            this.lab_tab2_fromprogram.Name = "lab_tab2_fromprogram";
            this.lab_tab2_fromprogram.Size = new System.Drawing.Size(90, 15);
            this.lab_tab2_fromprogram.TabIndex = 46;
            this.lab_tab2_fromprogram.Text = "From_Program";
            // 
            // cbx_tab2_fromarea
            // 
            this.cbx_tab2_fromarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_tab2_fromarea.FormattingEnabled = true;
            this.cbx_tab2_fromarea.Location = new System.Drawing.Point(358, 47);
            this.cbx_tab2_fromarea.Name = "cbx_tab2_fromarea";
            this.cbx_tab2_fromarea.Size = new System.Drawing.Size(148, 23);
            this.cbx_tab2_fromarea.TabIndex = 45;
            this.cbx_tab2_fromarea.SelectedIndexChanged += new System.EventHandler(this.cbx_tab2_fromarea_SelectedIndexChanged);
            // 
            // lab_atb2_fromarea
            // 
            this.lab_atb2_fromarea.AutoSize = true;
            this.lab_atb2_fromarea.Location = new System.Drawing.Point(285, 55);
            this.lab_atb2_fromarea.Name = "lab_atb2_fromarea";
            this.lab_atb2_fromarea.Size = new System.Drawing.Size(67, 15);
            this.lab_atb2_fromarea.TabIndex = 44;
            this.lab_atb2_fromarea.Text = "From_Area";
            // 
            // cbx_tab2_frommodule
            // 
            this.cbx_tab2_frommodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_tab2_frommodule.FormattingEnabled = true;
            this.cbx_tab2_frommodule.Location = new System.Drawing.Point(119, 47);
            this.cbx_tab2_frommodule.Name = "cbx_tab2_frommodule";
            this.cbx_tab2_frommodule.Size = new System.Drawing.Size(148, 23);
            this.cbx_tab2_frommodule.TabIndex = 43;
            this.cbx_tab2_frommodule.SelectedIndexChanged += new System.EventHandler(this.cbx_tab2_frommodule_SelectedIndexChanged);
            // 
            // lab_tab2_module
            // 
            this.lab_tab2_module.AutoSize = true;
            this.lab_tab2_module.Location = new System.Drawing.Point(18, 55);
            this.lab_tab2_module.Name = "lab_tab2_module";
            this.lab_tab2_module.Size = new System.Drawing.Size(86, 15);
            this.lab_tab2_module.TabIndex = 42;
            this.lab_tab2_module.Text = "From_Module";
            // 
            // tim_tab2
            // 
            this.tim_tab2.Enabled = true;
            this.tim_tab2.Interval = 1000;
            this.tim_tab2.Tick += new System.EventHandler(this.tim_tab2_Tick);
            // 
            // tw
            // 
            this.tw.HeaderText = "繁體中文";
            this.tw.Name = "tw";
            this.tw.Width = 250;
            // 
            // zh
            // 
            this.zh.HeaderText = "簡體中文";
            this.zh.Name = "zh";
            this.zh.Width = 150;
            // 
            // en
            // 
            this.en.HeaderText = "英文";
            this.en.Name = "en";
            this.en.Width = 150;
            // 
            // vi
            // 
            this.vi.HeaderText = "越南文";
            this.vi.Name = "vi";
            this.vi.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(829, 604);
            this.Controls.Add(this.tbc_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SunDiTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbc_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnl_tab1.ResumeLayout(false);
            this.pnl_tab1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grb_Backend.ResumeLayout(false);
            this.grb_Frontend.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnl_tab2.ResumeLayout(false);
            this.pnl_tab2.PerformLayout();
            this.grb_tab2_dbselect.ResumeLayout(false);
            this.grb_tab2_dbselect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tab2_languagetranslate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tim_checkinput;
        private TabControl tbc_main;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel pnl_tab1;
        private GroupBox groupBox1;
        private Button btn_getrepository;
        private Button btn_repositories;
        private Button btn_dto;
        private Button btn_interface;
        private GroupBox grb_Backend;
        private Button btn_backendmove;
        private Button btn_spname;
        private GroupBox grb_Frontend;
        private Button btn_Move;
        private Button btn_webapicopy;
        private Button btn_modulecopy;
        private Button button1;
        private ComboBox cbx_targetprogram;
        private Label lab_targetprogram;
        private ComboBox cbx_targetarea;
        private Label lab_targetarea;
        private ComboBox cbx_targetmodule;
        private Label lab_targetmodule;
        private TextBox tbx_resultMsg;
        private ComboBox cbx_fromprogram;
        private Label lab_fromprogram;
        private ComboBox cbx_fromarea;
        private Label lab_fromarea;
        private ComboBox cbx_frommodule;
        private Label lab_module;
        private Label lab_projectpath;
        private Button btn_selectpath;
        private TextBox tbx_projectpath;
        private Panel pnl_tab2;
        private ComboBox cbx_tab2_fromprogram;
        private Label lab_tab2_fromprogram;
        private ComboBox cbx_tab2_fromarea;
        private Label lab_atb2_fromarea;
        private ComboBox cbx_tab2_frommodule;
        private Label lab_tab2_module;
        private Button btn_gettranslate;
        private DataGridView dgv_tab2_languagetranslate;
        private Label lab_tab2_projectpath;
        private Button btn_tab2_selectpath;
        private TextBox tbx_tab2_projectpath;
        private TextBox tbx_tab2_resultMsg;
        private Button btn_IMultLanguage;
        private GroupBox grb_tab2_dbselect;
        private CheckBox cbx_eipdg;
        private CheckBox cbx_eiptc;
        private CheckBox cbx_eipvs;
        private CheckBox cbx_eipvn;
        private System.Windows.Forms.Timer tim_tab2;
        private DataGridViewTextBoxColumn tw;
        private DataGridViewTextBoxColumn zh;
        private DataGridViewTextBoxColumn en;
        private DataGridViewTextBoxColumn vi;
    }
}