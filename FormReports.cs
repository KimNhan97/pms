using PMS.BLL;
using PMS.DAL;
using PMS.DTO;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;


namespace PMS
{
    public partial class FormReports : Form
    {
        
        private readonly IReportService _reportService;
        private readonly IProjectService _projectService;
        private int _selectedReportId = 0;
        private int _selectedProjectId = 0;


        public FormReports(IReportService reportService, IProjectService projectService)
        {
            InitializeComponent();
            _reportService = reportService;
            _projectService = projectService;
        }
        private void SetupActionButtons()
        {
            // ===== BUTTON CHUNG =====
            Guna2Button[] buttons = { btnAdd, btnDelete, btnEdit, btnView };

            foreach (var btn in buttons)
            {
                btn.BorderRadius = 8;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.FillColor = Color.Gray;
                btn.ForeColor = Color.White;
                btn.DisabledState.FillColor = Color.FromArgb(200, 200, 200);
                btn.DisabledState.ForeColor = Color.White;
                btn.HoverState.FillColor = ControlPaint.Light(btn.FillColor);
                btn.PressedColor = ControlPaint.Dark(btn.FillColor);
                btn.Animated = true;
                btn.ShadowDecoration.Enabled = true;
                btn.ShadowDecoration.Depth = 4;
                btn.ShadowDecoration.Color = Color.FromArgb(120, 120, 120);
            }

            // ===== THÊM =====
            btnAdd.Text = "➕ Thêm";
            btnAdd.FillColor = Color.FromArgb(34, 197, 94); // xanh lá
            btnAdd.HoverState.FillColor = Color.FromArgb(22, 163, 74);


            // ===== XÓA =====
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.FillColor = Color.FromArgb(239, 68, 68); // đỏ
            btnDelete.HoverState.FillColor = Color.FromArgb(220, 38, 38);
            btnDelete.Enabled = false;

        }

        private void FormReports_Load(object sender, EventArgs e)
        {
          


            SetupActionButtons();
            SetupDataGridView();
            LoadProjects();
            LoadReportTypes();
            // Cho nhập bình thường
            btnDelete.Enabled = false;
            cboProject.SelectedIndex = 0;
            cboFilterType.SelectedIndex = -1;
           
            LoadReports();
        }

        #region Load Data

        private void LoadProjects()
        {
            var projects = _projectService.GetAllProjects();
            projects.Insert(0, new Project
            {
                ProjectID = 0,
                ProjectName = "Tất cả dự án"
            });

            cboProject.DataSource = projects;
            cboProject.DisplayMember = "ProjectName";
            cboProject.ValueMember = "ProjectID";

            cboProject.SelectedIndex = 0; // ✅ ĐÚNG CHỖ
        }
        private void LoadReportTypes()
        {
            var types = new Dictionary<string, string>
    {
        { "Tất cả", "" },
        { "One Pager", "OnePager" },
        { "VSM", "VSM" },
        { "Executive Summary", "ExecutiveSummary" }
    };

            cboFilterType.DataSource = new BindingSource(types, null);
            cboFilterType.DisplayMember = "Key";
            cboFilterType.ValueMember = "Value";
            cboFilterType.SelectedIndex = 0;

        }

