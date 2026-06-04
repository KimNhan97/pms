using PMS.BLL;
using PMS.Entities;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormUserManagement : Form
    {
        private readonly IAuthService _userService;
        private Timer _searchTimer;

        public FormUserManagement(IAuthService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void HideNavigationColumns()
        {
            if (dgvUsers.Columns["ManagedProjects"] != null)
                dgvUsers.Columns["ManagedProjects"].Visible = false;

            if (dgvUsers.Columns["ProjectMemberships"] != null)
                dgvUsers.Columns["ProjectMemberships"].Visible = false;
        }

        private void LoadUsers()
        {
            // 1. Nạp dữ liệu
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _userService.GetAll();

            // 2. Ẩn các cột không cần thiết
            HideNavigationColumns();

            // 3. Việt hóa Tiêu đề cột (Header Text)
            if (dgvUsers.Columns["UserID"] != null) dgvUsers.Columns["UserID"].HeaderText = "Mã NV";
            if (dgvUsers.Columns["FullName"] != null) dgvUsers.Columns["FullName"].HeaderText = "Họ và Tên";
            if (dgvUsers.Columns["Username"] != null) dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
            if (dgvUsers.Columns["Role"] != null) dgvUsers.Columns["Role"].HeaderText = "Vai trò";
            if (dgvUsers.Columns["Status"] != null) dgvUsers.Columns["Status"].HeaderText = "Trạng thái";

<<<<<<< HEAD
            // 4. Áp dụng Style chuẩn (Màu Header đen, chữ trắng, khoảng cách dòng)
            StyleDGV(dgvUsers);
        }
=======
            // Ẩn cột mật khẩu để bảo mật và đẹp giao diện
            //if (dgvUsers.Columns["PasswordHash"] != null) dgvUsers.Columns["PasswordHash"].Visible = false;

            // 4. Áp dụng Style chuẩn (Màu Header đen, chữ trắng, khoảng cách dòng)
            StyleDGV(dgvUsers);
        }


>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            // ===== ĐÃ CẬP NHẬT: Thêm PM vào ComboBox =====
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new[] { "Quản trị viên", "Quản lý dự án (PM)", "Nhân viên" });

            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new[] { "Sẵn sàng", "Đang bận", "Ngừng hoạt động" });
            cboSearchStatus.Items.Clear();
            cboSearchStatus.Items.AddRange(new[]
            {
                "Tất cả trạng thái",
                "Sẵn sàng",
                "Đang bận",
                "Ngừng hoạt động"
            });
            cboSearchStatus.SelectedIndex = 0;

            StyleRefresh(btnReload);
            StyleDelete(btnDelete);
            StyleUpdate(btnUpdate);
            StyleAdd(btnAdd);
            StyleSave(btnSave);

            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoGenerateColumns = true;

            _searchTimer = new Timer();
            _searchTimer.Interval = 300; // 300ms sau khi ngừng gõ
            _searchTimer.Tick += (s, ev) =>
            {
                _searchTimer.Stop();
                ApplyFilter();
            };

<<<<<<< HEAD
            StyleDGV(dgvUsers);
            StyleUpdate(btnUpdate);
            LoadUsers();
=======

            StyleDGV(dgvUsers); 
            StyleUpdate(btnUpdate);
            LoadUsers();

>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsers.Rows[e.RowIndex];

            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            cboRole.Text = row.Cells["Role"].Value.ToString();
            cboStatus.Text = row.Cells["Status"].Value.ToString();

            txtPassword.Text = ""; // KHÔNG load mật khẩu
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormCreateUser frm = new FormCreateUser(_userService))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // reload danh sách sau khi thêm
                }
            }
        }

        private void ClearEditPanel()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;

            dgvUsers.ClearSelection();
        }

        private void ResetFilter()
        {
            // Text search
            txtSearchName.Text = "Tìm kiếm theo tên...";
            txtSearchName.ForeColor = Color.Gray;

            // Combo trạng thái
            cboSearchStatus.SelectedIndex = 0; // "Tất cả trạng thái"

            // Reload toàn bộ danh sách
            LoadUsers();

            // Bỏ chọn dòng
            dgvUsers.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
                return;

            string message;
            bool success = _userService.DeleteUser(_selectedUserId.Value, out message);

            MessageBox.Show(message);

            if (success)
            {
                LoadUsers();
                ClearEditPanel();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa");
                return;
            }
            if (dgvUsers.CurrentRow == null) return;

            int id = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;

            User user = new User
            {
                UserID = id,
                FullName = txtFullName.Text,
                Username = txtUsername.Text,
                Role = ConvertRoleToEN(cboRole.Text),
                Status = ConvertStatusToEN(cboStatus.Text),
                PasswordHash = txtPassword.Text // có thể rỗng
            };
            _userService.Update(user);
            LoadUsers();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // 1. Reset các ô nhập liệu
            ClearEditPanel();

            // 2. Reset ô tìm kiếm
            txtSearchName.ForeColor = Color.Gray;
            cboSearchStatus.SelectedIndex = 0;

            // 3. Gọi lại hàm LoadUsers (Hàm này đã có StyleDGV nên sẽ luôn đẹp)
            LoadData();
<<<<<<< HEAD
=======

>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10
        }

        private void LoadUserToPanel(DataGridViewRow row)
        {
            _selectedUserId = (int)row.Cells["UserID"].Value;

            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();

            // Chuyển sang tiếng Việt để hiển thị
            cboRole.Text = ConvertRoleToVN(row.Cells["Role"].Value.ToString());
            cboStatus.Text = ConvertStatusToVN(row.Cells["Status"].Value.ToString());

            txtPassword.Text = "";
        }

        private int? _selectedUserId = null;

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            LoadUserToPanel(row);
        }

