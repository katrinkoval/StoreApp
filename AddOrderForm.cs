using System;
using System.Windows.Forms;
using ModelsDTO;
using StoreApp_DB_.Enums;
using StoreService;

namespace StoreApp_DB_
{
    public partial class AddOrderForm : Form
    {

        private readonly IStoreService _storeDB;

        public AddOrderForm(IStoreService storeDB, int consNumber)
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numberComboBox.SelectedItem.ToString())
                            || string.IsNullOrWhiteSpace(productIDComboBox.SelectedItem.ToString())
                                || string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
            }

            int number = int.Parse(numberComboBox.SelectedItem.ToString());

            string selectedProduct = productIDComboBox.SelectedItem.ToString();

            string prodName = selectedProduct.Substring(0, selectedProduct.IndexOf(" "));

            long productID = _storeDB.GetProductID(prodName);

            double amount = double.Parse(amountTextBox.Text);

            int result = _storeDB.AddOrder(number, productID, amount);

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProductTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

    }
}
