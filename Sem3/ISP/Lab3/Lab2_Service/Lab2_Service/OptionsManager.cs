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
        EtlJsonOptions etlJsonOptions;
        EtlXmlOptions etlXmlOptions;
        EtlOptions DefaultOptions = new EtlOptions();
        public string log = "";
        public bool JsonExists;
        public bool isJsonValid;
        public bool XmlExists;
        public bool isXmlValid;
        public OptionsManager(string path)
        {
            string input;
            string jsonPath = $"{path}\\appsettings.json";
            string xmlPath = $"{path}\\config.xml";
            if (File.Exists(jsonPath))
            {
                JsonExists = true;
                log += "\tappsettings.json found ";
                try
                {
                    input = File.ReadAllText(jsonPath);
                    etlJsonOptions = new EtlJsonOptions(input);
                    isJsonValid = true;
                    log += "and valid.";
                }
                catch
                {
                    log += "but isn't valid.";
                    isJsonValid = false;
                }
            }
            else
            {
                log += "\tappsettings.json not found";
                isJsonValid = false;
                JsonExists = false;
            }
            if (File.Exists(xmlPath))
            {
                log += "\n\t\t\tconfig.xml found ";
                XmlExists = true;
                try
                {
                    input = File.ReadAllText(xmlPath);
                    etlXmlOptions = new EtlXmlOptions(input);
                    isXmlValid = true;
                    log += "and valid.";
                }
                catch
                {
                    log += "but isn't valid.";
                    isXmlValid = false;
                }
            }
            else
            {
                log += "\n\t\t\tconfig.xml not found";
                isXmlValid = false;
                XmlExists = false;
            }
            if (isJsonValid)
            {
                log += "\n\t\t\tLoading appsettings.json";
            }
            else
            {
                if (isXmlValid)
                {
                    log += "\n\t\t\tLoading config.xml";
                }
                else
                {
                    log += "\n\t\t\tBoth configs are invalid. Loading Default config";
                }
            }
        }

        public Options GetOptions<T>()
        {
            if (isJsonValid)
            {
                return FindOption<T>(etlJsonOptions);
            }
            else
            {
                if (isXmlValid)
                {
                    return FindOption<T>(etlXmlOptions);
                }
                else
                {
                    return FindOption<T>(DefaultOptions);
                }
            }
        }
        Options FindOption<T>(EtlOptions options)
        {
            if (typeof(T) == typeof(EtlOptions))
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