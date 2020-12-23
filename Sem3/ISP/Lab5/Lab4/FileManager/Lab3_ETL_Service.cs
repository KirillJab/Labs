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
using OptionsManager;
using Converter;

namespace ETL
{
    public partial class ETL_Service : ServiceBase
    {
        FileSystemWatcher sourceWatcher;
        EtlOptions etlOptions;
        Logger logger;
        public ETL_Service()
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
            IParser parser = new Converter.Converter();
            OptionsManager<EtlOptions> optionsManager = new OptionsManager<EtlOptions>(path, parser);
            etlOptions = optionsManager.GetOptions<EtlOptions>() as EtlOptions;

            Directory.CreateDirectory(etlOptions.DirectoryOptions.SourceDirectory);
            Directory.CreateDirectory(etlOptions.DirectoryOptions.TargetDirectory);

            sourceWatcher = new FileSystemWatcher(etlOptions.DirectoryOptions.SourceDirectory);
            sourceWatcher.Filter = "*.txt";
            sourceWatcher.Filter = "*.xml";
            sourceWatcher.EnableRaisingEvents = true;
            sourceWatcher.IncludeSubdirectories = true;
            sourceWatcher.Created += SourceWatcher_Created;
            sourceWatcher.EnableRaisingEvents = true;

            logger = new Logger(etlOptions.LoggingOptions);
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
            logger.Log($"Domain directory: {path}");
            logger.Log(optionsManager.log);
            logger.Log($"Source Directory: {etlOptions.DirectoryOptions.SourceDirectory}");
            logger.Log($"Encryption Enabled: {etlOptions.EncryptionOptions.EncryptionEnabled}");
            logger.Log($"Compression Enabled: {etlOptions.ArchiveOptions.CompressionEnabled}");
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
            string clientDirectory = etlOptions.DirectoryOptions.TargetDirectory;
            string archieveDirectory = etlOptions.DirectoryOptions.ArchiveDirectory;
            string newFilePath = Path.Combine(clientDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");
            string newArchivePath = Path.Combine(archieveDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");
            bool compressionEnabled = etlOptions.ArchiveOptions.CompressionEnabled;

            CreateUniquePath(ref newFilePath);
            CreateUniquePath(ref newArchivePath);

            newFilePath += ".gz";
            newArchivePath += ".gz";

            AwaitForTheFileToClose(file.FullName);
            if (etlOptions.EncryptionOptions.EncryptionEnabled)
            {
                File.WriteAllText(file.FullName, Encryption.Encrypt(File.ReadAllText(file.FullName), key));
            }
            Directory.CreateDirectory(clientDirectory);
            Directory.CreateDirectory(archieveDirectory);
            ArchiveGZip.GZip(file.FullName, newFilePath, compressionEnabled);
            ArchiveGZip.GZip(file.FullName, newArchivePath, compressionEnabled);
            ArchiveGZip.DeGZip(newFilePath, Path.ChangeExtension(newFilePath, "txt"));
            File.Delete(newFilePath);
            File.Delete(file.FullName);

            newFilePath = Path.ChangeExtension(newFilePath, "txt");

            text = etlOptions.EncryptionOptions.EncryptionEnabled ? Encryption.Decrypt(File.ReadAllText(newFilePath), key) : File.ReadAllText(newFilePath);
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