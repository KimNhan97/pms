using PMS.BLL;
using PMS.DTO;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormProjectMembers : Form
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMemberService _service;
        private bool _isLoadingProject = false;


        private int _selectedUserId = 0;
        public FormProjectMembers(IProjectMemberService service, IProjectService projectService)
        {
            InitializeComponent();
            _service = service;
            _projectService = projectService;
        }

        private void FormProjectMembers_Load(object sender, EventArgs e)
        {
            // 🔐 BẮT BUỘC: Kiểm tra đã login chưa
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.");
                this.Close();
                return;
            }

            StyleGrid();
            StyleButtons();
            LoadProjects();

            // 🔐 PHÂN QUYỀN THEO SESSION
            // Lấy vai trò của người dùng đang đăng nhập
            string currentRole = Session.CurrentUser.Role;

            // Nếu KHÔNG phải là Admin và cũng KHÔNG phải là PM (tức là Nhân viên) thì mới ẩn nút
            if (currentRole != "Admin" && currentRole != "PM")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = false;
            }

            var project = cboProject.SelectedItem as ProjectDTO;
            if (project != null)
            {
                LoadMembers(project.ProjectID);
            }
        }


        // ================= LOAD PROJECTS =================
        private void LoadProjects()
        {
            _isLoadingProject = true;

            var allProjects = _projectService.GetAll() ?? new List<ProjectDTO>();
            List<ProjectDTO> displayProjects;

            if (Session.IsAdmin)
            {
                displayProjects = allProjects;
            }
            else
            {
                int currentUserId = Session.CurrentUser.UserID;

                var myProjectIds = _service.GetAllMembers()
                    .Where(m => m.UserID == currentUserId)
                    .Select(m => m.ProjectID)
                    .Distinct()
                    .ToList();

                displayProjects = allProjects
                    .Where(p => myProjectIds.Contains(p.ProjectID))
                    .ToList();
            }

            var finalItems = new List<ProjectDTO>
    {
        new ProjectDTO
        {
            ProjectID = 0,
            ProjectName = Session.IsAdmin ? "Tất cả dự án" : "Dự án của tôi"
        }
    };

            finalItems.AddRange(displayProjects);

            cboProject.DataSource = null;
            cboProject.DisplayMember = "ProjectName";
            cboProject.ValueMember = "ProjectID";
            cboProject.DataSource = finalItems;

            cboProject.SelectedIndex = 0;

            _isLoadingProject = false;
        }




        // ================= SELECT PROJECT =================
        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingProject) return;

            var project = cboProject.SelectedItem as ProjectDTO;
            if (project == null) return;

            LoadMembers(project.ProjectID);
        }


        



        // ================= LOAD MEMBERS =================
        private void LoadMembers(int projectId)
        {
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _service.GetMembers(projectId);
        }




        // ================= GRID STYLE =================
        private void StyleGrid()
        {
            dgvMembers.AutoGenerateColumns = false;

            // ===== HEADER STYLE =====
            dgvMembers.ColumnHeadersVisible = true;
            dgvMembers.ColumnHeadersHeight = 45;
            dgvMembers.EnableHeadersVisualStyles = false;

            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12f, FontStyle.Bold);

            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // ===== ROW STYLE =====
            dgvMembers.RowTemplate.Height = 34;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            dgvMembers.CellFormatting += dgvMembers_CellFormatting;

            dgvMembers.DefaultCellStyle.Font =
                new Font("Segoe UI", 12f, FontStyle.Regular);

            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvMembers.Columns.Clear();

            // 1. Cột Mã NV
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserID",
                DataPropertyName = "UserID",
                HeaderText = "Mã NV",
                Width = 80
            });

            // 2. THÊM MỚI: Cột Tên dự án
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProjectName",
                DataPropertyName = "ProjectName", // Đảm bảo ProjectMemberDTO có property này
                HeaderText = "Dự án",
                Width = 180
            });

            // 3. Họ và tên
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và tên",
                Width = 200
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Vai trò",
                Width = 120
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Width = 120
            });
        }

        private void StyleButtons()
        {
            // ===== ADD BUTTON =====
            btnAdd.Height = 35;
            btnAdd.BorderRadius = 10;
            btnAdd.FillColor = Color.FromArgb(37, 99, 235); // xanh modern
            btnAdd.ForeColor = Color.White;
            btnAdd.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            btnAdd.DisabledState.FillColor = Color.FromArgb(200, 200, 200);

            // ===== REMOVE BUTTON =====
            btnRemove.Height = 35;
            btnRemove.BorderRadius = 10;
            btnRemove.FillColor = Color.FromArgb(220, 38, 38); // đỏ danger
            btnRemove.ForeColor = Color.White;
            btnRemove.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            btnRemove.DisabledState.FillColor = Color.FromArgb(200, 200, 200);
        }



        // ================= SELECT MEMBER =================
        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _selectedUserId =
                Convert.ToInt32(dgvMembers.Rows[e.RowIndex].Cells["UserID"].Value);
        }

        // ================= ADD MEMBER =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var project = cboProject.SelectedItem as ProjectDTO;
            if (project == null || project.ProjectID == 0)
            {
                MessageBox.Show("Vui lòng chọn dự án");
                return;
            }

            using (var frm = new FormSelectUser(project.ProjectID))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _service.AddMember(project.ProjectID, frm.SelectedUserId);
                    LoadMembers(project.ProjectID);
                }
            }
        }





        // ================= REMOVE MEMBER =================
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa");
                return;
            }

            var project = cboProject.SelectedItem as ProjectDTO;
            if (project == null || project.ProjectID == 0) return;

            if (MessageBox.Show(
                "Xóa thành viên khỏi dự án?",
                "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _service.RemoveMember(project.ProjectID, _selectedUserId);
            _selectedUserId = 0;
            LoadMembers(project.ProjectID);
        }

        private void dgvMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;

            // 1. Chuyển đổi VAI TRÒ (Vai trò)
            if (dgvMembers.Columns[e.ColumnIndex].DataPropertyName == "Role")
            {
                string role = e.Value.ToString();
                switch (role)
                {
                    case "Admin":
                        e.Value = "Quản trị viên";
                        break;
                    case "Employee":
                    case "User":
                        e.Value = "Nhân viên";
                        break;
                }
                e.FormattingApplied = true;
            }

            // 2. Chuyển đổi TRẠNG THÁI (Trạng thái) và THIẾT LẬP MÀU SẮC
            if (dgvMembers.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "Available":
                    case "Sẵn sàng": // Đề phòng trường hợp giá trị đã là tiếng Việt
                        e.Value = "Sẵn sàng";
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá
                        break;
                    case "Busy":
                    case "Dang ban":
                    case "Đang bận":
                        e.Value = "Đang bận";
                        e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ
                        break;
                    case "Inactive":
                        e.Value = "Ngừng hoạt động";
                        e.CellStyle.ForeColor = Color.Gray;
                        break;
                }
                e.FormattingApplied = true;
            }
        }
    }
}
