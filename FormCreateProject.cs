using PMS.BLL;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormCreateProject : Form
    {
        private readonly IProjectService _service;
        private readonly IAuthService _authService;
        private readonly bool _isEdit;
        private Project _project;

        // Constructor cho trường hợp THÊM MỚI
        public FormCreateProject(IProjectService service, IAuthService authService)
        {
            InitializeComponent();
            _service = service;
            _authService = authService;
            _isEdit = false;
        }

        // Constructor cho trường hợp CHỈNH SỬA
        public FormCreateProject(IProjectService service, IAuthService authService, Project project)
        {
            InitializeComponent();
            _service = service;
            _authService = authService;
            _isEdit = true;
            _project = project;
        }

        private void FormCreateProject_Load(object sender, EventArgs e)
        {
            SetupUIStyles();           // 1. Định dạng giao diện (bo góc, màu sắc)
            LoadAdminsIntoComboBox();  // 2. Load danh sách người quản lý vào ComboBox
            txtDescription.Enabled = true;
            txtDescription.ReadOnly = false;
            txtDescription.Focus();

            if (_isEdit)
            {
                this.Text = "Sửa dự án";
                label1.Text = "CẬP NHẬT DỰ ÁN"; // Đổi title trên form nếu có
                btnSave.Text = "💾 Cập nhật";
                LoadProjectData();     // 3. Đổ dữ liệu cũ vào các control
            }
            else
            {
                this.Text = "Tạo dự án mới";
                btnSave.Text = "➕ Thêm mới";
                // Mặc định ngày bắt đầu là hôm nay
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now.AddDays(7);
                lblProgressPercent.Text = "0 %";
            }
        }

        private void SetupUIStyles()
        {
            // Định dạng DateTimePicker
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";

            // Định dạng TextBox Project Name
            txtProjectName.PlaceholderText = "Nhập tên dự án...";

            // Định dạng TextBox Description
            txtDescription.Multiline = true;
            txtDescription.PlaceholderText = "Nhập mô tả dự án...";

            // Định dạng ProgressBar (Guna2)
            prgProgress.Minimum = 0;
            prgProgress.Maximum = 100;
        }

        private void LoadAdminsIntoComboBox()
        {
            try
            {
                var admins = _authService.GetAll()
                    .Where(u => u.Role != null &&
                                u.Role.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                cmbManager.DataSource = admins;
                cmbManager.DisplayMember = "FullName";
                cmbManager.ValueMember = "UserID";
                cmbManager.SelectedIndex = -1; // Mặc định không chọn ai
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách Admin: " + ex.Message);
            }
        }

        private void LoadProjectData()
        {
            if (_project == null) return;

            // Đổ dữ liệu Text
            txtProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;

            // Đổ dữ liệu Date
            if (_project.StartDate >= dtpStartDate.MinDate) dtpStartDate.Value = _project.StartDate;
            if (_project.Deadline >= dtpEndDate.MinDate) dtpEndDate.Value = _project.Deadline;

            // Đổ dữ liệu Manager
            if (_project.ManagerID != null)
            {
                cmbManager.SelectedValue = _project.ManagerID;
            }

            // Đổ dữ liệu Progress
            int progress = _project.Progress;
            prgProgress.Value = Math.Max(0, Math.Min(100, progress));
            lblProgressPercent.Text = prgProgress.Value + " %";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation cơ bản
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dự án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProjectName.Focus();
                return;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy dữ liệu từ giao diện
            int? managerId = cmbManager.SelectedValue != null ? (int)cmbManager.SelectedValue : (int?)null;

            try
            {
                if (_isEdit)
                {
                    // CẬP NHẬT
                    _project.ProjectName = txtProjectName.Text.Trim();
                    _project.Description = txtDescription.Text.Trim();
                    _project.StartDate = dtpStartDate.Value;
                    _project.Deadline = dtpEndDate.Value;
                    _project.ManagerID = managerId;
                    // Progress thường được cập nhật ở form Task, nhưng nếu cho sửa ở đây:
                    _project.Progress = prgProgress.Value;

                    _service.Update(_project);
                    MessageBox.Show("Cập nhật dự án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // THÊM MỚI
                    Project newProject = new Project
                    {
                        ProjectName = txtProjectName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        StartDate = dtpStartDate.Value,
                        Deadline = dtpEndDate.Value,
                        ManagerID = managerId,
                        Progress = 0,
                        IsDeleted = false
                    };

                    _service.Add(newProject);
                    MessageBox.Show("Thêm dự án mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cập nhật label phần trăm khi kéo thanh progress (nếu prgProgress là TrackBar/HScrollBar)
        // Nếu prgProgress là ProgressBar thuần, bạn có thể thêm NumericUpDown để chỉnh %
        private void prgProgress_ValueChanged(object sender, EventArgs e)
        {
            lblProgressPercent.Text = prgProgress.Value + " %";
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}