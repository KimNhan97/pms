using PMS.Entities;
using System;
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

        public FrmProjectDetail()
        {
            InitializeComponent();
            _project = project;
            BindData();
        }
        private void BindData()
        {
            txtProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;
            dtpStartDate.Value = _project.StartDate;
            dtpDeadline.Value = _project.Deadline;
            progressBar.Value = _project.Progress;

            // Nếu chỉ xem:
            txtProjectName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            dtpStartDate.Enabled = false;
            dtpDeadline.Enabled = false;
        }

        private void FrmProjectDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
