/* Direct Draw Compatibility Changer
   Written by Ryan Crosby, 2010ish or sometime back then.

   Updated 2015-06-02:
       Did general cleanup and refactoring, made GUI scalable.
*/


using System;
using System.Windows.Forms;

namespace DirectDrawCompatibilityChanger
{
    public partial class MainForm : Form {
        public RegEdit Regedit { get; set; }

        public MainForm() {
            bool useWowNode = false;
            int regVersion = 0;

            // check the registry version to make sure this program will actually be of any use
            regVersion = RegEdit.CheckRegKeyVersion();

            if (regVersion == 0) {
                MessageBox.Show("Your OS is not compatible with DirectDraw Compatibility options. \r\n"
                    + "please make sure you are running this on Vista/7, otherwise you do not need it!");
                this.Close();
            }
            // if 32 bit os, non wow node will be 32 bit. In 64 bit os, the non wow node is 64 bit.
            else if (regVersion == 2) {
                useWowNode = true;
            }
            else {
                useWowNode = false;
            }

            this.Regedit = new RegEdit(useWowNode);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // update the games list
            UpdateGameList();
        }

        private void UpdateGameList() {
            // clear the list for fresh update
            lstCurrentFixes.Items.Clear();

            // get all the current game names out of the registry node
            foreach (string thisGameName in Regedit.GetCurrentApps()) {
                GameListItem game = new GameListItem() {
                    Name = thisGameName,
                    // get the compatibility information for this game
                    CompatibilityInformation = Regedit.GetCompatibilityInformationFromKey(thisGameName)
                };

                // add the game to the games list
                lstCurrentFixes.Items.Add(game);
            }
        }

        private void lstCurrentFixes_SelectedIndexChanged(object sender, EventArgs e) {
            // get the currently selected game item
            GameListItem gameListItem = (GameListItem)lstCurrentFixes.SelectedItem;

            // update the GUI
            if (gameListItem != null) {
                UpdateCompatibilityValues(gameListItem.CompatibilityInformation);
            }
        }

        private void btnLoadLastPlayed_Click(object sender, EventArgs e) {
            // get info about the last played game
            CompatibilityInformation compatInfo = Regedit.GetCompatibilityInformationForLastPlayed();

            // update the GUI
            UpdateCompatibilityValues(compatInfo);
        }

        private void UpdateCompatibilityValues(CompatibilityInformation compatInfo) {
            if (compatInfo != null) {
                txtKeyName.Text = compatInfo.KeyName;
                txtName.Text = compatInfo.Name;
                txtID.Text = compatInfo.ID;
                txtFlags.Text = compatInfo.Flags;
            }
        }

        private void btnSaveValues_Click(object sender, EventArgs e) {
            byte[] idBytes = Convert.FromHexString(txtID.Text);
            byte[] flagBytes = Convert.FromHexString(txtFlags.Text);

            // Save the values to the registry
            bool success = Regedit.SaveKey(txtKeyName.Text, txtName.Text, idBytes, flagBytes);

            // handle error
            if(!success) {
                MessageBox.Show("Could not add or save key. Please check you have sufficient privileges.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            // Update list to show changes
            UpdateGameList();
        }

        private void txtFlags_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            if ("ABCDEFabcdef0123456789\b".IndexOf(e.KeyChar) == -1) // only allow hex values
            {
                e.Handled = true;
            }
        }

        private void txtID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            if ("ABCDEFabcdef0123456789\b".IndexOf(e.KeyChar) == -1) // only allow hex values
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            // get the currently selected game
            string keyName = ((GameListItem)lstCurrentFixes.SelectedItem)?.Name;
            if (keyName != null) {
                // check with the user that they *really* want to do this
                DialogResult result = MessageBox.Show(
                    string.Format("Are you sure you want to delete game key {0}?", keyName),
                    "Confirm delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // confirm for delete
                if (result == DialogResult.Yes) {
                    // delete the key
                    if (!Regedit.DeleteKey(keyName)) {
                        MessageBox.Show("Could not delete key. Please check you have sufficient privileges.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    }
                }
            }

            // update games list to show changes
            UpdateGameList();
        }

        // clear all the input fields
        private void btnClearAll_Click(object sender, EventArgs e) {
            txtKeyName.Clear();
            txtName.Clear();
            txtID.Clear();
            txtFlags.Clear();
        }
    }
}
