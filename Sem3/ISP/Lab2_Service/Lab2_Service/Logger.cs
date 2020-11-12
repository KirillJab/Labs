using System.IO;
using System.Threading;

namespace Lab2_Service
{
    class Logger
    {
        /*
         FileSystemWatcher sourceWatcher = new FileSystemWatcher(@"C:\Users\Kirill\Desktop\SourceDirectory");

            sourceWatcher.Filter = "*.txt";
            sourceWatcher.EnableRaisingEvents = true;
            sourceWatcher.IncludeSubdirectories = true;

            sourceWatcher.Created += SourceWatcher_Created;
            sourceWatcher.Renamed += SourceWatcher_Renamed;
         */




        FileSystemWatcher sourceWatcher;
        bool enabled = true;
        public Logger()
        {
            sourceWatcher = new FileSystemWatcher(@"C:\Users\Kirill\Desktop\SourceDirectory");

            sourceWatcher.Filter = "*.txt";
            sourceWatcher.EnableRaisingEvents = true;
            sourceWatcher.IncludeSubdirectories = true;

            sourceWatcher.Created += SourceWatcher_Created;
        }

        public void Start()
        {
            sourceWatcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            sourceWatcher.EnableRaisingEvents = false;
            enabled = false;
        }       
        private void SourceWatcher_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo file = new FileInfo(e.FullPath);
            string text;
            var key = Encryption.GenerateKey(16);
            var clientDirectory = $@"C:\Users\Kirill\Desktop\TargetDirectory\ClientDirectory\{file.LastWriteTime:yyyy\\MM\\dd}";
            var archieveDirectory = @"C:\Users\Kirill\Desktop\TargetDirectory\Archieve";
            var newFilePath = Path.Combine(clientDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");
            var newArchivePath = Path.Combine(archieveDirectory, $"{Path.GetFileNameWithoutExtension(file.Name)}_{file.LastWriteTime:yyyy_MM_dd_hh_mm_ss}");

            CreateUniquePath(ref newFilePath);
            CreateUniquePath(ref newArchivePath);

            newFilePath += ".gz";
            newArchivePath += ".gz";

            AwaitForTheFileToClose(file.FullName);
            File.WriteAllText(file.FullName, Encryption.Encrypt(File.ReadAllText(file.FullName), key));
            Directory.CreateDirectory(clientDirectory);
            Directory.CreateDirectory(archieveDirectory);
            ArchiveGZip.GZip(file.FullName, newFilePath);
            ArchiveGZip.GZip(file.FullName, newArchivePath);
            ArchiveGZip.DeGZip(newFilePath, Path.ChangeExtension(newFilePath, "txt"));
            File.Delete(newFilePath);
            File.Delete(file.FullName);

            newFilePath = Path.ChangeExtension(newFilePath, "txt");
            text = Encryption.Decrypt(File.ReadAllText(newFilePath), key);
            File.WriteAllText(newFilePath, text);
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
    }
}