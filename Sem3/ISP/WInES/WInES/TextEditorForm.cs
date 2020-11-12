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
    public partial class TextEditorForm : Form
    {
        private string path { get; }
        public TextEditorForm(string filePath)
        {
            InitializeComponent();
            path = filePath;
            textBox.Text = File.ReadAllText(path);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(path, textBox.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Can't Save The File");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(path);
            this.Close();
        }
    }
}