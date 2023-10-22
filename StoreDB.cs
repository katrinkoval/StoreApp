using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoreApp_DB_
{
    public class StoreDB : IDisposable
    {
        private SqlConnection _connection;
        private bool _alreadyDisposed;

        private const string dataBaseName = "Store";

        public StoreDB(string servername, string login, string password)
        {
            InitializeConnection(servername, login, password);
        }

        public StoreDB()
        {
            _connection = null;
        }

        private void InitializeConnection(string servername, string login, string password)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = servername;
            sqlConnectionStringBuilder.InitialCatalog = dataBaseName;
            sqlConnectionStringBuilder.UserID = login;
            sqlConnectionStringBuilder.Password = password;
            string strConnection = sqlConnectionStringBuilder.ToString();

            _connection = new SqlConnection(strConnection);
        }

        private void CheckConnectionState()
        {
            if (_alreadyDisposed)      
            {
                throw new ObjectDisposedException(nameof(StoreDB));
            }
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                throw new SqlConnectionException("Connection is closed");
            }
        }

        public void OpenConnection(string servername = null, string login = null, string password = null)
        {
            if (_alreadyDisposed)       
            {
                throw new ObjectDisposedException(nameof(StoreDB));
            }

            if(_connection == null && servername != null  && login != null && password != null)
            {
                InitializeConnection(servername, login, password);
            }
            else
            {
                throw new SqlConnectionException("Incorrect connection string");
            }

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_alreadyDisposed)
            {
                throw new ObjectDisposedException(nameof(StoreDB));
            }

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            if (_alreadyDisposed)
            {
                return;
            }

            _connection.Dispose();

            _alreadyDisposed = true;

            GC.SuppressFinalize(this);
        }

        ~StoreDB()
        {
            if (_alreadyDisposed)
            {
                return;
            }

            Dispose();
        }


        #region === SQL Query ===

        public IEnumerable<Order> GetOrders()
        {
            CheckConnectionState();

            string commandStr = "SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID";

            SqlExecutor<Order> orderExecutor = new SqlExecutor<Order>(_connection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Order> GetConsignmentsOrders(int consigmentNumber)
        {
            string commandStr = string.Format("SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID " +
                "WHERE O.ConsignmentNumber = {0}", consigmentNumber);

            SqlExecutor<Order> orderExecutor = new SqlExecutor<Order>(_connection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Consignment> GetConsignments()
        {
            string commandStr = "SELECT C.Number, C.ConsignmentDate, I1.Name + ' ' + I1.Surname, "
                                      + "I2.Name + ' ' + I2.Surname FROM Consignments C "
                                      + "LEFT JOIN Individuals I1 ON C.SupplierID = I1.IPN "
                                      + "LEFT JOIN Individuals I2 ON C.RecipientID = I2.IPN";

            SqlExecutor<Consignment> consingmentExecutor = new SqlExecutor<Consignment>(_connection);

            return consingmentExecutor.GetRowsFromBD(commandStr);
        }

        public int ProcedureExecute(bool _isUsingIPN, string commandText, Consignment cons
                            , string supplierLastName = "", string recipientLastName = ""
                            , int supplierID = 0, int recipientID = 0)
        {
            SqlCommand command = new SqlCommand(commandText, _connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter number = new SqlParameter("@Number", SqlDbType.BigInt);
            number.Value = cons.Number;
            number.Direction = ParameterDirection.Input;
            command.Parameters.Add(number);

            SqlParameter date = new SqlParameter("@ConsigmentDate", SqlDbType.DateTime);
            date.Value = cons.ConsignmentDate;
            date.Direction = ParameterDirection.Input;
            command.Parameters.Add(date);

            if (_isUsingIPN)
            {
                SqlParameter supplierIPN = new SqlParameter("@SupplierID", SqlDbType.BigInt);
                supplierIPN.Value = supplierID;
                supplierIPN.Direction = ParameterDirection.Input;

                SqlParameter recipientIPN = new SqlParameter("@RecipientID", SqlDbType.BigInt);
                recipientIPN.Value = recipientID;
                recipientIPN.Direction = ParameterDirection.Input;

                command.Parameters.Add(supplierIPN);
                command.Parameters.Add(recipientIPN);
            }
            else
            {
                SqlParameter supplierName = new SqlParameter("@SupplierName", SqlDbType.NVarChar);
                supplierName.Value = cons.SupplierName;
                supplierName.Direction = ParameterDirection.Input;

                SqlParameter supplierSurname = new SqlParameter("@SupplierSurname", SqlDbType.NVarChar);
                supplierSurname.Value = supplierLastName;
                supplierSurname.Direction = ParameterDirection.Input;

                SqlParameter recipientName = new SqlParameter("@RecipientName", SqlDbType.NVarChar);
                recipientName.Value = cons.RecipientName;
                recipientName.Direction = ParameterDirection.Input;

                SqlParameter recipientSurname = new SqlParameter("@RecipientSurname", SqlDbType.NVarChar);
                recipientSurname.Value = recipientLastName;
                recipientSurname.Direction = ParameterDirection.Input;

                command.Parameters.Add(supplierName);
                command.Parameters.Add(supplierSurname);
                command.Parameters.Add(recipientName);
                command.Parameters.Add(recipientSurname);
            }

            SqlParameter operationResult = new SqlParameter();
            operationResult.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(operationResult);

            command.ExecuteNonQuery();

            return int.Parse(operationResult.Value.ToString());
        }

        public int DeleteConsignment(int consNumber)
        {
            SqlCommand command = new SqlCommand("RemoveConsignment", _connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter consignmentNumber = new SqlParameter("@Number", SqlDbType.BigInt);
            consignmentNumber.Value = consNumber;
            consignmentNumber.Direction = ParameterDirection.Input;
            command.Parameters.Add(consignmentNumber);

            SqlParameter operationResult = new SqlParameter();
            operationResult.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(operationResult);

            command.ExecuteNonQuery();

            return int.Parse(operationResult.Value.ToString());
        }

        public int AddOrder(int consNumber, int prodID, double prodAmount)
        {
            SqlCommand command = new SqlCommand("AddOrder2", _connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter number = new SqlParameter("@ConsigmentNumber", SqlDbType.BigInt);
            number.Value = consNumber;
            number.Direction = ParameterDirection.Input;
            command.Parameters.Add(number);

            SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.BigInt);
            productID.Value = prodID;
            productID.Direction = ParameterDirection.Input;
            command.Parameters.Add(productID);

            SqlParameter amount = new SqlParameter("@Amount", SqlDbType.Float);
            amount.Value = prodAmount;
            amount.Direction = ParameterDirection.Input;
            command.Parameters.Add(amount);

            SqlParameter operationResult = new SqlParameter();
            operationResult.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(operationResult);

            command.ExecuteNonQuery();

            return int.Parse(operationResult.Value.ToString());
        }

        public IEnumerable<string> GetProductNames()
        {
            string commandStr = "SELECT Name FROM Products";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetString(0);
                }
            }
        }

        public IEnumerable<long> GetConsignmentNumbers()
        {
            string commandStr = "SELECT Number FROM Consignments";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetInt64(0);
                }
            }

        }

        public int GetProductID(string name)
        {
            string commandStr = string.Format("SELECT ID FROM Products WHERE Name = '{0}'", name);

            SqlCommand command = new SqlCommand(commandStr, _connection);

            int result = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {

                if (reader.Read())
                {
                    result = Convert.ToInt32(reader.GetInt64(0));
                }

            }

            return result;
        }

        public int DeleteOrder(int consNumber, int prodID)
        {
            SqlCommand command = new SqlCommand("RemoveOrder", _connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter consignmentNumber = new SqlParameter("@Number", SqlDbType.BigInt);
            consignmentNumber.Value = consNumber;
            consignmentNumber.Direction = ParameterDirection.Input;
            command.Parameters.Add(consignmentNumber);

            SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.BigInt);
            productID.Value = prodID;
            productID.Direction = ParameterDirection.Input;
            command.Parameters.Add(productID);

            SqlParameter operationResult = new SqlParameter();
            operationResult.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(operationResult);

            command.ExecuteNonQuery();

            return int.Parse(operationResult.Value.ToString());
        }

        public int UpdateOrder(int consNum, int prodID, double amount, int prodtIDNew)
        {

            SqlCommand command = new SqlCommand("UpdateOrder", _connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter number = new SqlParameter("@Number", SqlDbType.BigInt);
            number.Value = consNum;
            number.Direction = ParameterDirection.Input;
            command.Parameters.Add(number);

            SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.BigInt);
            productID.Value = prodID;
            productID.Direction = ParameterDirection.Input;
            command.Parameters.Add(productID);

            SqlParameter productIDUpdated = new SqlParameter("@ProductIDUpdated", SqlDbType.BigInt);
            productIDUpdated.Value = prodID;
            productIDUpdated.Direction = ParameterDirection.Input;
            command.Parameters.Add(productIDUpdated);

            SqlParameter productAmount = new SqlParameter("@Amount", SqlDbType.Float);
            productAmount.Value = amount;
            productAmount.Direction = ParameterDirection.Input;
            command.Parameters.Add(productAmount);

            SqlParameter operationResult = new SqlParameter();
            operationResult.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(operationResult);

            command.ExecuteNonQuery();

            return int.Parse(operationResult.Value.ToString());
        }


        public IEnumerable<Product> GetProducts()
        {
            string commandStr = "SELECT P.Name, U.UnitType " +
                                    "FROM Products P LEFT JOIN Units U ON P.UnitID = U.ID";

            SqlExecutor<Product> productExecutor = new SqlExecutor<Product>(_connection);

            return productExecutor.GetRowsFromBD(commandStr);
        }

      
        #endregion

    }
}
