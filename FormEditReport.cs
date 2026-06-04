using Guna.UI2.WinForms;
using PMS.BLL;
using PMS.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS
{
    public enum ReportFormMode
    {
        Add,
        Edit,
        View
    }

    public partial class FormEditReport : Form
    {
        private readonly IReportService _service;
        private readonly ReportFormMode _mode;

        private int _reportId;
        private int _projectId;

        public FormEditReport(
            IReportService service,
            ReportFormMode mode,
            int projectId = 0,
            int reportId = 0)
        {
            InitializeComponent();

            _service = service;
            _mode = mode;
            _projectId = projectId;
            _reportId = reportId;
        }
        private void LoadReportTypes()
        {
            cboType.DataSource = new[]
            {
        "OnePager",
        "VSM",
        "ExecutiveSummary"
    };
        }

        // ================= FORM LOAD =================
        private void FormEditReport_Load(object sender, EventArgs e)
        {
            LoadReportTypes();
            LoadProjects();
            InitUI();
            if (_mode == ReportFormMode.Add)
            {
                Text = "Thêm báo cáo";
            }
            else
            {
                LoadReport();
                if (_mode == ReportFormMode.View)
                    SetReadOnlyMode();
            }
            switch (_mode)
            {
                case ReportFormMode.Add:
                    Text = "Thêm báo cáo";
                    //btnDelete.Visible = false;
                    break;

                case ReportFormMode.Edit:
                    Text = "Chỉnh sửa báo cáo";
                    LoadReport();            // ⭐ LOAD SẴN NỘI DUNG
                    //btnDelete.Visible = true;
                    break;

                case ReportFormMode.View:
                    Text = "Xem chi tiết báo cáo";
                    LoadReport();            // ⭐ LOAD
                    SetReadOnlyMode();       // ⭐ KHÓA
                    break;
            }
        }

        // ================= LOAD DATA =================
        private void LoadReport()
        {
            var dto = _service.GetById(_reportId);
            if (dto == null)
            {
                MessageBox.Show("Không tìm thấy báo cáo");
                Close();
                return;
            }

            _projectId = dto.ProjectID;
            Bind(dto);
        }

        private void Bind(ReportDTO dto)
        {
            txtTitle.Text = dto.Title;
            rtbContent.Text = dto.Content;

            cboProject.SelectedValue = dto.ProjectID; // ⭐ THÊM
            lblCreatedDate.Text = dto.CreatedDate
                .ToString("dd/MM/yyyy");              // ⭐ THÊM

            cboType.SelectedItem = dto.ReportType;

            btnSave.Enabled = _mode != ReportFormMode.View;
        }


        // ================= READ ONLY =================
        private void SetReadOnlyMode()
        {
            txtTitle.ReadOnly = true;
            rtbContent.ReadOnly = true;
            cboType.Enabled = false;

            btnSave.Visible = false;
            //btnDelete.Visible = false;
            //btnClear.Visible = false;
        }


        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Tiêu đề không được để trống");
                return;
            }

            _service.SaveReport(new ReportDTO
            {
                ReportID = _mode == ReportFormMode.Edit ? _reportId : 0,
                ProjectID = (int)cboProject.SelectedValue,
                Title = txtTitle.Text.Trim(),
                Content = rtbContent.Text,
                ReportType = cboType.SelectedValue?.ToString()
            });


            DialogResult = DialogResult.OK;
            Close();
        }
        // ================= UI INIT =================
        private void InitUI()
        {
            // PANEL
            guna2PanelContent.BorderRadius = 8;
            guna2PanelContent.BorderThickness = 1;
            guna2PanelContent.BorderColor = Color.FromArgb(220, 223, 230);
            guna2PanelContent.FillColor = Color.White;

            // RICH TEXT
            rtbContent.Font = new Font("Segoe UI", 12F);
            rtbContent.BackColor = Color.White;

            SetupButtons();
        }
        private void LoadProjects()
        {
            var projects = _service.GetAllProjects();

            cboProject.DataSource = projects;
            cboProject.DisplayMember = "ProjectName";
            cboProject.ValueMember = "ProjectID";

            if (_projectId > 0)
                cboProject.SelectedValue = _projectId;
        }

        private void SetupButtons()
        {
            Guna2Button[] buttons = {
                //btnSave,
                //btnDelete,
                //btnClear,
                //guna2ButtonAdd
            };

            foreach (var btn in buttons)
            {
                btn.BorderRadius = 8;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Animated = true;
            }


            // ADD
            //guna2ButtonAdd.Text = "➕ Thêm";
            //guna2ButtonAdd.FillColor = Color.FromArgb(34, 197, 94);

            //// SAVE
            //btnSave.Text = "💾 Lưu";
            //btnSave.FillColor = Color.FromArgb(59, 130, 246);
            //btnSave.Enabled = true;

            //// DELETE
            //btnDelete.Text = "🗑️ Xóa";
            //btnDelete.FillColor = Color.FromArgb(239, 68, 68);
            //btnDelete.Enabled = false;

            //// CLEAR
            //btnClear.Text = "🔄 Làm mới";
            //btnClear.FillColor = Color.FromArgb(100, 116, 139);
        }

        private void rtbContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
