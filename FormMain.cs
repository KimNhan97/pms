using PMS.BLL;
using PMS.DAL;
using PMS.Entities;
using System;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormMain : Form
    {
        private readonly User _currentUser;

        // Nhận user từ FormLogin
        public FormMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }
        private void OpenChildForm(Form childForm)
        {
            panelContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            lblUserName.Text = _currentUser.FullName;
            ApplyRole();
        }

        private void ApplyRole()
        {
            // Nếu là Employee thì ẩn chức năng quản trị
            if (_currentUser.Role == "Employee")
            {
                menuAdmin.Enabled = false;
            }

        }

        private void menuManageUsers_Click(object sender, EventArgs e)
        {
            var db = new PMSDbContext();
            var repo = new UserRepository(db);
            var service = new AuthService(repo);

            FormUserManagement frm = new FormUserManagement(service);
            OpenChildForm(frm);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
