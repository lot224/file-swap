using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace lot224.FileSwap {
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("40A2E3AD-28DC-43BF-BA78-058BA6EF29DB")]
    public class Options : DialogPage {

        private string masterFile = null;
        public string MasterFile {
            get { return masterFile; }
            set { masterFile = value; }
        }

        public Dictionary<string, string> files = new Dictionary<string, string>();
        public Dictionary<string, string> Files {
            get { return files; }
            set { files = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window {
            get {
                OptionsControl page = new OptionsControl();
                page.options = this;
                page.Initialize();
                return page;
            }
        }
    }
}
