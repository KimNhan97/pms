using PMS.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS
{
    public partial class FrmProjectDetail : Form
    {
        private Project _project;

        public FrmProjectDetail(Project project)
        {
            InitializeComponent();
            _project = project;
            // Không nên gọi BindData ở đây vì Control chưa Load xong UI
        }

        private void FrmProjectDetail_Load(object sender, EventArgs e)
        {
            SetupStyles();
            BindData();
        }

        private void SetupStyles()
        {
            // Định dạng DateTimePicker cho đẹp
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";

            // Tắt khả năng chỉnh sửa để chỉ xem
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
        }

        private void BindData()
        {
            if (_project == null) return;

            // Gán dữ liệu vào label/textbox
            lblProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;

            if (_project.StartDate != null)
                dtpStartDate.Value = _project.StartDate;

            if (_project.Deadline != null)
                dtpEndDate.Value = _project.Deadline;

            // Xử lý tiến độ (Hình image_8166e4.png đang bị hiện guna2HtmlLabel1)
            lblProgressPercent.Text = _project.Progress + " %";

            // Nếu bạn có thanh progress bar
            if (prgProgress != null)
            {
                prgProgress.Value = _project.Progress;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}