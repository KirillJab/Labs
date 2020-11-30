using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace Lab3
{
    public partial class Lab3_ETL_Service : ServiceBase
    {
        FileSystemWatcher sourceWatcher;
        ETLOptions etlOptions;
        Logger logger;
        public Lab3_ETL_Service()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            ConfigurateETL();
            logger.Log("Service has been started");
        }
        void ConfigurateETL()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            OptionsManager optionsManager = new OptionsManager(Path.Combine(path);
            etlOptions = optionsManager.GetOptions<ETLOptions>() as ETLOptions;


            Directory.CreateDirectory(etlOptions.DirectoryOptions.SourceDirectory); 
            Directory.CreateDirectory(etlOptions.DirectoryOptions.TargetDirectory);
            sourceWatcher = new FileSystemWatcher(etlOptions.DirectoryOptions.SourceDirectory);
            sourceWatcher.Filter = "*.txt";
            sourceWatcher.EnableRaisingEvents = true;
            sourceWatcher.IncludeSubdirectories = true;
            sourceWatcher.Created += SourceWatcher_Created;
            sourceWatcher.EnableRaisingEvents = true;

            logger = new Logger(etlOptions.LoggingOptions);
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            logger.Log(path);
            loggerThread.Start();

            string str = Newtonsoft.Json.JsonConvert.SerializeObject(etlOptions, Newtonsoft.Json.Formatting.Indented);
            logger.Log(str);
        }
        protected override void OnStop()
        {
            sourceWatcher.EnableRaisingEvents = false;
            logger.Log("Service has been stopped");
            logger.Stop();
            Thread.Sleep(1000);
        }
        private void SourceWatcher_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo file = new FileInfo(e.FullPath);
            string text;
            byte[] key = Encryption.GenerateKey(16);
            string clientDirectory = etlOptions.DirectoryOptions.TargetDirectory;                                              //$@"C:\Lab2_Yablonsky\TargetDirectory\ClientDirectory\{file.LastWriteTime:yyyy\\MM\\dd}";  //C:\Users\Kirill\Desktop\TargetDirectory\ClientDirectory\{file.LastWriteTime:yyyy\\MM\\dd}";
            string archieveDirectory = etlOptions.DirectoryOptions.ArchiveDirectory;                                         //C:\Users\Kirill\Desktop\TargetDirectory\Archieve";
            string newFilePath = Path.Combine(clientDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");
            string newArchivePath = Path.Combine(archieveDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");
            CompressionLevel compressionLevel = etlOptions.ArchiveOptions.compressionLevel;

            CreateUniquePath(ref newFilePath);
            CreateUniquePath(ref newArchivePath);

            newFilePath += ".gz";
            newArchivePath += ".gz";

            AwaitForTheFileToClose(file.FullName);
            File.WriteAllText(file.FullName, Encryption.Encrypt(File.ReadAllText(file.FullName), key));
            Directory.CreateDirectory(clientDirectory);
            Directory.CreateDirectory(archieveDirectory);
            ArchiveGZip.GZip(file.FullName, newFilePath, compressionLevel);
            ArchiveGZip.GZip(file.FullName, newArchivePath, compressionLevel);
            ArchiveGZip.DeGZip(newFilePath, Path.ChangeExtension(newFilePath, "txt"));
            File.Delete(newFilePath);
            File.Delete(file.FullName);

            newFilePath = Path.ChangeExtension(newFilePath, "txt");
            text = Encryption.Decrypt(File.ReadAllText(newFilePath), key);
            File.WriteAllText(newFilePath, text);
        }
        private static void AwaitForTheFileToClose(string path)
        {
            while (true)
            {
                try
                {
                    using (FileStream stream = new FileStream(path, FileMode.Open))
                    {
                        return;
                    }
                }
                catch
                {

                }
            }

        }
        private static void CreateUniquePath(ref string path)
        {
            string buff = path;
            for (int i = 1; File.Exists(path); i++)
            {
                buff = path + $"({i})";
            }
            path = buff;
        }
    }
}