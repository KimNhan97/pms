using PMS.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class FormCreateUser : Form
    {
        private readonly IAuthService _authService;

        public FormCreateUser(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void FormCreateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
