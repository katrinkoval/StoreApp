using System;
using System.Data;
using System.Data.SqlClient;

namespace StoreApp_DB_
{
    public partial class AddConsignmentForm : OperationWithConsignmentForm
    {
        public AddConsignmentForm(StoreDB storeDB)
            : base(DateTime.Now, Query.Add, storeDB)     
        {
            InitializeComponent();
        }

        protected override void button_Click(object sender, EventArgs e)
        {
            executeCommand("AddConsignment2");
        }

        private void AddingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
