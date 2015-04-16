namespace lot224.FileSwap {
    partial class OptionsControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsControl));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.bntFind = new System.Windows.Forms.Button();
            this.bntAdd = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.bntDelete = new System.Windows.Forms.Button();
            this.lstView = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblMaster = new System.Windows.Forms.Label();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bntSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "ellipsis.png");
            this.imgList.Images.SetKeyName(1, "delete.png");
            this.imgList.Images.SetKeyName(2, "minus.png");
            this.imgList.Images.SetKeyName(3, "plus.png");
            // 
            // bntFind
            // 
            this.bntFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntFind.ImageIndex = 0;
            this.bntFind.ImageList = this.imgList;
            this.bntFind.Location = new System.Drawing.Point(588, 38);
            this.bntFind.Name = "bntFind";
            this.bntFind.Size = new System.Drawing.Size(26, 22);
            this.bntFind.TabIndex = 30;
            this.toolTip.SetToolTip(this.bntFind, "The file to use when selected in the dropdown.");
            this.bntFind.UseVisualStyleBackColor = true;
            this.bntFind.Click += new System.EventHandler(this.bntFind_Click);
            // 
            // bntAdd
            // 
            this.bntAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntAdd.Enabled = false;
            this.bntAdd.ImageIndex = 3;
            this.bntAdd.ImageList = this.imgList;
            this.bntAdd.Location = new System.Drawing.Point(620, 38);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(26, 22);
            this.bntAdd.TabIndex = 29;
            this.toolTip.SetToolTip(this.bntAdd, "Add this to the collection.");
            this.bntAdd.UseVisualStyleBackColor = true;
            this.bntAdd.Click += new System.EventHandler(this.bntAdd_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(205, 43);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 13);
            this.lblFile.TabIndex = 28;
            this.lblFile.Text = "File:";
            this.toolTip.SetToolTip(this.lblFile, "The location of the file to copy the content into the master file when selected.");
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(237, 39);
            this.txtFile.MaxLength = 255;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(345, 20);
            this.txtFile.TabIndex = 27;
            this.toolTip.SetToolTip(this.txtFile, "The location of the file to copy the content into the master file when selected.");
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.lblName, "A friendly name to be displayed in the dropdown.");
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 39);
            this.txtName.MaxLength = 25;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(138, 20);
            this.txtName.TabIndex = 25;
            this.toolTip.SetToolTip(this.txtName, "A friendly name to be displayed in the dropdown.");
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // bntDelete
            // 
            this.bntDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntDelete.Enabled = false;
            this.bntDelete.Location = new System.Drawing.Point(571, 420);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(75, 23);
            this.bntDelete.TabIndex = 24;
            this.bntDelete.Text = "Delete";
            this.toolTip.SetToolTip(this.bntDelete, "Delete the selected item from the collection.");
            this.bntDelete.UseVisualStyleBackColor = true;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chFile});
            this.lstView.FullRowSelect = true;
            this.lstView.Location = new System.Drawing.Point(61, 66);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(585, 348);
            this.lstView.TabIndex = 23;
            this.toolTip.SetToolTip(this.lstView, "A listing of all files and there respective paths to be displayed in the dropdown" +
        ".");
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 106;
            // 
            // chFile
            // 
            this.chFile.Text = "File";
            this.chFile.Width = 467;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(24, 70);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(31, 13);
            this.lblFiles.TabIndex = 22;
            this.lblFiles.Text = "Files:";
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaster
            // 
            this.lblMaster.AutoSize = true;
            this.lblMaster.Location = new System.Drawing.Point(13, 17);
            this.lblMaster.Margin = new System.Windows.Forms.Padding(3);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(42, 13);
            this.lblMaster.TabIndex = 31;
            this.lblMaster.Text = "Master:";
            this.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.lblMaster, "This is the name of the file that will contain the contents of the selected file." +
        "");
            // 
            // txtMaster
            // 
            this.txtMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaster.Location = new System.Drawing.Point(61, 13);
            this.txtMaster.MaxLength = 255;
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(553, 20);
            this.txtMaster.TabIndex = 32;
            this.toolTip.SetToolTip(this.txtMaster, "This is the name of the file that will contain the contents of the selected file." +
        "");
            this.txtMaster.Leave += new System.EventHandler(this.txtMaster_Leave);
            // 
            // bntSave
            // 
            this.bntSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntSave.ImageIndex = 0;
            this.bntSave.ImageList = this.imgList;
            this.bntSave.Location = new System.Drawing.Point(620, 12);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(26, 22);
            this.bntSave.TabIndex = 33;
            this.toolTip.SetToolTip(this.bntSave, "Select/Create a file to be used as the master file.");
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.txtMaster);
            this.Controls.Add(this.lblMaster);
            this.Controls.Add(this.bntFind);
            this.Controls.Add(this.bntAdd);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.bntDelete);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.lblFiles);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "OptionsControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(659, 456);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button bntFind;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblMaster;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button bntSave;
    }
}
