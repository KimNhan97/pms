    using Autofac.Core;
    using Guna.UI2.WinForms;
    using PMS.BLL;
    using PMS.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace PMS
    {
        public partial class frmProjectManager : Form
        {
            private readonly IProjectService _service;
            private readonly IAuthService _authService;


            public frmProjectManager(IProjectService service, IAuthService authService)
            {
                InitializeComponent();

                _service = service ?? throw new ArgumentNullException(nameof(service));
                _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            }


        //private void LoadData()
        //{
        //    dgvProjects.DataSource = null;

        //    // 🔐 PHÂN QUYỀN LUỒNG DỮ LIỆU
        //    // Kiểm tra Role trực tiếp từ Session để đảm bảo Admin thấy hết
        //    if (Session.CurrentUser != null && Session.CurrentUser.Role == "Admin")
        //    {
        //        // Admin: Xem toàn bộ dự án trong hệ thống
        //        dgvProjects.DataSource = _service.GetAll();
        //    }
        //    else if (Session.CurrentUser != null)
        //    {
        //        // Nhân viên: Chỉ xem dự án được phân công
        //        int currentUserId = Session.CurrentUser.UserID;
        //        dgvProjects.DataSource = _service.GetProjectsByUserId(currentUserId);
        //    }

        //    // 🧹 XỬ LÝ GIAO DIỆN: Xóa/Ẩn các cột quan hệ trống (Cột thừa cuối bảng)
        //    HideExtraColumns();

        //    // Đổi tên tiêu đề cho chuyên nghiệp
        //    if (dgvProjects.Columns.Count > 0)
        //    {
        //        FormatGridHeader();
        //    }
        //}

        private void HideExtraColumns()
        {
            // Danh sách các cột thừa thường do Entity Framework tự tạo ra
            string[] columnsToHide = { "Manager", "Tasks", "ProjectMembers", "ProjectMemberships" };

            foreach (string colName in columnsToHide)
            {
                if (dgvProjects.Columns.Contains(colName))
                {
                    dgvProjects.Columns[colName].Visible = false;
                }
            }
        }

        private void FormatGridHeader()
        {
            // Đảm bảo các cột hiển thị đúng tên tiếng Việt
            if (dgvProjects.Columns.Contains("ProjectID")) dgvProjects.Columns["ProjectID"].HeaderText = "Mã DA";
            if (dgvProjects.Columns.Contains("ProjectName")) dgvProjects.Columns["ProjectName"].HeaderText = "Tên dự án";
            if (dgvProjects.Columns.Contains("Description")) dgvProjects.Columns["Description"].HeaderText = "Mô tả";
            if (dgvProjects.Columns.Contains("StartDate")) dgvProjects.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            if (dgvProjects.Columns.Contains("Deadline")) dgvProjects.Columns["Deadline"].HeaderText = "Hạn chót";
            if (dgvProjects.Columns.Contains("Progress")) dgvProjects.Columns["Progress"].HeaderText = "Tiến độ (%)";
            if (dgvProjects.Columns.Contains("ManagerName")) dgvProjects.Columns["ManagerName"].HeaderText = "Người quản lý";
        }
        private void InitControls()
            {
                txtSearch.PlaceholderText = "Tìm theo tên dự án...";
                txtSearch.BorderRadius = 8;

                cboStatus.Items.Clear();
                cboStatus.Items.AddRange(new string[]
                {
                        "Tất cả",
                        "Đang làm",
                        "Hoàn thành",
                        "Trễ hạn"
                });
                cboStatus.SelectedIndex = 0;
            }
        private void ApplyFilter()
        {
            // 1. Lấy tham số lọc
            string keyword = txtSearch.Text.Trim();
            string statusText = cboStatus.SelectedItem?.ToString();
            string statusValue = GetStatusMapping(statusText); // Dùng hàm dùng chung

            // 2. Phân quyền: Admin truyền null, User thường truyền ID
            int? filterUserId = Session.CurrentUser?.Role == "Admin" ? (int?)null : Session.CurrentUser?.UserID;

            // 3. Gọi Service (Tối ưu: Chỉ dùng 1 hàm Search cho mọi trường hợp)
            var data = _service.Search(keyword, statusValue, filterUserId);

            dgvProjects.DataSource = null;
            dgvProjects.DataSource = data;

            // 4. Xử lý hiển thị
            HideExtraColumns();
        }

        // Lúc này LoadData chỉ cần gọi ApplyFilter
        private void LoadData() => ApplyFilter();

        // Hàm phụ để map text sang status code
        private string GetStatusMapping(string displayText)
                {
                    switch (displayText)
                    {
                        case "Đang làm":
                            return "In Progress";
                        case "Hoàn thành":
                            return "Completed";
                        case "Trễ hạn":
                            return "Late";
                        default:
                            return null;
                    }
                }

        private void frmProjectManager_Load(object sender, EventArgs e)
            {
         
                dgvProjects.BorderStyle = BorderStyle.None;
                dgvProjects.BackgroundColor = Color.White;
                dgvProjects.EnableHeadersVisualStyles = false;
                dgvProjects.ColumnHeadersHeight = 45;

                dgvProjects.ColumnHeadersDefaultCellStyle.BackColor =
                        Color.FromArgb(0, 120, 215);
                
                dgvProjects.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 12, FontStyle.Bold);

                dgvProjects.DefaultCellStyle.Font =
                    new Font("Segoe UI", 12);

                dgvProjects.RowTemplate.Height = 45;
                dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProjects.MultiSelect = false;
                dgvProjects.ReadOnly = true;
                dgvProjects.DefaultCellStyle.SelectionBackColor =
                  Color.FromArgb(239, 246, 255);

                dgvProjects.DefaultCellStyle.SelectionForeColor =   
                    Color.Black;

                btnView.Text = "Xem chi tiết";
                btnView.BorderRadius = 10;
                btnView.ForeColor = Color.FromArgb(37, 99, 235); // Xanh dương
                btnView.FillColor = Color.Black;
                btnView.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnView.Size = new Size(130, 35);

                btnAdd.Text = "+ Thêm ";
                btnAdd.BorderRadius = 10;
                btnAdd.FillColor = Color.FromArgb(37, 99, 235);
                btnAdd.ForeColor = Color.White;
                btnAdd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnAdd.Size = new Size(120, 35);

                btnEdit.Text = "✎ Sửa";
                btnEdit.BorderRadius = 10;
                btnEdit.FillColor = Color.FromArgb(37, 99, 235); // Xanh dương
                btnEdit.ForeColor = Color.White;
                btnEdit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnEdit.Size = new Size(100, 35);

                btnDelete.Text = "🗑 Xóa";
                btnDelete.BorderRadius = 10;
                btnDelete.FillColor = Color.FromArgb(220, 38, 38); // Đỏ
                btnDelete.ForeColor = Color.White;
                btnDelete.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnDelete.Size = new Size(100, 35);

                btnEdit.HoverState.FillColor = Color.FromArgb(29, 78, 216);
                btnDelete.HoverState.FillColor = Color.FromArgb(185, 28, 28);

                btnEdit.DisabledState.FillColor = Color.FromArgb(203, 213, 225);
                btnDelete.DisabledState.FillColor = Color.FromArgb(203, 213, 225);


                SetupOutline(btnEdit);
                SetupOutline(btnDelete);

                txtSearch.PlaceholderText = "Nhập tên dự án...";
                txtSearch.BorderRadius = 8;
                txtSearch.Size = new Size(220, 36);
                txtSearch.FillColor = Color.White;
                txtSearch.Font = new Font("Segoe UI", 12);

            

                cboStatus.BorderRadius = 8;
                cboStatus.Size = new Size(160, 36);
                cboStatus.Items.AddRange(new object[]
                {
                    "Tất cả trạng thái",
                    "Đang làm",
                    "Hoàn thành",
                    "Trễ hạn"
                });
                cboStatus.SelectedIndex = 0;
                cboStatus.Font = new Font("Segoe UI", 12);


            // 🔐 PHÂN QUYỀN GIAO DIỆN
            string currentRole = Session.CurrentUser.Role;
            if (currentRole != "Admin" && currentRole != "PM")
            {
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;

                    // Căn chỉnh lại vị trí nút btnView nếu cần để giao diện đẹp hơn
                    btnView.Location = btnAdd.Location;
                }

                InitControls();
                InitGrid();   
                LoadData();

            }
            void SetupOutline(Guna2Button btn)
            {
                btn.FillColor = Color.White;
                btn.BorderColor = Color.FromArgb(220, 224, 230);
                btn.BorderThickness = 1;
                btn.ForeColor = Color.FromArgb(55, 65, 81);
                btn.BorderRadius = 10;
            }
            private void InitGrid()
            {
                dgvProjects.AutoGenerateColumns = false;
                dgvProjects.Columns.Clear();

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProjectID",
                    Name = "ProjectID",
                    Visible = false
                });

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProjectName",
                    HeaderText = "Tên dự án"
                });

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Description",
                    HeaderText = "Mô tả"
                });

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StartDate",
                    HeaderText = "Ngày bắt đầu",
                    DefaultCellStyle = { Format = "dd/MM/yyyy" }
                });

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Deadline",
                    HeaderText = "Deadline",
                    DefaultCellStyle = { Format = "dd/MM/yyyy" }
                });

                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Progress",
                    HeaderText = "Tiến độ (%)"
                });

                // ✅ THÊM CỘT MANAGER Ở CUỐI
                dgvProjects.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ManagerName",   // PHẢI CÓ TRONG DTO
                    HeaderText = "Người quản lý",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }



            private void guna2Button2_Click(object sender, EventArgs e)
            {
            if (dgvProjects.CurrentRow == null) return;

            // Thay vì ép kiểu trực tiếp, hãy lấy ID và gọi Service để lấy Project chuẩn từ DB
            int projectId = Convert.ToInt32(dgvProjects.CurrentRow.Cells["ProjectID"].Value);
            Project p = _service.GetById(projectId);

            if (p != null)
            {
                using (var frm = new FormCreateProject(_service, _authService, p))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

            private void cboStatus_Click(object sender, EventArgs e)
            {

            }

            private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                ApplyFilter();
            }

            private void dgvProjects_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (dgvProjects.Columns[e.ColumnIndex].Name == "Status")
                {
                    var cell = dgvProjects.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string status = e.Value.ToString();

                    if (status == "Hoàn thành")
                        cell.Style.BackColor = Color.FromArgb(209, 250, 229);
                    else if (status == "Trễ hạn")
                        cell.Style.BackColor = Color.FromArgb(254, 226, 226);
                    else
                        cell.Style.BackColor = Color.FromArgb(219, 234, 254);

                    cell.Style.ForeColor = Color.Black;
                }
            }

            private void labelFullName_Click(object sender, EventArgs e)
            {

            }

            private void labelUsername_Click(object sender, EventArgs e)
            {

            }

            private void panelToolbar_Paint(object sender, PaintEventArgs e)
            {

            }

            private void btnAdd_Click_1(object sender, EventArgs e)
            {
                using (FormCreateProject frm =
                     new FormCreateProject(_service, _authService))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        LoadData();
                }

            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProjectId();
            if (id == -1) return;

            if (MessageBox.Show("Xóa dự án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _service.Delete(id); // Dùng trực tiếp ID
                LoadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
            {
                ApplyFilter();  
            }

            private void dgvProjects_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex < 0) return;

                if (dgvProjects.Columns[e.ColumnIndex].Name == "Progress")
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);

                    int progress = Convert.ToInt32(e.Value);

                    // Padding trong ô
                    Rectangle rect = new Rectangle(
                        e.CellBounds.X + 6,
                        e.CellBounds.Y + 10,
                        e.CellBounds.Width - 12,
                        e.CellBounds.Height - 20
                    );

                    // Nền progress
                    using (Brush backBrush = new SolidBrush(Color.FromArgb(229, 231, 235)))
                    {
                        e.Graphics.FillRectangle(backBrush, rect);
                    }

                    // Màu theo tiến độ
                    Color progressColor = GetProgressColor(progress);

                    // Thanh tiến độ
                    int width = (int)(rect.Width * progress / 100.0);
                    Rectangle progressRect = new Rectangle(rect.X, rect.Y, width, rect.Height);

                    using (Brush progressBrush = new SolidBrush(progressColor))
                    {
                        e.Graphics.FillRectangle(progressBrush, progressRect);
                    }

                    // Viền
                    using (Pen pen = new Pen(Color.FromArgb(203, 213, 225)))
                    {
                        e.Graphics.DrawRectangle(pen, rect);
                    }

                    // Text %
                    string text = $"{progress}%";
                    TextRenderer.DrawText(
                        e.Graphics,
                        text,
                        new Font("Segoe UI", 10, FontStyle.Bold),
                        e.CellBounds,
                        Color.Black,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }
            }
            private Color GetProgressColor(int progress)
            {
                if (progress == 100)
                    return Color.FromArgb(34, 197, 94);   // xanh lá
                if (progress >= 70)
                    return Color.FromArgb(37, 99, 235);   // xanh dương
                if (progress >= 30)
                    return Color.FromArgb(234, 179, 8);   // vàng
                return Color.FromArgb(239, 68, 68);       // đỏ
            }
            private int GetSelectedProjectId()
            {
                if (dgvProjects.CurrentRow == null)
                    return -1;

                return Convert.ToInt32(
                    dgvProjects.CurrentRow.Cells["ProjectID"].Value
                );
            }

            private void btnView_Click(object sender, EventArgs e)
            {
                int id = GetSelectedProjectId();
                if (id == -1)
                {
                    MessageBox.Show("Vui lòng chọn dự án.");
                    return;
                }

                Project project = _service.GetById(id);
                if (project == null)
                {
                    MessageBox.Show("Dự án không tồn tại.");
                    return;
                }

                var frm = new FrmProjectDetail(project);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                LoadData();
            }


            private void dgvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                btnView_Click(sender, e);

            }
        }
    }
