using System;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class AuthenticationForm : Form
    {
        private const string DEFAULT_USER_NAME = "User";
        private const string DEFAULT_SERVER_NAME = "localhost\\sqlexpress";
        public AuthenticationForm()
        {
            InitializeComponent();

            serverNameTextBox.Text = DEFAULT_SERVER_NAME;
            loginTextBox.Text = DEFAULT_USER_NAME;
            passwordTextBox.Select();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
