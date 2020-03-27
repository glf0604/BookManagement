using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace BookManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Instantiate authentication Form
            frmLogin objFrmLogin = new frmLogin();
            //Display Login Interface
            DialogResult result = objFrmLogin.ShowDialog();
            //Depending on the result, open the main form if it is OK
            if (result == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }

        }

        //Define a global object for a SysAdmins
        public static SysAdmins currentUser = null;

        //Define an Id for the current login date
        public static int currentLogId = 0;
    }
}
