namespace WInES
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.directoryView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unzipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryInput = new System.Windows.Forms.TextBox();
            this.textPreviewBox = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.createNewToolStripMenuItem.Text = "Create New";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click_1);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.FolderToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem1_Click);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(11, 28);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(63, 23);
            this.prevButton.TabIndex = 2;
            this.prevButton.Text = "<- Prev";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(84, 28);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(63, 23);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "Next ->";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // directoryView
            // 
            this.directoryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.directoryView.ContextMenuStrip = this.contextMenuStrip;
            this.directoryView.HideSelection = false;
            this.directoryView.Location = new System.Drawing.Point(11, 97);
            this.directoryView.Name = "directoryView";
            this.directoryView.Size = new System.Drawing.Size(409, 419);
            this.directoryView.TabIndex = 4;
            this.directoryView.UseCompatibleStateImageBehavior = false;
            this.directoryView.View = System.Windows.Forms.View.List;
            this.directoryView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directoryView_KeyDown);
            this.directoryView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DirView_MouseClick);
            this.directoryView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DirView_MouseDoubleClick);
            this.directoryView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 132;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.AllowDrop = true;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.archieveToolStripMenuItem,
            this.unzipToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 136);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // archieveToolStripMenuItem
            // 
            this.archieveToolStripMenuItem.Name = "archieveToolStripMenuItem";
            this.archieveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.archieveToolStripMenuItem.Text = "Zip";
            this.archieveToolStripMenuItem.Click += new System.EventHandler(this.ZipToolStripMenuItem_Click);
            // 
            // unzipToolStripMenuItem
            // 
            this.unzipToolStripMenuItem.Name = "unzipToolStripMenuItem";
            this.unzipToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.unzipToolStripMenuItem.Text = "UnZip";
            this.unzipToolStripMenuItem.Click += new System.EventHandler(this.UnzipToolStripMenuItem_Click);
            // 
            // directoryInput
            // 
            this.directoryInput.Location = new System.Drawing.Point(11, 64);
            this.directoryInput.Margin = new System.Windows.Forms.Padding(2);
            this.directoryInput.Name = "directoryInput";
            this.directoryInput.Size = new System.Drawing.Size(760, 20);
            this.directoryInput.TabIndex = 6;
            this.directoryInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // textPreviewBox
            // 
            this.textPreviewBox.Location = new System.Drawing.Point(512, 97);
            this.textPreviewBox.Multiline = true;
            this.textPreviewBox.Name = "textPreviewBox";
            this.textPreviewBox.ReadOnly = true;
            this.textPreviewBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textPreviewBox.Size = new System.Drawing.Size(289, 419);
            this.textPreviewBox.TabIndex = 7;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RefreshButton.Location = new System.Drawing.Point(776, 60);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(25, 27);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 536);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.textPreviewBox);
            this.Controls.Add(this.directoryInput);
            this.Controls.Add(this.directoryView);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "WinES";
            this.Activated += new System.EventHandler(this.RefreshButton_Click);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ListView directoryView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox directoryInput;
        private System.Windows.Forms.TextBox textPreviewBox;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ToolStripMenuItem archieveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unzipToolStripMenuItem;
    }
}

