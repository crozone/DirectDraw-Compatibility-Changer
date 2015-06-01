using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DirectDraw_Colourfix {
    public class RegEdit {
        public const string RegDDPath = (@"SOFTWARE\Microsoft\DirectDraw\");
        public const string RegDDPathWow = (@"SOFTWARE\Wow6432Node\Microsoft\DirectDraw\");

        public bool UseWowNode { get; set; }

        public RegEdit(bool useWowNode) {
            UseWowNode = useWowNode;
        }

        public string[] GetCurrentApps() {
            RegistryKey Reg = Registry.LocalMachine;
            if (UseWowNode) {
                Reg = Reg.OpenSubKey(RegDDPathWow + @"Compatibility\"); // path to 64 bit DirectDraw compatibility 
            }
            else {
                Reg = Reg.OpenSubKey(RegDDPath + @"Compatibility\"); // path to 32 bit DirectDraw compatibility
            }

            return Reg.GetSubKeyNames();
        }

        public bool SaveKey(string KeyName, string exeName, byte[] exeID, byte[] exeFlags) {
            try {
                RegistryKey Reg = Registry.LocalMachine;
                if (UseWowNode) {
                    Reg = Reg.CreateSubKey(RegDDPathWow + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                else {
                    Reg = Reg.CreateSubKey(RegDDPath + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                Reg.SetValue("Name", exeName, RegistryValueKind.String);
                Reg.SetValue("ID", exeID, RegistryValueKind.Binary);
                Reg.SetValue("Flags", exeFlags, RegistryValueKind.Binary);
            }
            catch (UnauthorizedAccessException) {
                return false;
            }
            catch (SecurityException) {
                return false;
            }
            return true;
        }

        public bool DeleteKey(string KeyName) {
            try {
                RegistryKey Reg = Registry.LocalMachine;
                if (UseWowNode) {
                    Reg = Reg.OpenSubKey(RegDDPathWow + @"Compatibility\", true);
                }
                else {
                    Reg = Reg.OpenSubKey(RegDDPath + @"Compatibility\", true);
                }
                Reg.DeleteSubKey(KeyName, false);
            }
            catch (UnauthorizedAccessException) {
                return false;
            }
            catch (SecurityException) {
                return false;
            }
            return true;
        }

        public CompatibilityInformation GetCompatibilityInformationFromKey(string keyname) {
            CompatibilityInformation compatInfo = new CompatibilityInformation();

            compatInfo.KeyName = keyname;
            RegistryKey Reg = Registry.LocalMachine;
            if (this.UseWowNode) {
                Reg = Reg.OpenSubKey(RegDDPathWow + @"Compatibility\" + keyname);
            }
            else {
                Reg = Reg.OpenSubKey(RegDDPath + @"Compatibility\" + keyname);
            }

            compatInfo.Name = (string)Reg.GetValue("Name");

            if (Reg.GetValueKind("ID") == RegistryValueKind.Binary) {
                byte[] IDBytes = (byte[])Reg.GetValue("ID");
                compatInfo.ID = Utilities.ByteArrayToHex(IDBytes);
            }
            else if (Reg.GetValueKind("ID") == RegistryValueKind.DWord) {
                byte[] IDBytes = BitConverter.GetBytes((int)Reg.GetValue("ID"));
                compatInfo.ID = Utilities.ByteArrayToHex(IDBytes);
            }

            byte[] FlagBytes = (byte[])Reg.GetValue("Flags");
            compatInfo.Flags = Utilities.ByteArrayToHex(FlagBytes);

            return compatInfo;
        }

        public CompatibilityInformation GetCompatibilityInformationForLastPlayed() {
            string LastName;
            string LastID;
            // pull the most recent application from the registry
            RegistryKey Reg = Registry.LocalMachine;
            if (this.UseWowNode) {
                Reg = Reg.OpenSubKey(RegDDPathWow + @"MostRecentApplication\");
            }
            else {
                Reg = Reg.OpenSubKey(RegDDPath + @"MostRecentApplication\");
            }
            LastName = (string)Reg.GetValue("Name");
            byte[] LastIDBytes = BitConverter.GetBytes((int)Reg.GetValue("ID"));
            LastID = Utilities.ByteArrayToHex(LastIDBytes);

            CompatibilityInformation compatInfo = new CompatibilityInformation() {
                KeyName = LastName.Substring(0, LastName.LastIndexOf(".exe", StringComparison.OrdinalIgnoreCase)),
                Name = LastName,
                ID = LastID,
                Flags = ""
            };

            return compatInfo;
        }

        public static int CheckRegKeyVersion() {
            RegistryKey Reg = Registry.LocalMachine;
            Reg = Reg.OpenSubKey(RegDDPath + @"Compatibility\");
            if (Reg == null) {
                return 0; // check the os actually has the compatibility key (Vista and 7 only), 0 is it doesn't
            }
            else { // now we know its vista/7, check if it's got the Wow32Node (x64)
                Reg = Registry.LocalMachine;
                Reg = Reg.OpenSubKey(RegDDPathWow + @"Compatibility\");
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
