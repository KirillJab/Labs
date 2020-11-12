using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace WInES
{
    public partial class Form1 : Form
    {
        StringBuilder curDir = new StringBuilder(@"D:\");
        List<string> history = new List<string>();
        List<string> historyNext = new List<string>();
        List<FileObj> fileList = new List<FileObj>();
        List<string> filesToCopy = new List<string>();
        List<string> directoriesToCopy = new List<string>();

        public Form1()
        {
            InitializeComponent();
            prevButton.Enabled = false;
            nextButton.Enabled = false;
            GoToDirectory(curDir.ToString());
            contextMenuStrip.Items[1].Enabled = false;
        }
        public Form1(string path)
        {
            InitializeComponent();
            prevButton.Enabled = false;
            nextButton.Enabled = false;
            curDir = new StringBuilder (path);
            GoToDirectory(curDir.ToString());
            contextMenuStrip.Items[1].Enabled = false;
        }
        private void GoToDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                fileList.Clear();
                string[] directories = Directory.GetDirectories(dir);
                string[] files = Directory.GetFiles(dir);

                if (directories.Length != 0)
                {
                    foreach (string directory in directories)
                    {
                        fileList.Add(new FileObj(Path.GetFileName(directory), true));
                    }
                }
                if (files.Length != 0)
                {
                    foreach (string file in files)
                    {
                        fileList.Add(new FileObj(Path.GetFileName(file), false));
                    }
                }
                curDir = new StringBuilder(dir);
                UpdateListView();
            }
            else
            {
                try
                {
                    GoToDirectory(curDir.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error" + e.Message);
                }
            }
        }
        private void UpdateListView()
        {
            int i = 0;

            directoryView.Items.Clear();
            foreach (var file in fileList)
            {
                if (file.IsFolder)
                {
                    directoryView.Items.Add(file.Name);
                    directoryView.Items[i].BackColor = Color.Bisque;
                }
                else
                {
                    directoryView.Items.Add(file.Name);
                    if (Path.GetExtension(Path.Combine(curDir.ToString() + file.Name)) == ".zip")
                    {
                        directoryView.Items[i].BackColor = Color.LightCyan;
                    }
                    else
                    {
                        directoryView.Items[i].BackColor = Color.White;
                    }
                }
                i++;
            }
            directoryInput.Text = curDir.ToString();
            textPreviewBox.Text = "";
        }
        private void DirView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (directoryView.SelectedIndices.Count == 1)
            {
                var file = fileList[directoryView.SelectedIndices[0]];
                var path = Path.Combine(curDir.ToString(), file.Name);
                if (file.IsFolder)
                {
                    history.Add(curDir.ToString());
                    GoToDirectory(path);
                    prevButton.Enabled = true;
                }
                else
                {
                    textPreviewBox.Text = "";
                    var editor = new TextEditorForm(path);
                    editor.Show();
                }
            }
        }
        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (history.Count != 0)
            {
                historyNext.Add(curDir.ToString());
                while (!Directory.Exists(history.Last()))
                {
                    history.RemoveAt(history.Count - 1);
                }
                GoToDirectory(history.Last());
                history.RemoveAt(history.Count - 1);
                if (history.Count == 0)
                {
                    prevButton.Enabled = false;
                }
                nextButton.Enabled = true;
            }
            else
            {
                prevButton.Enabled = false;
            }
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (historyNext.Count != 0)
            {
                history.Add(curDir.ToString());
                while (!Directory.Exists(historyNext.Last()))
                {
                    historyNext.RemoveAt(historyNext.Count - 1);
                    if (historyNext.Count == 0)
                    {
                        break;
                    }
                }
                GoToDirectory(historyNext.Last() ?? curDir.ToString());
                historyNext.RemoveAt(historyNext.Count - 1);
                if (historyNext.Count == 0)
                {
                    nextButton.Enabled = false;
                }
                prevButton.Enabled = true;
            }
            else
            {
                nextButton.Enabled = false;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button.ToString())
            {
                case "XButton1":
                    {
                        PrevButton_Click(sender, e);
                        break;
                    }
                case "XButton2":
                    {
                        NextButton_Click(sender, e);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var prevDir = curDir.ToString();
            if (e.KeyCode == Keys.Enter && curDir.ToString() != directoryInput.Text)
            {
                GoToDirectory(directoryInput.Text);
                if (curDir.ToString() != prevDir)
                {
                    history.Add(prevDir);
                    prevButton.Enabled = true;
                }
            }
        }
        private void DirView_MouseClick(object sender, MouseEventArgs e)
        {
            if (directoryView.SelectedIndices.Count == 1)
            {
                var curFile = fileList[directoryView.SelectedIndices[0]];
                if (!curFile.IsFolder && Path.GetExtension(curFile.Name) == ".txt")
                {
                    var path = Path.Combine(curDir.ToString(), curFile.Name);
                    textPreviewBox.Text = File.ReadAllText(path);
                }
                else
                {
                    textPreviewBox.Text = "";
                }
            }
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesToCopy.Clear();
            directoriesToCopy.Clear();
            var collection = directoryView.SelectedIndices;
            for (int i = 0; i < collection.Count; i++)
            {
                if (!fileList[collection[i]].IsFolder)
                {
                    filesToCopy.Add(Path.Combine(curDir.ToString(), fileList[collection[i]].Name));
                }
                else
                {
                    directoriesToCopy.Add(Path.Combine(curDir.ToString(), fileList[collection[i]].Name));
                }
            }
            contextMenuStrip.Items[1].Enabled = true;
        }
        private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string file in filesToCopy)
                {
                    var newPath = Path.Combine(curDir.ToString(), Path.GetFileName(file));
                    CreateUniqueFile(ref newPath);
                    File.Copy(file, Path.Combine(curDir.ToString(), Path.GetFileName(file)), true);
                }
                //foreach (var directory in directoriesToCopy)
                //{
                //    var newPath = Path.Combine(curDir.ToString(), Path.GetFileName(directory));
                //    CreateUniqueDirectory(ref newPath);
                //    CopyDirectory(directory, newPath);
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Can't paste this file here");
            }
            RefreshButton_Click(sender, e);
        }
        private void CopyDirectory(string root, string dest)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                string newDirPath = Path.Combine(dest, Path.GetFileName(directory));
                if (!Directory.Exists(newDirPath))
                {
                    Directory.CreateDirectory(newDirPath);
                }
                CopyDirectory(directory, newDirPath);
            }

            foreach (var file in Directory.GetFiles(root))
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
            }
        }
        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var collection = directoryView.SelectedIndices;
            for (int i = 0; i < collection.Count; i++)
            {
                if (!fileList[collection[i]].IsFolder)
                {
                    File.Delete(Path.Combine(curDir.ToString(), fileList[collection[i]].Name));
                }
                else
                {
                    Directory.Delete(Path.Combine(curDir.ToString(), fileList[collection[i]].Name), true);
                }
            }
            RefreshButton_Click(sender, e);
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (historyNext.Count != 0)
            {
                while (!Directory.Exists(historyNext.Last()))
                {
                    historyNext.RemoveAt(historyNext.Count - 1);
                    if (historyNext.Count == 0)
                    {
                        nextButton.Enabled = false;
                        break;
                    }
                }
            }
            GoToDirectory(curDir.ToString());
        }
        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form rename = new RenameForm(Path.Combine(curDir.ToString(), fileList[directoryView.SelectedIndices[0]].Name));
            rename.Show();
        }
        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip.Items[3].Enabled = directoryView.SelectedItems.Count == 1 ? true : false;
            contextMenuStrip.Items[5].Enabled = (directoryView.SelectedItems.Count == 1 && Path.GetExtension(Path.Combine(curDir.ToString(), directoryView.SelectedItems[0].Text)) == ".zip") ? true : false;
        }
        private void FileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form newFile = new NewFileForm(curDir.ToString(), false);
            newFile.Show();
        }
        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFile = new NewFileForm(curDir.ToString(), true);
            newFile.Show();
        }
        private string CreateUniqueZip(ref string path)
        {
            var newPath = new StringBuilder(path + ".zip");
            if (!File.Exists(path + ".zip"))
            {
                ZipFile.CreateFromDirectory(path, newPath.ToString());
            }
            else
            {
                for (int i = 1; i > 0; i++)
                {
                    newPath = new StringBuilder(path + " (" + i + ").zip");
                    if (!File.Exists(newPath.ToString()))
                    {
                        ZipFile.CreateFromDirectory(path, newPath.ToString());
                        break;
                    }
                }
            }
            path = newPath.ToString();
            return newPath.ToString();
        }
        private string CreateUniqueDirectory(ref string path)
        {
            var newPath = new StringBuilder(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                for (int i = 1; i > 0; i++)
                {
                    newPath = new StringBuilder (path + " (" + i + ")");
                    if (!Directory.Exists(newPath.ToString()))
                    {
                        Directory.CreateDirectory(newPath.ToString());
                        path = newPath.ToString();
                        break;
                    }
                }
            }
            path = newPath.ToString();
            return newPath.ToString();
        }
        private string CreateUniqueFile(ref string path)
        {
            var newPath = new StringBuilder(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                for (int i = 1; i > 0; i++)
                {
                    newPath = new StringBuilder(path + " (" + i + ")");
                    if (!File.Exists(newPath.ToString()))
                    {
                        File.Create(newPath.ToString());
                        path = newPath.ToString();
                        break;
                    }
                }
            }
            path = newPath.ToString();
            return newPath.ToString();
        }
        private void ZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var archivePath = Path.Combine(curDir.ToString(), "archive");
            var collection = directoryView.SelectedIndices;
                
            CreateUniqueDirectory(ref archivePath);
            for (int i = 0; i < collection.Count; i++)
            {
                var file = fileList[collection[i]];
                file.Path = Path.Combine(curDir.ToString(), file.Name);
                if (file.IsFolder)
                {
                    var newPath = Path.Combine(archivePath, file.Name);
                    CreateUniqueDirectory(ref newPath);
                    CopyDirectory(file.Path, newPath);
                }
                else
                {
                    File.Copy(file.Path, Path.Combine(archivePath, file.Name), true);
                }
            }
            string folderPath = archivePath;
            CreateUniqueZip(ref archivePath);
            Directory.Delete(folderPath, true);

            var newNameForm = new RenameForm(archivePath);
            newNameForm.Show();

            RefreshButton_Click(sender, e);
        }

        private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var archievePath = Path.Combine(curDir.ToString(), directoryView.SelectedItems[0].Text);
            var newPath = Path.Combine(curDir.ToString(), Path.GetFileNameWithoutExtension(archievePath));
            CreateUniqueDirectory(ref newPath);
            ZipFile.ExtractToDirectory(archievePath, newPath);
            RefreshButton_Click(sender, e);
        }
        private void directoryView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteToolStripMenuItem1_Click(sender, e);
            }
        }
    }
}