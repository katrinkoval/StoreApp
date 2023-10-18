using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class DeleteConsignmentForm : Form
    {
        private StoreDB _storeDB;
        public DeleteConsignmentForm(StoreDB storeDB, int consignmentNumber)
        {
            _storeDB = storeDB;
            InitializeComponent();

            numberTextBox.Text = consignmentNumber.ToString();
            numberTextBox.Select();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool confirmDeleting()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = String.Format("Are you sure you want to delete consignment [{0}]?", numberTextBox.Text);
            result = MessageBox.Show(message, "Confirm deleting", buttons);

            if (result == DialogResult.Yes)
            {
                return true;                
            }

            return false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numberTextBox.Text) || !int.TryParse(numberTextBox.Text, out int number))
            {
                MessageBox.Show("Incorrect consignment number");
                return;
            }
             
            if(!confirmDeleting())
            {
                return;
            }

            int result = _storeDB.DeleteConsignment(number);

            HandleDeletingResult(result);
        }

        private void HandleDeletingResult(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("Successful operation");
                    Close();
                    break;
                case 1:
                    MessageBox.Show("Incorrect consignment number");
                    break;
                case 2:
                    MessageBox.Show("You cannot delete this consignment");
                    break;
                default:
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numberLabel_Click(object sender, EventArgs e)
        {

        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
