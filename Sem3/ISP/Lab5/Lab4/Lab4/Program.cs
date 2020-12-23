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
        static async Task Main(string[] args) 
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
            XmlGenerator.XmlGenerator generator = new XmlGenerator.XmlGenerator(sendingOptions);

            logger.Log(optionsManager.log);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            logger.Log("Pulling of the data has been started...");
            Console.WriteLine("Pulling of the data has been started...");
            people = await sl.GetPersonInfoListAsync(5000);
            Console.WriteLine("Pulling of the data has been done successfully!");
            watch.Stop();
            Console.WriteLine($"Total execution time: {watch.ElapsedMilliseconds}");
            logger.Log("Pulling of the data has been done successfully!");
            generator.CreateXML(people);
            logger.Log("Xml file was created successfully");
            Console.ReadLine();
        }

    }
}
