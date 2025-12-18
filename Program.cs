using System;
using System.Windows.Forms;
using PMS.BLL;
using PMS.DAL;

namespace PMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. DbContext
            PMSDbContext db = new PMSDbContext();

            // 2. Repository
            IUserRepository userRepo = new UserRepository(db);

            // 3. Service
            IAuthService authService = new AuthService(userRepo);

            // 4. Form
            Application.Run(new FormLogin(authService));
        }
    }
}
