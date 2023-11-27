using System.Data;
using Models;

namespace DataAccessLevel
{
    public struct ProductIO : ISqlObject<Product>
    {
        Product ISqlObject<Product>.ReadFromRecord(IDataRecord reader)
        {
            Product prod = new Product();

            prod.Name = reader["Name"].ToString();                                
            prod.UnitType = reader["UnitType"].ToString();                         

            return prod;
        }

    }
}