        private void LoadReports()
        {
            if (cboProject.DataSource == null || cboFilterType.DataSource == null)
                return;

            int projectId = cboProject.SelectedValue == null
    ? 0
    : (int)cboProject.SelectedValue;

            string type = cboFilterType.SelectedValue?.ToString();


            dgvReports.AutoGenerateColumns = false;
            dgvReports.Columns.Clear();

            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReportID",
                HeaderText = "Mã",
                DataPropertyName = "ReportID",
                Width = 60
            });

            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Tiêu đề",
                DataPropertyName = "Title",
                Width = 220
            });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContentShort",
                HeaderText = "Nội dung",
                DataPropertyName = "ContentShort",
                Width = 300
            });


            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReportType",
                HeaderText = "Loại",
                DataPropertyName = "ReportType",
                Width = 150
            });

            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProjectName",
                HeaderText = "Dự án",
                DataPropertyName = "ProjectName",
                Width = 200
            });

            dgvReports.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Ngày tạo",
                DataPropertyName = "CreatedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // CUỐI CÙNG mới gán DataSource
            dgvReports.DataSource = _reportService.GetReports(projectId, type);

            dgvReports.ClearSelection();
        }


        #endregion

        #region Event Handlers

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dto = dgvReports.Rows[e.RowIndex].DataBoundItem as ReportDTO;
            if (dto == null) return;

            _selectedReportId = dto.ReportID;
            _selectedProjectId = dto.ProjectID;

            btnDelete.Enabled = true;
        }



        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        #endregion

        #region Helper


        private void SetupDataGridView()
        {
            // ===== Chung =====
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AllowUserToResizeRows = false;
            dgvReports.ReadOnly = true;
            dgvReports.MultiSelect = false;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.RowHeadersVisible = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== Font =====
            dgvReports.DefaultCellStyle.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Regular);

            dgvReports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // ===== Header =====
            dgvReports.ColumnHeadersHeight = 42;
            dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;

            // ===== Row =====
            dgvReports.RowTemplate.Height = 36;
            dgvReports.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(221, 235, 247);
            dgvReports.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // ===== Zebra style =====
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);

            dgvReports.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            // ===== Border =====
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReports.GridColor = System.Drawing.Color.LightGray;
        }

        #endregion
      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (_selectedReportId == 0)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để xóa");
                return;
            }

            if (MessageBox.Show("Xóa báo cáo?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _reportService.DeleteReport(_selectedReportId);

            LoadReports();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }


       
        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadProjectSummary(int projectId)
        {
            if (projectId == 0)
                return;

            var summary = _reportService.GetProjectSummary(projectId);
            if (summary == null) return;

            // ===== TÊN DỰ ÁN =====
            lblProjectName.Text = $"Dự án: {summary.ProjectName}";
            lblProjectName.ForeColor = Color.FromArgb(30, 64, 175);

            // ===== TIẾN ĐỘ =====
            prgProgress.Value = summary.Progress;
            lblProgressPercent.Text = $"Tiến độ: {summary.Progress} %";

            if (summary.Progress >= 90)
                lblProgressPercent.ForeColor = Color.Green;
            else if (summary.Progress >= 60)
                lblProgressPercent.ForeColor = Color.Orange;
            else
                lblProgressPercent.ForeColor = Color.Red;

            // ===== DEADLINE =====
            lblDeadline.Text = $" Deadline: {summary.Deadline:dd/MM/yyyy}";
            lblDeadline.ForeColor = Color.FromArgb(55, 65, 81);

            // ===== TRẠNG THÁI =====
            lblLateStatus.Text = summary.IsLate
                ? $"⚠ Trạng thái: Trễ {Math.Abs(summary.DaysRemaining)} ngày"
                : $"✅ Trạng thái: Còn {summary.DaysRemaining} ngày";

            lblLateStatus.ForeColor =
                summary.IsLate ? Color.Red : Color.Green;

            // ===== KHỐI PHỤ =====
            LoadTaskStatus(summary);
            LoadMemberStatus(summary);
        }

        private void LoadTaskStatus(ProjectReportSummaryDTO summary)
        {
            lblTotalTasks.Text = $"Tổng task: {summary.TotalTasks}";
            lblDoneTasks.Text = $"✔ Hoàn thành: {summary.DoneTasks}";
            lblDoingTasks.Text = $"⏳ Đang làm: {summary.DoingTasks}";
            lblLateTasks.Text = $"⚠ Trễ hạn: {summary.LateTasks}";

            // MÀU CẢNH BÁO
            lblLateTasks.ForeColor =
                summary.LateTasks > 0 ? Color.Red : Color.DarkGreen;
        }
        private void LoadMemberStatus(ProjectReportSummaryDTO summary)
        {
            lblTotalMembers.Text = $"Nhân sự: {summary.TotalMembers}";
            lblBusyMembers.Text = $"Bận: {summary.BusyMembers}";
            lblAvailableMembers.Text = $" Rảnh: {summary.AvailableMembers}";

            lblBusyMembers.ForeColor = Color.Red;
            lblAvailableMembers.ForeColor = Color.Green;
        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboProject.SelectedValue is int projectId)
            {
                LoadProjectSummary(projectId);
            
                LoadReports();
            }
        }
        private ReportDTO GetSelectedReport()
        {
            if (dgvReports.CurrentRow == null)
                return null;

            return dgvReports.CurrentRow.DataBoundItem as ReportDTO;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (cboProject.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn dự án");
                return;
            }

            int projectId = (int)cboProject.SelectedValue;

            using (var f = new FormEditReport(
                _reportService,
                ReportFormMode.Add,
                projectId: projectId))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadReports(); // reload grid
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            var report = GetSelectedReport();
            if (report == null)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để sửa");
                return;
            }

            using (var f = new FormEditReport(
                _reportService,
                ReportFormMode.Edit,
                reportId: report.ReportID))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadReports();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var report = GetSelectedReport();
            if (report == null)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để xóa");
                return;
            }

            if (MessageBox.Show(
                "Bạn chắc chắn muốn xóa báo cáo này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _reportService.DeleteReport(report.ReportID);
                LoadReports();
            }
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            var report = GetSelectedReport();
            if (report == null)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để xem");
                return;
            }

            using (var f = new FormEditReport(
                _reportService,
                ReportFormMode.View,
                reportId: report.ReportID))
            {
                f.ShowDialog();
            }
        }

    }
}
