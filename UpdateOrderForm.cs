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
    public partial class UpdateOrderForm : Form
    {
        private StoreDB _storeDB;
        private int _consNumber;
        private string _productName;

        public UpdateOrderForm(StoreDB storeDB, int consNumber, string prodName, double amount, string unitType)
        {
            _storeDB = storeDB;
            _consNumber = consNumber;
            _productName = prodName;

            InitializeComponent();

            string orderDescription = string.Format("[{0}]: {1}, {2}", consNumber, prodName, unitType);
            orderLabel.Text = orderDescription;
            productComboBox.SelectedIndex = productComboBox.FindString(orderDescription);
            amountTextBox.Text = amount.ToString();

            foreach(Product product in _storeDB.GetProducts())
            {
                productComboBox.Items.Add(string.Format($"{product.Name} {product.UnitType}"));
            }

            productComboBox.SelectedIndex = 0;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(amountTextBox.Text, out double amount))
            {
                MessageBox.Show("Incorrect amount value");
                return;
            }

            long productID = _storeDB.GetProductID(_productName);

            string selectedProduct = productComboBox.SelectedItem.ToString();

            string prodName = selectedProduct.Substring(0, selectedProduct.IndexOf(" "));

            long productIDUpdated = _storeDB.GetProductID(prodName);

            int result = _storeDB.UpdateOrder(_consNumber, productID, amount, productIDUpdated);

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
                case 3:
                    MessageBox.Show("Incorrect new product ID");
                    break;
                default:
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
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
