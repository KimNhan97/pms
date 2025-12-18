using System;
using System.Windows.Forms;
using PMS.BLL;
using PMS.Entities;

namespace PMS
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;

        // Constructor có DI
        public FormLogin(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Không cần code gì
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user = _authService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show(
                    "Sai tài khoản hoặc mật khẩu",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Đăng nhập thành công
            FormMain main = new FormMain(user);
            this.Hide();
            main.Show();
        }

    }
}
