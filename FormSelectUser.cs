using PMS.DAL;
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
    public partial class FormSelectUser : Form
    {
        public int SelectedUserId { get; private set; }
        private readonly PMSDbContext _context;
        private readonly int _projectId;
        private bool _isEditMode; // Biến kiểm tra chế độ

        // Constructor mặc định cho Thêm mới
        public FormSelectUser(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            _context = new PMSDbContext();
            _isEditMode = false; // Mặc định là Thêm
        }

        // Hàm public để bên Form chính gọi khi muốn Sửa
        public void SetEditMode(bool isEdit)
        {
            _isEditMode = isEdit;
            UpdateUIByMode();
        }

        private void UpdateUIByMode()
        {
            if (_isEditMode)
            {
                this.Text = "CHỈNH SỬA THÀNH VIÊN DỰ ÁN";
                guna2Button1.Text = "CẬP NHẬT";
                guna2Button1.FillColor = Color.FromArgb(16, 185, 129); // Màu xanh lá cho nút sửa
            }
            else
            {
                this.Text = "THÊM THÀNH VIÊN VÀO DỰ ÁN";
                guna2Button1.Text = "THÊM VÀO DỰ ÁN";
                guna2Button1.FillColor = Color.FromArgb(30, 64, 175); // Màu xanh dương cho nút thêm
            }
        }
        private void FormSelectUser_Load(object sender, EventArgs e)
        {
            StyleGridUsers();

            var users = _context.Users
                .Where(u => !_context.ProjectMembers
                    .Any(pm => pm.ProjectID == _projectId && pm.UserID == u.UserID))
                .Select(u => new
                {
                    u.UserID,
                    u.FullName,
                    u.Role,
                    u.Status
                })
                .ToList();

            dgvUsers.DataSource = users;
        }

        private void StyleGridUsers()
        {
            guna2Button1.Text = "THÊM VÀO DỰ ÁN";
            guna2Button1.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            guna2Button1.FillColor = Color.FromArgb(30, 64, 175);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.BorderRadius = 6;

            btnCancel.Text = "HỦY";
            btnCancel.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
            btnCancel.FillColor = Color.FromArgb(220, 38, 38);
            btnCancel.ForeColor = Color.White;
            btnCancel.BorderRadius = 6;

            btnCancel.Click += (s, e) => this.Close();

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersHeight = 45;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12f, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;

            dgvUsers.RowTemplate.Height = 34;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.MultiSelect = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvUsers.DefaultCellStyle.Font =
                new Font("Segoe UI", 12f, FontStyle.Regular);

            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserID",
                DataPropertyName = "UserID",
                HeaderText = "Mã NV",
                Width = 90
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và tên",
                Width = 220
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Vai trò",
                Width = 130
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {

                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Width = 120
            });
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            // Cách 1: Truy cập bằng tên (Sau khi đã sửa bước 1 ở trên)
            // string status = dgvUsers.CurrentRow.Cells["Status"].Value?.ToString();

            // Cách 2: Tìm cột dựa trên DataPropertyName (An toàn nhất nếu không nhớ tên cột)
            var statusColumn = dgvUsers.Columns.Cast<DataGridViewColumn>()
                                .FirstOrDefault(c => c.DataPropertyName == "Status");

            if (statusColumn != null)
            {
                string status = dgvUsers.CurrentRow.Cells[statusColumn.Index].Value?.ToString();

                if (status == "Inactive")
                {
                    MessageBox.Show("Nhân viên này đã ngừng hoạt động!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            SelectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            DialogResult = DialogResult.OK;
        }
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SelectedUserId =
                Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);

            DialogResult = DialogResult.OK;


        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.RowIndex < 0) return;

            // 1. Chuyển đổi VAI TRÒ (Role)
            if (dgvUsers.Columns[e.ColumnIndex].DataPropertyName == "Role")
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

            // 2. Chuyển đổi TRẠNG THÁI (Status) và TÔ MÀU
            if (dgvUsers.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "Available":
                        e.Value = "Sẵn sàng";
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá
                        break;
                    case "Busy":
                        e.Value = "Đang bận";
                        e.CellStyle.ForeColor = Color.FromArgb(245, 158, 11); // Cam/Vàng
                        break;
                    case "Inactive":
                        e.Value = "Ngừng hoạt động"; // Đã cập nhật theo yêu cầu
                        e.CellStyle.ForeColor = Color.Gray; // Màu xám
                        break;
                }
                e.FormattingApplied = true;
            }
        }
    }

}
