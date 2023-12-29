using System;
using System.Windows.Forms;
using StoreService;

namespace StoreApp_DB_
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (IStoreService storeDB = new StoreDbService())
            {
                Application.Run(new MainForm(storeDB));
            }
        }
    }
}
