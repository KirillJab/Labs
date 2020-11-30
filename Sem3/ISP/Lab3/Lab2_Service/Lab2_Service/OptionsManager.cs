using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class OptionsManager
    {
        EtlJsonOptions EtlJsonOptions;
        ETLOptions DefaultOptions = new ETLOptions();
        bool isJsonFoundAndValid;
        //bool isXMLValid;
        public OptionsManager(string path)
        {
            string jsonPath = Path.Combine(path, "appsettings.json");
            if (File.Exists(jsonPath))
            {
                try
                {
                    string input = File.ReadAllText(jsonPath);
                    EtlJsonOptions = new EtlJsonOptions(input);
                    isJsonFoundAndValid = true;
                }
                catch
                {
                    isJsonFoundAndValid = false;
                    throw;
                }
            }
            else
            {
                isJsonFoundAndValid = false;
            }
            if(!isJsonFoundAndValid)
            {

            }
        }
        public Options GetOptions<T>()
        {
            if (isJsonFoundAndValid)
            {
                return FindOption<T>(EtlJsonOptions);
            }
            else
            {
                return FindOption<T>(DefaultOptions);
            }
        }

        Options FindOption<T>(ETLOptions options)
        {
            if (typeof(T) == typeof(ETLOptions))
            {
                return options;
            }
            string name = typeof(T).Name;
            try
            {
                return options.GetType().GetProperty(name).GetValue(options, null) as Options;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
