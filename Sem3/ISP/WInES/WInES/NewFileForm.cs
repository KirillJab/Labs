using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInES
{
    public partial class NewFileForm : Form
    {
        string path { get; }
        bool isFolder { get; }
        public NewFileForm(string directory, bool isFolder)
        {
            InitializeComponent();
            path = directory;
            this.isFolder = isFolder;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var newPath = textBox1.Text;
            foreach (char ch in Path.GetInvalidFileNameChars())
            {
                if (newPath.Contains(ch))
                {
                    MessageBox.Show("Invalid Name!");
                    return;
                }
            }
            if (newPath == "")
            {
                MessageBox.Show("Invalid Name!");
                return;
            }
            newPath = Path.Combine(path, newPath);
            newPath += !isFolder ? ".txt" : "";

            if (File.Exists(newPath))
            {
                MessageBox.Show("The Name is already taken!");
                return;
            }
            if(!isFolder)
            {
                using (File.CreateText(newPath)) { };
            }
            else
            {
                Directory.CreateDirectory(newPath);
            }
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
