using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public class StoreDB
    {
        public readonly SqlConnection _сonnection;
        private const string dataBaseName = "Store";

        public StoreDB(string servername, string login, string password)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = servername;
            sqlConnectionStringBuilder.InitialCatalog = dataBaseName;
            //sqlConnectionStringBuilder.IntegratedSecurity = true;
            sqlConnectionStringBuilder.UserID = login;
            sqlConnectionStringBuilder.Password = password;
            string strConnection = sqlConnectionStringBuilder.ToString();
            _сonnection = new SqlConnection(strConnection);
        }

        public StoreDB()
        {
            _сonnection = null;
        }

        public void openConnection()
        {
            if (_сonnection.State == System.Data.ConnectionState.Closed)
            {
                _сonnection.Open();
            }
        }

        public void closeConnection()
        {
            if (_сonnection.State == System.Data.ConnectionState.Open)
            {
                _сonnection.Close();
            }
        }   

        public IEnumerable<Order> GetOrders()
        {
            string commandStr = "SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID";

            SqlExecutor<Order> orderExecutor = new SqlExecutor<Order>(_сonnection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Order> GetConsignmentsOrders(int consigmentNumber)
        {
            string commandStr = string.Format("SELECT O.ConsignmentNumber, P.Name, P.Price, O.Amount" +
                ", U.UnitType, P.Price * O.Amount " +
                "FROM Orders O LEFT JOIN Products P ON O.ProductID = P.ID " +
                "LEFT JOIN Units U ON U.ID = P.UnitID " +
                "WHERE O.ConsignmentNumber = {0}", consigmentNumber);

            SqlExecutor<Order> orderExecutor = new SqlExecutor<Order>(_сonnection);

            return orderExecutor.GetRowsFromBD(commandStr);
        }

        public IEnumerable<Consignment> GetConsignments()
        {
            string commandStr = "SELECT C.Number, C.ConsignmentDate, I1.Name + ' ' + I1.Surname, "
                                      + "I2.Name + ' ' + I2.Surname FROM Consignments C "
                                      + "LEFT JOIN Individuals I1 ON C.SupplierID = I1.IPN "
                                      + "LEFT JOIN Individuals I2 ON C.RecipientID = I2.IPN";

            SqlExecutor<Consignment> consingmentExecutor = new SqlExecutor<Consignment>(_сonnection);

            return consingmentExecutor.GetRowsFromBD(commandStr);
        }

        public int ProcedureExecute(bool _isUsingIPN, string commandText, Consignment cons
                            , string supplierLastName = "", string recipientLastName = ""
                            ,    int supplierID = 0, int recipientID = 0)
        {
            SqlCommand command = new SqlCommand(commandText, _сonnection);
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
            SqlCommand command = new SqlCommand("RemoveConsignment", _сonnection);
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
            SqlCommand command = new SqlCommand("AddOrder2", _сonnection);
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

            SqlCommand command = new SqlCommand(commandStr, _сonnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())  
            {
                yield return reader.GetString(0);
            }

            reader.Close();

        }

        public IEnumerable<long> GetConsignmentNumbers()
        {
            string commandStr = "SELECT Number FROM Consignments";

            SqlCommand command = new SqlCommand(commandStr, _сonnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return reader.GetInt64(0);
            }

            reader.Close();

        }

        public long GetProductID(string name)
        {
            string commandStr = string.Format("SELECT ID FROM Products WHERE Name = '{0}'", name);

            SqlCommand command = new SqlCommand(commandStr, _сonnection);

            SqlDataReader reader = command.ExecuteReader();

            long result = 0;

            if (reader.Read())
            {
                result = reader.GetInt64(0);
            }

            reader.Close();

            return result;
        }

        public int DeleteOrder(int consNumber, int prodID)
        {
            SqlCommand command = new SqlCommand("RemoveOrder", _сonnection);
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

    }
}
