using System;
using System.Data.SqlClient;

namespace StoreApp_DB_
{
    public partial class UpdateConsignmentForm : OperationWithConsignmentForm
    {
        public UpdateConsignmentForm(StoreDB storeDB, int number, DateTime date
                                    , string supplierName, string supplierSurname, string recipientName
                                    , string recipientSurname)
            : base(date, Query.Update, storeDB)
        {
            numberTextBox.Text = number.ToString();
            dateTextBox.Text = date.ToString();
            supplierNameTextBox.Text = supplierName;
            supplierSurnameTextBox.Text = supplierSurname;
            recipientNameTextBox.Text = recipientName;
            recipientSurnameTextBox.Text = recipientSurname;

            InitializeComponent();
        }

        protected override void button_Click(object sender, EventArgs e)
        {
            executeCommand("UpdateConsignment");
        }
        private void UpdateConsignmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
