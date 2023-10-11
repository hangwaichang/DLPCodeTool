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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tim_checkinput = new System.Windows.Forms.Timer(components);
            tbc_main = new TabControl();
            tabPage1 = new TabPage();
            pnl_tab1 = new Panel();
            cbx_copydiff = new CheckBox();
            groupBox1 = new GroupBox();
            btn_getrepository = new Button();
            btn_repositories = new Button();
            btn_dto = new Button();
            btn_interface = new Button();
            grb_Backend = new GroupBox();
            btn_backendmove = new Button();
            btn_spname = new Button();
            grb_Frontend = new GroupBox();
            btn_Move = new Button();
            btn_webapicopy = new Button();
            btn_modulecopy = new Button();
            button1 = new Button();
            cbx_targetprogram = new ComboBox();
            lab_targetprogram = new Label();
            cbx_targetarea = new ComboBox();
            lab_targetarea = new Label();
            cbx_targetmodule = new ComboBox();
            lab_targetmodule = new Label();
            tbx_resultMsg = new TextBox();
            cbx_fromprogram = new ComboBox();
            lab_fromprogram = new Label();
            cbx_fromarea = new ComboBox();
            lab_fromarea = new Label();
            cbx_frommodule = new ComboBox();
            lab_module = new Label();
            lab_projectpath = new Label();
            btn_selectpath = new Button();
            tbx_projectpath = new TextBox();
            tabPage2 = new TabPage();
            pnl_tab2 = new Panel();
            grb_tab2_dbselect = new GroupBox();
            cbx_vndb = new CheckBox();
            cbx_dgdb = new CheckBox();
            cbx_tcdb = new CheckBox();
            cbx_vsdb = new CheckBox();
            cbx_vgdb = new CheckBox();
            btn_IMultLanguage = new Button();
            tbx_tab2_resultMsg = new TextBox();
            lab_tab2_projectpath = new Label();
            btn_tab2_selectpath = new Button();
            tbx_tab2_projectpath = new TextBox();
            btn_gettranslate = new Button();
            dgv_tab2_languagetranslate = new DataGridView();
            tw = new DataGridViewTextBoxColumn();
            zh = new DataGridViewTextBoxColumn();
            en = new DataGridViewTextBoxColumn();
            vi = new DataGridViewTextBoxColumn();
            cbx_tab2_fromprogram = new ComboBox();
            lab_tab2_fromprogram = new Label();
            cbx_tab2_fromarea = new ComboBox();
            lab_atb2_fromarea = new Label();
            cbx_tab2_frommodule = new ComboBox();
            lab_tab2_module = new Label();
            tabPage3 = new TabPage();
            dGV_innerObj = new DataGridView();
            textBoxResults = new TextBox();
            btn_run = new Button();
            btn_clearMessege = new Button();
            dGdVwHeaders = new DataGridView();
            Index = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            lstVwSubItems = new ListView();
            btnPath = new Button();
            txtSelectPath = new TextBox();
            tim_tab2 = new System.Windows.Forms.Timer(components);
            cmt_tab2_deleterow = new ContextMenuStrip(components);
            delectRowToolStripMenuItem = new ToolStripMenuItem();
            tbc_main.SuspendLayout();
            tabPage1.SuspendLayout();
            pnl_tab1.SuspendLayout();
            groupBox1.SuspendLayout();
            grb_Backend.SuspendLayout();
            grb_Frontend.SuspendLayout();
            tabPage2.SuspendLayout();
            pnl_tab2.SuspendLayout();
            grb_tab2_dbselect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_tab2_languagetranslate).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_innerObj).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGdVwHeaders).BeginInit();
            cmt_tab2_deleterow.SuspendLayout();
            SuspendLayout();
            // 
            // tim_checkinput
            // 
            tim_checkinput.Enabled = true;
            tim_checkinput.Interval = 1000;
            tim_checkinput.Tick += tim_checkinput_Tick;
            // 
            // tbc_main
            // 
            tbc_main.Controls.Add(tabPage1);
            tbc_main.Controls.Add(tabPage2);
            tbc_main.Controls.Add(tabPage3);
            tbc_main.Location = new Point(-6, 3);
            tbc_main.Name = "tbc_main";
            tbc_main.SelectedIndex = 0;
            tbc_main.Size = new Size(797, 598);
            tbc_main.TabIndex = 30;
            tbc_main.Tag = "";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnl_tab1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(789, 570);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "SunDiRo";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_tab1
            // 
            pnl_tab1.Controls.Add(cbx_copydiff);
            pnl_tab1.Controls.Add(groupBox1);
            pnl_tab1.Controls.Add(grb_Backend);
            pnl_tab1.Controls.Add(grb_Frontend);
            pnl_tab1.Controls.Add(button1);
            pnl_tab1.Controls.Add(cbx_targetprogram);
            pnl_tab1.Controls.Add(lab_targetprogram);
            pnl_tab1.Controls.Add(cbx_targetarea);
            pnl_tab1.Controls.Add(lab_targetarea);
            pnl_tab1.Controls.Add(cbx_targetmodule);
            pnl_tab1.Controls.Add(lab_targetmodule);
            pnl_tab1.Controls.Add(tbx_resultMsg);
            pnl_tab1.Controls.Add(cbx_fromprogram);
            pnl_tab1.Controls.Add(lab_fromprogram);
            pnl_tab1.Controls.Add(cbx_fromarea);
            pnl_tab1.Controls.Add(lab_fromarea);
            pnl_tab1.Controls.Add(cbx_frommodule);
            pnl_tab1.Controls.Add(lab_module);
            pnl_tab1.Controls.Add(lab_projectpath);
            pnl_tab1.Controls.Add(btn_selectpath);
            pnl_tab1.Controls.Add(tbx_projectpath);
            pnl_tab1.Dock = DockStyle.Fill;
            pnl_tab1.Location = new Point(3, 3);
            pnl_tab1.Name = "pnl_tab1";
            pnl_tab1.Size = new Size(783, 564);
            pnl_tab1.TabIndex = 0;
            // 
            // cbx_copydiff
            // 
            cbx_copydiff.AutoSize = true;
            cbx_copydiff.Location = new Point(619, 17);
            cbx_copydiff.Name = "cbx_copydiff";
            cbx_copydiff.Size = new Size(131, 19);
            cbx_copydiff.TabIndex = 50;
            cbx_copydiff.Text = "Copy Diff Program";
            cbx_copydiff.UseVisualStyleBackColor = true;
            cbx_copydiff.Click += cbx_copydiff_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_getrepository);
            groupBox1.Controls.Add(btn_repositories);
            groupBox1.Controls.Add(btn_dto);
            groupBox1.Controls.Add(btn_interface);
            groupBox1.Location = new Point(6, 236);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(767, 85);
            groupBox1.TabIndex = 49;
            groupBox1.TabStop = false;
            groupBox1.Text = "3.Repository";
            // 
            // btn_getrepository
            // 
            btn_getrepository.Location = new Point(6, 22);
            btn_getrepository.Name = "btn_getrepository";
            btn_getrepository.Size = new Size(132, 44);
            btn_getrepository.TabIndex = 26;
            btn_getrepository.Text = "Get Repository";
            btn_getrepository.UseVisualStyleBackColor = true;
            btn_getrepository.Click += btn_getrepository_Click;
            // 
            // btn_repositories
            // 
            btn_repositories.Location = new Point(448, 22);
            btn_repositories.Name = "btn_repositories";
            btn_repositories.Size = new Size(132, 44);
            btn_repositories.TabIndex = 28;
            btn_repositories.Text = "Repositories";
            btn_repositories.UseVisualStyleBackColor = true;
            btn_repositories.Click += btn_repositories_Click;
            // 
            // btn_dto
            // 
            btn_dto.Location = new Point(157, 22);
            btn_dto.Name = "btn_dto";
            btn_dto.Size = new Size(132, 44);
            btn_dto.TabIndex = 25;
            btn_dto.Text = "DTO";
            btn_dto.UseVisualStyleBackColor = true;
            btn_dto.Click += btn_dto_Click;
            // 
            // btn_interface
            // 
            btn_interface.Location = new Point(306, 22);
            btn_interface.Name = "btn_interface";
            btn_interface.Size = new Size(132, 44);
            btn_interface.TabIndex = 27;
            btn_interface.Text = "Interface";
            btn_interface.UseVisualStyleBackColor = true;
            btn_interface.Click += btn_interface_Click;
            // 
            // grb_Backend
            // 
            grb_Backend.Controls.Add(btn_backendmove);
            grb_Backend.Controls.Add(btn_spname);
            grb_Backend.Location = new Point(489, 137);
            grb_Backend.Name = "grb_Backend";
            grb_Backend.Size = new Size(284, 93);
            grb_Backend.TabIndex = 48;
            grb_Backend.TabStop = false;
            grb_Backend.Text = "2.Backend";
            // 
            // btn_backendmove
            // 
            btn_backendmove.Location = new Point(6, 31);
            btn_backendmove.Name = "btn_backendmove";
            btn_backendmove.Size = new Size(132, 44);
            btn_backendmove.TabIndex = 20;
            btn_backendmove.Text = "Backend Move";
            btn_backendmove.UseVisualStyleBackColor = true;
            btn_backendmove.Click += btn_backendmove_Click;
            // 
            // btn_spname
            // 
            btn_spname.Location = new Point(144, 31);
            btn_spname.Name = "btn_spname";
            btn_spname.Size = new Size(132, 44);
            btn_spname.TabIndex = 21;
            btn_spname.Text = "SPName";
            btn_spname.UseVisualStyleBackColor = true;
            btn_spname.Click += btn_spname_Click;
            // 
            // grb_Frontend
            // 
            grb_Frontend.Controls.Add(btn_Move);
            grb_Frontend.Controls.Add(btn_webapicopy);
            grb_Frontend.Controls.Add(btn_modulecopy);
            grb_Frontend.Location = new Point(6, 137);
            grb_Frontend.Name = "grb_Frontend";
            grb_Frontend.Size = new Size(465, 93);
            grb_Frontend.TabIndex = 47;
            grb_Frontend.TabStop = false;
            grb_Frontend.Text = "1.Frontend";
            // 
            // btn_Move
            // 
            btn_Move.Location = new Point(6, 31);
            btn_Move.Name = "btn_Move";
            btn_Move.Size = new Size(132, 44);
            btn_Move.TabIndex = 16;
            btn_Move.Text = "Frontend Move";
            btn_Move.UseVisualStyleBackColor = true;
            btn_Move.Click += btn_Move_Click;
            // 
            // btn_webapicopy
            // 
            btn_webapicopy.Location = new Point(157, 31);
            btn_webapicopy.Name = "btn_webapicopy";
            btn_webapicopy.Size = new Size(132, 44);
            btn_webapicopy.TabIndex = 17;
            btn_webapicopy.Text = "web-api.service  web-api.model";
            btn_webapicopy.UseVisualStyleBackColor = true;
            btn_webapicopy.Click += btn_webapicopy_Click;
            // 
            // btn_modulecopy
            // 
            btn_modulecopy.Location = new Point(306, 31);
            btn_modulecopy.Name = "btn_modulecopy";
            btn_modulecopy.Size = new Size(132, 44);
            btn_modulecopy.TabIndex = 19;
            btn_modulecopy.Text = "routing.module.ts module.ts ";
            btn_modulecopy.UseVisualStyleBackColor = true;
            btn_modulecopy.Click += btn_modulecopy_Click;
            // 
            // button1
            // 
            button1.Location = new Point(339, 538);
            button1.Name = "button1";
            button1.Size = new Size(132, 23);
            button1.TabIndex = 46;
            button1.Text = "Move";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // cbx_targetprogram
            // 
            cbx_targetprogram.FormattingEnabled = true;
            cbx_targetprogram.Location = new Point(619, 88);
            cbx_targetprogram.Name = "cbx_targetprogram";
            cbx_targetprogram.Size = new Size(148, 23);
            cbx_targetprogram.TabIndex = 45;
            cbx_targetprogram.Leave += cbx_targetprogram_Leave;
            // 
            // lab_targetprogram
            // 
            lab_targetprogram.AutoSize = true;
            lab_targetprogram.Location = new Point(518, 96);
            lab_targetprogram.Name = "lab_targetprogram";
            lab_targetprogram.Size = new Size(98, 15);
            lab_targetprogram.TabIndex = 44;
            lab_targetprogram.Text = "Target_Program";
            // 
            // cbx_targetarea
            // 
            cbx_targetarea.FormattingEnabled = true;
            cbx_targetarea.Location = new Point(356, 88);
            cbx_targetarea.Name = "cbx_targetarea";
            cbx_targetarea.Size = new Size(148, 23);
            cbx_targetarea.TabIndex = 43;
            cbx_targetarea.SelectedIndexChanged += cbx_targetarea_SelectedIndexChanged;
            cbx_targetarea.Leave += cbx_targetarea_Leave;
            // 
            // lab_targetarea
            // 
            lab_targetarea.AutoSize = true;
            lab_targetarea.Location = new Point(283, 96);
            lab_targetarea.Name = "lab_targetarea";
            lab_targetarea.Size = new Size(75, 15);
            lab_targetarea.TabIndex = 42;
            lab_targetarea.Text = "Target_Area";
            // 
            // cbx_targetmodule
            // 
            cbx_targetmodule.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_targetmodule.FormattingEnabled = true;
            cbx_targetmodule.Location = new Point(117, 88);
            cbx_targetmodule.Name = "cbx_targetmodule";
            cbx_targetmodule.Size = new Size(148, 23);
            cbx_targetmodule.TabIndex = 41;
            cbx_targetmodule.SelectedIndexChanged += cbx_targetmodule_SelectedIndexChanged;
            // 
            // lab_targetmodule
            // 
            lab_targetmodule.AutoSize = true;
            lab_targetmodule.Location = new Point(16, 96);
            lab_targetmodule.Name = "lab_targetmodule";
            lab_targetmodule.Size = new Size(94, 15);
            lab_targetmodule.TabIndex = 40;
            lab_targetmodule.Text = "Target_Module";
            // 
            // tbx_resultMsg
            // 
            tbx_resultMsg.Location = new Point(6, 342);
            tbx_resultMsg.Multiline = true;
            tbx_resultMsg.Name = "tbx_resultMsg";
            tbx_resultMsg.ScrollBars = ScrollBars.Both;
            tbx_resultMsg.Size = new Size(767, 206);
            tbx_resultMsg.TabIndex = 39;
            tbx_resultMsg.TextChanged += tbx_resultMsg_TextChanged;
            // 
            // cbx_fromprogram
            // 
            cbx_fromprogram.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_fromprogram.FormattingEnabled = true;
            cbx_fromprogram.Location = new Point(619, 50);
            cbx_fromprogram.Name = "cbx_fromprogram";
            cbx_fromprogram.Size = new Size(148, 23);
            cbx_fromprogram.TabIndex = 38;
            cbx_fromprogram.SelectedIndexChanged += cbx_fromprogram_SelectedIndexChanged;
            // 
            // lab_fromprogram
            // 
            lab_fromprogram.AutoSize = true;
            lab_fromprogram.Location = new Point(526, 58);
            lab_fromprogram.Name = "lab_fromprogram";
            lab_fromprogram.Size = new Size(90, 15);
            lab_fromprogram.TabIndex = 37;
            lab_fromprogram.Text = "From_Program";
            // 
            // cbx_fromarea
            // 
            cbx_fromarea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_fromarea.FormattingEnabled = true;
            cbx_fromarea.Location = new Point(356, 50);
            cbx_fromarea.Name = "cbx_fromarea";
            cbx_fromarea.Size = new Size(148, 23);
            cbx_fromarea.TabIndex = 36;
            cbx_fromarea.SelectedIndexChanged += cbx_fromarea_SelectedIndexChanged;
            // 
            // lab_fromarea
            // 
            lab_fromarea.AutoSize = true;
            lab_fromarea.Location = new Point(283, 58);
            lab_fromarea.Name = "lab_fromarea";
            lab_fromarea.Size = new Size(67, 15);
            lab_fromarea.TabIndex = 35;
            lab_fromarea.Text = "From_Area";
            // 
            // cbx_frommodule
            // 
            cbx_frommodule.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_frommodule.FormattingEnabled = true;
            cbx_frommodule.Location = new Point(117, 50);
            cbx_frommodule.Name = "cbx_frommodule";
            cbx_frommodule.Size = new Size(148, 23);
            cbx_frommodule.TabIndex = 34;
            cbx_frommodule.SelectedIndexChanged += cbx_frommodule_SelectedIndexChanged;
            // 
            // lab_module
            // 
            lab_module.AutoSize = true;
            lab_module.Location = new Point(16, 58);
            lab_module.Name = "lab_module";
            lab_module.Size = new Size(86, 15);
            lab_module.TabIndex = 33;
            lab_module.Text = "From_Module";
            // 
            // lab_projectpath
            // 
            lab_projectpath.AutoSize = true;
            lab_projectpath.Location = new Point(16, 22);
            lab_projectpath.Name = "lab_projectpath";
            lab_projectpath.Size = new Size(71, 15);
            lab_projectpath.TabIndex = 32;
            lab_projectpath.Text = "ProjectPath";
            // 
            // btn_selectpath
            // 
            btn_selectpath.Location = new Point(511, 14);
            btn_selectpath.Name = "btn_selectpath";
            btn_selectpath.Size = new Size(75, 23);
            btn_selectpath.TabIndex = 31;
            btn_selectpath.Text = "Select";
            btn_selectpath.UseVisualStyleBackColor = true;
            btn_selectpath.Click += btn_selectpath_Click;
            // 
            // tbx_projectpath
            // 
            tbx_projectpath.Location = new Point(117, 14);
            tbx_projectpath.Name = "tbx_projectpath";
            tbx_projectpath.Size = new Size(388, 23);
            tbx_projectpath.TabIndex = 30;
            tbx_projectpath.Text = ".\\dlp-develop";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnl_tab2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(789, 570);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "DoGoRo";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnl_tab2
            // 
            pnl_tab2.Controls.Add(grb_tab2_dbselect);
            pnl_tab2.Controls.Add(btn_IMultLanguage);
            pnl_tab2.Controls.Add(tbx_tab2_resultMsg);
            pnl_tab2.Controls.Add(lab_tab2_projectpath);
            pnl_tab2.Controls.Add(btn_tab2_selectpath);
            pnl_tab2.Controls.Add(tbx_tab2_projectpath);
            pnl_tab2.Controls.Add(btn_gettranslate);
            pnl_tab2.Controls.Add(dgv_tab2_languagetranslate);
            pnl_tab2.Controls.Add(cbx_tab2_fromprogram);
            pnl_tab2.Controls.Add(lab_tab2_fromprogram);
            pnl_tab2.Controls.Add(cbx_tab2_fromarea);
            pnl_tab2.Controls.Add(lab_atb2_fromarea);
            pnl_tab2.Controls.Add(cbx_tab2_frommodule);
            pnl_tab2.Controls.Add(lab_tab2_module);
            pnl_tab2.Dock = DockStyle.Fill;
            pnl_tab2.Location = new Point(3, 3);
            pnl_tab2.Name = "pnl_tab2";
            pnl_tab2.Size = new Size(783, 564);
            pnl_tab2.TabIndex = 0;
            // 
            // grb_tab2_dbselect
            // 
            grb_tab2_dbselect.Controls.Add(cbx_vndb);
            grb_tab2_dbselect.Controls.Add(cbx_dgdb);
            grb_tab2_dbselect.Controls.Add(cbx_tcdb);
            grb_tab2_dbselect.Controls.Add(cbx_vsdb);
            grb_tab2_dbselect.Controls.Add(cbx_vgdb);
            grb_tab2_dbselect.Location = new Point(151, 76);
            grb_tab2_dbselect.Name = "grb_tab2_dbselect";
            grb_tab2_dbselect.Size = new Size(201, 102);
            grb_tab2_dbselect.TabIndex = 60;
            grb_tab2_dbselect.TabStop = false;
            grb_tab2_dbselect.Text = "Select DB";
            // 
            // cbx_vndb
            // 
            cbx_vndb.AutoSize = true;
            cbx_vndb.Location = new Point(6, 47);
            cbx_vndb.Name = "cbx_vndb";
            cbx_vndb.Size = new Size(60, 19);
            cbx_vndb.TabIndex = 60;
            cbx_vndb.Text = "VNDB";
            cbx_vndb.UseVisualStyleBackColor = true;
            cbx_vndb.Click += cbx_vndb_Click;
            // 
            // cbx_dgdb
            // 
            cbx_dgdb.AutoSize = true;
            cbx_dgdb.Location = new Point(6, 22);
            cbx_dgdb.Name = "cbx_dgdb";
            cbx_dgdb.Size = new Size(60, 19);
            cbx_dgdb.TabIndex = 56;
            cbx_dgdb.Text = "DGDB";
            cbx_dgdb.UseVisualStyleBackColor = true;
            cbx_dgdb.Click += cbx_dgdb_Click;
            // 
            // cbx_tcdb
            // 
            cbx_tcdb.AutoSize = true;
            cbx_tcdb.Location = new Point(107, 22);
            cbx_tcdb.Name = "cbx_tcdb";
            cbx_tcdb.Size = new Size(57, 19);
            cbx_tcdb.TabIndex = 59;
            cbx_tcdb.Text = "TCDB";
            cbx_tcdb.UseVisualStyleBackColor = true;
            cbx_tcdb.Click += cbx_tcdb_Click;
            // 
            // cbx_vsdb
            // 
            cbx_vsdb.AutoSize = true;
            cbx_vsdb.Location = new Point(6, 72);
            cbx_vsdb.Name = "cbx_vsdb";
            cbx_vsdb.Size = new Size(57, 19);
            cbx_vsdb.TabIndex = 57;
            cbx_vsdb.Text = "VSDB";
            cbx_vsdb.UseVisualStyleBackColor = true;
            cbx_vsdb.Click += cbx_vsdb_Click;
            // 
            // cbx_vgdb
            // 
            cbx_vgdb.AutoSize = true;
            cbx_vgdb.Location = new Point(107, 47);
            cbx_vgdb.Name = "cbx_vgdb";
            cbx_vgdb.Size = new Size(59, 19);
            cbx_vgdb.TabIndex = 58;
            cbx_vgdb.Text = "VGDB";
            cbx_vgdb.UseVisualStyleBackColor = true;
            cbx_vgdb.Click += cbx_vgdb_Click;
            // 
            // btn_IMultLanguage
            // 
            btn_IMultLanguage.Location = new Point(13, 134);
            btn_IMultLanguage.Name = "btn_IMultLanguage";
            btn_IMultLanguage.Size = new Size(132, 44);
            btn_IMultLanguage.TabIndex = 55;
            btn_IMultLanguage.Text = "Insert MultiLanguage";
            btn_IMultLanguage.UseVisualStyleBackColor = true;
            btn_IMultLanguage.Click += btn_IMultLanguage_Click;
            // 
            // tbx_tab2_resultMsg
            // 
            tbx_tab2_resultMsg.Location = new Point(358, 84);
            tbx_tab2_resultMsg.Multiline = true;
            tbx_tab2_resultMsg.Name = "tbx_tab2_resultMsg";
            tbx_tab2_resultMsg.ScrollBars = ScrollBars.Both;
            tbx_tab2_resultMsg.Size = new Size(411, 124);
            tbx_tab2_resultMsg.TabIndex = 53;
            tbx_tab2_resultMsg.TextChanged += tbx_tab2_resultMsg_TextChanged;
            // 
            // lab_tab2_projectpath
            // 
            lab_tab2_projectpath.AutoSize = true;
            lab_tab2_projectpath.Location = new Point(18, 22);
            lab_tab2_projectpath.Name = "lab_tab2_projectpath";
            lab_tab2_projectpath.Size = new Size(71, 15);
            lab_tab2_projectpath.TabIndex = 52;
            lab_tab2_projectpath.Text = "ProjectPath";
            // 
            // btn_tab2_selectpath
            // 
            btn_tab2_selectpath.Location = new Point(513, 14);
            btn_tab2_selectpath.Name = "btn_tab2_selectpath";
            btn_tab2_selectpath.Size = new Size(75, 23);
            btn_tab2_selectpath.TabIndex = 51;
            btn_tab2_selectpath.Text = "Select";
            btn_tab2_selectpath.UseVisualStyleBackColor = true;
            btn_tab2_selectpath.Click += btn_tab2_selectpath_Click;
            // 
            // tbx_tab2_projectpath
            // 
            tbx_tab2_projectpath.Location = new Point(119, 14);
            tbx_tab2_projectpath.Name = "tbx_tab2_projectpath";
            tbx_tab2_projectpath.Size = new Size(388, 23);
            tbx_tab2_projectpath.TabIndex = 50;
            tbx_tab2_projectpath.Text = ".\\dlp-develop";
            // 
            // btn_gettranslate
            // 
            btn_gettranslate.Location = new Point(13, 84);
            btn_gettranslate.Name = "btn_gettranslate";
            btn_gettranslate.Size = new Size(132, 44);
            btn_gettranslate.TabIndex = 49;
            btn_gettranslate.Text = "Get Translate";
            btn_gettranslate.UseVisualStyleBackColor = true;
            btn_gettranslate.Click += btn_gettranslate_Click;
            // 
            // dgv_tab2_languagetranslate
            // 
            dgv_tab2_languagetranslate.AllowUserToAddRows = false;
            dgv_tab2_languagetranslate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_tab2_languagetranslate.Columns.AddRange(new DataGridViewColumn[] { tw, zh, en, vi });
            dgv_tab2_languagetranslate.Location = new Point(3, 214);
            dgv_tab2_languagetranslate.Name = "dgv_tab2_languagetranslate";
            dgv_tab2_languagetranslate.RowTemplate.Height = 25;
            dgv_tab2_languagetranslate.Size = new Size(766, 353);
            dgv_tab2_languagetranslate.TabIndex = 48;
            dgv_tab2_languagetranslate.CellMouseUp += dgv_tab2_languagetranslate_CellMouseUp;
            // 
            // tw
            // 
            tw.HeaderText = "繁體中文";
            tw.Name = "tw";
            tw.Width = 250;
            // 
            // zh
            // 
            zh.HeaderText = "簡體中文";
            zh.Name = "zh";
            zh.Width = 150;
            // 
            // en
            // 
            en.HeaderText = "英文";
            en.Name = "en";
            en.Width = 150;
            // 
            // vi
            // 
            vi.HeaderText = "越南文";
            vi.Name = "vi";
            vi.Width = 150;
            // 
            // cbx_tab2_fromprogram
            // 
            cbx_tab2_fromprogram.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_tab2_fromprogram.FormattingEnabled = true;
            cbx_tab2_fromprogram.Location = new Point(621, 47);
            cbx_tab2_fromprogram.Name = "cbx_tab2_fromprogram";
            cbx_tab2_fromprogram.Size = new Size(148, 23);
            cbx_tab2_fromprogram.TabIndex = 47;
            // 
            // lab_tab2_fromprogram
            // 
            lab_tab2_fromprogram.AutoSize = true;
            lab_tab2_fromprogram.Location = new Point(528, 55);
            lab_tab2_fromprogram.Name = "lab_tab2_fromprogram";
            lab_tab2_fromprogram.Size = new Size(90, 15);
            lab_tab2_fromprogram.TabIndex = 46;
            lab_tab2_fromprogram.Text = "From_Program";
            // 
            // cbx_tab2_fromarea
            // 
            cbx_tab2_fromarea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_tab2_fromarea.FormattingEnabled = true;
            cbx_tab2_fromarea.Location = new Point(358, 47);
            cbx_tab2_fromarea.Name = "cbx_tab2_fromarea";
            cbx_tab2_fromarea.Size = new Size(148, 23);
            cbx_tab2_fromarea.TabIndex = 45;
            cbx_tab2_fromarea.SelectedIndexChanged += cbx_tab2_fromarea_SelectedIndexChanged;
            // 
            // lab_atb2_fromarea
            // 
            lab_atb2_fromarea.AutoSize = true;
            lab_atb2_fromarea.Location = new Point(285, 55);
            lab_atb2_fromarea.Name = "lab_atb2_fromarea";
            lab_atb2_fromarea.Size = new Size(67, 15);
            lab_atb2_fromarea.TabIndex = 44;
            lab_atb2_fromarea.Text = "From_Area";
            // 
            // cbx_tab2_frommodule
            // 
            cbx_tab2_frommodule.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_tab2_frommodule.FormattingEnabled = true;
            cbx_tab2_frommodule.Location = new Point(119, 47);
            cbx_tab2_frommodule.Name = "cbx_tab2_frommodule";
            cbx_tab2_frommodule.Size = new Size(148, 23);
            cbx_tab2_frommodule.TabIndex = 43;
            cbx_tab2_frommodule.SelectedIndexChanged += cbx_tab2_frommodule_SelectedIndexChanged;
            // 
            // lab_tab2_module
            // 
            lab_tab2_module.AutoSize = true;
            lab_tab2_module.Location = new Point(18, 55);
            lab_tab2_module.Name = "lab_tab2_module";
            lab_tab2_module.Size = new Size(86, 15);
            lab_tab2_module.TabIndex = 42;
            lab_tab2_module.Text = "From_Module";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dGV_innerObj);
            tabPage3.Controls.Add(textBoxResults);
            tabPage3.Controls.Add(btn_run);
            tabPage3.Controls.Add(btn_clearMessege);
            tabPage3.Controls.Add(dGdVwHeaders);
            tabPage3.Controls.Add(lstVwSubItems);
            tabPage3.Controls.Add(btnPath);
            tabPage3.Controls.Add(txtSelectPath);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(789, 570);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ColDef";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dGV_innerObj
            // 
            dGV_innerObj.AllowUserToAddRows = false;
            dGV_innerObj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dGV_innerObj.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_innerObj.Location = new Point(3, 368);
            dGV_innerObj.Name = "dGV_innerObj";
            dGV_innerObj.RowTemplate.Height = 25;
            dGV_innerObj.Size = new Size(783, 187);
            dGV_innerObj.TabIndex = 14;
            dGV_innerObj.Visible = false;
            // 
            // textBoxResults
            // 
            textBoxResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxResults.Location = new Point(6, 361);
            textBoxResults.Multiline = true;
            textBoxResults.Name = "textBoxResults";
            textBoxResults.ScrollBars = ScrollBars.Both;
            textBoxResults.Size = new Size(777, 203);
            textBoxResults.TabIndex = 7;
            // 
            // btn_run
            // 
            btn_run.Location = new Point(587, 14);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(89, 56);
            btn_run.TabIndex = 13;
            btn_run.Text = "執行";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // btn_clearMessege
            // 
            btn_clearMessege.Location = new Point(494, 14);
            btn_clearMessege.Name = "btn_clearMessege";
            btn_clearMessege.Size = new Size(87, 56);
            btn_clearMessege.TabIndex = 12;
            btn_clearMessege.Text = "清MSG";
            btn_clearMessege.UseVisualStyleBackColor = true;
            btn_clearMessege.Click += btn_clearMessege_Click;
            // 
            // dGdVwHeaders
            // 
            dGdVwHeaders.AllowUserToAddRows = false;
            dGdVwHeaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGdVwHeaders.Columns.AddRange(new DataGridViewColumn[] { Index, Type });
            dGdVwHeaders.Location = new Point(6, 76);
            dGdVwHeaders.Name = "dGdVwHeaders";
            dGdVwHeaders.RowTemplate.Height = 25;
            dGdVwHeaders.Size = new Size(181, 279);
            dGdVwHeaders.TabIndex = 11;
            dGdVwHeaders.CellMouseDown += dGdVwHeaders_CellMouseDown;
            dGdVwHeaders.SelectionChanged += dGdVwHeaders_SelectionChanged;
            // 
            // Index
            // 
            Index.HeaderText = "區段代號";
            Index.Name = "Index";
            Index.ReadOnly = true;
            Index.Width = 60;
            // 
            // Type
            // 
            Type.HeaderText = "Model類型";
            Type.Name = "Type";
            Type.ToolTipText = "111";
            Type.Width = 70;
            // 
            // lstVwSubItems
            // 
            lstVwSubItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstVwSubItems.GridLines = true;
            lstVwSubItems.Location = new Point(193, 76);
            lstVwSubItems.Name = "lstVwSubItems";
            lstVwSubItems.Size = new Size(590, 279);
            lstVwSubItems.TabIndex = 10;
            lstVwSubItems.UseCompatibleStateImageBehavior = false;
            lstVwSubItems.ItemCheck += lstVwSubItems_ItemCheck;
            // 
            // btnPath
            // 
            btnPath.Location = new Point(396, 14);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(92, 56);
            btnPath.TabIndex = 9;
            btnPath.Text = "選文字檔";
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // txtSelectPath
            // 
            txtSelectPath.Location = new Point(6, 14);
            txtSelectPath.Multiline = true;
            txtSelectPath.Name = "txtSelectPath";
            txtSelectPath.Size = new Size(384, 56);
            txtSelectPath.TabIndex = 8;
            // 
            // tim_tab2
            // 
            tim_tab2.Enabled = true;
            tim_tab2.Interval = 1000;
            tim_tab2.Tick += tim_tab2_Tick;
            // 
            // cmt_tab2_deleterow
            // 
            cmt_tab2_deleterow.Items.AddRange(new ToolStripItem[] { delectRowToolStripMenuItem });
            cmt_tab2_deleterow.Name = "cmt_tab2_deleterow";
            cmt_tab2_deleterow.Size = new Size(140, 26);
            cmt_tab2_deleterow.Click += cmt_tab2_deleterow_Click;
            // 
            // delectRowToolStripMenuItem
            // 
            delectRowToolStripMenuItem.Name = "delectRowToolStripMenuItem";
            delectRowToolStripMenuItem.Size = new Size(139, 22);
            delectRowToolStripMenuItem.Text = "Delete Row";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(797, 604);
            Controls.Add(tbc_main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "SunDiTool";
            Load += Form1_Load;
            tbc_main.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            pnl_tab1.ResumeLayout(false);
            pnl_tab1.PerformLayout();
            groupBox1.ResumeLayout(false);
            grb_Backend.ResumeLayout(false);
            grb_Frontend.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            pnl_tab2.ResumeLayout(false);
            pnl_tab2.PerformLayout();
            grb_tab2_dbselect.ResumeLayout(false);
            grb_tab2_dbselect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_tab2_languagetranslate).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_innerObj).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGdVwHeaders).EndInit();
            cmt_tab2_deleterow.ResumeLayout(false);
            ResumeLayout(false);
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
        private CheckBox cbx_dgdb;
        private CheckBox cbx_tcdb;
        private CheckBox cbx_vsdb;
        private CheckBox cbx_vgdb;
        private System.Windows.Forms.Timer tim_tab2;
        private DataGridViewTextBoxColumn tw;
        private DataGridViewTextBoxColumn zh;
        private DataGridViewTextBoxColumn en;
        private DataGridViewTextBoxColumn vi;
        private ContextMenuStrip cmt_tab2_deleterow;
        private ToolStripMenuItem delectRowToolStripMenuItem;
        private CheckBox cbx_vndb;
        private CheckBox cbx_copydiff;
        private TabPage tabPage3;
        private DataGridView dGV_innerObj;
        private TextBox textBoxResults;
        private Button btn_run;
        private Button btn_clearMessege;
        private DataGridView dGdVwHeaders;
        private ListView lstVwSubItems;
        private Button btnPath;
        private TextBox txtSelectPath;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewTextBoxColumn Type;
    }
}