using System;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (StoreDB storeDB = new StoreDB())
            {
                Application.Run(new MainForm(storeDB));
            }
        }
    }
}
