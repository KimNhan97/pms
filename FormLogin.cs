using Guna.UI2.WinForms;
using PMS.BLL;
using PMS.DAL;
using PMS.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;

        // Constructor có DI
        // Constructor này sẽ đảm bảo luôn có Service
        public FormLogin(IAuthService authService = null)
        {
            InitializeComponent();

            // Nếu authService truyền vào bị null (do gọi new FormLogin() từ nút Đăng xuất)
            // thì tự khởi tạo mới một đối tượng Service.
            _authService = authService ?? new AuthService(new UserRepository(new PMSDbContext()));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
        private bool _showPassword = false;

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // ===== FORM =====
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.ClientSize = new Size(1300, 768);

            // ===== CARD =====
            guna2PanelCard.BorderRadius = 16;
            guna2PanelCard.FillColor = Color.White;
            guna2PanelCard.Size = new Size(380, 480);
            guna2PanelCard.Location = new Point(
                (ClientSize.Width - guna2PanelCard.Width) / 2,
                (ClientSize.Height - guna2PanelCard.Height) / 2
            );
            guna2PanelCard.ShadowDecoration.Enabled = true;
            guna2PanelCard.ShadowDecoration.Depth = 6;
            guna2PanelCard.ShadowDecoration.BorderRadius = 16;

            // ===== ICON =====
            guna2CirclePictureBox1.Size = new Size(64, 64);
            guna2CirclePictureBox1.Location = new Point(
                (guna2PanelCard.Width - 56) / 2, 20
            );
            guna2CirclePictureBox1.FillColor = Color.FromArgb(230, 240, 255);
            guna2CirclePictureBox1.Image = Properties.Resources.lock_icon;
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            // ===== TITLE =====
            lblTitle.Text = "Chào mừng trở lại";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(
                (guna2PanelCard.Width - lblTitle.Width) / 2, 110
            );

            // ===== DESC =====
            lblDesc.Text = "Vui lòng nhập thông tin để đăng nhập";
            lblDesc.Font = new Font("Segoe UI", 11);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(
                (guna2PanelCard.Width - lblDesc.Width) / 2, 150
            );

            // ===== USERNAME =====
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtUsername.IconLeft = Properties.Resources.user_icon;
            txtUsername.BorderRadius = 12;
            txtUsername.Size = new Size(300, 46);
            txtUsername.BorderThickness = 2;
            txtUsername.Location = new Point(
                (guna2PanelCard.Width - txtUsername.Width) / 2,
                220
            );

            // ===== PASSWORD =====
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.BorderThickness = 2;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtPassword.IconLeft = Properties.Resources.key_icon;
            txtPassword.IconRight = Properties.Resources.eye_icon;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.BorderRadius = 12;
            txtPassword.Size = new Size(300, 46);
            txtPassword.Location = new Point(
                (guna2PanelCard.Width - txtPassword.Width) / 2,
                txtUsername.Bottom + 30
            );


            // ===== BUTTON =====
            btnLogin.Text = "Đăng nhập";
            btnLogin.FillColor = Color.FromArgb(59, 130, 246);
            btnLogin.BorderRadius = 10;
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.Size = new Size(150, 44);
            btnLogin.Location = new Point(
                (guna2PanelCard.Width - btnLogin.Width) / 2,
                guna2PanelCard.Height - btnLogin.Height - 45
            );
            btnLogin.HoverState.FillColor = Color.FromArgb(37, 99, 235);

            // ===== FOOTER =====
            lblFooter.Text = "© 2026 PMS. All rights reserved.";
            lblFooter.Font = new Font("Segoe UI", 10);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(
                (ClientSize.Width - lblFooter.Width) / 2,
                ClientSize.Height - 50
            );

            //CLSOE
            btnClose.Text = "Đóng";
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnClose.FillColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(107, 114, 128); // xám trung
            btnClose.BorderRadius = 8;
            btnClose.BorderThickness = 1;
            btnClose.BorderColor = Color.FromArgb(209, 213, 219);

            btnClose.Size = new Size(72, 32);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            // Hover
            btnClose.HoverState.FillColor = Color.FromArgb(243, 244, 246);
            btnClose.HoverState.BorderColor = Color.FromArgb(156, 163, 175);
            btnClose.HoverState.ForeColor = Color.FromArgb(17, 24, 39);

            


        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
           

        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            _showPassword = !_showPassword;
            txtPassword.UseSystemPasswordChar = !_showPassword;
        }

        private void lblFooter_Click(object sender, EventArgs e)
        {
            lblFooter.Text = "© 2024 Your Application. All rights reserved.";
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Font = new Font("Segoe UI", 8);
            lblFooter.AutoSize = true;
            lblFooter.Left = (this.ClientSize.Width - lblFooter.Width) / 2;
            lblFooter.Top = this.ClientSize.Height - 30;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu");
                return;
            }

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

            // ✅ LƯU USER TOÀN CỤC
            Session.SetUser(user);

            // ✅ MỞ MAIN
            FormMain main = new FormMain();
            main.Show();

            this.Hide();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
