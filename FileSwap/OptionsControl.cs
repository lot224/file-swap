using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lot224.FileSwap {
    public partial class OptionsControl : UserControl {
        public OptionsControl() {
            InitializeComponent();
        }

        internal Options options;

        public void Initialize() {
            txtMaster.Text = options.MasterFile;
            chkRecycleAppPools.Checked = options.RecycleAppPools;
            ListItems();
        }

        private Dictionary<string, string> items = null;
        public Dictionary<string, string> Items {
            get {
                if (items == null)
                    items = options.jsonToDictionary(options.Files);
                return items;
            }
        }

        private void bntSave_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CreatePrompt = true;
            sfd.DefaultExt = ".config";
            sfd.FileName = txtMaster.Text;
            sfd.Filter = "Config files *.config|*.config";
            sfd.OverwritePrompt = false;

            if (sfd.ShowDialog() == DialogResult.OK) {
                options.MasterFile = txtMaster.Text = sfd.FileName;
                if (System.IO.File.Exists(sfd.FileName) == false) {
                    FileStream fs = File.Create(sfd.FileName);
                    fs.Close();
                    //fs.Dispose();
                }
            }
        }

        private void txtMaster_Leave(object sender, EventArgs e) {
            FileInfo fi = new FileInfo(txtMaster.Text);
            options.MasterFile = fi.FullName;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream()) {
                bf.Serialize(ms, fi.FullName);
                //options.Berger = Convert.ToBase64String(ms.ToArray());
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e) {
            bntAdd.Enabled = txtName.Text.Length > 0 && txtFile.Text.Length > 0;
        }

        private void txtFile_TextChanged(object sender, EventArgs e) {
            bntAdd.Enabled = txtName.Text.Length > 0 && txtFile.Text.Length > 0;
        }

        private void bntFind_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = txtFile.Text;
            ofd.Filter = "Config files *.config|*.config";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
                txtFile.Text = ofd.FileName;

        }

        private void bntAdd_Click(object sender, EventArgs e) {

            foreach (string key in Items.Keys) {
                if (key.ToLower() == txtName.Text.Trim().ToLower()) {
                    MessageBox.Show(string.Format("Can not add item, the name ({0}) already exists in the collection.", txtName.Text.Trim()), "Error adding item.");
                    return;
                }
            }

            FileInfo fi = new FileInfo(txtFile.Text.Trim());
            if (!fi.Exists) {
                MessageBox.Show(string.Format("The file ({0}) does not exist.", txtFile.Text.Trim()), "Error adding item.");
                return;
            }


            Items.Add(txtName.Text.Trim(), fi.FullName);
            txtName.Text = txtFile.Text = string.Empty;
            bntAdd.Enabled = false;
            ListItems();
        }

        private void ListItems() {
            lstView.Items.Clear();
            foreach (string key in Items.Keys) {
                if (File.Exists(Items[key]) == true) {
                    ListViewItem lvi = new ListViewItem(key);
                    lvi.SubItems.Add(Items[key]);
                    lstView.Items.Add(lvi);
                }
            }
        }

        private void lstView_SelectedIndexChanged(object sender, EventArgs e) {
            bntDelete.Enabled = lstView.SelectedItems.Count > 0;
        }

        private void bntDelete_Click(object sender, EventArgs e) {
            string name = lstView.SelectedItems[0].Text;
            Items.Remove(name);
            bntDelete.Enabled = false;
            ListItems();
        }

        private void chkRecycleAppPools_CheckedChanged(object sender, EventArgs e) {
            options.RecycleAppPools = chkRecycleAppPools.Checked;
        }
    }
}
