using Autofac.Core;
using PMS.BLL;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMS
{
    public partial class FrmTaskManager : Form
    {
        private ITaskService _taskService;


        public FrmTaskManager(ITaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;
        }
        private Timer _searchTimer;
        private void InitSearchTimer()
        {
            _searchTimer = new Timer { Interval = 300 };
            _searchTimer.Tick += (s, e) =>
            {
                _searchTimer.Stop();
                LoadGrid();
            };
        }
        private void LoadData()
        {
            dgvTask.DataSource = null;

            dgvTask.DataSource = _taskService.GetTasksForUser(
                Session.CurrentUser.UserID,
                Session.IsAdmin
            );
        }
        private void LoadGrid()
        {
            // Keyword: Kiểm tra màu chữ để tránh lấy placeholder
            string keyword = (txtKeyword.ForeColor == Color.Gray) ? "" : txtKeyword.Text.Trim();

            // Dự án: Index 0 là "Tất cả dự án" -> truyền null
            int? projectId = cboProject.SelectedIndex > 0
                ? (int?)Convert.ToInt32(cboProject.SelectedValue)
                : null;

            // Nhân viên: Index 0 là "Tất cả nhân viên" -> truyền null
            int? userId = cboUser.SelectedIndex > 0
                ? (int?)Convert.ToInt32(cboUser.SelectedValue)
                : null;

            // Ép quyền xem: Nếu không phải Admin thì chỉ lọc trong Task của chính mình
            if (!Session.IsAdmin)
            {
                userId = Session.CurrentUser.UserID;
            }

            // Trạng thái: Chuyển Việt -> Anh để khớp với DB
            string statusVN = cboStatus.Text;
            string statusEN = null; // Mặc định là null để lấy tất cả

            if (statusVN == "Chờ xử lý") statusEN = "Pending";
            else if (statusVN == "Đang thực hiện") statusEN = "Doing";
            else if (statusVN == "Hoàn thành") statusEN = "Done";
            else if (statusVN == "Đã hủy") statusEN = "Cancelled";

            // Gọi Service và nạp lại Grid
            dgvTask.DataSource = null;
            dgvTask.DataSource = _taskService.SearchTasks(keyword, projectId, userId, statusEN);
        }


        private void ApplyFilter()
        {
            string keyword = txtKeyword.Text.Trim();

            int? projectId = cboProject.SelectedIndex > 0
                ? (int?)Convert.ToInt32(cboProject.SelectedValue)
                : null;

            int? userId = cboUser.SelectedIndex > 0
                ? (int?)Convert.ToInt32(cboUser.SelectedValue)
                : null;

            string status = cboStatus.SelectedIndex > 0
                ? cboStatus.Text
                : null;

            if (Session.IsAdmin)
            {
                dgvTask.DataSource = _taskService.SearchTasks(
                    keyword,
                    projectId,
                    userId,
                    status
                );
            }
            else
            {
                // User chỉ tìm trong task của mình
                dgvTask.DataSource = _taskService.SearchTasks(
                    keyword,
                    projectId,
                    Session.CurrentUser.UserID,
                    status
                );
            }

        }
        private void InitControls()
        {
            // Màu sắc chủ đạo
            Color primaryColor = Color.FromArgb(94, 148, 255);
            Color dangerColor = Color.FromArgb(239, 68, 68);
            Color textColor = Color.FromArgb(31, 41, 55);

            // 1. Tối ưu TextBox Tìm kiếm
            txtKeyword.Size = new Size(200, 60);
            txtKeyword.AutoSize = false;

            txtKeyword.PlaceholderText = "Tìm theo tên công việc...";
            txtKeyword.Font = new Font("Segoe UI", 12);
            txtKeyword.BorderRadius = 8;
            txtKeyword.Padding = new Padding(10, 0, 0, 0); // Tạo khoảng trống cho text
            txtKeyword.FocusedState.BorderColor = primaryColor;

            // 2. Tối ưu các ComboBox (Guna2ComboBox)
            var combos = new[] { cboProject, cboStatus, cboUser };
            foreach (var cb in combos)
            {
                cb.BorderRadius = 8;
                cb.Font = new Font("Segoe UI", 10);
                cb.HoverState.BorderColor = primaryColor;
                cb.ItemHeight = 30; // Giúp danh sách xổ xuống thoáng hơn
            }
            SetupSearchTextBox(txtKeyword);
            SetupCombo(cboProject);
            SetupCombo(cboUser);

            // 3. Tối ưu các Button
            btnAdd.BorderRadius = 8;
            btnAdd.FillColor = primaryColor;
            btnAdd.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnUpdate.BorderRadius = 8;
            btnUpdate.FillColor = Color.FromArgb(16, 185, 129); // Màu xanh lá hiện đại

            btnDelete.BorderRadius = 8;
            btnDelete.FillColor = dangerColor;

            btnReset.BorderRadius = 8; // "Làm mới" nên dùng outline hoặc màu nhẹ
            btnReset.FillColor = Color.FromArgb(156, 163, 175);

            // Tìm đoạn cboStatus.Items.Clear() và thay bằng:
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[]
            {
    "Tất cả",
    "Chờ xử lý",
    "Đang thực hiện",
    "Hoàn thành",
    "Đã hủy"
            });
            cboStatus.SelectedIndex = 0;
        }


        private void InitGrid()
        {
            // ================= THEME CHUNG =================
            dgvTask.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;

            dgvTask.EnableHeadersVisualStyles = false;
            dgvTask.ColumnHeadersHeight = 45;
            dgvTask.RowHeadersVisible = false;
            dgvTask.CellFormatting += dgvTask_CellFormatting;

            // ================= HEADER =================
            dgvTask.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 23, 42); // Xanh đậm hiện đại
            dgvTask.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTask.ThemeStyle.HeaderStyle.Font =
                new Font("Segoe UI Semibold", 12, FontStyle.Bold); // fallback an toàn cho Seoul
            dgvTask.ThemeStyle.HeaderStyle.Height = 45;

            dgvTask.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // ================= ROW =================
            dgvTask.ThemeStyle.RowsStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            dgvTask.ThemeStyle.RowsStyle.Height = 42;
            dgvTask.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTask.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(31, 41, 55);

            dgvTask.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(224, 242, 254); // xanh nhạt
            dgvTask.ThemeStyle.RowsStyle.SelectionForeColor =
                Color.FromArgb(2, 132, 199);

            dgvTask.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgvTask.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTask.GridColor = Color.FromArgb(226, 232, 240);

            // ================= CĂN CHỈNH =================
            dgvTask.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvTask.DefaultCellStyle.Padding = new Padding(5);

            dgvTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ================= CỘT =================
            dgvTask.AutoGenerateColumns = false;
            dgvTask.Columns.Clear();

            AddColumn("TaskName", "TÊN CÔNG VIỆC", 200, alignLeft: true);
            AddColumn("ProjectName", "DỰ ÁN", 150, alignLeft: true);
            AddColumn("AssignedUser", "NGƯỜI THỰC HIỆN", 160);
            AddColumn("Status", "TRẠNG THÁI", 120);
            AddColumn("StartDate", "BẮT ĐẦU", 110, "dd/MM/yyyy");
            AddColumn("Deadline", "HẠN CHÓT", 110, "dd/MM/yyyy");
        }


        // Hàm hỗ trợ tạo cột nhanh
        private void AddColumn(
    string dataProperty,
    string header,
    int width,
    string format = null,
    bool alignLeft = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProperty,
                HeaderText = header,
                MinimumWidth = width,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = alignLeft
                ? DataGridViewContentAlignment.MiddleLeft
                : DataGridViewContentAlignment.MiddleCenter
        }
            };

            if (!string.IsNullOrEmpty(format))
            {
                col.DefaultCellStyle.Format = format;
            }

            dgvTask.Columns.Add(col);
        }

        private void InitButtons()
        {
            // ===== ADD =====
            btnAdd.Text = "+ THÊM";
            SetupPrimaryButton(btnAdd);

            // ===== EDIT =====
            btnUpdate.Text = "✎ SỬA";
            SetupOutlineButton(btnUpdate);

            // ===== DELETE =====
            btnDelete.Text = "🗑 XÓA";
            SetupDangerButton(btnDelete);
        }
        private void SetupCombo(Guna.UI2.WinForms.Guna2ComboBox cbo)
        {
            cbo.BorderRadius = 8;
            cbo.BorderThickness = 1;
            cbo.BorderColor = Color.FromArgb(203, 213, 225);

            cbo.FillColor = Color.White;
            cbo.ForeColor = Color.FromArgb(31, 41, 55);

            cbo.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            cbo.Size = new Size(180, 36);
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbo.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            cbo.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
        }

        private void SetupSearchTextBox(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            txt.BorderRadius = 8;
            txt.BorderThickness = 1;
            txt.BorderColor = Color.FromArgb(203, 213, 225);

            txt.FillColor = Color.White;
            txt.ForeColor = Color.FromArgb(31, 41, 55);

            txt.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txt.PlaceholderText = "Nhập từ khóa...";
            txt.PlaceholderForeColor = Color.FromArgb(148, 163, 184);

            txt.Size = new Size(220, 36);

            // Focus
            txt.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            txt.HoverState.BorderColor = Color.FromArgb(37, 99, 235);

            txt.Cursor = Cursors.IBeam;
        }

        private void SetupDangerButton(Guna.UI2.WinForms.Guna2Button btn)
        {
            btn.BorderRadius = 10;
            btn.FillColor = Color.FromArgb(220, 38, 38);     // Đỏ
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.Size = new Size(100, 38);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            btn.DisabledState.FillColor = Color.FromArgb(203, 213, 225);
            btn.ShadowDecoration.Enabled = false;
        }
        private void SetupOutlineButton(Guna.UI2.WinForms.Guna2Button btn)
        {
            btn.BorderRadius = 10;
            btn.FillColor = Color.White;
            btn.ForeColor = Color.FromArgb(55, 65, 81);
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.BorderThickness = 1;
            btn.BorderColor = Color.FromArgb(220, 224, 230);

            btn.Size = new Size(100, 38);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            btn.HoverState.ForeColor = Color.FromArgb(37, 99, 235);

            btn.DisabledState.FillColor = Color.FromArgb(243, 244, 246);
            btn.ShadowDecoration.Enabled = false;
        }
        private void SetupPrimaryButton(Guna.UI2.WinForms.Guna2Button btn)
        {
            btn.BorderRadius = 10;
            btn.FillColor = Color.FromArgb(37, 99, 235);     // Xanh dương
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.Size = new Size(120, 38);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            btn.DisabledState.FillColor = Color.FromArgb(203, 213, 225);
            btn.ShadowDecoration.Enabled = false;
        }

        private void FrmTaskManager_Load(object sender, EventArgs e)
        {
            InitButtons();
            InitControls();
            InitGrid();
            LoadCombos();
            InitSearchTimer();

            if (!Session.IsAdmin)
            {
                cboUser.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }

            LoadGrid();
            // Giúp Grid mượt hơn khi cuộn
            dgvTask.StandardTab = true;
        }
        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        //private void txtKeyword_TextChanged(object sender, EventArgs e)
        //{
        //    ApplyFilter();
        //    LoadTasks();
        //    _searchTimer.Stop();
        //    _searchTimer.Start();
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmTaskEdit(_taskService, null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGrid();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTask.CurrentRow == null) return;

            TaskEntity task =
                dgvTask.CurrentRow.DataBoundItem as TaskEntity;

            // USER: chỉ được sửa task của mình
            if (!Session.IsAdmin)
            {
                if (task.AssignedTo != Session.CurrentUser.UserID)
                {
                    MessageBox.Show(
                        "Bạn chỉ được cập nhật công việc của mình",
                        "Không có quyền",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            // ADMIN hoặc USER hợp lệ -> mở form edit
            using (FrmTaskEdit frm = new FrmTaskEdit(_taskService, task))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGrid();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTask.CurrentRow == null) return;

            TaskEntity task =
                dgvTask.CurrentRow.DataBoundItem as TaskEntity;

            if (MessageBox.Show("Xóa công việc này?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _taskService.Delete(task.TaskId);
                LoadData();
            }
        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();
        private void cboUser_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();
        private void LoadCombos()
        {

            // ================= PROJECT =================
            var projects = _taskService.GetProjects();
            projects.Insert(0, new Project
            {
                ProjectID = 0,
                ProjectName = "Tất cả dự án"
            });

            cboProject.DataSource = projects;
            cboProject.DisplayMember = "ProjectName";
            cboProject.ValueMember = "ProjectID";
            cboProject.SelectedIndex = 0;

            SetupGunaCombo(cboProject);

            // ================= USER =================
            var users = _taskService.GetUsers();
            users.Insert(0, new User
            {
                UserID = 0,
                FullName = "Tất cả nhân viên"
            });

            cboUser.DataSource = users;
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "UserID";
            cboUser.SelectedIndex = 0;

            SetupGunaCombo(cboUser);
            SetupGunaCombo(cboStatus);
            
        }
        private void SetupGunaCombo(Guna.UI2.WinForms.Guna2ComboBox cbo)
        {
            cbo.BorderRadius = 8;
            cbo.BorderThickness = 1;
            cbo.BorderColor = Color.FromArgb(229, 231, 235);

            cbo.FillColor = Color.White;
            cbo.ForeColor = Color.FromArgb(31, 41, 55);

            cbo.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            cbo.ItemHeight = 36;
            cbo.DrawMode = DrawMode.OwnerDrawFixed;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbo.FocusedColor = Color.FromArgb(37, 99, 235);
            cbo.HoverState.BorderColor = Color.FromArgb(37, 99, 235);

            cbo.ShadowDecoration.Enabled = false;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            // Đưa các ComboBox về vị trí "Tất cả" (Index 0)
            if (cboProject.Items.Count > 0) cboProject.SelectedIndex = 0;
            if (cboUser.Items.Count > 0) cboUser.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            LoadGrid(); // Gọi hàm này để nạp lại toàn bộ danh sách

            //InitControls();
            //LoadCombos();
            //LoadData();
        }

        private void dgvTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột Trạng thái (Status)
            if (dgvTask.Columns[e.ColumnIndex].DataPropertyName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                switch (status)
                {
                    case "Pending":
                        e.Value = "Chờ xử lý";
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                    case "Doing":
                        e.Value = "Đang thực hiện";
                        e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Xanh dương
                        break;
                    case "Done":
                        e.Value = "Hoàn thành";
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá
                        break;
                    case "Cancelled":
                        e.Value = "Đã hủy";
                        e.CellStyle.ForeColor = Color.Gray;
                        break;
                }
                e.FormattingApplied = true;
            }
        }
    }
}
