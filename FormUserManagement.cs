using PMS.BLL;
using PMS.Entities;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PMS
{
    public partial class FormUserManagement : Form
    {
        private readonly IAuthService _userService;



        public FormUserManagement(IAuthService userService)
        {
            InitializeComponent();
            
            _userService = userService;
        }
        
        private void LoadUsers()
        {
            dgvUsers.DataSource = _userService.GetAll();
            dgvUsers.AutoGenerateColumns = true;

            dgvUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {

            cboSearchStatus.Items.Clear();
            cboSearchStatus.Items.AddRange(new[] { "Tất cả trạng thái", "Available", "Busy" });
            cboSearchStatus.SelectedIndex = 0;

            StyleRefresh(btnReload);
            StyleDelete(btnDelete);
            StyleUpdate(btnUpdate);
            StyleAdd(btnAdd);


            SetBorderRadius(panelEdit, 10);
            SetBorderRadius(txtSearchName, 5);
            SetBorderRadius(dgvUsers, 5);
            //SetBorderRadius(txtFullName, 5);



            dgvUsers.AutoGenerateColumns = true;

            LoadUsers();
            StyleDGV(dgvUsers);

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            cboRole.Items.AddRange(new[] { "Admin", "Employee" });
            cboStatus.Items.AddRange(new[] { "Available", "Busy" });
            cboSearchStatus.SelectedIndex = 0;
            LoadUsers();
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


        private void ClearForm()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
        }
        private void ClearEditPanel()
        {
            
            txtFullName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;

            // Bỏ chọn DataGridView
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
                Role = cboRole.Text,
                Status = cboStatus.Text,
                PasswordHash = txtPassword.Text // có thể rỗng
            };
            _userService.Update(user);
            LoadUsers();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            
            ClearEditPanel();
           
        }
        private void LoadUserToPanel(DataGridViewRow row)
        {
            _selectedUserId = (int)row.Cells["UserID"].Value;

            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            cboRole.Text = row.Cells["Role"].Value.ToString();
            cboStatus.Text = row.Cells["Status"].Value.ToString();

            // Không hiển thị password
            txtPassword.Text = "";
        }

        private int? _selectedUserId = null;

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            LoadUserToPanel(row);
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Nhập tên nhân viên...")
            {
                txtSearchName.Text = "";
                txtSearchName.ForeColor = Color.Black;
            }
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchName.Text))
            {
                txtSearchName.Text = "🔍 Nhập họ tên để tìm kiếm...";
                txtSearchName.ForeColor = Color.Gray;
            }
        }
        private void SearchUsers()
        {
            string keyword = txtSearchName.ForeColor == Color.Gray
                ? ""
                : txtSearchName.Text.Trim();

            string status = cboSearchStatus.SelectedItem != null
                ? cboSearchStatus.SelectedItem.ToString()
                : "Tất cả trạng thái";

            var data = _userService.SearchUsers(keyword, status);

            dgvUsers.DataSource = null;   // BẮT BUỘC
            dgvUsers.DataSource = data;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
         
            SearchUsers();
        }

        private void cboSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchUsers();
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
            //code UI
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

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelRole_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboRole_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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

        private void label6_Click(object sender, EventArgs e)
        {

        }
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

            SetRounded(btn, 8);

            btn.MouseEnter += (s, e) =>
                btn.BackColor = Color.FromArgb(245, 245, 245);

            btn.MouseLeave += (s, e) =>
                btn.BackColor = Color.White;
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


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
        void StyleDGV(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.GridColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 248, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.RowTemplate.Height = 55;
            dgv.RowHeadersVisible = false;
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role" && e.Value != null)
            {
                string role = e.Value.ToString();

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                if (role == "Admin")
                {
                    e.CellStyle.BackColor = Color.FromArgb(224, 231, 255);
                    e.CellStyle.ForeColor = Color.FromArgb(67, 56, 202);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(55, 65, 81);
                }
            }

            if (dgvUsers.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);
                    e.CellStyle.ForeColor = Color.Gray;
                }
            }
           
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Action")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI ", 14);
                e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            }
            // Chữ trong cell
            dgvUsers.DefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Regular);

            // Chữ header
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);


        }

     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

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
                    Role = cboRole.Text,
                    Status = cboStatus.Text,
                    PasswordHash = txtPassword.Text.Trim() // có thể rỗng
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

    }
}
