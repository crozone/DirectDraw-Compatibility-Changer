using System;
using System.Security;

using Microsoft.Win32;

namespace DirectDrawCompatibilityChanger
{
    public class RegEdit {
        public const string RegistryDirectDrawPath = (@"SOFTWARE\Microsoft\DirectDraw\");
        public const string RegistryDirectDrawPathWow = (@"SOFTWARE\Wow6432Node\Microsoft\DirectDraw\");

        public bool UseWowNode { get; set; }

        public RegEdit(bool useWowNode) {
            UseWowNode = useWowNode;
        }

        public string[] GetCurrentApps() {
            RegistryKey registryKey = Registry.LocalMachine;
            if (UseWowNode) {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPathWow + @"Compatibility\"); // path to 64 bit DirectDraw compatibility 
            }
            else {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPath + @"Compatibility\"); // path to 32 bit DirectDraw compatibility
            }

            return registryKey.GetSubKeyNames();
        }

        public bool SaveKey(string KeyName, string exeName, byte[] exeID, byte[] exeFlags) {
            try {
                RegistryKey registryKey = Registry.LocalMachine;
                if (UseWowNode) {
                    registryKey = registryKey.CreateSubKey(RegistryDirectDrawPathWow + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                else {
                    registryKey = registryKey.CreateSubKey(RegistryDirectDrawPath + @"Compatibility\" + KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                registryKey.SetValue("Name", exeName, RegistryValueKind.String);
                registryKey.SetValue("ID", exeID, RegistryValueKind.Binary);
                registryKey.SetValue("Flags", exeFlags, RegistryValueKind.Binary);
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
                RegistryKey registryKey = Registry.LocalMachine;
                if (UseWowNode) {
                    registryKey = registryKey.OpenSubKey(RegistryDirectDrawPathWow + @"Compatibility\", true);
                }
                else {
                    registryKey = registryKey.OpenSubKey(RegistryDirectDrawPath + @"Compatibility\", true);
                }
                registryKey.DeleteSubKey(KeyName, false);
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
            RegistryKey registryKey = Registry.LocalMachine;
            if (this.UseWowNode) {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPathWow + @"Compatibility\" + keyname);
            }
            else {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPath + @"Compatibility\" + keyname);
            }

            compatInfo.Name = (string)registryKey.GetValue("Name");

            if (registryKey.GetValueKind("ID") == RegistryValueKind.Binary) {
                byte[] idBytes = (byte[])registryKey.GetValue("ID");
                compatInfo.ID = Utilities.ByteArrayToHex(idBytes);
            }
            else if (registryKey.GetValueKind("ID") == RegistryValueKind.DWord) {
                byte[] idBytes = BitConverter.GetBytes((int)registryKey.GetValue("ID"));
                compatInfo.ID = Utilities.ByteArrayToHex(idBytes);
            }

            byte[] flagBytes = (byte[])registryKey.GetValue("Flags");
            compatInfo.Flags = Utilities.ByteArrayToHex(flagBytes);

            return compatInfo;
        }

        public CompatibilityInformation GetCompatibilityInformationForLastPlayed() {
            string lastName;
            string lastID;
            // pull the most recent application from the registry
            RegistryKey registryKey = Registry.LocalMachine;
            if (this.UseWowNode) {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPathWow + @"MostRecentApplication\");
            }
            else {
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPath + @"MostRecentApplication\");
            }
            lastName = (string)registryKey.GetValue("Name");
            byte[] LastIDBytes = BitConverter.GetBytes((int)registryKey.GetValue("ID"));
            lastID = Utilities.ByteArrayToHex(LastIDBytes);

            CompatibilityInformation compatInfo = new CompatibilityInformation() {
                KeyName = lastName.Substring(0, lastName.LastIndexOf(".exe", StringComparison.OrdinalIgnoreCase)),
                Name = lastName,
                ID = lastID,
                Flags = ""
            };

            return compatInfo;
        }

        public static int CheckRegKeyVersion() {
            RegistryKey registryKey = Registry.LocalMachine;
            registryKey = registryKey.OpenSubKey(RegistryDirectDrawPath + @"Compatibility\");
            if (registryKey == null) {
                return 0; // check the os actually has the compatibility key (Vista and 7 only), 0 is it doesn't
            }
            else { // now we know its vista/7, check if it's got the Wow32Node (x64)
                registryKey = Registry.LocalMachine;
                registryKey = registryKey.OpenSubKey(RegistryDirectDrawPathWow + @"Compatibility\");
                if (registryKey == null) {
                    return 1; // the OS is 32 bit, return 1
                }
                else {
                    return 2; // the OS has both paths
                }
            }
        }
    }
}
