using PMS.BLL;
using PMS.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            cboRole.Items.AddRange(new[] { "Admin", "Employee" });

        }
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            cboStatus.Items.AddRange(new[] { "Available", "Busy" });
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
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            User user = new User
            {
                FullName = txtFullName.Text,
                Username = txtUsername.Text,
                PasswordHash = txtPassword.Text, 
                Role = cboRole.Text,
                Status = cboStatus.Text
            };

            _userService.Create(user);
            LoadUsers();
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
                txtSearchName.Text = "Nhập tên nhân viên...";
                txtSearchName.ForeColor = Color.Gray;
            }
        }
        private void SearchUsers()
        {
            string keyword = txtSearchName.ForeColor == Color.Gray
                ? ""
                : txtSearchName.Text.Trim();

            string status = cboSearchStatus.SelectedItem.ToString();

            dgvUsers.DataSource = _userService.SearchUsers(keyword, status);
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.ForeColor == Color.Gray) return;

            SearchUsers();
        }

        private void cboSearchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }
    }
}
