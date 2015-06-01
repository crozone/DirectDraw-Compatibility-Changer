using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DirectDraw_Colourfix {
    public class RegEdit {
        public bool UseWowNode { get; set; }

        public RegEdit(bool useWowNode) {
            UseWowNode = useWowNode;
        }

        public string[] GetCurrentApps() {

            RegistryKey Reg = Registry.LocalMachine;
            if (UseWowNode) {
                Reg = Reg.OpenSubKey(MainForm.RegDDPathWow + @"Compatibility\"); // path to 64 bit DirectDraw compatibility 
            }
            else {
                Reg = Reg.OpenSubKey(MainForm.RegDDPath + @"Compatibility\"); // path to 32 bit DirectDraw compatibility
            }

            return Reg.GetSubKeyNames();

        }
        public void SaveKey(string KeyName, string exeName, byte[] exeID, byte[] exeFlags) {
            RegistryKey Reg = Registry.LocalMachine;
            if (UseWowNode) {
                Reg = Reg.CreateSubKey(MainForm.RegDDPathWow + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            else {
                Reg = Reg.CreateSubKey(MainForm.RegDDPath + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            Reg.SetValue("Name", exeName, RegistryValueKind.String);
            Reg.SetValue("ID", exeID, RegistryValueKind.Binary);
            Reg.SetValue("Flags", exeFlags, RegistryValueKind.Binary);
        }
        public void DeleteKey(string KeyName) {
            RegistryKey Reg = Registry.LocalMachine;
            if (UseWowNode) {
                Reg = Reg.OpenSubKey(MainForm.RegDDPathWow + @"Compatibility\", true);
            }
            else {
                Reg = Reg.OpenSubKey(MainForm.RegDDPath + @"Compatibility\", true);
            }
            Reg.DeleteSubKey(KeyName, false);

        }
        public static int CheckRegKeyVersion() {
            RegistryKey Reg = Registry.LocalMachine;
            Reg = Reg.OpenSubKey(MainForm.RegDDPath + @"Compatibility\");
            if (Reg == null) {
                return 0; // check the os actually has the compatibility key (Vista and 7 only), 0 is it doesn't
            }
            else { // now we know its vista/7, check if it's got the Wow32Node (x64)
                Reg = Registry.LocalMachine;
                Reg = Reg.OpenSubKey(MainForm.RegDDPathWow + @"Compatibility\");
                if (Reg == null) {
                    return 1; // the OS is 32 bit, return 1
                }
                else {
                    return 2; // the OS has both paths
                }
            }
        }
    }
}
