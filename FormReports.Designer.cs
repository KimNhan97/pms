namespace PMS
{
    partial class FormReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.cboFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvReports = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.prgProgress = new Guna.UI2.WinForms.Guna2VProgressBar();
            this.lblLateStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDeadline = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProgressPercent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProjectName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalTasks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDoneTasks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDoingTasks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLateTasks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAvailableMembers = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBusyMembers = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalMembers = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(17, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bản tóm lược kết quả và lộ trình tối ưu hóa dự án.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "📄 BÁO CÁO DỰ ÁN";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel1.Controls.Add(this.btnDelete);
            this.guna2Panel1.Controls.Add(this.btnEdit);
            this.guna2Panel1.Controls.Add(this.btnView);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.cboFilterType);
            this.guna2Panel1.Controls.Add(this.cboProject);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 62);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1049, 60);
            this.guna2Panel1.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(653, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(766, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 36);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(506, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(117, 36);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "Xem chi tiết ";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(902, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+ Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // cboFilterType
            // 
            this.cboFilterType.BackColor = System.Drawing.Color.Transparent;
            this.cboFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFilterType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboFilterType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboFilterType.ItemHeight = 30;
            this.cboFilterType.Location = new System.Drawing.Point(283, 12);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(195, 36);
            this.cboFilterType.TabIndex = 1;
            // 
            // cboProject
            // 
            this.cboProject.BackColor = System.Drawing.Color.Transparent;
            this.cboProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboProject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboProject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboProject.ItemHeight = 30;
            this.cboProject.Location = new System.Drawing.Point(20, 12);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(223, 36);
            this.cboProject.TabIndex = 0;
            this.cboProject.SelectedIndexChanged += new System.EventHandler(this.cboProject_SelectedIndexChanged);
            // 
            // dgvReports
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReports.ColumnHeadersHeight = 4;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReports.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReports.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReports.Location = new System.Drawing.Point(0, 270);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.Size = new System.Drawing.Size(1049, 455);
            this.dgvReports.TabIndex = 6;
            this.dgvReports.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReports.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReports.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReports.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReports.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReports.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReports.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReports.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReports.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReports.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReports.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReports.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReports.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvReports.ThemeStyle.ReadOnly = false;
            this.dgvReports.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReports.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReports.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReports.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReports.ThemeStyle.RowsStyle.Height = 22;
            this.dgvReports.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReports.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellClick);
            this.dgvReports.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellDoubleClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Controls.Add(this.prgProgress);
            this.guna2Panel2.Controls.Add(this.lblLateStatus);
            this.guna2Panel2.Controls.Add(this.lblDeadline);
            this.guna2Panel2.Controls.Add(this.lblProgressPercent);
            this.guna2Panel2.Controls.Add(this.lblProjectName);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Location = new System.Drawing.Point(2, 134);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(351, 118);
            this.guna2Panel2.TabIndex = 7;
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(302, 29);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(23, 32);
            this.prgProgress.TabIndex = 15;
            this.prgProgress.Text = "guna2VProgressBar1";
            this.prgProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblLateStatus
            // 
            this.lblLateStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblLateStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLateStatus.Location = new System.Drawing.Point(205, 77);
            this.lblLateStatus.Name = "lblLateStatus";
            this.lblLateStatus.Size = new System.Drawing.Size(49, 23);
            this.lblLateStatus.TabIndex = 14;
            this.lblLateStatus.Text = "Label1";
            // 
            // lblDeadline
            // 
            this.lblDeadline.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadline.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDeadline.Location = new System.Drawing.Point(18, 77);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(49, 23);
            this.lblDeadline.TabIndex = 13;
            this.lblDeadline.Text = "Label1";
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressPercent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProgressPercent.Location = new System.Drawing.Point(205, 38);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(41, 23);
            this.lblProgressPercent.TabIndex = 12;
            this.lblProgressPercent.Text = "abel1";
            // 
            // lblProjectName
            // 
            this.lblProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProjectName.Location = new System.Drawing.Point(18, 38);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(127, 23);
            this.lblProjectName.TabIndex = 11;
            this.lblProjectName.Text = "guna2HtmlLabel1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "TỔNG QUAN DỰ ÁN";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Honeydew;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Lime;
            this.guna2Panel3.Controls.Add(this.lblTotalTasks);
            this.guna2Panel3.Controls.Add(this.lblDoneTasks);
            this.guna2Panel3.Controls.Add(this.lblDoingTasks);
            this.guna2Panel3.Controls.Add(this.lblLateTasks);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel3.Controls.Add(this.label4);
            this.guna2Panel3.Location = new System.Drawing.Point(382, 134);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(330, 118);
            this.guna2Panel3.TabIndex = 8;
            // 
            // lblTotalTasks
            // 
            this.lblTotalTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTasks.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalTasks.Location = new System.Drawing.Point(24, 38);
            this.lblTotalTasks.Name = "lblTotalTasks";
            this.lblTotalTasks.Size = new System.Drawing.Size(77, 23);
            this.lblTotalTasks.TabIndex = 23;
            this.lblTotalTasks.Text = "Tổng task : ";
            // 
            // lblDoneTasks
            // 
            this.lblDoneTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblDoneTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoneTasks.ForeColor = System.Drawing.Color.Orange;
            this.lblDoneTasks.Location = new System.Drawing.Point(194, 38);
            this.lblDoneTasks.Name = "lblDoneTasks";
            this.lblDoneTasks.Size = new System.Drawing.Size(77, 23);
            this.lblDoneTasks.TabIndex = 22;
            this.lblDoneTasks.Text = "Tổng task : ";
            // 
            // lblDoingTasks
            // 
            this.lblDoingTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblDoingTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoingTasks.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblDoingTasks.Location = new System.Drawing.Point(24, 79);
            this.lblDoingTasks.Name = "lblDoingTasks";
            this.lblDoingTasks.Size = new System.Drawing.Size(77, 23);
            this.lblDoingTasks.TabIndex = 21;
            this.lblDoingTasks.Text = "Tổng task : ";
            // 
            // lblLateTasks
            // 
            this.lblLateTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblLateTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateTasks.ForeColor = System.Drawing.Color.Crimson;
            this.lblLateTasks.Location = new System.Drawing.Point(194, 79);
            this.lblLateTasks.Name = "lblLateTasks";
            this.lblLateTasks.Size = new System.Drawing.Size(77, 23);
            this.lblLateTasks.TabIndex = 20;
            this.lblLateTasks.Text = "Tổng task : ";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.LimeGreen;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 38);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel1.TabIndex = 16;
            this.guna2HtmlLabel1.Text = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(19, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "TÌNH TRẠNG CÔNG VIỆC";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.LavenderBlush;
            this.guna2Panel4.Controls.Add(this.lblAvailableMembers);
            this.guna2Panel4.Controls.Add(this.lblBusyMembers);
            this.guna2Panel4.Controls.Add(this.lblTotalMembers);
            this.guna2Panel4.Controls.Add(this.label5);
            this.guna2Panel4.Location = new System.Drawing.Point(741, 134);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(308, 118);
            this.guna2Panel4.TabIndex = 9;
            // 
            // lblAvailableMembers
            // 
            this.lblAvailableMembers.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableMembers.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblAvailableMembers.Location = new System.Drawing.Point(26, 77);
            this.lblAvailableMembers.Name = "lblAvailableMembers";
            this.lblAvailableMembers.Size = new System.Drawing.Size(42, 23);
            this.lblAvailableMembers.TabIndex = 24;
            this.lblAvailableMembers.Text = " rảnh : ";
            // 
            // lblBusyMembers
            // 
            this.lblBusyMembers.BackColor = System.Drawing.Color.Transparent;
            this.lblBusyMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusyMembers.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblBusyMembers.Location = new System.Drawing.Point(159, 77);
            this.lblBusyMembers.Name = "lblBusyMembers";
            this.lblBusyMembers.Size = new System.Drawing.Size(49, 23);
            this.lblBusyMembers.TabIndex = 25;
            this.lblBusyMembers.Text = "n bận : ";
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembers.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalMembers.Location = new System.Drawing.Point(26, 38);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(78, 23);
            this.lblTotalMembers.TabIndex = 26;
            this.lblTotalMembers.Text = "nhân viên : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label5.Location = new System.Drawing.Point(21, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "NGUỒN LỰC NHÂN SỰ";
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 725);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormReports";
            this.Text = "FormReports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboProject;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterType;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReports;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProgressPercent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProjectName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDeadline;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLateStatus;
        private Guna.UI2.WinForms.Guna2VProgressBar prgProgress;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalTasks;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDoneTasks;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDoingTasks;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLateTasks;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvailableMembers;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBusyMembers;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalMembers;
    }
}
