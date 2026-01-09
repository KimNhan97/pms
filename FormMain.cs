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
        private readonly IAuthService _authService;


        // Nhận user từ FormLogin
        public FormMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }
        public FormMain(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
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
            lblname.Text = _currentUser.Username;

            ApplyRole();
        }

        private void ApplyRole()
        {
            // Nếu là Employee thì ẩn chức năng quản trị
            if (_currentUser.Role == "Employee")
            {
                menuManageUsers.Enabled = false;
            }

        }

      
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuManageUsers_Click_1(object sender, EventArgs e)
        {
            var db = new PMSDbContext();
            var repo = new UserRepository(db);
            var service = new AuthService(repo);

            FormUserManagement frm = new FormUserManagement(service);
            OpenChildForm(frm);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new PMSDbContext();
            var repo = new ProjectRepository(db);
            var service = new ProjectService(repo);

            frmProjectManager frm = new frmProjectManager(service);
            OpenChildForm(frm);
        }


        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormLogin login = new FormLogin(_authService);
            login.Show();

            this.Close();
        }

    }
}
