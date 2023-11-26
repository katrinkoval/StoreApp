using System;
using DataAccessLevel;

namespace StoreApp_DB_
{
    public partial class AddConsignmentForm : OperationWithConsignmentForm
    {
        public AddConsignmentForm(StoreDB storeDB)
            : base(DateTime.Now, QueryType.Add, storeDB)
        {
            InitializeComponent();

            this.Width = 456; 
            this.Height = 263;

            supplierNameComboBox.SelectedItem = supplierNameComboBox.Items[0];
            recipientNameComboBox.SelectedItem = recipientNameComboBox.Items[0];

            supplierIpnComboBox.SelectedItem = supplierIpnComboBox.Items[0];
            recipientIpnComboBox.SelectedItem = recipientIpnComboBox.Items[0];
        }


        protected override void button_Click(object sender, EventArgs e)
        {
            ExecuteCommand("AddConsignment2");
        }

    }
}
