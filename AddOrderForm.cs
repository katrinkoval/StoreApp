using System;
using System.Windows.Forms;
using Models;
using StoreApp_DB_.Enums;
using DataAccessLevel;

namespace StoreApp_DB_
{
    public partial class AddOrderForm : Form
    {

        private StoreDB _storeDB;

        public AddOrderForm(StoreDB storeDB, int consNumber)
        {
            _storeDB = storeDB;

            InitializeComponent();

            foreach (Product product in _storeDB.GetProducts())
            {
                productIDComboBox.Items.Add(string.Format($"{product.Name} {product.UnitType}"));
            }

            productIDComboBox.SelectedIndex = 0;

            foreach (int number in _storeDB.GetConsignmentNumbers())
            {
                numberComboBox.Items.Add(number);
            }

            productIDComboBox.SelectedIndex = 1;

            numberComboBox.SelectedIndex = numberComboBox.FindString(consNumber.ToString());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HandleOperationResult(int errorCode)
        {
            switch ((OrderOperationResult)errorCode)
            {
                case OrderOperationResult.Successful:
                    MessageBox.Show("Successful operation");
                    Close();
                    break;
                case OrderOperationResult.IncorrectConsignmentNumber:
                    MessageBox.Show("Incorrect consignment number");
                    break;
                case OrderOperationResult.IncorrectProductID:
                    MessageBox.Show("Incorrect product ID");
                    break;
                default:
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void productTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void amountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

    }
}
