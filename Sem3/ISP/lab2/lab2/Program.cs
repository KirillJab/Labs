using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        string sourceDirectory = @"C:\Users\Kirill\Desktop\SourceDirectory";
        string targetDirectory = @"C:\Users\Kirill\Desktop\TargetDirectory";
        static void Main(string[] args)
        {
            FileSystemWatcher sourceWatcher = new FileSystemWatcher(@"C:\Users\Kirill\Desktop\SourceDirectory");

            sourceWatcher.Filter = "*.txt";
            sourceWatcher.EnableRaisingEvents = true;
            sourceWatcher.IncludeSubdirectories = true;

            sourceWatcher.Created += SourceWatcher_Created;

            try
            {
                File.Copy(@"C:\Users\Kirill\Desktop\SourceDirectory\Test.txt", @"C:\Users\Kirill\Desktop\SourceDirectory\File.txt");
            }
            catch
            {
                File.Delete(@"C:\Users\Kirill\Desktop\SourceDirectory\File.txt");
                File.Copy(@"C:\Users\Kirill\Desktop\SourceDirectory\Test.txt", @"C:\Users\Kirill\Desktop\SourceDirectory\File.txt");
            }

            Console.ReadLine();
        }

        private static void SourceWatcher_Created(object sender, FileSystemEventArgs e)
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

            newFilePath = Path.ChangeExtension(newFilePath, "txt");
            text = Encryption.Decrypt(File.ReadAllText(newFilePath), key);
            File.WriteAllText(newFilePath, text);
        }

        private static void CreateUniquePath(ref string path)
        {
            string buff = path;
            for(int i = 1; File.Exists(path); i++)
            {
                buff = path + $"({i})";
            }
            path = buff;
        }

        private static void AwaitForTheFileToClose(string path)
        {
            while(true)
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
