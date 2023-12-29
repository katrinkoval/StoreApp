using System;
using StoreService;

namespace StoreApp_DB_
{
    public partial class AddConsignmentForm : OperationWithConsignmentForm
    {
        public AddConsignmentForm(IStoreService storeDB)
            : base(DateTime.Now, QueryType.Add, storeDB)
        {
            InitializeComponent();

            supplierNameComboBox.SelectedItem = supplierNameComboBox.Items[0];
            recipientNameComboBox.SelectedItem = recipientNameComboBox.Items[0];

            supplierIpnComboBox.SelectedItem = supplierIpnComboBox.Items[0];
            recipientIpnComboBox.SelectedItem = recipientIpnComboBox.Items[0];
        }


        protected override void ActionButton_Click(object sender, EventArgs e)
        {
            ExecuteCommand("AddConsignment2");
        }

    }
}
