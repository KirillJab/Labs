using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlGenerator
{
    public class XmlGenerator
    {
        string fileName;
        DataAccessLayer.Options.SendingOptions sendingOptions;
        public XmlGenerator(DataAccessLayer.Options.SendingOptions options)
        {
            sendingOptions = options;
            Directory.CreateDirectory(sendingOptions.TargetDirectory);
            fileName = "list.xml";

        }
        public XmlGenerator(DataAccessLayer.Options.SendingOptions options, string fileName)
        {
            sendingOptions = options;
            Directory.CreateDirectory(sendingOptions.TargetDirectory);
            this.fileName = fileName;
        }
        public void CreateXML(List<PersonInfo> list)
        {
            XmlSerializer xml = new XmlSerializer(list.GetType());
            using (FileStream fs = new FileStream(Path.Combine(sendingOptions.TargetDirectory, fileName), FileMode.Create))
            {
                xml.Serialize(fs, list);
            }
        }
    }
}
