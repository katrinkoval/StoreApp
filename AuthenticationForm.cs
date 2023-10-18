using System;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class AuthenticationForm : Form
    {
        private string defaultUserName = "User";
        private string defaultServerName = "localhost\\sqlexpress";
        public AuthenticationForm()
        {
            InitializeComponent();

            serverNameTextBox.Text = defaultServerName;
            loginTextBox.Text = defaultUserName;
            passwordTextBox.Select();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(serverNameTextBox.Text) || string.IsNullOrWhiteSpace(loginTextBox.Text)
                                || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
