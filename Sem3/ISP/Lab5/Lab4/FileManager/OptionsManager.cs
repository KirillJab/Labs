using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class OptionsManager<T> where T : new()
    {
        T JsonOptions;
        T XmlOptions;
        T DefaultOptions = new T();
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
                    JsonOptions = Converter.DeserializeJSON<T>(input);
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
                    XmlOptions = Converter.DeserializeXML<T>(input);
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

        public object GetOptions<T>()
        {
            if (isJsonValid)
            {
                return FindOption<T>(JsonOptions);
            }
            else
            {
                if (isXmlValid)
                {
                    return FindOption<T>(XmlOptions);
                }
                else
                {
                    return FindOption<T>(DefaultOptions);
                }
            }
        }
        object FindOption<T>(object options)
        {
            if (typeof(T) == DefaultOptions.GetType())
            {
                return options;
            }
            string name = typeof(T).Name;
            try
            {
                return options.GetType().GetProperty(name).GetValue(options, null);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}