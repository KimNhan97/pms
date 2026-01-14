namespace PMS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.menuManageUsers = new System.Windows.Forms.Button();
            this.btnMyProjects = new System.Windows.Forms.Button();
            this.btnTaskManager = new System.Windows.Forms.Button();
            this.btnProjectManagement = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Navy;
            this.lblUserName.Location = new System.Drawing.Point(36, 9);
            this.lblUserName.MaximumSize = new System.Drawing.Size(135, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(134, 42);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Người dùng";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(225, 29);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1060, 748);
            this.panelContent.TabIndex = 3;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.menuManageUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnMyProjects);
            this.flowLayoutPanel1.Controls.Add(this.btnTaskManager);
            this.flowLayoutPanel1.Controls.Add(this.btnProjectManagement);
            this.flowLayoutPanel1.Controls.Add(this.btnReports);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 72);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 676);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "MAIN MENU ";
            // 
            // menuManageUsers
            // 
            this.menuManageUsers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuManageUsers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menuManageUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuManageUsers.Location = new System.Drawing.Point(10, 51);
            this.menuManageUsers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.menuManageUsers.Name = "menuManageUsers";
            this.menuManageUsers.Size = new System.Drawing.Size(176, 47);
            this.menuManageUsers.TabIndex = 0;
            this.menuManageUsers.Text = "⚙  Quản lý tài khoản ";
            this.menuManageUsers.UseVisualStyleBackColor = false;
            this.menuManageUsers.Click += new System.EventHandler(this.menuManageUsers_Click_1);
            // 
            // btnMyProjects
            // 
            this.btnMyProjects.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMyProjects.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyProjects.Location = new System.Drawing.Point(10, 128);
            this.btnMyProjects.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.btnMyProjects.Name = "btnMyProjects";
            this.btnMyProjects.Size = new System.Drawing.Size(176, 47);
            this.btnMyProjects.TabIndex = 2;
            this.btnMyProjects.Text = "📁  Quản lý dự án  ";
            this.btnMyProjects.UseVisualStyleBackColor = false;
            this.btnMyProjects.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTaskManager
            // 
            this.btnTaskManager.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaskManager.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskManager.Location = new System.Drawing.Point(10, 205);
            this.btnTaskManager.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.btnTaskManager.Name = "btnTaskManager";
            this.btnTaskManager.Size = new System.Drawing.Size(176, 47);
            this.btnTaskManager.TabIndex = 3;
            this.btnTaskManager.Text = "📋  Quản lý công việc";
            this.btnTaskManager.UseVisualStyleBackColor = false;
            this.btnTaskManager.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnProjectManagement
            // 
            this.btnProjectManagement.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProjectManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectManagement.Location = new System.Drawing.Point(10, 282);
            this.btnProjectManagement.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.btnProjectManagement.Name = "btnProjectManagement";
            this.btnProjectManagement.Size = new System.Drawing.Size(176, 47);
            this.btnProjectManagement.TabIndex = 4;
            this.btnProjectManagement.Text = "👥  Quản lý nhân viên";
            this.btnProjectManagement.UseVisualStyleBackColor = false;
            this.btnProjectManagement.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(10, 359);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0, 0, 0, 190);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(176, 47);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "📄  Báo cáo dự án ";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(10, 596);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 47);
            this.button4.TabIndex = 5;
            this.button4.Text = "🚪 Đăng xuất ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.lblname);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 69);
            this.panel2.TabIndex = 5;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblname.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblname.Location = new System.Drawing.Point(38, 45);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(43, 17);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "👤";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 729);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelContent);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load_1);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button menuManageUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMyProjects;
        private System.Windows.Forms.Button btnTaskManager;
        private System.Windows.Forms.Button btnProjectManagement;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnReports;
    }
}