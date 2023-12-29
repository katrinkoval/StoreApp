using System;
using System.Windows.Forms;
using StoreApp_DB_.Enums;
using Models;
using StoreService;

namespace StoreApp_DB_
{
    public partial class MainForm : Form
    {
        private readonly IStoreService _storeDB;
        
        public MainForm(IStoreService storeDB)
        {
            _storeDB = storeDB;
            TotalPriceChangeManager.EventHandler = new TotalPriceChangeManager.TotalPriceChanged(TotalPriceChangedEventHandler);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AuthenticationForm auntForm = new AuthenticationForm();

            if (auntForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _storeDB.OpenConnection(auntForm.serverNameTextBox.Text
                            , auntForm.loginTextBox.Text, auntForm.passwordTextBox.Text);

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
            AddConsignmentOrdersToDGV(int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString()));

            showOrdersComboBox.SelectedIndex = 0;

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

        private void AddConsignmentOrdersToDGV(int consigmentNumber)
        {
            dvgOrders.Rows.Clear();

            foreach (Order order in _storeDB.GetConsignmentsOrders(consigmentNumber))
            {
                dvgOrders.Rows.Add(order.ConsignmentNumber, order.Product, order.Price
                            , order.Amount, order.UnitType, order.TotalPrice);
            }
        }


        #region === CRUD Consignments ===

        private void UpdateConsignment_Click(object sender, EventArgs e)
        {
            int number = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());
            DateTime date = DateTime.Parse(dgvConsignments.CurrentRow.Cells[1].Value.ToString());
            string supplierName = dgvConsignments.CurrentRow.Cells[2].Value.ToString();
            string recipientName = dgvConsignments.CurrentRow.Cells[3].Value.ToString();

            OperationWithConsignmentForm updateForm = new UpdateConsignmentForm(_storeDB
                , number, date, supplierName, recipientName);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();
            }
        }

        private void AddConsignment_Click(object sender, EventArgs e)
        {
            OperationWithConsignmentForm addForm = new AddConsignmentForm(_storeDB);
            
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                AddConsignmentsToDGV();

                dgvConsignments.Rows[dgvConsignments.Rows.Count - 1].Selected = true;

                if (showOrdersComboBox.SelectedIndex == 0)
                {
                    dvgOrders.Rows.Clear();
                }
                else
                {
                    AddOrdersToDGV();
                }
            }

        }

        private void RemoveConsignment_Click(object sender, EventArgs e)
        {
            int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

            string message = String.Format("Are you sure you want to delete consignment [{0}]?"
                          , consignmentNumber);


            if (!ConfirmDeleting(message))
            {
                return;
            }

            int result = _storeDB.DeleteConsignment(consignmentNumber);

            HandleDeletionResult(result);

            if (result == 0)
            {
                AddConsignmentsToDGV();
                FillOrdersDGV();
            }
        }


        #endregion


        #region === CRUD Orders ===

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

            AddOrderForm addForm = new AddOrderForm(_storeDB, consignmentNumber);

            if(addForm.ShowDialog() == DialogResult.OK)
            {
                FillOrdersDGV();
            }
        }

        private void UpdateOrder_Click(object sender, EventArgs e)
        {
            int number = int.Parse(dvgOrders.CurrentRow.Cells[0].Value.ToString());
            string productName = dvgOrders.CurrentRow.Cells[1].Value.ToString();
            double amount = double.Parse(dvgOrders.CurrentRow.Cells[3].Value.ToString());
            string unitType = dvgOrders.CurrentRow.Cells[4].Value.ToString();

            UpdateOrderForm updateForm = new UpdateOrderForm(_storeDB, number
                                                        , productName, amount, unitType);
            
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                FillOrdersDGV();
            }

        }

        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            int consignmentNumber = int.Parse(dvgOrders.CurrentRow.Cells[0].Value.ToString());

            string productName = dvgOrders.CurrentRow.Cells[1].Value.ToString();

            string message = String.Format("Are you sure you want to delete order [{0}, {1}]?"
                            , consignmentNumber, productName);

            if (!ConfirmDeleting(message))
            {
                return;
            }

            long productID = _storeDB.GetProductID(productName);

            int result = _storeDB.DeleteOrder(consignmentNumber, productID);

            HandleDeletionResult(result);

            if(result == 0)
            {
                FillOrdersDGV(); ;
            }
        }

        #endregion

        private void ShowOrdersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (showOrdersComboBox.SelectedIndex == 0)
            {
                int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

                AddConsignmentOrdersToDGV(consignmentNumber);

                deleteOrder.Enabled = true;
                updateConsignment.Enabled = true;
            }
            else
            {
                deleteOrder.Enabled = false;
                updateConsignment.Enabled = false;

                AddOrdersToDGV();
            }

        }

        private void FillOrdersDGV()
        {
            if (showOrdersComboBox.SelectedIndex == 0)
            {
                AddConsignmentOrdersToDGV(int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString()));
            }
            else
            {
                AddOrdersToDGV();
            }
        }

        private void DgvConsignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillOrdersDGV();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _storeDB.CloseConnection();

            Close();
        }

        private void HandleDeletionResult(int errorCode)
        {
            switch ((DeletionResult)errorCode)
            {
                case DeletionResult.Successful:
                    MessageBox.Show("Successful operation");
                    break;
                case DeletionResult.IncorrectConsignmentNumber:
                    MessageBox.Show("Incorrect consignment number");
                    break;
                case DeletionResult.ImpossibleDeletion:
                    MessageBox.Show("You cannot delete this record");
                    break;
                case DeletionResult.IncorrectProductName:
                    MessageBox.Show("Incorrect product name");
                    break;
                default:
                    break;
            }           
        }

        private bool ConfirmDeleting(string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show(message, "Confirm deleting", buttons);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        private void MaximizeWindowButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void TotalPriceChangedEventHandler(double persentage, PriceChanging option)
        {
            dvgOrders.Rows.Clear();

            int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

            var orders = _storeDB.GetConsignmentsOrders(consignmentNumber);

            switch (option)
            {
                case PriceChanging.Increase:
                    orders = orders.GetOrdersWithIncrease(persentage);                    
                    break;
                case PriceChanging.Decrease:
                    orders = orders.GetOrdersWithDiscount(persentage);
                    break;
                default:
                    break;
            }

            foreach (Order order in orders)
            {
                dvgOrders.Rows.Add(order.ConsignmentNumber, order.Product, order.Price
                            , order.Amount, order.UnitType, order.TotalPrice);
            }
        }

        private void DgvConsignments_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int consignmentNumber = int.Parse(dgvConsignments.CurrentRow.Cells[0].Value.ToString());

                ChangeTotalPriceForm changeTotalPriceForm = new ChangeTotalPriceForm(consignmentNumber);
                changeTotalPriceForm.Show();
            }
        }
    }
}
