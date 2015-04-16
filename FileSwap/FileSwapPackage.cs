using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using Microsoft.Web.Administration;

namespace lot224.FileSwap {

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidFileSwapPkgString)]
    [ProvideOptionPage(typeof(Options), "EO Options", "File Swap", 0, 0, true)]
    public sealed class FileSwapPackage : Package {
        internal Options options;
        public FileSwapPackage() { }

        protected override void Initialize() {
            base.Initialize();

            options = (Options)GetDialogPage(typeof(Options));

            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs) {
                CommandID menuCommandID = new CommandID(GuidList.guidFileSwapCmdSet, (int)PkgCmdIDList.cmdidFileSwapDropDown);
                OleMenuCommand menuItem = new OleMenuCommand(new EventHandler(OnFileSwapDropDown), menuCommandID);
                mcs.AddCommand(menuItem);

                CommandID menuCommandListID = new CommandID(GuidList.guidFileSwapCmdSet, (int)PkgCmdIDList.cmdidFileSwapDropDownList);
                OleMenuCommand menuItemList = new OleMenuCommand(new EventHandler(OnFileSwapDropDownList), menuCommandListID);
                mcs.AddCommand(menuItemList);
            }
        }

        // Event Fires when loading the dropdown with content.
        private void OnFileSwapDropDownList(object sender, EventArgs e) {
            if ((e == null) || (e == EventArgs.Empty))
                return;

            OleMenuCmdEventArgs eventArgs = e as OleMenuCmdEventArgs;

            if (eventArgs != null) {
                object vIn = eventArgs.InValue;
                IntPtr vOut = eventArgs.OutValue;
                if (vIn == null && vOut != IntPtr.Zero) {
                    Marshal.GetNativeVariantForObject(DropDownOptions(), vOut);
                }
            }
        }

        // Event Fires when the dropdown is clicked.
        private void OnFileSwapDropDown(object sender, EventArgs e) {
            OleMenuCmdEventArgs eventArgs = e as OleMenuCmdEventArgs;

            if (eventArgs != null) {

                string vIn = eventArgs.InValue as string;
                IntPtr vOut = eventArgs.OutValue;

                if (vIn != null || vOut != IntPtr.Zero) {
                    if (vOut != IntPtr.Zero) {
                        Marshal.GetNativeVariantForObject(options.Current, vOut);
                    } else if (vIn != null) {
                        string[] items = DropDownOptions();
                        int index = -1;
                        for (var i = 0; i < items.Length; i++) {
                            if (string.Compare(items[i], vIn, StringComparison.CurrentCultureIgnoreCase) == 0) {
                                index = i;
                                break;
                            }
                        }
                        if (index > -1) {
                            if (index == items.Length - 1) {
                                showOptions();
                            } else if(vIn != options.Current) {
                                options.SwapFile(vIn);
                                log(string.Format("Updated {0} to {1}", options.MasterFile, vIn));
                                if (options.RecycleAppPools) {
                                    ServerManager serverManager = new ServerManager();
                                    ApplicationPoolCollection appPools = serverManager.ApplicationPools;
                                    foreach (ApplicationPool ap in appPools) {
                                        if (ap.WorkerProcesses.Count > 0) {
                                            ap.Recycle();
                                            log(string.Format("Recycled ({0}) App Pool.", ap.Name));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string[] DropDownOptions() {
            List<string> nResult = new List<string>();

            Dictionary<string, string> items = options.jsonToDictionary(options.Files);
            foreach (string key in items.Keys) {
                nResult.Add(key);
            }
            nResult.Add("<options>");
            return nResult.ToArray();
        }

        private void showOptions() {
            string target = "40A2E3AD-28DC-43BF-BA78-058BA6EF29DB";
            var command = new CommandID(VSConstants.GUID_VSStandardCommandSet97, VSConstants.cmdidToolsOptions);
            var mcs = GetService(typeof(IMenuCommandService)) as MenuCommandService;
            mcs.GlobalInvoke(command, target);
        }

        internal IVsOutputWindowPane pane = null;
        private void log(string msg) {
            if (this.pane == null) {
                IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
                Guid guidGeneral = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
                int hr = outputWindow.CreatePane(guidGeneral, "General", 1, 0);
                hr = outputWindow.GetPane(guidGeneral, out this.pane);
            }

            //pane.Activate();
            pane.OutputString(msg + Environment.NewLine);
        }

    }
}
