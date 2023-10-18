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
            List<T> values = new List<T>();

            SqlCommand command = new SqlCommand(query, _connection);

            //TODO: using reader

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())   //yeild return
            {
                T value = new T();
                value.ReadFromRecord(reader);

                yield return value;
            }

            reader.Close();

        }
    }
}
