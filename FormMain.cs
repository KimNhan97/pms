using PMS.BLL;
using PMS.DAL;
using PMS.Entities;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace PMS
{
    public partial class FormMain : Form
    {
        private readonly IAuthService _authService;


        public FormMain()
        {
            InitializeComponent();
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

      

        private void ApplyRole()
        {
            bool isAdmin = Session.IsAdmin;

            // ADMIN
            menuManageUsers.Visible = isAdmin;
            //btnProjectManagement.Visible = isAdmin;
            btnReports.Visible = isAdmin;

            // USER
            btnProjectManagement.Visible = true;
            btnTaskManager.Visible = true;
            btnMyProjects.Visible = true;
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

            // Project
            var projectRepo = new ProjectRepository(db);
            var projectService = new ProjectService(projectRepo);

            // User / Auth
            var userRepo = new UserRepository(db);
            var authService = new AuthService(userRepo);

            // Truyền CẢ HAI service
            frmProjectManager frm = new frmProjectManager(projectService, authService);
            OpenChildForm(frm);
        }



        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. Xóa session cũ
            Session.Clear();

            // 2. Ẩn Form hiện tại (FormMain)
            this.Hide();

            // 3. Tạo FormLogin mới và truyền Service vào để không bị Null
            // Đảm bảo _authService đã được khai báo ở cấp lớp trong Form này
            FormLogin login = new FormLogin(_authService);

            // 4. Khi đóng FormLogin thì đóng luôn ứng dụng (tránh chạy ngầm)
            login.FormClosed += (s, args) => Application.Exit();

            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new PMSDbContext();

            var taskRepo = new TaskRepository(db);
            var projectRepo = new ProjectRepository(db);
            var userRepo = new UserRepository(db);

            var taskService = new TaskService(taskRepo, projectRepo, userRepo);

            FrmTaskManager frm = new FrmTaskManager(taskService);
            OpenChildForm(frm);
        }
        //dùng ADO.NET
        private void button3_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập lại");
                return;
            }

            var context = new PMSDbContext();
            IProjectRepository projectRepo = new ProjectRepository(context);
            IProjectMemberRepository memberRepo = new ProjectMemberRepository(context);
            IProjectService projectService = new ProjectService(projectRepo);
            IProjectMemberService memberService = new ProjectMemberService(memberRepo);

            FormProjectMembers frm = new FormProjectMembers(memberService, projectService);

            OpenChildForm(frm);
        }


        private void btnReports_Click(object sender, EventArgs e)
        {
            // ===== Khởi tạo DbContext (DUY NHẤT) =====
            var context = new PMSDbContext();

            // ===== Khởi tạo Repository =====
            IProjectRepository projectRepo = new ProjectRepository(context);
            IReportRepository reportRepo = new ReportRepository(context);

            // ===== Khởi tạo Service =====
            IProjectService projectService = new ProjectService(projectRepo);
            IReportService reportService = new ReportService(reportRepo, projectRepo);

            // ===== Tạo FormReports =====
            FormReports frm = new FormReports(reportService, projectService);

            // ===== Mở Form con =====
            OpenChildForm(frm);
        }

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ");
                Application.Exit();
                return;
            }

            var user = Session.CurrentUser;

            lblUserName.Text = user.FullName;
            lblname.Text = user.Username;

            ApplyRole();
        }
    }
}
