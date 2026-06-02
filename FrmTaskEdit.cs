using PMS.BLL;
using PMS.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PMS
{
    public partial class FrmTaskEdit : Form
    {
        private readonly ITaskService _taskService;
        private TaskEntity _task;
        private readonly bool _isEdit;

        // ================= ADD =================
        public FrmTaskEdit(ITaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;
            _isEdit = false;
            _task = null; // tạo ở btnSave

        }

        // ================= EDIT =================
        public FrmTaskEdit(ITaskService taskService, TaskEntity task)
     : this(taskService)
        {
            if (task == null)
            {
                MessageBox.Show(
                    "Không thể chỉnh sửa công việc do dữ liệu rỗng.",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }

            _task = task;
            _isEdit = true;
        }



        // ================= LOAD =================
        private void FrmTaskEdit_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo giao diện cơ bản (Font, Placeholder...)
            InitControls();

            // 2. Load dữ liệu cho các ComboBox
            LoadCombobox();

            // 3. THIẾT LẬP CHẾ ĐỘ (Đây là phần quan trọng nhất cần chạy cuối)
            if (_isEdit && _task != null)
            {
                this.Text = "CHỈNH SỬA CÔNG VIỆC"; // Gán tiêu đề Form
                btnSave.Text = "CẬP NHẬT";         // Gán chữ cho nút
                btnSave.FillColor = Color.FromArgb(16, 185, 129); // Màu xanh lá khi sửa

                LoadTask(); // Đổ dữ liệu vào các ô
            }
            else
            {
                this.Text = "THÊM MỚI CÔNG VIỆC";  // Gán tiêu đề Form
                btnSave.Text = "LƯU MỚI";          // Gán chữ cho nút
                btnSave.FillColor = Color.FromArgb(30, 64, 175); // Màu xanh dương khi thêm

                // Mặc định ngày bắt đầu là hôm nay cho tiện
                dtStart.Value = DateTime.Today;
                dtDeadline.Value = DateTime.Today.AddDays(7);
            }
            btnSave.CheckedState.FillColor = btnSave.FillColor;
            btnSave.HoverState.FillColor = ControlPaint.Light(btnSave.FillColor);
        }

        // ================= INIT UI =================
        private void InitControls()
        {
            // Chỉ gán những thứ cố định không đổi theo chế độ
            txtTaskName.Font = new Font("Segoe UI", 12);
            txtTaskName.PlaceholderText = "Nhập tên công việc...";

            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new[]
            {
        "Chờ xử lý",
        "Đang thực hiện",
        "Hoàn thành",
        "Đã hủy"
    });
            cboStatus.SelectedIndex = 0;

            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.CustomFormat = "dd/MM/yyyy";

            dtDeadline.Format = DateTimePickerFormat.Custom;
            dtDeadline.CustomFormat = "dd/MM/yyyy";
        }
        // ================= LOAD COMBO =================
        private void LoadCombobox()
        {
            // ===== PROJECT =====
            var projects = _taskService.GetProjects();
            projects.Insert(0, new Project
            {
                ProjectID = 0,
                ProjectName = "-- Chọn dự án --"
            });

            cboProject.DataSource = projects;
            cboProject.DisplayMember = "ProjectName";
            cboProject.ValueMember = "ProjectID";
            cboProject.SelectedIndex = 0;

            // ===== USER =====
            var users = _taskService.GetUsers();
            users.Insert(0, new User
            {
                UserID = 0,
                FullName = "-- Chưa phân công --"
            });

            var allUsers = _taskService.GetUsers();
            var activeUsers = allUsers.Where(u => u.Status != "Inactive").ToList();

            // Trường hợp đang SỬA task mà người được phân công cũ bỗng nhiên bị Inactive
            // Chúng ta vẫn phải thêm họ vào list để không bị lỗi hiển thị, nhưng sẽ chặn ở nút Lưu
            if (_isEdit && _task != null && _task.AssignedTo.HasValue)
            {
                var currentUser = allUsers.FirstOrDefault(u => u.UserID == _task.AssignedTo.Value);
                if (currentUser != null && !activeUsers.Any(u => u.UserID == currentUser.UserID))
                {
                    activeUsers.Add(currentUser);
                }
            }

            activeUsers.Insert(0, new User { UserID = 0, FullName = "-- Chưa phân công --" });

            cboUser.DataSource = activeUsers;
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "UserID";
            cboUser.SelectedIndex = 0;
        }

        // ================= LOAD TASK (EDIT) =================
        private void LoadTask()
        {
            txtTaskName.Text = _task.TaskName;
            cboProject.SelectedValue = _task.ProjectId;
            string statusVN = "Chờ xử lý";
            if (_task.Status == "Doing") statusVN = "Đang thực hiện";
            else if (_task.Status == "Done") statusVN = "Hoàn thành";
            else if (_task.Status == "Cancelled") statusVN = "Đã hủy";

            cboStatus.SelectedItem = statusVN;

            dtStart.Value = _task.StartDate ?? DateTime.Today;
            dtDeadline.Value = _task.Deadline;

            if (_task.AssignedTo.HasValue)
                cboUser.SelectedValue = _task.AssignedTo.Value;
            else
                cboUser.SelectedIndex = 0;
        }

        // ================= SAVE =================


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên công việc");
                return;
            }

            if (cboProject.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn dự án");
                return;
            }

            if (dtDeadline.Value.Date < dtStart.Value.Date)
            {
                MessageBox.Show("Hạn chót không được trước ngày bắt đầu");
                return;
            }

            TaskEntity task;

            if (_isEdit)
            {
                if (_task == null)
                {
                    MessageBox.Show("Không tải được dữ liệu công việc để chỉnh sửa.");
                    return;
                }
                task = _task;
            }
            else
            {
                task = new TaskEntity();
            }

            task.TaskName = txtTaskName.Text.Trim();
            task.ProjectId = (int)cboProject.SelectedValue;

            string statusVN = cboStatus.SelectedItem.ToString();
            string statusEN = "Pending";

            if (statusVN == "Đang thực hiện") statusEN = "Doing";
            else if (statusVN == "Hoàn thành") statusEN = "Done";
            else if (statusVN == "Đã hủy") statusEN = "Cancelled";

            task.Status = statusEN;
            task.StartDate = dtStart.Value.Date;
            task.Deadline = dtDeadline.Value.Date;

            task.AssignedTo = cboUser.SelectedIndex > 0
                ? (int?)cboUser.SelectedValue
                : null;

            if (!Session.IsAdmin && !task.AssignedTo.HasValue)
                task.AssignedTo = Session.CurrentUser.UserID;

            try
            {
                if (_isEdit)
                    _taskService.Update(task);
                else
                    _taskService.Add(task);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
