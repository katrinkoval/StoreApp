using System;
using System.Data.SqlClient;

namespace StoreApp_DB_
{
    public partial class UpdateConsignmentForm : OperationWithConsignmentForm
    {
        public UpdateConsignmentForm(StoreDB storeDB, int number, DateTime date
                                            , string supplierName, string recipientName)
               : base(date, Query.Update, storeDB)
        {
            InitializeComponent();

            numberTextBox.Text = number.ToString();
            dateTimePicker.Value = date;

            supplierNameComboBox.Text = supplierName;
            recipientNameComboBox.Text = recipientName;

            supplierIpnComboBox.Text = storeDB.GetIPNByName(supplierName).ToString();
            recipientIpnComboBox.Text = storeDB.GetIPNByName(recipientName).ToString();

            this.Width = 456;
            this.Height = 263;
        }

        protected override void button_Click(object sender, EventArgs e)
        {
            executeCommand("UpdateConsignment");
        }
    }
}
