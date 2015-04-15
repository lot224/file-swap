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

namespace lot224.FileSwap
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidFileSwapPkgString)]
    [ProvideOptionPage(typeof(Options), "EO Options", "File Swap", 0, 0, true)]
    public sealed class FileSwapPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public FileSwapPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize() {
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs ) {
                CommandID menuCommandID = new CommandID(GuidList.guidFileSwapCmdSet, (int)PkgCmdIDList.cmdidFileSwapDropDown);
                OleMenuCommand menuItem = new OleMenuCommand(new EventHandler(OnFileSwapDropDown), menuCommandID);
                mcs.AddCommand( menuItem );

                CommandID menuCommandListID = new CommandID(GuidList.guidFileSwapCmdSet, (int)PkgCmdIDList.cmdidFileSwapDropDownList);
                OleMenuCommand menuItemList = new OleMenuCommand( new EventHandler(OnFileSwapDropDownList), menuCommandListID);
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
                if (vIn == null && vOut != IntPtr.Zero){
                    log("Updating Options List");
                    Marshal.GetNativeVariantForObject(DropDownOptions(), vOut);
                }
            }
        }

        // Event Fires when the dropdown is clicked.
        private void OnFileSwapDropDown(object sender, EventArgs e) {
            //throw new NotImplementedException();
            log("OnFileSwapDropDown: Event Fired.");

            OleMenuCmdEventArgs eventArgs = e as OleMenuCmdEventArgs;

            if (eventArgs != null) {

                string vIn = eventArgs.InValue as string;
                IntPtr vOut = eventArgs.OutValue;

                if (vIn != null || vOut != IntPtr.Zero) {
                    if (vOut != IntPtr.Zero) {
                        log("Updating Selected Item");
                        Marshal.GetNativeVariantForObject(selectedOption(), vOut);
                    } else if (vIn != null) {
                        string[] options = DropDownOptions();
                        int index = -1;
                        for (var i = 0; i < options.Length; i++) {
                            log(" -> Index: " + i.ToString());
                            if (string.Compare(options[i], vIn, StringComparison.CurrentCultureIgnoreCase) == 0) {
                                log(" -> Found Index");
                                index = i;
                                break;
                            }
                        }
                        if (index > -1) {
                            if (index == options.Length-1) {
                                log(" -> Show Options");
                                showOptions();
                            } else {
                                log(string.Format("Item Selected - Index:{0}, Value:{1}", index, vIn));
                            }
                        }

                    }

                }
            }
        }
        #endregion


        private string[] DropDownOptions() {
            return new string[] { "1", "2", "3", "<options>" };
        }

        private string selectedOption() {
            return "BERGER";
        }

        private void showOptions() {
            string target = "40A2E3AD-28DC-43BF-BA78-058BA6EF29DB";
            var command = new CommandID(VSConstants.GUID_VSStandardCommandSet97, VSConstants.cmdidToolsOptions);
            var mcs = GetService(typeof(IMenuCommandService)) as MenuCommandService;
            mcs.GlobalInvoke(command, target);
        }

        private void showMessage(string title, string msg) {
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0, ref clsid, title, msg, string.Empty, 0, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, 0, out result));
        }


        internal IVsOutputWindowPane pane = null;
        private void log(string msg) {
            if (this.pane == null) {
                IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
                Guid guidGeneral = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
                //IVsOutputWindowPane pane;
                int hr = outputWindow.CreatePane(guidGeneral, "General", 1, 0);
                hr = outputWindow.GetPane(guidGeneral, out this.pane);
            }
           
            pane.Activate();
            pane.OutputString(msg + Environment.NewLine);
        } 

    }
}
