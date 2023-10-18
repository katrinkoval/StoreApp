using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class DeleteOrderForm : Form
    {

        private StoreDB _storeDB;

        public DeleteOrderForm(StoreDB storeDB)
        {
            _storeDB = storeDB;
            InitializeComponent();
        }

        private void DeleteOrderForm_Load(object sender, EventArgs e)
        {
            foreach (string productName in _storeDB.GetProductNames())
            {
                productNameComboBox.Items.Add(productName);
            }

            foreach (int consNumber in _storeDB.GetConsignmentNumbers())
            {
                numberComboBox.Items.Add(consNumber);
            }
        }

        private bool confirmDeleting()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = String.Format("Are you sure you want to delete order [{0}, {1}]?"
                            , numberComboBox.SelectedItem.ToString(), productNameComboBox.SelectedItem.ToString());
            result = MessageBox.Show(message, "Confirm deleting", buttons);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productNameComboBox.SelectedItem.ToString())
                || string.IsNullOrWhiteSpace(numberComboBox.SelectedItem.ToString())
                || !int.TryParse(numberComboBox.SelectedItem.ToString(), out int number))
            {
                MessageBox.Show("Incorrect consignment number or product name");
                return;
            }

            if (!confirmDeleting())
            {
                return;
            }

            int productID = Convert.ToInt32(_storeDB.GetProductID(productNameComboBox.SelectedItem.ToString()));

            int result = _storeDB.DeleteOrder(number, productID);

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
                    MessageBox.Show("Incorrect product name");
                    break;
                case 3:
                    MessageBox.Show("You cannot delete this order");
                    break;
                default:
                    break;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
