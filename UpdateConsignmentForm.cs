using System;
using DataAccessLevel;

namespace StoreApp_DB_
{
    public partial class UpdateConsignmentForm : OperationWithConsignmentForm
    {
        public UpdateConsignmentForm(StoreDB storeDB, int number, DateTime date
                                            , string supplierName, string recipientName)
               : base(date, QueryType.Update, storeDB)
        {

            numberTextBox.Text = number.ToString();
            dateTimePicker.Value = date;

            supplierNameComboBox.Text = supplierName;
            recipientNameComboBox.Text = recipientName;

            supplierIpnComboBox.Text = storeDB.GetIPNByName(supplierName).ToString();
            recipientIpnComboBox.Text = storeDB.GetIPNByName(recipientName).ToString();

            this.Width = 456;
            this.Height = 263;

            InitializeComponent();
        }

        private UpdateConsignmentForm()
        {

        }

        protected override void ActionButton_Click(object sender, EventArgs e)
        {
            ExecuteCommand("UpdateConsignment");
        }
    }
}
