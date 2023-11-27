using System.Data;

namespace DataAccessLevel
{
    public interface ISqlObject<T>
    {
        T ReadFromRecord(IDataRecord reader);        
    }
}
