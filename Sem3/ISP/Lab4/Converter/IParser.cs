using System.Collections.Generic;

namespace Converter
{
    public interface IParser
    {
        T DeserializeJSON<T>(string json) where T : new();
        T DeserializeXML<T>(string xml) where T : new();
        T Map<T>(Dictionary<string, object> dictionary);
    }
}