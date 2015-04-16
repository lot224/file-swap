using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.Web.Administration;
using Newtonsoft.Json;

namespace lot224.FileSwap {
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("40A2E3AD-28DC-43BF-BA78-058BA6EF29DB")]
    public class Options : DialogPage {

        private OptionsControl page;

        private string masterFile = null;
        public string MasterFile {
            get { return masterFile; }
            set { masterFile = value; }
        }

        private string files = string.Empty;
        public string Files {
            get { return files; }
            set { files = value; }
        }

        private string current = string.Empty;
        public string Current {
            get { return current; }
            set { current = value; }
        }

        private bool recycleAppPools = false;
        public bool RecycleAppPools {
            get { return recycleAppPools; }
            set { recycleAppPools = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, string> jsonToDictionary(string json) {
            Dictionary<string, string> nResult;
            nResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            if (nResult == null)
                return new Dictionary<string, string>();
            return nResult;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string dictionaryToJson(Dictionary<string, string> dictionary) {
            return JsonConvert.SerializeObject(dictionary);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window {
            get {
                page = new OptionsControl();
                page.options = this;
                page.Initialize();
                return page;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void SwapFile(string file) {
            Dictionary<string, string> items = jsonToDictionary(Files);
            FileInfo fi = new FileInfo(items[file]);
            if (fi.Exists && Current != file) {
                Current = file;
                SaveSettingsToStorage();
                string data = File.ReadAllText(fi.FullName);
                File.WriteAllText(MasterFile, data);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnApply(PageApplyEventArgs e) {
            files = dictionaryToJson(page.Items);
            base.OnApply(e);
        }
    }
}