<<<<<<< HEAD
=======
     
>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10
        private void SearchUsers()
        {
            // 1. Lấy từ khóa tìm kiếm (Xử lý Placeholder)
            string keyword = (txtSearchName.ForeColor == Color.Gray)
                ? string.Empty
                : txtSearchName.Text.Trim();

            // 2. Lấy trạng thái từ ComboBox
            string statusVN = cboSearchStatus.SelectedItem != null
                ? cboSearchStatus.SelectedItem.ToString()
                : "Tất cả trạng thái";

            // 3. Chuyển đổi ngôn ngữ VN -> EN
            string statusEN = null;

            if (statusVN == "Sẵn sàng")
            {
                statusEN = "Available";
            }
            else if (statusVN == "Đang bận")
            {
                statusEN = "Busy";
            }
            else if (statusVN == "Ngừng hoạt động")
            {
                statusEN = "Inactive";
            }

            try
            {
                // 4. Gọi service để lấy dữ liệu 
                var data = _userService.SearchUsers(keyword, statusEN);

                // 5. Cập nhật giao diện DataGridView
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = data;

                // 6. Định dạng lại cột
                HideNavigationColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void panelEdit_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                Rectangle rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                e.Graphics.DrawRectangle(pen, rect);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedPath(panelEdit.ClientRectangle, 10))
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        public static void SetBorderRadius(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(control.Width - d, 0, d, d, 270, 90);
            path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
            path.AddArc(0, control.Height - d, d, d, 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }

        private void label6_Click(object sender, EventArgs e) { }

        //Chỉnh giao diện 
        private void SetRounded(Control c, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(c.Width - d, 0, d, d, 270, 90);
            path.AddArc(c.Width - d, c.Height - d, d, d, 0, 90);
            path.AddArc(0, c.Height - d, d, d, 90, 90);
            path.CloseFigure();

            c.Region = new Region(path);
        }

        private void StyleRefresh(Button btn)
        {
            btn.Text = "  ⟳  Làm mới";
            btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            btn.BackColor = Color.White;
            btn.ForeColor = Color.FromArgb(64, 64, 64);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.LightGray;
            btn.UseVisualStyleBackColor = false;

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(245, 245, 245);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
        }

        private void StyleDelete(Button btn)
        {
            Color normal = Color.FromArgb(220, 53, 69);
            Color hover = Color.FromArgb(200, 35, 51);

            btn.Text = "  🗑  Xóa";
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.BackColor = normal;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;

            SetRounded(btn, 8);

            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        private void StyleUpdate(Button btn)
        {
            Color normal = Color.FromArgb(13, 110, 253);
            Color hover = Color.FromArgb(11, 94, 215);

            btn.Text = "  ✏  Sửa";
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.BackColor = normal;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;

            SetRounded(btn, 8);

            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        private void StyleAdd(Button btn)
        {
            Color normal = Color.FromArgb(25, 135, 84);   // xanh lá
            Color hover = Color.FromArgb(20, 108, 67);   // xanh lá đậm

            btn.Text = "  +  Thêm mới";
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.BackColor = normal;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;

            SetRounded(btn, 5);

            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        private void StyleSave(Guna.UI2.WinForms.Guna2Button btn)
        {
            btn.Text = "Lưu";
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btn.FillColor = Color.FromArgb(59, 130, 246);      // xanh Save
            btn.HoverState.FillColor = Color.FromArgb(37, 99, 235);

            btn.ForeColor = Color.White;

            btn.BorderRadius = 8;
            btn.BorderThickness = 0;

            btn.ImageAlign = HorizontalAlignment.Left;
            btn.ImageOffset = new Point(5, 0);
            btn.TextOffset = new Point(10, 0);

            btn.Cursor = Cursors.Hand;

            // Disabled state
            btn.DisabledState.FillColor = Color.FromArgb(203, 213, 225);
            btn.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void txtFullName_TextChanged(object sender, EventArgs e) { }

        void StyleDGV(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Màu Header
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Màu dòng dữ liệu và độ cao dòng
            dgv.RowTemplate.Height = 55;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dgv.DefaultCellStyle.Padding = new Padding(10);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Màu khi chọn dòng
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            // Xử lý cột Vai trò
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role")
            {
                string role = e.Value.ToString();
                e.Value = ConvertRoleToVN(role); // Đổi sang tiếng Việt
                e.FormattingApplied = true;

                e.CellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                if (role == "Admin")
                {
                    e.CellStyle.BackColor = Color.FromArgb(224, 231, 255);
                    e.CellStyle.ForeColor = Color.FromArgb(67, 56, 202);
                }
                // ===== ĐÃ CẬP NHẬT: Thêm Style riêng biệt cho thẻ Role PM =====
                else if (role == "PM")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 237, 213); // Nền màu cam nhạt
                    e.CellStyle.ForeColor = Color.FromArgb(194, 65, 12);   // Chữ màu cam đậm
                }
            }

            // Xử lý cột Trạng thái
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Status")
            {
                string status = e.Value.ToString();
                e.Value = ConvertStatusToVN(status); // Đổi sang tiếng Việt
                e.FormattingApplied = true;

                e.CellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                if (status == "Available")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                }
                else if (status == "Busy")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(202, 138, 4);
                }
                else if (status == "Inactive")
                {
                    e.CellStyle.BackColor = Color.FromArgb(243, 244, 246);
                    e.CellStyle.ForeColor = Color.FromArgb(107, 114, 128);
                }
            }
        }

        private void LoadData() => ApplyFilter();

<<<<<<< HEAD
        private void panel1_Paint(object sender, PaintEventArgs e) { }
=======
        private void LoadData() => ApplyFilter();
>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa trước khi lưu");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                cboRole.SelectedIndex < 0 ||
                cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            try
            {
                User user = new User
                {
                    UserID = _selectedUserId.Value,
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Role = ConvertRoleToEN(cboRole.Text),
                    Status = ConvertStatusToEN(cboStatus.Text),

                    // Gán trực tiếp không qua hàm Hash
                    PasswordHash = txtPassword.Text.Trim()
                };

                _userService.Update(user);

                MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo");

                LoadUsers();        // reload danh sách
                ClearEditPanel();  // clear panel chỉnh sửa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            LoadUserToPanel(row);
        }

        // ===== ĐÃ CẬP NHẬT: Xử lý dịch thuật ngôn ngữ cho PM =====
        private string ConvertRoleToVN(string role)
        {
            if (role == "Admin") return "Quản trị viên";
            if (role == "PM") return "Quản lý dự án (PM)"; // Thêm dòng này
            if (role == "Employee") return "Nhân viên";

            return role;
        }

        private string ConvertRoleToEN(string roleVN)
        {
            if (roleVN == "Quản trị viên") return "Admin";
            if (roleVN == "Quản lý dự án (PM)") return "PM"; // Thêm dòng này
            if (roleVN == "Nhân viên") return "Employee";

            return roleVN;
        }

        private string ConvertStatusToVN(string status)
        {
            if (status == "Available") return "Sẵn sàng";
            if (status == "Busy") return "Đang bận";
            if (status == "Inactive") return "Ngừng hoạt động";

            return status;
        }

        private string ConvertStatusToEN(string statusVN)
        {
<<<<<<< HEAD
=======

>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10
            if (string.IsNullOrWhiteSpace(statusVN) || statusVN == "Tất cả trạng thái")
                return null;

            if (statusVN == "Sẵn sàng") return "Available";
            if (statusVN == "Đang bận") return "Busy";
            if (statusVN == "Ngừng hoạt động") return "Inactive";

            return statusVN;
        }

        private void txtSearchName_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearchName.ForeColor == Color.Gray)
                return;
<<<<<<< HEAD
=======

            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void ApplyFilter()
        {
            // 1. Keyword (xử lý placeholder)
            string keyword = (txtSearchName.ForeColor == Color.Gray)
                ? null
                : txtSearchName.Text.Trim();

            // 2. Status
            string statusVN = cboSearchStatus.SelectedItem?.ToString();
            string statusEN = ConvertStatusToEN(statusVN);

            try
            {
                var data = _userService.SearchUsers(keyword, statusEN);

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = data;

                HideNavigationColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }


    }
}
>>>>>>> 16ef3ecfcf9f5551d6337f1e8bd6f1142e1cec10

            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void ApplyFilter()
        {
            // 1. Keyword (xử lý placeholder)
            string keyword = (txtSearchName.ForeColor == Color.Gray)
                ? null
                : txtSearchName.Text.Trim();

            // 2. Status
            string statusVN = cboSearchStatus.SelectedItem?.ToString();
            string statusEN = ConvertStatusToEN(statusVN);

            try
            {
                var data = _userService.SearchUsers(keyword, statusEN);

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = data;

                HideNavigationColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}