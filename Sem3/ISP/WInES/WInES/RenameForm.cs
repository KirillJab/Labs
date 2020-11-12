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
    public partial class RenameForm : Form
    {
        private string path { get; }
        public string FilePath => path;
        public RenameForm(string root)
        {
            InitializeComponent();
            path = root;
            textBox1.Text = Path.GetFileName(path);
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
            newPath = Path.Combine(Path.GetDirectoryName(path), newPath);

            if (path != newPath && File.Exists(newPath))
            {
                MessageBox.Show("The Name is already taken!");
                return;
            }
            try
            {
                File.Move(path, newPath);
            }
            catch (Exception)
            {
                Directory.Move(path, newPath);
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
