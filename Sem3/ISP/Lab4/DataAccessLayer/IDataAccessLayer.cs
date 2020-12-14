using Converter;
using DataAccessLayer.Models;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public interface IDataAccessLayer
    {
        Person GetPerson(int id);
        T Map<T>(SqlDataReader reader, IParser parser) where T : new();
    }
}