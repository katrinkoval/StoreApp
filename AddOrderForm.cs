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

        private void button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numberComboBox.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(productIDComboBox.SelectedItem.ToString())
                                || string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
            }

            int number = int.Parse(numberComboBox.SelectedItem.ToString());

            string selectedProduct = productIDComboBox.SelectedItem.ToString();

            string prodName = selectedProduct.Substring(0, selectedProduct.IndexOf(" "));

            int productID = _storeDB.GetProductID(prodName);

            float amount = float.Parse(amountTextBox.Text);

            int result = _storeDB.AddOrder(number, productID, amount);

            HandleOperationResult(result);

        }

        private void HandleOperationResult(int errorCode)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
