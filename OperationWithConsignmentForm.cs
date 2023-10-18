using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class OperationWithConsignmentForm : Form
    {
        protected bool _isUsingIPN;
        protected StoreDB _storeDB;

        public OperationWithConsignmentForm(DateTime consigmentDate, Query option, StoreDB storeDB)
        {
            _storeDB = storeDB;

            InitializeComponent();

            supplierIpnTextBox.Visible = false;
            recipientIpnTextBox.Visible = false;
            supplierIpnLabel.Visible = false;
            recipientIpnLabel.Visible = false;

            _isUsingIPN = false;

            dateTextBox.Text = consigmentDate.ToString();
            button.Text = option.ToString();
        }

        public OperationWithConsignmentForm()
            : this(DateTime.Now, Query.Add, null)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        protected void executeCommand(string commandText)
        {
            if (!validateInputedData())
            {
                return;
            }

            Consignment cons = new Consignment();
            cons.Number = long.Parse(numberTextBox.Text);
            cons.ConsignmentDate = DateTime.Parse(dateTextBox.Text);
            cons.SupplierName = supplierNameTextBox.Text;
            cons.RecipientName = recipientNameTextBox.Text;

            int result = 0;

            if (_isUsingIPN)
            {
                int supplierId = int.Parse(supplierIpnTextBox.Text);
                int recipientId = int.Parse(recipientIpnTextBox.Text);
                result = _storeDB.ProcedureExecute(_isUsingIPN, commandText, cons, supplierID: supplierId
                                                                            , recipientID: recipientId);
            }
            else
            {
                result = _storeDB.ProcedureExecute(_isUsingIPN, commandText, cons
                                                , supplierSurnameTextBox.Text, recipientSurnameTextBox.Text);
            }
           

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
                    MessageBox.Show("You must input the first and last name or IPN of the supplier and recipient");
                    break;
                case 3:
                    MessageBox.Show("Incorrect name of supplier");
                    break;
                case 4:
                    MessageBox.Show("Incorrect name of recipient");
                    break;
                case 5:
                    MessageBox.Show("Incorrect IPN of supplier");
                    break;
                case 6:
                    MessageBox.Show("Incorrect IPN of recipient");
                    break;
                default:
                    break;
            }
        }

        protected virtual void button_Click(object sender, EventArgs e)
        {
        }

        protected bool validateInputedData()
        {
            if (string.IsNullOrWhiteSpace(numberTextBox.Text) || string.IsNullOrWhiteSpace(dateTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
                return false;
            }
            if(_isUsingIPN)
            {
                if (string.IsNullOrWhiteSpace(supplierIpnTextBox.Text) 
                                        || string.IsNullOrWhiteSpace(recipientIpnTextBox.Text))
                {
                    MessageBox.Show("All fields must be filled");
                    return false;
                }
                if(!int.TryParse(supplierIpnTextBox.Text, out int suppplierIpn))
                {
                    MessageBox.Show("Incorrect value of supplier IPN");
                    return false;
                }
                if (!int.TryParse(recipientIpnTextBox.Text, out int recipientIpn))
                {
                    MessageBox.Show("Incorrect value of recipient IPN");
                    return false;
                }

                return true;
            }

            if (string.IsNullOrWhiteSpace(supplierNameTextBox.Text)
                                       || string.IsNullOrWhiteSpace(supplierSurnameTextBox.Text)
                                       || string.IsNullOrWhiteSpace(recipientNameTextBox.Text)
                                       || string.IsNullOrWhiteSpace(recipientSurnameTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
                return false;
            }

            if (!int.TryParse(numberTextBox.Text, out int number))
            {
                MessageBox.Show("Incorrect value of consigment number");
                return false;
            }
            if (!DateTime.TryParse(dateTextBox.Text, out DateTime date))
            {
                MessageBox.Show("Incorrect value of date");
                return false;
            }

            return true;

        }

        private void useIdLabel_Click(object sender, EventArgs e)
        {
            supplierNameLabel.Visible = false;
            supplierSurnameLabel.Visible = false;
            recipientNameLabel.Visible = false;
            recipientSurnameLabel.Visible = false;
            supplierNameTextBox.Visible = false;
            supplierSurnameTextBox.Visible = false;
            recipientSurnameTextBox.Visible = false;
            recipientNameTextBox.Visible = false;

            supplierIpnTextBox.Visible = true;
            recipientIpnTextBox.Visible = true;
            supplierIpnLabel.Visible = true;
            recipientIpnLabel.Visible = true;

            _isUsingIPN = true;
        }

        private void useIdLabel_MouseEnter(object sender, EventArgs e)
        {
            useIdLabel.BackColor = Color.DarkOrange;
        }

        private void useIdLabel_MouseLeave(object sender, EventArgs e)
        {
            useIdLabel.BackColor = Color.White;
        }
    }
}
