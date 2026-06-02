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
    public partial class FormCreateUser : Form
    {
        private readonly IAuthService _authService;

        public FormCreateUser(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }
        private string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void FormCreateUser_Load(object sender, EventArgs e)
        {
            // Nạp danh sách Role tiếng Việt
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[] { "Quản trị viên", "Nhân viên" });
            cboRole.SelectedIndex = 1; // Mặc định là Nhân viên

            // Nạp danh sách Trạng thái tiếng Việt
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "Sẵn sàng", "Đang bận" });
            cboStatus.SelectedIndex = 0; // Mặc định là Sẵn sàng
            cboRole.SelectedIndex = 0;     // Admin
            cboStatus.SelectedIndex = 1;   // Available
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }
            string roleVN = cboRole.SelectedItem.ToString();
            string roleEN = (roleVN == "Quản trị viên") ? "Admin" : "Employee";

            string statusVN = cboStatus.SelectedItem.ToString();
            string statusEN = "Available"; // luôn mặc định

            // 2. Tạo user entity với giá trị Tiếng Anh
            var user = new User
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                PasswordHash = HashPassword(txtPassword.Text),
                Role = roleEN,    // Lưu "Admin" hoặc "User"
                Status = statusEN, // Lưu "Available" hoặc "Busy"

            };

            try
            {
                // 3. Gọi BLL
                _authService.Add(user);

                MessageBox.Show("Thêm tài khoản thành công!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

                MessageBox.Show("Lỗi: " + msg);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
