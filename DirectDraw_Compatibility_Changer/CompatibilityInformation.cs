using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DirectDraw_Colourfix {
    public class CompatibilityInformation {
        public string KeyName;
        public string Name;
        public string ID;
        public string Flags;

        public CompatibilityInformation(string Keyname, bool fromWowNode) {
            this.KeyName = Keyname;
            RegistryKey Reg = Registry.LocalMachine;
            if (fromWowNode) {
                Reg = Reg.OpenSubKey(MainForm.RegDDPathWow + @"Compatibility\" + KeyName);
            }
            else {
                Reg = Reg.OpenSubKey(MainForm.RegDDPath + @"Compatibility\" + KeyName);
            }

            Name = (string)Reg.GetValue("Name");

            if (Reg.GetValueKind("ID") == RegistryValueKind.Binary) {
                byte[] IDBytes = (byte[])Reg.GetValue("ID");
                ID = Utilities.ByteArrayToHex(IDBytes);
            }
            else if (Reg.GetValueKind("ID") == RegistryValueKind.DWord) {
                byte[] IDBytes = BitConverter.GetBytes((int)Reg.GetValue("ID"));
                ID = Utilities.ByteArrayToHex(IDBytes);
            }

            byte[] FlagBytes = (byte[])Reg.GetValue("Flags");
            Flags = Utilities.ByteArrayToHex(FlagBytes);
        }

        
    }
}
