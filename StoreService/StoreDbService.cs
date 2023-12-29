using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;
using DataAccessLevel;

namespace StoreService
{
    public class StoreDbService : IDisposable, IStoreService
    {
        private SqlConnection _connection;
        private bool _alreadyDisposed;

        private const string DB_NAME = "Store";

        public StoreDbService(string servername, string login, string password)
        {
            InitializeConnection(servername, login, password);
        }

        public StoreDbService()
        {
            _connection = null;
        }

        private void InitializeConnection(string servername, string login, string password)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = servername;
            sqlConnectionStringBuilder.InitialCatalog = DB_NAME;
            sqlConnectionStringBuilder.UserID = login;
            sqlConnectionStringBuilder.Password = password;                 //useruser
            string strConnection = sqlConnectionStringBuilder.ToString();

            _connection = new SqlConnection(strConnection);
        }

        private void CheckConnectionState()
        {
            if (_alreadyDisposed)      
            {
                throw new ObjectDisposedException(nameof(StoreDbService));
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
                throw new ObjectDisposedException(nameof(StoreDbService));
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
                throw new ObjectDisposedException(nameof(StoreDbService));
            }

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            if (_alreadyDisposed || _connection == null)
            {
                return;
            }

            _connection.Dispose();

            _alreadyDisposed = true;

            GC.SuppressFinalize(this);
        }

        ~StoreDbService()
        {
            if (_alreadyDisposed || _connection == null)
            {
                return;
            }

            Dispose();
        }


        #region === SQL Queries ===

        public IEnumerable<Order> GetOrders()
        {
            CheckConnectionState();

            string commandStr = "SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount AS TotalPrice " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID";

            SqlExecutor<Order,OrderIO> orderExecutor = new SqlExecutor<Order, OrderIO>(_connection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Order> GetConsignmentsOrders(int consigmentNumber)
        {
            CheckConnectionState();

            string commandStr = string.Format("SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount AS TotalPrice " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID " +
                "WHERE O.ConsignmentNumber = {0}", consigmentNumber);

            SqlExecutor<Order, OrderIO> orderExecutor = new SqlExecutor<Order, OrderIO>(_connection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Consignment> GetConsignments()
        {
            CheckConnectionState();

            string commandStr = "SELECT C.Number, C.ConsignmentDate, I1.Name + ' ' + I1.Surname AS Supplier, "
                                      + "I2.Name + ' ' + I2.Surname AS Recipient FROM Consignments C "
                                      + "LEFT JOIN Individuals I1 ON C.SupplierID = I1.IPN "
                                      + "LEFT JOIN Individuals I2 ON C.RecipientID = I2.IPN";

            SqlExecutor<Consignment, ConsignmentIO> consingmentExecutor 
                                                = new SqlExecutor<Consignment, ConsignmentIO>(_connection);

            return consingmentExecutor.GetRowsFromBD(commandStr);
        }

        public int ProcedureExecute(bool _isUsingIPN, string commandText, Consignment cons)
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
                supplierIPN.Value = cons.SupplierIpn;
                supplierIPN.Direction = ParameterDirection.Input;

                SqlParameter recipientIPN = new SqlParameter("@RecipientID", SqlDbType.BigInt);
                recipientIPN.Value = cons.RecipientIpn;
                recipientIPN.Direction = ParameterDirection.Input;

                command.Parameters.Add(supplierIPN);
                command.Parameters.Add(recipientIPN);
            }
            else
            {
                string[] supplierNameParts = cons.SupplierName.Split(' ');
                string[] recipientNameParts = cons.RecipientName.Split(' ');

                SqlParameter supplierName = new SqlParameter("@SupplierName", SqlDbType.NVarChar);
                supplierName.Value = supplierNameParts[0];
                supplierName.Direction = ParameterDirection.Input;

                SqlParameter supplierSurname = new SqlParameter("@SupplierSurname", SqlDbType.NVarChar);
                supplierSurname.Value = supplierNameParts[1];
                supplierSurname.Direction = ParameterDirection.Input;

                SqlParameter recipientName = new SqlParameter("@RecipientName", SqlDbType.NVarChar);
                recipientName.Value = recipientNameParts[0];
                recipientName.Direction = ParameterDirection.Input;

                SqlParameter recipientSurname = new SqlParameter("@RecipientSurname", SqlDbType.NVarChar);
                recipientSurname.Value = recipientNameParts[1];
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
            CheckConnectionState();

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

        public int AddOrder(int consNumber, long prodID, double prodAmount)
        {
            CheckConnectionState();

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
            CheckConnectionState();

            string commandStr = "SELECT Name FROM Products";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader["Name"].ToString();
                }
            }
        }

        public IEnumerable<long> GetConsignmentNumbers()
        {
            CheckConnectionState();

            string commandStr = "SELECT Number FROM Consignments";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Convert.ToInt64(reader["Number"]);
                }
            }
        }

        public IEnumerable<long> GetIndividualIDs()
        {
            CheckConnectionState();

            string commandStr = "SELECT IPN FROM Individuals";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Convert.ToInt64(reader["IPN"]);
                }
            }
        }

        public IEnumerable<string> GetIndividualNames()
        {
            CheckConnectionState();

            string commandStr = "SELECT Name + ' ' + Surname AS FullName FROM Individuals";

            SqlCommand command = new SqlCommand(commandStr, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader["FullName"].ToString();
                }
            }
        }

        public long GetProductID(string name)
        {
            CheckConnectionState();

            string commandStr = string.Format("SELECT ID FROM Products WHERE Name = '{0}'", name);

            SqlCommand command = new SqlCommand(commandStr, _connection);

            long result = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = Convert.ToInt64(reader["ID"]);
                }
            }

            return result;
        }

        public string GetNameByIPN(int ipn)
        {
            CheckConnectionState();

            string commandStr = string.Format("SELECT Name + ' ' + Surname AS FullName " +
                                               "FROM Individuals WHERE IPN = {0}", ipn);

            SqlCommand command = new SqlCommand(commandStr, _connection);

            string result = "";

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = reader["FullName"].ToString();
                }
            }

            return result;
        }

        public long GetIPNByName(string name)
        {
            CheckConnectionState();

            string[] nameParts = name.Split(' ');

            string commandStr = string.Format("SELECT IPN FROM Individuals " +
                                                "WHERE Name = '{0}' AND Surname = '{1}'", nameParts[0], nameParts[1]);

            SqlCommand command = new SqlCommand(commandStr, _connection);

            long result = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = Convert.ToInt64(reader["IPN"]);
                }
            }

            return result;
        }

        public int DeleteOrder(int consNumber, long prodID)
        {
            CheckConnectionState();

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

        public int UpdateOrder(int consNum, long prodID, double amount, long prodtIDNew)
        {
            CheckConnectionState();

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
            productIDUpdated.Value = prodtIDNew;
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
            CheckConnectionState();

            string commandStr = "SELECT P.Name, U.UnitType " +
                                    "FROM Products P LEFT JOIN Units U ON P.UnitID = U.ID";

            SqlExecutor<Product, ProductIO> productExecutor = new SqlExecutor<Product, ProductIO>(_connection);

            return productExecutor.GetRowsFromBD(commandStr);
        }

      
        #endregion

    }
}
