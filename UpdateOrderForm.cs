using System;
using System.Windows.Forms;
using Models;
using StoreApp_DB_.Enums;
using DataAccessLevel;

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
            switch ((OrderOperationResult)errorCode)
            {
                case OrderOperationResult.Successful:
                    MessageBox.Show("Successful operation");
                    Close();
                    break;
                case OrderOperationResult.IncorrectProductID:
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
