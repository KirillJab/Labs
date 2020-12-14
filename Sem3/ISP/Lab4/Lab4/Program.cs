using Converter;
using XmlGenerator;
using DataAccessLayer.Models;
using DataAccessLayer.Options;
using Logger;
using OptionsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    class Program
    {
        static void Main(string[] args)
        {

            IParser parser = new Converter.Converter();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            OptionsManager<DataAccessOptions> optionsManager = new OptionsManager<DataAccessOptions>(path, parser);
            LoggingOptions loggingOptions = new LoggingOptions();
            loggingOptions.ConnectionOptions = optionsManager.GetOptions<ConnectionOptions>() as ConnectionOptions;
            SendingOptions sendingOptions = optionsManager.GetOptions<SendingOptions>() as SendingOptions;
            ConnectionOptions connectionOptions = optionsManager.GetOptions<ConnectionOptions>() as ConnectionOptions;
            ILogger logger = new Logger.Logger(loggingOptions, parser);
            ServiceLayer.ServiceLayer sl = new ServiceLayer.ServiceLayer(connectionOptions, parser);
            List<PersonInfo> people;


            logger.Log(optionsManager.log);
            logger.Log("Pulling of the data has been started...");
            people = sl.GetPersonInfoList(200);
            logger.Log("Pulling of the data has been done successfully!");
            logger.Log("Xml file was created successfully");
            XmlGenerator.XmlGenerator generator = new XmlGenerator.XmlGenerator(sendingOptions);
            generator.CreateXML(people);
            logger.Log("Xml file was created successfully");
        }

    }
}
