using System.Collections.Generic;
using System.Data.SqlClient;


namespace DataAccessLevel
{
    class SqlExecutor<TEntity, TEntityIO> where TEntityIO: ISqlObject<TEntity>, new()
    {
        private readonly SqlConnection _connection;

        public SqlExecutor(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TEntity> GetRowsFromBD(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                TEntityIO entityIO = new TEntityIO();

                while (reader.Read())   
                {
                    TEntity item = entityIO.ReadFromRecord(reader);

                    yield return item;
                }
            }

        }
    }
}
