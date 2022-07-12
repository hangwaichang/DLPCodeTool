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
            this.tbx_projectpath = new System.Windows.Forms.TextBox();
            this.btn_selectpath = new System.Windows.Forms.Button();
            this.lab_projectpath = new System.Windows.Forms.Label();
            this.lab_module = new System.Windows.Forms.Label();
            this.cbx_frommodule = new System.Windows.Forms.ComboBox();
            this.cbx_fromarea = new System.Windows.Forms.ComboBox();
            this.lab_fromarea = new System.Windows.Forms.Label();
            this.cbx_fromprogram = new System.Windows.Forms.ComboBox();
            this.lab_fromprogram = new System.Windows.Forms.Label();
            this.tbx_resultMsg = new System.Windows.Forms.TextBox();
            this.cbx_targetprogram = new System.Windows.Forms.ComboBox();
            this.lab_targetprogram = new System.Windows.Forms.Label();
            this.cbx_targetarea = new System.Windows.Forms.ComboBox();
            this.lab_targetarea = new System.Windows.Forms.Label();
            this.cbx_targetmodule = new System.Windows.Forms.ComboBox();
            this.lab_targetmodule = new System.Windows.Forms.Label();
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_webapicopy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_modulecopy = new System.Windows.Forms.Button();
            this.btn_backendmove = new System.Windows.Forms.Button();
            this.btn_spname = new System.Windows.Forms.Button();
            this.grb_Frontend = new System.Windows.Forms.GroupBox();
            this.grb_Backend = new System.Windows.Forms.GroupBox();
            this.btn_dto = new System.Windows.Forms.Button();
            this.btn_getrepository = new System.Windows.Forms.Button();
            this.btn_interface = new System.Windows.Forms.Button();
            this.btn_repositories = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tim_checkinput = new System.Windows.Forms.Timer(this.components);
            this.grb_Frontend.SuspendLayout();
            this.grb_Backend.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_projectpath
            // 
            this.tbx_projectpath.Location = new System.Drawing.Point(132, 27);
            this.tbx_projectpath.Name = "tbx_projectpath";
            this.tbx_projectpath.Size = new System.Drawing.Size(388, 23);
            this.tbx_projectpath.TabIndex = 0;
            this.tbx_projectpath.Text = ".\\dlp-develop";
            // 
            // btn_selectpath
            // 
            this.btn_selectpath.Location = new System.Drawing.Point(526, 27);
            this.btn_selectpath.Name = "btn_selectpath";
            this.btn_selectpath.Size = new System.Drawing.Size(75, 23);
            this.btn_selectpath.TabIndex = 1;
            this.btn_selectpath.Text = "Select";
            this.btn_selectpath.UseVisualStyleBackColor = true;
            this.btn_selectpath.Click += new System.EventHandler(this.btn_selectpath_Click);
            // 
            // lab_projectpath
            // 
            this.lab_projectpath.AutoSize = true;
            this.lab_projectpath.Location = new System.Drawing.Point(31, 35);
            this.lab_projectpath.Name = "lab_projectpath";
            this.lab_projectpath.Size = new System.Drawing.Size(71, 15);
            this.lab_projectpath.TabIndex = 2;
            this.lab_projectpath.Text = "ProjectPath";
            // 
            // lab_module
            // 
            this.lab_module.AutoSize = true;
            this.lab_module.Location = new System.Drawing.Point(31, 71);
            this.lab_module.Name = "lab_module";
            this.lab_module.Size = new System.Drawing.Size(86, 15);
            this.lab_module.TabIndex = 3;
            this.lab_module.Text = "From_Module";
            // 
            // cbx_frommodule
            // 
            this.cbx_frommodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_frommodule.FormattingEnabled = true;
            this.cbx_frommodule.Location = new System.Drawing.Point(132, 63);
            this.cbx_frommodule.Name = "cbx_frommodule";
            this.cbx_frommodule.Size = new System.Drawing.Size(148, 23);
            this.cbx_frommodule.TabIndex = 4;
            this.cbx_frommodule.SelectedIndexChanged += new System.EventHandler(this.cbx_frommodule_SelectedIndexChanged);
            // 
            // cbx_fromarea
            // 
            this.cbx_fromarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_fromarea.FormattingEnabled = true;
            this.cbx_fromarea.Location = new System.Drawing.Point(371, 63);
            this.cbx_fromarea.Name = "cbx_fromarea";
            this.cbx_fromarea.Size = new System.Drawing.Size(148, 23);
            this.cbx_fromarea.TabIndex = 6;
            this.cbx_fromarea.SelectedIndexChanged += new System.EventHandler(this.cbx_fromarea_SelectedIndexChanged);
            // 
            // lab_fromarea
            // 
            this.lab_fromarea.AutoSize = true;
            this.lab_fromarea.Location = new System.Drawing.Point(298, 71);
            this.lab_fromarea.Name = "lab_fromarea";
            this.lab_fromarea.Size = new System.Drawing.Size(67, 15);
            this.lab_fromarea.TabIndex = 5;
            this.lab_fromarea.Text = "From_Area";
            // 
            // cbx_fromprogram
            // 
            this.cbx_fromprogram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_fromprogram.FormattingEnabled = true;
            this.cbx_fromprogram.Location = new System.Drawing.Point(634, 63);
            this.cbx_fromprogram.Name = "cbx_fromprogram";
            this.cbx_fromprogram.Size = new System.Drawing.Size(148, 23);
            this.cbx_fromprogram.TabIndex = 8;
            this.cbx_fromprogram.SelectedIndexChanged += new System.EventHandler(this.cbx_fromprogram_SelectedIndexChanged);
            // 
            // lab_fromprogram
            // 
            this.lab_fromprogram.AutoSize = true;
            this.lab_fromprogram.Location = new System.Drawing.Point(541, 71);
            this.lab_fromprogram.Name = "lab_fromprogram";
            this.lab_fromprogram.Size = new System.Drawing.Size(90, 15);
            this.lab_fromprogram.TabIndex = 7;
            this.lab_fromprogram.Text = "From_Program";
            // 
            // tbx_resultMsg
            // 
            this.tbx_resultMsg.Location = new System.Drawing.Point(21, 355);
            this.tbx_resultMsg.Multiline = true;
            this.tbx_resultMsg.Name = "tbx_resultMsg";
            this.tbx_resultMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_resultMsg.Size = new System.Drawing.Size(767, 157);
            this.tbx_resultMsg.TabIndex = 9;
            // 
            // cbx_targetprogram
            // 
            this.cbx_targetprogram.FormattingEnabled = true;
            this.cbx_targetprogram.Location = new System.Drawing.Point(634, 101);
            this.cbx_targetprogram.Name = "cbx_targetprogram";
            this.cbx_targetprogram.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetprogram.TabIndex = 15;
            // 
            // lab_targetprogram
            // 
            this.lab_targetprogram.AutoSize = true;
            this.lab_targetprogram.Location = new System.Drawing.Point(533, 109);
            this.lab_targetprogram.Name = "lab_targetprogram";
            this.lab_targetprogram.Size = new System.Drawing.Size(98, 15);
            this.lab_targetprogram.TabIndex = 14;
            this.lab_targetprogram.Text = "Target_Program";
            // 
            // cbx_targetarea
            // 
            this.cbx_targetarea.FormattingEnabled = true;
            this.cbx_targetarea.Location = new System.Drawing.Point(371, 101);
            this.cbx_targetarea.Name = "cbx_targetarea";
            this.cbx_targetarea.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetarea.TabIndex = 13;
            this.cbx_targetarea.SelectedIndexChanged += new System.EventHandler(this.cbx_targetarea_SelectedIndexChanged);
            // 
            // lab_targetarea
            // 
            this.lab_targetarea.AutoSize = true;
            this.lab_targetarea.Location = new System.Drawing.Point(298, 109);
            this.lab_targetarea.Name = "lab_targetarea";
            this.lab_targetarea.Size = new System.Drawing.Size(75, 15);
            this.lab_targetarea.TabIndex = 12;
            this.lab_targetarea.Text = "Target_Area";
            // 
            // cbx_targetmodule
            // 
            this.cbx_targetmodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_targetmodule.FormattingEnabled = true;
            this.cbx_targetmodule.Location = new System.Drawing.Point(132, 101);
            this.cbx_targetmodule.Name = "cbx_targetmodule";
            this.cbx_targetmodule.Size = new System.Drawing.Size(148, 23);
            this.cbx_targetmodule.TabIndex = 11;
            this.cbx_targetmodule.SelectedIndexChanged += new System.EventHandler(this.cbx_targetmodule_SelectedIndexChanged);
            // 
            // lab_targetmodule
            // 
            this.lab_targetmodule.AutoSize = true;
            this.lab_targetmodule.Location = new System.Drawing.Point(31, 109);
            this.lab_targetmodule.Name = "lab_targetmodule";
            this.lab_targetmodule.Size = new System.Drawing.Size(94, 15);
            this.lab_targetmodule.TabIndex = 10;
            this.lab_targetmodule.Text = "Target_Module";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.grb_Frontend.Location = new System.Drawing.Point(21, 150);
            this.grb_Frontend.Name = "grb_Frontend";
            this.grb_Frontend.Size = new System.Drawing.Size(465, 93);
            this.grb_Frontend.TabIndex = 23;
            this.grb_Frontend.TabStop = false;
            this.grb_Frontend.Text = "1.Frontend";
            // 
            // grb_Backend
            // 
            this.grb_Backend.Controls.Add(this.btn_backendmove);
            this.grb_Backend.Controls.Add(this.btn_spname);
            this.grb_Backend.Location = new System.Drawing.Point(504, 150);
            this.grb_Backend.Name = "grb_Backend";
            this.grb_Backend.Size = new System.Drawing.Size(284, 93);
            this.grb_Backend.TabIndex = 24;
            this.grb_Backend.TabStop = false;
            this.grb_Backend.Text = "2.Backend";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_getrepository);
            this.groupBox1.Controls.Add(this.btn_repositories);
            this.groupBox1.Controls.Add(this.btn_dto);
            this.groupBox1.Controls.Add(this.btn_interface);
            this.groupBox1.Location = new System.Drawing.Point(21, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 85);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3.Repository";
            // 
            // tim_checkinput
            // 
            this.tim_checkinput.Enabled = true;
            this.tim_checkinput.Interval = 1000;
            this.tim_checkinput.Tick += new System.EventHandler(this.tim_checkinput_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb_Backend);
            this.Controls.Add(this.grb_Frontend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbx_targetprogram);
            this.Controls.Add(this.lab_targetprogram);
            this.Controls.Add(this.cbx_targetarea);
            this.Controls.Add(this.lab_targetarea);
            this.Controls.Add(this.cbx_targetmodule);
            this.Controls.Add(this.lab_targetmodule);
            this.Controls.Add(this.tbx_resultMsg);
            this.Controls.Add(this.cbx_fromprogram);
            this.Controls.Add(this.lab_fromprogram);
            this.Controls.Add(this.cbx_fromarea);
            this.Controls.Add(this.lab_fromarea);
            this.Controls.Add(this.cbx_frommodule);
            this.Controls.Add(this.lab_module);
            this.Controls.Add(this.lab_projectpath);
            this.Controls.Add(this.btn_selectpath);
            this.Controls.Add(this.tbx_projectpath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SunDiTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grb_Frontend.ResumeLayout(false);
            this.grb_Backend.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbx_projectpath;
        private Button btn_selectpath;
        private Label lab_projectpath;
        private Label lab_module;
        private ComboBox cbx_frommodule;
        private ComboBox cbx_fromarea;
        private Label lab_fromarea;
        private ComboBox cbx_fromprogram;
        private Label lab_fromprogram;
        private TextBox tbx_resultMsg;
        private ComboBox cbx_targetprogram;
        private Label lab_targetprogram;
        private ComboBox cbx_targetarea;
        private Label lab_targetarea;
        private ComboBox cbx_targetmodule;
        private Label lab_targetmodule;
        private Button btn_Move;
        private Button btn_webapicopy;
        private Button button1;
        private Button btn_modulecopy;
        private Button btn_backendmove;
        private Button btn_spname;
        private GroupBox grb_Frontend;
        private GroupBox grb_Backend;
        private Button btn_dto;
        private Button btn_getrepository;
        private Button btn_interface;
        private Button btn_repositories;
        private GroupBox groupBox1;
        private System.Windows.Forms.Timer tim_checkinput;
    }
}