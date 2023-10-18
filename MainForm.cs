using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class MainForm : Form
    {
        private StoreDB _storeDB;

        public MainForm(StoreDB storeDB)
        {
            _storeDB = storeDB;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AuthenticationForm auntForm = new AuthenticationForm();

            if (auntForm.ShowDialog() == DialogResult.OK)
            {
                _storeDB = new StoreDB(auntForm.serverNameTextBox.Text, auntForm.loginTextBox.Text
                                                                    , auntForm.passwordTextBox.Text);
                try
                {
                    _storeDB.openConnection();

                    auntForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                    return;
                }
            }
            else
            {
                Close();
                return;
            }

            AddColumnsToDgvConsigments();
            AddConsignmentsToDGV();
            AddColumnsToDgvOrders();
            AddOrdersToDGV();
        }

        private void AddColumnsToDgvConsigments()
        {
            dgvConsignments.Columns.Add("number", "Number");
            dgvConsignments.Columns.Add("date", "Date");
            dgvConsignments.Columns.Add("supplier", "Supplier");
            dgvConsignments.Columns.Add("recipient", "Recipient");
        }

        private void AddColumnsToDgvOrders()
        {
            dvgOrders.Columns.Add("consignmentNumber", "ConsignmentNumber");
            dvgOrders.Columns.Add("product", "Product");
            dvgOrders.Columns.Add("price", "Price");
            dvgOrders.Columns.Add("amount", "Amount");
            dvgOrders.Columns.Add("unitType", "UnitType");
            dvgOrders.Columns.Add("totalPrice", "TotalPrice");

            dvgOrders.Columns[3].Width = 60;
            dvgOrders.Columns[4].Width = 120;
        }


        private void AddConsignmentsToDGV()
        {
            dgvConsignments.Rows.Clear();

            foreach (Consignment consignment in _storeDB.GetConsignments())
            {
                dgvConsignments.Rows.Add(consignment.Number, consignment.ConsignmentDate.ToString()
                                    , consignment.SupplierName, consignment.RecipientName);
            }
        }

        private void AddOrdersToDGV()
        {
            dvgOrders.Rows.Clear();

            foreach (Order order in _storeDB.GetOrders())
            {
                dvgOrders.Rows.Add(order.ConsignmentNumber, order.Product, order.Price
                            , order.Amount, order.UnitType, order.TotalPrice);
            }
        }

        private void AddConsignmentOrders(int consigmentNumber)
        {
            dvgOrders.Rows.Clear();

            foreach (Order order in _storeDB.GetConsignmentsOrders(consigmentNumber))
            {
                dvgOrders.Rows.Add(order.ConsignmentNumber, order.Product, order.Price
                            , order.Amount, order.UnitType, order.TotalPrice);
            }
        }

       
        private void updateConsignment_Click(object sender, EventArgs e)
        {
            int number = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());
            DateTime date = DateTime.Parse(dgvConsignments.CurrentRow.Cells[1].Value.ToString());
            string supplierName = dgvConsignments.CurrentRow.Cells[2].Value.ToString();
            string recipientName = dgvConsignments.CurrentRow.Cells[3].Value.ToString();

            string[] supplierNameParts = supplierName.Split(' ');
            string[] recipientNameParts = recipientName.Split(' ');

            OperationWithConsignmentForm updateForm = new UpdateConsignmentForm(_storeDB
                , number, date, supplierNameParts[0], supplierNameParts[1], recipientNameParts[0]
                , recipientNameParts[1]);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
                AddOrdersToDGV();
            }
        }

        private void addConsignment_Click(object sender, EventArgs e)
        {
            OperationWithConsignmentForm addForm = new AddConsignmentForm(_storeDB);
            
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
                AddOrdersToDGV();
            }

        }

        private void removeConsignment_Click(object sender, EventArgs e)
        {
            int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

            DeleteConsignmentForm deleteForm = new DeleteConsignmentForm(_storeDB, consignmentNumber);

            if (deleteForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
                AddOrdersToDGV();
            }
        }

        private void dgvConsignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int consignmentNumber = int.Parse(dgvConsignments.Rows[e.RowIndex].Cells[0].Value.ToString());
            AddConsignmentOrders(consignmentNumber);
        }


        private void showAllOrders_Click(object sender, EventArgs e)
        {
            AddOrdersToDGV();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _storeDB.closeConnection();

            Close();
        }

        private void showAllOrders_MouseEnter(object sender, EventArgs e)
        {
            showAllOrders.BackColor = System.Drawing.Color.DarkOrange;
        }

        private void showAllOrders_MouseLeave(object sender, EventArgs e)
        {
            showAllOrders.BackColor = System.Drawing.Color.LightGray;
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

            AddOrderForm addForm = new AddOrderForm(_storeDB, consignmentNumber);

            if(addForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
                AddOrdersToDGV();
            }
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrderForm deleteForm = new DeleteOrderForm(_storeDB);

            if (deleteForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
                AddOrdersToDGV();
            }

        }
    }
}
