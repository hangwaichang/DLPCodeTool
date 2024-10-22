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
			tabPage5 = new TabPage();
			btn_line_notify_test = new Button();
			lab_line_token = new Label();
			txtLineNotifyToken = new TextBox();
			lab_gitlab_userid = new Label();
			lab_gitlab_token = new Label();
			txtUserId = new TextBox();
			txtToken = new TextBox();
			lab_tab1_notice = new Label();
			lab_setting_frontendpath = new Label();
			btn_setting_selectfrontendpath = new Button();
			tbx_setting_frontendpath = new TextBox();
			lab_setting_projectpath = new Label();
			btn_setting_selectpath = new Button();
			tbx_setting_projectpath = new TextBox();
			tabPage1 = new TabPage();
			pnl_tab1 = new Panel();
			cbx_iswo = new CheckBox();
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
			lab_atb2_fromarea = new Label();
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
			cbx_tab2_frommodule = new ComboBox();
			lab_tab2_module = new Label();
			tabPage3 = new TabPage();
			btn_othercolumn = new Button();
			chk_Gridtype = new CheckBox();
			comboBox1 = new ComboBox();
			dGV_innerObj = new DataGridView();
			textBoxResults = new TextBox();
			btn_run = new Button();
			btn_clearMessege = new Button();
			dGdVwHeaders = new DataGridView();
			Index = new DataGridViewTextBoxColumn();
			Type = new DataGridViewComboBoxColumn();
			lstVwSubItems = new ListView();
			btnPath = new Button();
			txtSelectPath = new TextBox();
			tabPage4 = new TabPage();
			tbx_APIGo_resultMsg = new TextBox();
			grb_front_end = new GroupBox();
			btn_move2develop = new Button();
			dgv_component_list = new DataGridView();
			Col_Check = new DataGridViewCheckBoxColumn();
			Col_Component = new DataGridViewTextBoxColumn();
			Col_Version = new DataGridViewTextBoxColumn();
			Col_OldVersion = new DataGridViewTextBoxColumn();
			btn_com_movekill = new Button();
			btn_install_component = new Button();
			btn_ng_build = new Button();
			btn_dotnet_close_all = new Button();
			cbx_DV = new CheckBox();
			cbx_PM = new CheckBox();
			cbx_MP = new CheckBox();
			cbx_WO = new CheckBox();
			cbx_XX = new CheckBox();
			cbx_OA = new CheckBox();
			cbx_MI = new CheckBox();
			cbx_MG = new CheckBox();
			cbx_MD = new CheckBox();
			cbx_SD = new CheckBox();
			cbx_SingnalR = new CheckBox();
			cbx_AppPortal = new CheckBox();
			btn_dotnet_run = new Button();
			tabPage6 = new TabPage();
			lab_mr_status = new Label();
			lab_timer_status = new Label();
			btn_detect_pipeline = new Button();
			textBox1 = new TextBox();
			btn_getMRinfo = new Button();
			btnCreateMergeRequest = new Button();
			lab_tab6_notice = new Label();
			btn_cancel_reserve = new Button();
			cbx_tab6_vn = new CheckBox();
			cbx_tab6_tc = new CheckBox();
			cbx_tab6_dg = new CheckBox();
			btn_reserve = new Button();
			tbx_tab6_resultMsg = new TextBox();
			cbx_tab6_branch = new ComboBox();
			lab_tab6_branch = new Label();
			lab_tab6_checkTime = new Label();
			dtp_checkTime = new DateTimePicker();
			tabPage7 = new TabPage();
			tbx_tab7_Program = new TextBox();
			dgv_tab7_sqlanalyze = new DataGridView();
			tableDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			queryDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			insertDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			updateDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			deleteDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			joinDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			sqlAnalyzeBindingSource = new BindingSource(components);
			btn_dbconnect = new Button();
			btn_sqlanalyze = new Button();
			tbx_tab7_resultMsg = new TextBox();
			lab_atb7_fromarea = new Label();
			lab_tab7_fromprogram = new Label();
			cbx_tab7_fromarea = new ComboBox();
			tim_tab2 = new System.Windows.Forms.Timer(components);
			cmt_tab2_deleterow = new ContextMenuStrip(components);
			delectRowToolStripMenuItem = new ToolStripMenuItem();
			oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
			tim_tab6_reservecheck = new System.Windows.Forms.Timer(components);
			contextMenuStrip1 = new ContextMenuStrip(components);
			tim_pipelinecheck = new System.Windows.Forms.Timer(components);
			tbc_main.SuspendLayout();
			tabPage5.SuspendLayout();
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
			tabPage4.SuspendLayout();
			grb_front_end.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv_component_list).BeginInit();
			tabPage6.SuspendLayout();
			tabPage7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv_tab7_sqlanalyze).BeginInit();
			((System.ComponentModel.ISupportInitialize)sqlAnalyzeBindingSource).BeginInit();
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
			tbc_main.Controls.Add(tabPage5);
			tbc_main.Controls.Add(tabPage1);
			tbc_main.Controls.Add(tabPage2);
			tbc_main.Controls.Add(tabPage3);
			tbc_main.Controls.Add(tabPage4);
			tbc_main.Controls.Add(tabPage6);
			tbc_main.Controls.Add(tabPage7);
			tbc_main.Location = new Point(-6, 3);
			tbc_main.Name = "tbc_main";
			tbc_main.SelectedIndex = 0;
			tbc_main.Size = new Size(797, 598);
			tbc_main.TabIndex = 30;
			tbc_main.Tag = "";
			tbc_main.SelectedIndexChanged += tbc_main_SelectedIndexChanged;
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(btn_line_notify_test);
			tabPage5.Controls.Add(lab_line_token);
			tabPage5.Controls.Add(txtLineNotifyToken);
			tabPage5.Controls.Add(lab_gitlab_userid);
			tabPage5.Controls.Add(lab_gitlab_token);
			tabPage5.Controls.Add(txtUserId);
			tabPage5.Controls.Add(txtToken);
			tabPage5.Controls.Add(lab_tab1_notice);
			tabPage5.Controls.Add(lab_setting_frontendpath);
			tabPage5.Controls.Add(btn_setting_selectfrontendpath);
			tabPage5.Controls.Add(tbx_setting_frontendpath);
			tabPage5.Controls.Add(lab_setting_projectpath);
			tabPage5.Controls.Add(btn_setting_selectpath);
			tabPage5.Controls.Add(tbx_setting_projectpath);
			tabPage5.Location = new Point(4, 24);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new Size(789, 570);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "Setting";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// btn_line_notify_test
			// 
			btn_line_notify_test.Location = new Point(381, 262);
			btn_line_notify_test.Name = "btn_line_notify_test";
			btn_line_notify_test.Size = new Size(75, 23);
			btn_line_notify_test.TabIndex = 64;
			btn_line_notify_test.Text = "test";
			btn_line_notify_test.UseVisualStyleBackColor = true;
			btn_line_notify_test.Visible = false;
			btn_line_notify_test.Click += btn_line_notify_test_Click;
			// 
			// lab_line_token
			// 
			lab_line_token.AutoSize = true;
			lab_line_token.Location = new Point(90, 265);
			lab_line_token.Name = "lab_line_token";
			lab_line_token.Size = new Size(106, 15);
			lab_line_token.TabIndex = 63;
			lab_line_token.Text = "Line Notify Token";
			lab_line_token.Visible = false;
			// 
			// txtLineNotifyToken
			// 
			txtLineNotifyToken.Location = new Point(201, 262);
			txtLineNotifyToken.Name = "txtLineNotifyToken";
			txtLineNotifyToken.Size = new Size(162, 23);
			txtLineNotifyToken.TabIndex = 62;
			txtLineNotifyToken.Visible = false;
			// 
			// lab_gitlab_userid
			// 
			lab_gitlab_userid.AutoSize = true;
			lab_gitlab_userid.Location = new Point(90, 236);
			lab_gitlab_userid.Name = "lab_gitlab_userid";
			lab_gitlab_userid.Size = new Size(84, 15);
			lab_gitlab_userid.TabIndex = 61;
			lab_gitlab_userid.Text = "GitLab UserID";
			// 
			// lab_gitlab_token
			// 
			lab_gitlab_token.AutoSize = true;
			lab_gitlab_token.Location = new Point(90, 207);
			lab_gitlab_token.Name = "lab_gitlab_token";
			lab_gitlab_token.Size = new Size(82, 15);
			lab_gitlab_token.TabIndex = 61;
			lab_gitlab_token.Text = "GitLab Token";
			// 
			// txtUserId
			// 
			txtUserId.Location = new Point(201, 233);
			txtUserId.Name = "txtUserId";
			txtUserId.Size = new Size(76, 23);
			txtUserId.TabIndex = 60;
			// 
			// txtToken
			// 
			txtToken.Location = new Point(201, 204);
			txtToken.Name = "txtToken";
			txtToken.Size = new Size(162, 23);
			txtToken.TabIndex = 60;
			// 
			// lab_tab1_notice
			// 
			lab_tab1_notice.CausesValidation = false;
			lab_tab1_notice.Font = new Font("新細明體", 20F, FontStyle.Bold, GraphicsUnit.Point);
			lab_tab1_notice.ForeColor = Color.Red;
			lab_tab1_notice.Location = new Point(17, 25);
			lab_tab1_notice.Name = "lab_tab1_notice";
			lab_tab1_notice.Size = new Size(521, 31);
			lab_tab1_notice.TabIndex = 59;
			lab_tab1_notice.Text = "前請先設定專案路徑";
			// 
			// lab_setting_frontendpath
			// 
			lab_setting_frontendpath.AutoSize = true;
			lab_setting_frontendpath.Location = new Point(19, 143);
			lab_setting_frontendpath.Name = "lab_setting_frontendpath";
			lab_setting_frontendpath.Size = new Size(160, 15);
			lab_setting_frontendpath.TabIndex = 58;
			lab_setting_frontendpath.Text = "ProjectPath (dlp-front-end)";
			// 
			// btn_setting_selectfrontendpath
			// 
			btn_setting_selectfrontendpath.Location = new Point(595, 135);
			btn_setting_selectfrontendpath.Name = "btn_setting_selectfrontendpath";
			btn_setting_selectfrontendpath.Size = new Size(75, 23);
			btn_setting_selectfrontendpath.TabIndex = 57;
			btn_setting_selectfrontendpath.Text = "Select";
			btn_setting_selectfrontendpath.UseVisualStyleBackColor = true;
			btn_setting_selectfrontendpath.Click += btn_setting_selectfrontendpath_Click;
			// 
			// tbx_setting_frontendpath
			// 
			tbx_setting_frontendpath.Location = new Point(201, 135);
			tbx_setting_frontendpath.Name = "tbx_setting_frontendpath";
			tbx_setting_frontendpath.Size = new Size(388, 23);
			tbx_setting_frontendpath.TabIndex = 56;
			tbx_setting_frontendpath.Text = "D:\\DLP_Git\\dlp-front-end";
			// 
			// lab_setting_projectpath
			// 
			lab_setting_projectpath.AutoSize = true;
			lab_setting_projectpath.Location = new Point(19, 83);
			lab_setting_projectpath.Name = "lab_setting_projectpath";
			lab_setting_projectpath.Size = new Size(153, 15);
			lab_setting_projectpath.TabIndex = 55;
			lab_setting_projectpath.Text = "ProjectPath (dlp-develop)";
			lab_setting_projectpath.Visible = false;
			// 
			// btn_setting_selectpath
			// 
			btn_setting_selectpath.Location = new Point(595, 80);
			btn_setting_selectpath.Name = "btn_setting_selectpath";
			btn_setting_selectpath.Size = new Size(75, 23);
			btn_setting_selectpath.TabIndex = 54;
			btn_setting_selectpath.Text = "Select";
			btn_setting_selectpath.UseVisualStyleBackColor = true;
			btn_setting_selectpath.Visible = false;
			btn_setting_selectpath.Click += btn_setting_selectpath_Click;
			// 
			// tbx_setting_projectpath
			// 
			tbx_setting_projectpath.Location = new Point(201, 80);
			tbx_setting_projectpath.Name = "tbx_setting_projectpath";
			tbx_setting_projectpath.Size = new Size(388, 23);
			tbx_setting_projectpath.TabIndex = 53;
			tbx_setting_projectpath.Text = ".\\dlp-develop";
			tbx_setting_projectpath.Visible = false;
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
			pnl_tab1.Controls.Add(cbx_iswo);
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
			// cbx_iswo
			// 
			cbx_iswo.AutoSize = true;
			cbx_iswo.Location = new Point(619, 25);
			cbx_iswo.Name = "cbx_iswo";
			cbx_iswo.Size = new Size(118, 19);
			cbx_iswo.TabIndex = 51;
			cbx_iswo.Text = "Copy WO Pages";
			cbx_iswo.UseVisualStyleBackColor = true;
			// 
			// cbx_copydiff
			// 
			cbx_copydiff.AutoSize = true;
			cbx_copydiff.Location = new Point(619, 3);
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
			pnl_tab2.Controls.Add(lab_atb2_fromarea);
			pnl_tab2.Controls.Add(tbx_tab2_projectpath);
			pnl_tab2.Controls.Add(btn_gettranslate);
			pnl_tab2.Controls.Add(dgv_tab2_languagetranslate);
			pnl_tab2.Controls.Add(cbx_tab2_fromprogram);
			pnl_tab2.Controls.Add(lab_tab2_fromprogram);
			pnl_tab2.Controls.Add(cbx_tab2_fromarea);
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
			// lab_atb2_fromarea
			// 
			lab_atb2_fromarea.AutoSize = true;
			lab_atb2_fromarea.Location = new Point(285, 55);
			lab_atb2_fromarea.Name = "lab_atb2_fromarea";
			lab_atb2_fromarea.Size = new Size(67, 15);
			lab_atb2_fromarea.TabIndex = 44;
			lab_atb2_fromarea.Text = "From_Area";
			// 
			// tbx_tab2_projectpath
			// 
			tbx_tab2_projectpath.Location = new Point(119, 14);
			tbx_tab2_projectpath.Name = "tbx_tab2_projectpath";
			tbx_tab2_projectpath.Size = new Size(388, 23);
			tbx_tab2_projectpath.TabIndex = 50;
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
			dgv_tab2_languagetranslate.RowHeadersWidth = 51;
			dgv_tab2_languagetranslate.RowTemplate.Height = 25;
			dgv_tab2_languagetranslate.Size = new Size(766, 353);
			dgv_tab2_languagetranslate.TabIndex = 48;
			dgv_tab2_languagetranslate.CellMouseUp += dgv_tab2_languagetranslate_CellMouseUp;
			// 
			// tw
			// 
			tw.HeaderText = "繁體中文";
			tw.MinimumWidth = 6;
			tw.Name = "tw";
			tw.Width = 250;
			// 
			// zh
			// 
			zh.HeaderText = "簡體中文";
			zh.MinimumWidth = 6;
			zh.Name = "zh";
			zh.Width = 150;
			// 
			// en
			// 
			en.HeaderText = "英文";
			en.MinimumWidth = 6;
			en.Name = "en";
			en.Width = 150;
			// 
			// vi
			// 
			vi.HeaderText = "越南文";
			vi.MinimumWidth = 6;
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
			tabPage3.Controls.Add(btn_othercolumn);
			tabPage3.Controls.Add(chk_Gridtype);
			tabPage3.Controls.Add(comboBox1);
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
			tabPage3.RightToLeft = RightToLeft.No;
			tabPage3.Size = new Size(789, 570);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "ColDef";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// btn_othercolumn
			// 
			btn_othercolumn.Location = new Point(494, 43);
			btn_othercolumn.Name = "btn_othercolumn";
			btn_othercolumn.Size = new Size(87, 26);
			btn_othercolumn.TabIndex = 17;
			btn_othercolumn.Text = "加其他欄位";
			btn_othercolumn.UseVisualStyleBackColor = true;
			btn_othercolumn.Click += btn_othercolumn_Click;
			// 
			// chk_Gridtype
			// 
			chk_Gridtype.AutoSize = true;
			chk_Gridtype.Checked = true;
			chk_Gridtype.CheckState = CheckState.Checked;
			chk_Gridtype.Location = new Point(682, 46);
			chk_Gridtype.Name = "chk_Gridtype";
			chk_Gridtype.Size = new Size(104, 19);
			chk_Gridtype.TabIndex = 16;
			chk_Gridtype.Text = "DlpGrid/Form";
			chk_Gridtype.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(694, 14);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(88, 23);
			comboBox1.TabIndex = 15;
			comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
			comboBox1.MouseLeave += comboBox1_MouseLeave;
			// 
			// dGV_innerObj
			// 
			dGV_innerObj.AllowUserToAddRows = false;
			dGV_innerObj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dGV_innerObj.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dGV_innerObj.Location = new Point(3, 438);
			dGV_innerObj.Name = "dGV_innerObj";
			dGV_innerObj.RowHeadersWidth = 51;
			dGV_innerObj.RowTemplate.Height = 25;
			dGV_innerObj.Size = new Size(783, 117);
			dGV_innerObj.TabIndex = 14;
			dGV_innerObj.Visible = false;
			// 
			// textBoxResults
			// 
			textBoxResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBoxResults.Location = new Point(6, 426);
			textBoxResults.Multiline = true;
			textBoxResults.Name = "textBoxResults";
			textBoxResults.ScrollBars = ScrollBars.Both;
			textBoxResults.Size = new Size(777, 137);
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
			btn_clearMessege.Size = new Size(87, 27);
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
			dGdVwHeaders.Location = new Point(6, 77);
			dGdVwHeaders.Name = "dGdVwHeaders";
			dGdVwHeaders.RowHeadersWidth = 51;
			dGdVwHeaders.RowTemplate.Height = 25;
			dGdVwHeaders.Size = new Size(236, 344);
			dGdVwHeaders.TabIndex = 11;
			dGdVwHeaders.CellMouseDown += dGdVwHeaders_CellMouseDown;
			dGdVwHeaders.SelectionChanged += dGdVwHeaders_SelectionChanged;
			// 
			// Index
			// 
			Index.HeaderText = "CANVAS";
			Index.MinimumWidth = 6;
			Index.Name = "Index";
			Index.ReadOnly = true;
			Index.Width = 70;
			// 
			// Type
			// 
			Type.HeaderText = "選擇類型(Grid/Form)";
			Type.Items.AddRange(new object[] { "", "Form", "Grid" });
			Type.MinimumWidth = 6;
			Type.Name = "Type";
			Type.Resizable = DataGridViewTriState.True;
			Type.SortMode = DataGridViewColumnSortMode.Automatic;
			Type.ToolTipText = "依據選擇產出，為空則不產出";
			Type.Width = 95;
			// 
			// lstVwSubItems
			// 
			lstVwSubItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstVwSubItems.GridLines = true;
			lstVwSubItems.Location = new Point(248, 76);
			lstVwSubItems.Name = "lstVwSubItems";
			lstVwSubItems.Size = new Size(534, 345);
			lstVwSubItems.TabIndex = 10;
			lstVwSubItems.UseCompatibleStateImageBehavior = false;
			lstVwSubItems.ItemCheck += lstVwSubItems_ItemCheck;
			lstVwSubItems.MouseUp += lstVwSubItems_MouseUp;
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
			// tabPage4
			// 
			tabPage4.Controls.Add(tbx_APIGo_resultMsg);
			tabPage4.Controls.Add(grb_front_end);
			tabPage4.Controls.Add(btn_dotnet_close_all);
			tabPage4.Controls.Add(cbx_DV);
			tabPage4.Controls.Add(cbx_PM);
			tabPage4.Controls.Add(cbx_MP);
			tabPage4.Controls.Add(cbx_WO);
			tabPage4.Controls.Add(cbx_XX);
			tabPage4.Controls.Add(cbx_OA);
			tabPage4.Controls.Add(cbx_MI);
			tabPage4.Controls.Add(cbx_MG);
			tabPage4.Controls.Add(cbx_MD);
			tabPage4.Controls.Add(cbx_SD);
			tabPage4.Controls.Add(cbx_SingnalR);
			tabPage4.Controls.Add(cbx_AppPortal);
			tabPage4.Controls.Add(btn_dotnet_run);
			tabPage4.Location = new Point(4, 24);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new Size(789, 570);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "APIGo";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// tbx_APIGo_resultMsg
			// 
			tbx_APIGo_resultMsg.Location = new Point(25, 369);
			tbx_APIGo_resultMsg.Multiline = true;
			tbx_APIGo_resultMsg.Name = "tbx_APIGo_resultMsg";
			tbx_APIGo_resultMsg.ScrollBars = ScrollBars.Both;
			tbx_APIGo_resultMsg.Size = new Size(736, 180);
			tbx_APIGo_resultMsg.TabIndex = 40;
			// 
			// grb_front_end
			// 
			grb_front_end.Controls.Add(btn_move2develop);
			grb_front_end.Controls.Add(dgv_component_list);
			grb_front_end.Controls.Add(btn_com_movekill);
			grb_front_end.Controls.Add(btn_install_component);
			grb_front_end.Controls.Add(btn_ng_build);
			grb_front_end.Location = new Point(25, 99);
			grb_front_end.Name = "grb_front_end";
			grb_front_end.Size = new Size(736, 264);
			grb_front_end.TabIndex = 14;
			grb_front_end.TabStop = false;
			grb_front_end.Text = "底層發粄工具";
			// 
			// btn_move2develop
			// 
			btn_move2develop.Location = new Point(459, 192);
			btn_move2develop.Name = "btn_move2develop";
			btn_move2develop.Size = new Size(116, 46);
			btn_move2develop.TabIndex = 19;
			btn_move2develop.Text = "Move To Develop";
			btn_move2develop.UseVisualStyleBackColor = true;
			btn_move2develop.Click += btn_move2develop_Click;
			// 
			// dgv_component_list
			// 
			dgv_component_list.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_component_list.Columns.AddRange(new DataGridViewColumn[] { Col_Check, Col_Component, Col_Version, Col_OldVersion });
			dgv_component_list.Location = new Point(6, 22);
			dgv_component_list.Name = "dgv_component_list";
			dgv_component_list.RowHeadersWidth = 51;
			dgv_component_list.RowTemplate.Height = 25;
			dgv_component_list.Size = new Size(724, 150);
			dgv_component_list.TabIndex = 18;
			// 
			// Col_Check
			// 
			Col_Check.DataPropertyName = "Check";
			Col_Check.HeaderText = "";
			Col_Check.MinimumWidth = 6;
			Col_Check.Name = "Col_Check";
			Col_Check.Width = 50;
			// 
			// Col_Component
			// 
			Col_Component.DataPropertyName = "ComponentName";
			Col_Component.HeaderText = "元件名稱";
			Col_Component.MinimumWidth = 6;
			Col_Component.Name = "Col_Component";
			Col_Component.ReadOnly = true;
			Col_Component.Width = 300;
			// 
			// Col_Version
			// 
			Col_Version.DataPropertyName = "NewVersion";
			Col_Version.HeaderText = "版本";
			Col_Version.MinimumWidth = 6;
			Col_Version.Name = "Col_Version";
			Col_Version.Width = 150;
			// 
			// Col_OldVersion
			// 
			Col_OldVersion.DataPropertyName = "OldVersion";
			Col_OldVersion.HeaderText = "OldVersion";
			Col_OldVersion.MinimumWidth = 6;
			Col_OldVersion.Name = "Col_OldVersion";
			Col_OldVersion.Visible = false;
			Col_OldVersion.Width = 125;
			// 
			// btn_com_movekill
			// 
			btn_com_movekill.Location = new Point(144, 192);
			btn_com_movekill.Name = "btn_com_movekill";
			btn_com_movekill.Size = new Size(116, 46);
			btn_com_movekill.TabIndex = 17;
			btn_com_movekill.Text = "Component Move Kill";
			btn_com_movekill.UseVisualStyleBackColor = true;
			btn_com_movekill.Click += btn_com_movekill_Click;
			// 
			// btn_install_component
			// 
			btn_install_component.Location = new Point(597, 192);
			btn_install_component.Name = "btn_install_component";
			btn_install_component.Size = new Size(116, 46);
			btn_install_component.TabIndex = 16;
			btn_install_component.Text = "Install Component";
			btn_install_component.UseVisualStyleBackColor = true;
			btn_install_component.Click += btn_install_component_Click;
			// 
			// btn_ng_build
			// 
			btn_ng_build.Location = new Point(6, 192);
			btn_ng_build.Name = "btn_ng_build";
			btn_ng_build.Size = new Size(116, 46);
			btn_ng_build.TabIndex = 15;
			btn_ng_build.Text = "ng build";
			btn_ng_build.UseVisualStyleBackColor = true;
			btn_ng_build.Click += btn_ng_build_Click;
			// 
			// btn_dotnet_close_all
			// 
			btn_dotnet_close_all.Location = new Point(622, 26);
			btn_dotnet_close_all.Name = "btn_dotnet_close_all";
			btn_dotnet_close_all.Size = new Size(116, 46);
			btn_dotnet_close_all.TabIndex = 13;
			btn_dotnet_close_all.Text = "Close All";
			btn_dotnet_close_all.UseVisualStyleBackColor = true;
			btn_dotnet_close_all.Click += btn_dotnet_close_all_Click;
			// 
			// cbx_DV
			// 
			cbx_DV.AutoSize = true;
			cbx_DV.Location = new Point(412, 62);
			cbx_DV.Name = "cbx_DV";
			cbx_DV.Size = new Size(43, 19);
			cbx_DV.TabIndex = 12;
			cbx_DV.Text = "DV";
			cbx_DV.UseVisualStyleBackColor = true;
			// 
			// cbx_PM
			// 
			cbx_PM.AutoSize = true;
			cbx_PM.Location = new Point(348, 62);
			cbx_PM.Name = "cbx_PM";
			cbx_PM.Size = new Size(45, 19);
			cbx_PM.TabIndex = 11;
			cbx_PM.Text = "PM";
			cbx_PM.UseVisualStyleBackColor = true;
			// 
			// cbx_MP
			// 
			cbx_MP.AutoSize = true;
			cbx_MP.Location = new Point(284, 26);
			cbx_MP.Name = "cbx_MP";
			cbx_MP.Size = new Size(45, 19);
			cbx_MP.TabIndex = 10;
			cbx_MP.Text = "MP";
			cbx_MP.UseVisualStyleBackColor = true;
			// 
			// cbx_WO
			// 
			cbx_WO.AutoSize = true;
			cbx_WO.Location = new Point(139, 26);
			cbx_WO.Name = "cbx_WO";
			cbx_WO.Size = new Size(48, 19);
			cbx_WO.TabIndex = 9;
			cbx_WO.Text = "WO";
			cbx_WO.UseVisualStyleBackColor = true;
			// 
			// cbx_XX
			// 
			cbx_XX.AutoSize = true;
			cbx_XX.Location = new Point(412, 26);
			cbx_XX.Name = "cbx_XX";
			cbx_XX.Size = new Size(42, 19);
			cbx_XX.TabIndex = 8;
			cbx_XX.Text = "XX";
			cbx_XX.UseVisualStyleBackColor = true;
			// 
			// cbx_OA
			// 
			cbx_OA.AutoSize = true;
			cbx_OA.Location = new Point(139, 62);
			cbx_OA.Name = "cbx_OA";
			cbx_OA.Size = new Size(44, 19);
			cbx_OA.TabIndex = 7;
			cbx_OA.Text = "OA";
			cbx_OA.UseVisualStyleBackColor = true;
			// 
			// cbx_MI
			// 
			cbx_MI.AutoSize = true;
			cbx_MI.Location = new Point(284, 62);
			cbx_MI.Name = "cbx_MI";
			cbx_MI.Size = new Size(41, 19);
			cbx_MI.TabIndex = 6;
			cbx_MI.Text = "MI";
			cbx_MI.UseVisualStyleBackColor = true;
			// 
			// cbx_MG
			// 
			cbx_MG.AutoSize = true;
			cbx_MG.Location = new Point(348, 26);
			cbx_MG.Name = "cbx_MG";
			cbx_MG.Size = new Size(47, 19);
			cbx_MG.TabIndex = 5;
			cbx_MG.Text = "MG";
			cbx_MG.UseVisualStyleBackColor = true;
			// 
			// cbx_MD
			// 
			cbx_MD.AutoSize = true;
			cbx_MD.Location = new Point(210, 62);
			cbx_MD.Name = "cbx_MD";
			cbx_MD.Size = new Size(47, 19);
			cbx_MD.TabIndex = 4;
			cbx_MD.Text = "MD";
			cbx_MD.UseVisualStyleBackColor = true;
			// 
			// cbx_SD
			// 
			cbx_SD.AutoSize = true;
			cbx_SD.Location = new Point(210, 26);
			cbx_SD.Name = "cbx_SD";
			cbx_SD.Size = new Size(42, 19);
			cbx_SD.TabIndex = 3;
			cbx_SD.Text = "SD";
			cbx_SD.UseVisualStyleBackColor = true;
			// 
			// cbx_SingnalR
			// 
			cbx_SingnalR.AutoSize = true;
			cbx_SingnalR.Location = new Point(25, 62);
			cbx_SingnalR.Name = "cbx_SingnalR";
			cbx_SingnalR.Size = new Size(69, 19);
			cbx_SingnalR.TabIndex = 2;
			cbx_SingnalR.Text = "SignalR";
			cbx_SingnalR.UseVisualStyleBackColor = true;
			// 
			// cbx_AppPortal
			// 
			cbx_AppPortal.AutoSize = true;
			cbx_AppPortal.Location = new Point(25, 26);
			cbx_AppPortal.Name = "cbx_AppPortal";
			cbx_AppPortal.Size = new Size(83, 19);
			cbx_AppPortal.TabIndex = 1;
			cbx_AppPortal.Text = "AppPortal";
			cbx_AppPortal.UseVisualStyleBackColor = true;
			// 
			// btn_dotnet_run
			// 
			btn_dotnet_run.Location = new Point(484, 26);
			btn_dotnet_run.Name = "btn_dotnet_run";
			btn_dotnet_run.Size = new Size(116, 46);
			btn_dotnet_run.TabIndex = 0;
			btn_dotnet_run.Text = "Dotnet Run";
			btn_dotnet_run.UseVisualStyleBackColor = true;
			btn_dotnet_run.Click += btn_base_api_Click;
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(lab_mr_status);
			tabPage6.Controls.Add(lab_timer_status);
			tabPage6.Controls.Add(btn_detect_pipeline);
			tabPage6.Controls.Add(textBox1);
			tabPage6.Controls.Add(btn_getMRinfo);
			tabPage6.Controls.Add(btnCreateMergeRequest);
			tabPage6.Controls.Add(lab_tab6_notice);
			tabPage6.Controls.Add(btn_cancel_reserve);
			tabPage6.Controls.Add(cbx_tab6_vn);
			tabPage6.Controls.Add(cbx_tab6_tc);
			tabPage6.Controls.Add(cbx_tab6_dg);
			tabPage6.Controls.Add(btn_reserve);
			tabPage6.Controls.Add(tbx_tab6_resultMsg);
			tabPage6.Controls.Add(cbx_tab6_branch);
			tabPage6.Controls.Add(lab_tab6_branch);
			tabPage6.Controls.Add(lab_tab6_checkTime);
			tabPage6.Controls.Add(dtp_checkTime);
			tabPage6.Location = new Point(4, 24);
			tabPage6.Name = "tabPage6";
			tabPage6.Padding = new Padding(3);
			tabPage6.Size = new Size(789, 570);
			tabPage6.TabIndex = 5;
			tabPage6.Text = "PokemonGo";
			tabPage6.UseVisualStyleBackColor = true;
			// 
			// lab_mr_status
			// 
			lab_mr_status.Location = new Point(508, 163);
			lab_mr_status.Name = "lab_mr_status";
			lab_mr_status.RightToLeft = RightToLeft.No;
			lab_mr_status.Size = new Size(119, 21);
			lab_mr_status.TabIndex = 53;
			lab_mr_status.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lab_timer_status
			// 
			lab_timer_status.Location = new Point(508, 225);
			lab_timer_status.Name = "lab_timer_status";
			lab_timer_status.RightToLeft = RightToLeft.No;
			lab_timer_status.Size = new Size(119, 21);
			lab_timer_status.TabIndex = 52;
			lab_timer_status.TextAlign = ContentAlignment.MiddleRight;
			// 
			// btn_detect_pipeline
			// 
			btn_detect_pipeline.Location = new Point(644, 213);
			btn_detect_pipeline.Name = "btn_detect_pipeline";
			btn_detect_pipeline.Size = new Size(116, 45);
			btn_detect_pipeline.TabIndex = 51;
			btn_detect_pipeline.Text = "Detect Finish";
			btn_detect_pipeline.UseVisualStyleBackColor = true;
			btn_detect_pipeline.Click += btn_detect_pipeline_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(29, 161);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(103, 23);
			textBox1.TabIndex = 50;
			textBox1.Visible = false;
			// 
			// btn_getMRinfo
			// 
			btn_getMRinfo.Location = new Point(138, 161);
			btn_getMRinfo.Name = "btn_getMRinfo";
			btn_getMRinfo.Size = new Size(84, 23);
			btn_getMRinfo.TabIndex = 49;
			btn_getMRinfo.Text = "Get MR Info";
			btn_getMRinfo.UseVisualStyleBackColor = true;
			btn_getMRinfo.Visible = false;
			btn_getMRinfo.Click += btn_getMRinfo_Click;
			// 
			// btnCreateMergeRequest
			// 
			btnCreateMergeRequest.Location = new Point(644, 149);
			btnCreateMergeRequest.Name = "btnCreateMergeRequest";
			btnCreateMergeRequest.Size = new Size(116, 45);
			btnCreateMergeRequest.TabIndex = 48;
			btnCreateMergeRequest.Text = "Merge Request";
			btnCreateMergeRequest.UseVisualStyleBackColor = true;
			btnCreateMergeRequest.Click += btnCreateMergeRequest_Click;
			// 
			// lab_tab6_notice
			// 
			lab_tab6_notice.CausesValidation = false;
			lab_tab6_notice.Font = new Font("新細明體", 20F, FontStyle.Bold, GraphicsUnit.Point);
			lab_tab6_notice.ForeColor = Color.Red;
			lab_tab6_notice.Location = new Point(29, 94);
			lab_tab6_notice.Name = "lab_tab6_notice";
			lab_tab6_notice.Size = new Size(521, 56);
			lab_tab6_notice.TabIndex = 47;
			lab_tab6_notice.Text = "使用前請先確認是否有已異動檔案未處理此排程會 Restore 所有異動檔";
			// 
			// btn_cancel_reserve
			// 
			btn_cancel_reserve.Location = new Point(644, 88);
			btn_cancel_reserve.Name = "btn_cancel_reserve";
			btn_cancel_reserve.Size = new Size(116, 46);
			btn_cancel_reserve.TabIndex = 46;
			btn_cancel_reserve.Text = "Reserve Cancel";
			btn_cancel_reserve.UseVisualStyleBackColor = true;
			btn_cancel_reserve.Click += btn_cancel_reserve_Click;
			// 
			// cbx_tab6_vn
			// 
			cbx_tab6_vn.AutoSize = true;
			cbx_tab6_vn.Location = new Point(594, 42);
			cbx_tab6_vn.Name = "cbx_tab6_vn";
			cbx_tab6_vn.Size = new Size(44, 19);
			cbx_tab6_vn.TabIndex = 45;
			cbx_tab6_vn.Text = "VN";
			cbx_tab6_vn.UseVisualStyleBackColor = true;
			// 
			// cbx_tab6_tc
			// 
			cbx_tab6_tc.AutoSize = true;
			cbx_tab6_tc.Location = new Point(547, 42);
			cbx_tab6_tc.Name = "cbx_tab6_tc";
			cbx_tab6_tc.Size = new Size(41, 19);
			cbx_tab6_tc.TabIndex = 44;
			cbx_tab6_tc.Text = "TC";
			cbx_tab6_tc.UseVisualStyleBackColor = true;
			// 
			// cbx_tab6_dg
			// 
			cbx_tab6_dg.AutoSize = true;
			cbx_tab6_dg.Location = new Point(497, 42);
			cbx_tab6_dg.Name = "cbx_tab6_dg";
			cbx_tab6_dg.Size = new Size(44, 19);
			cbx_tab6_dg.TabIndex = 43;
			cbx_tab6_dg.Text = "DG";
			cbx_tab6_dg.UseVisualStyleBackColor = true;
			// 
			// btn_reserve
			// 
			btn_reserve.Location = new Point(644, 27);
			btn_reserve.Name = "btn_reserve";
			btn_reserve.Size = new Size(116, 46);
			btn_reserve.TabIndex = 42;
			btn_reserve.Text = "Reserve";
			btn_reserve.UseVisualStyleBackColor = true;
			btn_reserve.Click += btn_reserve_Click;
			// 
			// tbx_tab6_resultMsg
			// 
			tbx_tab6_resultMsg.Location = new Point(29, 286);
			tbx_tab6_resultMsg.Multiline = true;
			tbx_tab6_resultMsg.Name = "tbx_tab6_resultMsg";
			tbx_tab6_resultMsg.ScrollBars = ScrollBars.Both;
			tbx_tab6_resultMsg.Size = new Size(736, 251);
			tbx_tab6_resultMsg.TabIndex = 41;
			// 
			// cbx_tab6_branch
			// 
			cbx_tab6_branch.AutoCompleteCustomSource.AddRange(new string[] { "SIT", "UAT", "PRD" });
			cbx_tab6_branch.FormattingEnabled = true;
			cbx_tab6_branch.Location = new Point(357, 40);
			cbx_tab6_branch.Name = "cbx_tab6_branch";
			cbx_tab6_branch.Size = new Size(121, 23);
			cbx_tab6_branch.TabIndex = 3;
			// 
			// lab_tab6_branch
			// 
			lab_tab6_branch.AutoSize = true;
			lab_tab6_branch.Location = new Point(293, 46);
			lab_tab6_branch.Name = "lab_tab6_branch";
			lab_tab6_branch.Size = new Size(45, 15);
			lab_tab6_branch.TabIndex = 2;
			lab_tab6_branch.Text = "Branch";
			// 
			// lab_tab6_checkTime
			// 
			lab_tab6_checkTime.AutoSize = true;
			lab_tab6_checkTime.Location = new Point(29, 46);
			lab_tab6_checkTime.Name = "lab_tab6_checkTime";
			lab_tab6_checkTime.Size = new Size(79, 15);
			lab_tab6_checkTime.TabIndex = 1;
			lab_tab6_checkTime.Text = "預計發版時間";
			// 
			// dtp_checkTime
			// 
			dtp_checkTime.CustomFormat = "yyyy-MM-dd HH:mm";
			dtp_checkTime.Format = DateTimePickerFormat.Custom;
			dtp_checkTime.Location = new Point(131, 40);
			dtp_checkTime.Name = "dtp_checkTime";
			dtp_checkTime.Size = new Size(141, 23);
			dtp_checkTime.TabIndex = 0;
			// 
			// tabPage7
			// 
			tabPage7.Controls.Add(tbx_tab7_Program);
			tabPage7.Controls.Add(dgv_tab7_sqlanalyze);
			tabPage7.Controls.Add(btn_dbconnect);
			tabPage7.Controls.Add(btn_sqlanalyze);
			tabPage7.Controls.Add(tbx_tab7_resultMsg);
			tabPage7.Controls.Add(lab_atb7_fromarea);
			tabPage7.Controls.Add(lab_tab7_fromprogram);
			tabPage7.Controls.Add(cbx_tab7_fromarea);
			tabPage7.Location = new Point(4, 24);
			tabPage7.Name = "tabPage7";
			tabPage7.Padding = new Padding(3);
			tabPage7.Size = new Size(789, 570);
			tabPage7.TabIndex = 6;
			tabPage7.Text = "SqlAnalyze";
			tabPage7.UseVisualStyleBackColor = true;
			// 
			// tbx_tab7_Program
			// 
			tbx_tab7_Program.Location = new Point(330, 6);
			tbx_tab7_Program.Name = "tbx_tab7_Program";
			tbx_tab7_Program.PlaceholderText = "範例：PK_MI_MII470";
			tbx_tab7_Program.Size = new Size(388, 23);
			tbx_tab7_Program.TabIndex = 77;
			// 
			// dgv_tab7_sqlanalyze
			// 
			dgv_tab7_sqlanalyze.AllowUserToAddRows = false;
			dgv_tab7_sqlanalyze.AutoGenerateColumns = false;
			dgv_tab7_sqlanalyze.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_tab7_sqlanalyze.Columns.AddRange(new DataGridViewColumn[] { tableDataGridViewTextBoxColumn, queryDataGridViewCheckBoxColumn, insertDataGridViewCheckBoxColumn, updateDataGridViewCheckBoxColumn, deleteDataGridViewCheckBoxColumn, joinDataGridViewCheckBoxColumn });
			dgv_tab7_sqlanalyze.DataSource = sqlAnalyzeBindingSource;
			dgv_tab7_sqlanalyze.Location = new Point(10, 270);
			dgv_tab7_sqlanalyze.Name = "dgv_tab7_sqlanalyze";
			dgv_tab7_sqlanalyze.RowHeadersWidth = 51;
			dgv_tab7_sqlanalyze.RowTemplate.Height = 25;
			dgv_tab7_sqlanalyze.Size = new Size(766, 294);
			dgv_tab7_sqlanalyze.TabIndex = 76;
			// 
			// tableDataGridViewTextBoxColumn
			// 
			tableDataGridViewTextBoxColumn.DataPropertyName = "Table";
			tableDataGridViewTextBoxColumn.HeaderText = "Table";
			tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
			// 
			// queryDataGridViewCheckBoxColumn
			// 
			queryDataGridViewCheckBoxColumn.DataPropertyName = "Query";
			queryDataGridViewCheckBoxColumn.HeaderText = "Query";
			queryDataGridViewCheckBoxColumn.Name = "queryDataGridViewCheckBoxColumn";
			// 
			// insertDataGridViewCheckBoxColumn
			// 
			insertDataGridViewCheckBoxColumn.DataPropertyName = "Insert";
			insertDataGridViewCheckBoxColumn.HeaderText = "Insert";
			insertDataGridViewCheckBoxColumn.Name = "insertDataGridViewCheckBoxColumn";
			// 
			// updateDataGridViewCheckBoxColumn
			// 
			updateDataGridViewCheckBoxColumn.DataPropertyName = "Update";
			updateDataGridViewCheckBoxColumn.HeaderText = "Update";
			updateDataGridViewCheckBoxColumn.Name = "updateDataGridViewCheckBoxColumn";
			// 
			// deleteDataGridViewCheckBoxColumn
			// 
			deleteDataGridViewCheckBoxColumn.DataPropertyName = "Delete";
			deleteDataGridViewCheckBoxColumn.HeaderText = "Delete";
			deleteDataGridViewCheckBoxColumn.Name = "deleteDataGridViewCheckBoxColumn";
			// 
			// joinDataGridViewCheckBoxColumn
			// 
			joinDataGridViewCheckBoxColumn.DataPropertyName = "Join";
			joinDataGridViewCheckBoxColumn.HeaderText = "Join";
			joinDataGridViewCheckBoxColumn.Name = "joinDataGridViewCheckBoxColumn";
			// 
			// sqlAnalyzeBindingSource
			// 
			sqlAnalyzeBindingSource.DataSource = typeof(SqlAnalyze);
			// 
			// btn_dbconnect
			// 
			btn_dbconnect.Location = new Point(17, 35);
			btn_dbconnect.Name = "btn_dbconnect";
			btn_dbconnect.Size = new Size(132, 44);
			btn_dbconnect.TabIndex = 75;
			btn_dbconnect.Text = "DB Connect";
			btn_dbconnect.UseVisualStyleBackColor = true;
			btn_dbconnect.Click += btn_dbconnect_Click;
			// 
			// btn_sqlanalyze
			// 
			btn_sqlanalyze.Location = new Point(155, 35);
			btn_sqlanalyze.Name = "btn_sqlanalyze";
			btn_sqlanalyze.Size = new Size(132, 44);
			btn_sqlanalyze.TabIndex = 74;
			btn_sqlanalyze.Text = "Sql Analyze";
			btn_sqlanalyze.UseVisualStyleBackColor = true;
			btn_sqlanalyze.Click += btn_sqlanalyze_Click;
			// 
			// tbx_tab7_resultMsg
			// 
			tbx_tab7_resultMsg.Location = new Point(10, 85);
			tbx_tab7_resultMsg.Multiline = true;
			tbx_tab7_resultMsg.Name = "tbx_tab7_resultMsg";
			tbx_tab7_resultMsg.ScrollBars = ScrollBars.Both;
			tbx_tab7_resultMsg.Size = new Size(766, 179);
			tbx_tab7_resultMsg.TabIndex = 71;
			// 
			// lab_atb7_fromarea
			// 
			lab_atb7_fromarea.AutoSize = true;
			lab_atb7_fromarea.Location = new Point(16, 14);
			lab_atb7_fromarea.Name = "lab_atb7_fromarea";
			lab_atb7_fromarea.Size = new Size(33, 15);
			lab_atb7_fromarea.TabIndex = 63;
			lab_atb7_fromarea.Text = "Area";
			// 
			// lab_tab7_fromprogram
			// 
			lab_tab7_fromprogram.AutoSize = true;
			lab_tab7_fromprogram.Location = new Point(268, 14);
			lab_tab7_fromprogram.Name = "lab_tab7_fromprogram";
			lab_tab7_fromprogram.Size = new Size(56, 15);
			lab_tab7_fromprogram.TabIndex = 65;
			lab_tab7_fromprogram.Text = "Program";
			// 
			// cbx_tab7_fromarea
			// 
			cbx_tab7_fromarea.DropDownStyle = ComboBoxStyle.DropDownList;
			cbx_tab7_fromarea.FormattingEnabled = true;
			cbx_tab7_fromarea.Items.AddRange(new object[] { "DG", "VN", "VG", "TC" });
			cbx_tab7_fromarea.Location = new Point(89, 6);
			cbx_tab7_fromarea.Name = "cbx_tab7_fromarea";
			cbx_tab7_fromarea.Size = new Size(148, 23);
			cbx_tab7_fromarea.TabIndex = 64;
			cbx_tab7_fromarea.SelectedIndexChanged += cbx_tab7_fromarea_SelectedIndexChanged;
			// 
			// tim_tab2
			// 
			tim_tab2.Enabled = true;
			tim_tab2.Interval = 1000;
			tim_tab2.Tick += tim_tab2_Tick;
			// 
			// cmt_tab2_deleterow
			// 
			cmt_tab2_deleterow.ImageScalingSize = new Size(20, 20);
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
			// oracleCommand1
			// 
			oracleCommand1.Transaction = null;
			// 
			// tim_tab6_reservecheck
			// 
			tim_tab6_reservecheck.Interval = 1000;
			tim_tab6_reservecheck.Tick += tim_tab6_reservecheck_Tick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// tim_pipelinecheck
			// 
			tim_pipelinecheck.Interval = 10000;
			tim_pipelinecheck.Tick += tim_pipelinecheck_Tick;
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
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
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
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			grb_front_end.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgv_component_list).EndInit();
			tabPage6.ResumeLayout(false);
			tabPage6.PerformLayout();
			tabPage7.ResumeLayout(false);
			tabPage7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgv_tab7_sqlanalyze).EndInit();
			((System.ComponentModel.ISupportInitialize)sqlAnalyzeBindingSource).EndInit();
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
        private ComboBox comboBox1;
        private TabPage tabPage4;
        private Button btn_dotnet_run;
        private TabPage tabPage5;
        private Label lab_setting_projectpath;
        private Button btn_setting_selectpath;
        private TextBox tbx_setting_projectpath;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private CheckBox cbx_DV;
        private CheckBox cbx_PM;
        private CheckBox cbx_MP;
        private CheckBox cbx_WO;
        private CheckBox cbx_XX;
        private CheckBox cbx_OA;
        private CheckBox cbx_MI;
        private CheckBox cbx_MG;
        private CheckBox cbx_MD;
        private CheckBox cbx_SD;
        private CheckBox cbx_SingnalR;
        private CheckBox cbx_AppPortal;
        private Button btn_dotnet_close_all;
        private GroupBox grb_front_end;
        private Label lab_setting_frontendpath;
        private Button btn_setting_selectfrontendpath;
        private TextBox tbx_setting_frontendpath;
        private Button btn_com_movekill;
        private Button btn_install_component;
        private Button btn_ng_build;
        private DataGridView dgv_component_list;
        private TextBox tbx_APIGo_resultMsg;
        private DataGridViewCheckBoxColumn Col_Check;
        private DataGridViewTextBoxColumn Col_Component;
        private DataGridViewTextBoxColumn Col_Version;
        private DataGridViewTextBoxColumn Col_OldVersion;
        private Button btn_move2develop;
        private TabPage tabPage6;
        private Label lab_tab6_branch;
        private Label lab_tab6_checkTime;
        private Button btn_reserve;
        private TextBox tbx_tab6_resultMsg;
        private ComboBox cbx_tab6_branch;
        private System.Windows.Forms.Timer tim_tab6_reservecheck;
        public DateTimePicker dtp_checkTime;
        private CheckBox cbx_tab6_vn;
        private CheckBox cbx_tab6_tc;
        private CheckBox cbx_tab6_dg;
        private Button btn_cancel_reserve;
        private Label lab_tab6_notice;
        private ContextMenuStrip contextMenuStrip1;
        private Label lab_tab1_notice;
        private CheckBox cbx_iswo;
        private CheckBox chk_Gridtype;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewComboBoxColumn Type;
        private Button btn_othercolumn;
        private Button btnCreateMergeRequest;
        private Label lab_gitlab_token;
        private TextBox txtToken;
        private Label lab_gitlab_userid;
        private TextBox txtUserId;
        private Button btn_getMRinfo;
        private TextBox textBox1;
        private TabPage tabPage7;
        private TextBox tbx_tab7_resultMsg;
        private Label lab_atb7_fromarea;
        private Label lab_tab7_fromprogram;
        private ComboBox cbx_tab7_fromarea;
        private Button btn_sqlanalyze;
        private Button btn_dbconnect;
        private DataGridView dgv_tab7_sqlanalyze;
        private DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn queryDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn insertDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn updateDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn deleteDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn joinDataGridViewCheckBoxColumn;
        private BindingSource sqlAnalyzeBindingSource;
        public TextBox tbx_tab7_Program;
		private System.Windows.Forms.Timer tim_pipelinecheck;
		private Button btn_detect_pipeline;
		private Label lab_line_token;
		private TextBox txtLineNotifyToken;
		private Label lab_timer_status;
		private Button btn_line_notify_test;
		private Label lab_mr_status;
	}
}