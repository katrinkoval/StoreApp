using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    class SqlExecutor<T> where T: ISqlObject, new()
    {
        private readonly SqlConnection _connection;

        public SqlExecutor(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> GetRowsFromBD(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())   
                {
                    T value = new T();
                    value.ReadFromRecord(reader);

                    yield return value;
                }

            }

        }
    }
}
