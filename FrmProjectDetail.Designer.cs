namespace PMS
{
    partial class FrmProjectDetail
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelRole = new System.Windows.Forms.Label();
            this.lblProjectName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(258, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Theo dõi tiến độ, thời hạn và trạng thái các dự án hiện tại";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(285, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 32);
            this.label1.TabIndex = 37;
            this.label1.Text = "📁 XEM CHI TIẾT DỰ ÁN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.labelFullName);
            this.guna2Panel1.Controls.Add(this.txtDescription);
            this.guna2Panel1.Controls.Add(this.labelRole);
            this.guna2Panel1.Controls.Add(this.lblProjectName);
            this.guna2Panel1.Controls.Add(this.labelUsername);
            this.guna2Panel1.Controls.Add(this.dtpStartDate);
            this.guna2Panel1.Controls.Add(this.labelStatus);
            this.guna2Panel1.Controls.Add(this.dtpEndDate);
            this.guna2Panel1.Location = new System.Drawing.Point(205, 104);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(432, 334);
            this.guna2Panel1.TabIndex = 41;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(158, 142);
            this.guna2HtmlLabel1.MaximumSize = new System.Drawing.Size(240, 45);
            this.guna2HtmlLabel1.MinimumSize = new System.Drawing.Size(240, 23);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(240, 23);
            this.guna2HtmlLabel1.TabIndex = 42;
            this.guna2HtmlLabel1.Text = "guna2HtmlLabel1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(59, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "Tiến độ :";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelFullName.ForeColor = System.Drawing.Color.Navy;
            this.labelFullName.Location = new System.Drawing.Point(44, 31);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(88, 21);
            this.labelFullName.TabIndex = 29;
            this.labelFullName.Text = "Tên dự án :";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(158, 89);
            this.txtDescription.MaximumSize = new System.Drawing.Size(240, 45);
            this.txtDescription.MinimumSize = new System.Drawing.Size(240, 23);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 23);
            this.txtDescription.TabIndex = 40;
            this.txtDescription.Text = "guna2HtmlLabel1";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelRole.ForeColor = System.Drawing.Color.Navy;
            this.labelRole.Location = new System.Drawing.Point(17, 197);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(115, 21);
            this.labelRole.TabIndex = 31;
            this.labelRole.Text = "Ngày bắt đầu :";
            // 
            // lblProjectName
            // 
            this.lblProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(158, 31);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(127, 23);
            this.lblProjectName.TabIndex = 39;
            this.lblProjectName.Text = "guna2HtmlLabel1";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelUsername.ForeColor = System.Drawing.Color.Navy;
            this.labelUsername.Location = new System.Drawing.Point(71, 89);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(61, 21);
            this.labelUsername.TabIndex = 30;
            this.labelUsername.Text = "Mô tả :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(158, 197);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(240, 35);
            this.dtpStartDate.TabIndex = 35;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 31, 0, 48, 39, 38);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.Navy;
            this.labelStatus.Location = new System.Drawing.Point(17, 265);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(119, 21);
            this.labelStatus.TabIndex = 32;
            this.labelStatus.Text = "Ngày kết thúc :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(158, 265);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(240, 40);
            this.dtpEndDate.TabIndex = 36;
            this.dtpEndDate.Value = new System.DateTime(2025, 12, 31, 0, 48, 49, 585);
            // 
            // FrmProjectDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmProjectDetail";
            this.Text = "FrmProjectDetail";
            this.Load += new System.EventHandler(this.FrmProjectDetail_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label labelFullName;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtDescription;
        private System.Windows.Forms.Label labelRole;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProjectName;
        private System.Windows.Forms.Label labelUsername;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label labelStatus;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label label2;
    }
}