using PMS.Entities;
using System;
using PMS.BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMS
{
    public partial class FrmProjectDetail : Form
    {
        private Project _project;

        public FrmProjectDetail(Project project)
        {
            InitializeComponent();
            _project = project;
            BindData();
        }
        private void BindData()
        {
            lblProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;
            dtpStartDate.Value = _project.StartDate;
            //dtpDeadline.Value = _project.Deadline;
            //progressBar.Value = _project.Progress;

            // Nếu chỉ xem:
            //lblProjectName.ReadOnly = true;
            //txtDescription.ReadOnly = true;
            dtpStartDate.Enabled = false;
            //dtpDeadline.Enabled = false;
        }

        private void FrmProjectDetail_Load(object sender, EventArgs e)
        {

            dtpStartDate.BorderRadius = 8;
            dtpStartDate.BorderColor = Color.FromArgb(37, 99, 235);
            dtpStartDate.FillColor = Color.FromArgb(239, 246, 255);
            dtpStartDate.ForeColor = Color.FromArgb(30, 64, 175);
            dtpStartDate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";

            dtpEndDate.BorderRadius = 8;
            dtpEndDate.BorderColor = Color.FromArgb(220, 38, 38);
            dtpEndDate.FillColor = Color.FromArgb(254, 242, 242);
            dtpEndDate.ForeColor = Color.FromArgb(185, 28, 28);
            dtpEndDate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";


            //txtProjectName.BorderRadius = 8;
            //txtProjectName.FillColor = Color.FromArgb(239, 246, 255);   // nền xanh nhạt
            //txtProjectName.BorderColor = Color.FromArgb(37, 99, 235);   // viền xanh
            //txtProjectName.ForeColor = Color.FromArgb(30, 64, 175);    // chữ xanh đậm
            //txtProjectName.Font = new Font("Segoe UI", 12);
            //txtProjectName.PlaceholderText = "Nhập tên dự án...";
            //txtProjectName.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            //txtProjectName.FocusedState.BorderColor = Color.FromArgb(29, 78, 216);
            //txtProjectName.HoverState.BorderColor = Color.FromArgb(37, 99, 235);

            //txtDescription.BorderRadius = 8;
            //txtDescription.FillColor = Color.FromArgb(248, 250, 252);  // xám rất nhạt
            //txtDescription.BorderColor = Color.FromArgb(203, 213, 225);
            //txtDescription.ForeColor = Color.FromArgb(15, 23, 42);
            //txtDescription.Font = new Font("Segoe UI", 12);
            //txtDescription.Multiline = true;
            //txtDescription.PlaceholderText = "Nhập mô tả dự án...";
            //txtDescription.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            //txtDescription.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            //txtDescription.HoverState.BorderColor = Color.FromArgb(148, 163, 184);
        }
    }
}
