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

            supplierIpnComboBox.Visible = false;
            recipientIpnComboBox.Visible = false;
            supplierIpnLabel.Visible = false;
            recipientIpnLabel.Visible = false;

            _isUsingIPN = false;

            dateTimePicker.Value = consigmentDate;
            button.Text = option.ToString();

            foreach (string name in _storeDB.GetIndividualNames())
            {
                supplierNameComboBox.Items.Add(name);
                recipientNameComboBox.Items.Add(name);
            }


            foreach (long id in _storeDB.GetIndividualIDs())
            {
                supplierIpnComboBox.Items.Add(id);
                recipientIpnComboBox.Items.Add(id);
            }

        }

        private OperationWithConsignmentForm()
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

            Consignment newConsignment = new Consignment();

            newConsignment.Number = long.Parse(numberTextBox.Text);
            newConsignment.ConsignmentDate = dateTimePicker.Value;

            if (_isUsingIPN)
            {
                newConsignment.SupplierIpn = int.Parse(supplierIpnComboBox.Text);
                newConsignment.RecipientIpn =  int.Parse(recipientIpnComboBox.Text);
            }
            else
            {

                newConsignment.SupplierName = supplierNameComboBox.SelectedItem.ToString();
                newConsignment.RecipientName = recipientNameComboBox.SelectedItem.ToString();
            }

            int result = _storeDB.ProcedureExecute(_isUsingIPN, commandText, newConsignment);

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
            if (string.IsNullOrWhiteSpace(numberTextBox.Text))
            {
                MessageBox.Show("All fields must be filled");
                return false;
            }

            if(_isUsingIPN)
            {
                if (string.IsNullOrWhiteSpace(supplierIpnComboBox.SelectedItem.ToString()) 
                                        || string.IsNullOrWhiteSpace(recipientIpnComboBox.Text))
                {
                    MessageBox.Show("All fields must be filled");
                    return false;
                }
            }
            else if (string.IsNullOrWhiteSpace(supplierNameComboBox.Text)
                                        || string.IsNullOrWhiteSpace(recipientNameComboBox.Text))
            {
                MessageBox.Show("All fields must be filled");
                return false;
            }

            return true;

        }

        private void useIdLabel_Click(object sender, EventArgs e)
        {   if (_isUsingIPN)
            {
                useIdLabel.Text = "Use IPN";
                supplierNameLabel.Visible = true;
                recipientNameLabel.Visible = true;
                supplierNameComboBox.Visible = true;
                recipientNameComboBox.Visible = true;

                supplierIpnComboBox.Visible = false;
                recipientIpnComboBox.Visible = false;
                supplierIpnLabel.Visible = false;
                recipientIpnLabel.Visible = false;

                _isUsingIPN = false;

                if (supplierIpnComboBox.SelectedItem != null)
                {
                    int supplierIpn = int.Parse(supplierIpnComboBox.SelectedItem.ToString());
                    supplierNameComboBox.SelectedItem = _storeDB.GetNameByIPN(supplierIpn);
                }
                if (recipientIpnComboBox.SelectedItem != null)
                {
                    int recipientIpn = int.Parse(recipientIpnComboBox.SelectedItem.ToString());
                    recipientNameComboBox.SelectedItem = _storeDB.GetNameByIPN(recipientIpn);
                }
            }
            else
            {
                useIdLabel.Text = "Use name";

                supplierNameLabel.Visible = false;
                recipientNameLabel.Visible = false;
                supplierNameComboBox.Visible = false;
                recipientNameComboBox.Visible = false;

                supplierIpnComboBox.Visible = true;
                recipientIpnComboBox.Visible = true;
                supplierIpnLabel.Visible = true;
                recipientIpnLabel.Visible = true;

                _isUsingIPN = true;

                if(supplierNameComboBox.SelectedItem != null)
                {
                    supplierIpnComboBox.SelectedItem = _storeDB.GetIPNByName(supplierNameComboBox.SelectedItem.ToString());
                }
                if (recipientNameComboBox.SelectedItem != null)
                {
                    recipientIpnComboBox.SelectedItem = _storeDB.GetIPNByName(recipientNameComboBox.SelectedItem.ToString());
                }
            }
        }

        private void useIdLabel_MouseEnter(object sender, EventArgs e)
        {
            useIdLabel.BackColor = Color.DarkOrange;
        }

        private void useIdLabel_MouseLeave(object sender, EventArgs e)
        {
            useIdLabel.BackColor = Color.White;
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
