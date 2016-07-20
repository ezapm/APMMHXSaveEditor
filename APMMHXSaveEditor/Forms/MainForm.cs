using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using APMMHXSaveEditor.Data;
using APMMHXSaveEditor.Util;
using APMMHXSaveEditor.Forms;

namespace APMMHXSaveEditor
{
    public partial class MainForm : Form
    {
        private SaveFile saveFile { get; set; }
        private DataExtractor dataExtractor { get; set; }
        private string filePath { get; set; }
        private int currentPlayer { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = Constants.EDITOR_VERSION;
            switchProfileToolStripMenuItem.Enabled = false;
            saveSlot1ToolStripMenuItem.Enabled = false;
            saveSlot2ToolStripMenuItem.Enabled = false;
            saveSlot3ToolStripMenuItem.Enabled = false;

            //Limits
            textBoxPlayerName.MaxLength = 16;
            numericUpDownAcademyPoints.Maximum = int.MaxValue;
            numericUpDownBerunaPoints.Maximum = int.MaxValue;
            numericUpDownHrLevel.Maximum = int.MaxValue;
            numericUpDownHrPoints.Maximum = int.MaxValue;
            numericUpDownHunterArt1.Maximum = UInt16.MaxValue;
            numericUpDownHunterArt2.Maximum = UInt16.MaxValue;
            numericUpDownHunterArt3.Maximum = UInt16.MaxValue;
            numericUpDownKokotoPoints.Maximum = int.MaxValue;
            numericUpDownPokkePoints.Maximum = int.MaxValue;
            numericUpDownYukumoPoints.Maximum = int.MaxValue;
            numericUpDownZenny.Maximum = int.MaxValue;
            numericUpDownPlayTime.Maximum = UInt32.MaxValue;
            numericUpDownClothing.Maximum = 255;
            numericUpDownEyeColor.Maximum = 255;
            numericUpDownFeatures.Maximum = 255;
            numericUpDownHair.Maximum = 255;
            numericUpDownHuntingStyle.Maximum = 255;
            numericUpDownVoice.Maximum = 255;

            textBoxSkinColorRGBA.MaxLength = 8;
            textBoxHairColorRGBA.MaxLength = 8;
            textBoxFeaturesColorRGBA.MaxLength = 8;
            textBoxClothingColorRGBA.MaxLength = 8;

            comboBoxEquipmentBox.SelectedIndex = 0;
            comboBoxGender.SelectedIndex = 0;
            comboBoxItemBox.SelectedIndex = 0;
            comboBoxPouch.SelectedIndex = 0;

            //allCraftableArmorToolStripMenuItem.Visible = false;
            buttonEditGuildCard.Visible = false;
        }

        private void clearForms()
        {
            this.Text = Constants.EDITOR_VERSION;
            textBoxPlayerName.Text = "";
            numericUpDownHrLevel.Value = 0;
            numericUpDownHrPoints.Value = 0;
            numericUpDownZenny.Value = 0;
            numericUpDownAcademyPoints.Value = 0;
            numericUpDownBerunaPoints.Value = 0;
            numericUpDownKokotoPoints.Value = 0;
            numericUpDownPokkePoints.Value = 0;
            numericUpDownYukumoPoints.Value = 0;

            //Player Tab
            comboBoxGender.SelectedIndex = 0;
            numericUpDownHair.Value = 0;
            numericUpDownFace.Value = 0;
            numericUpDownFeatures.Value = 0;
            numericUpDownVoice.Value = 0;
            numericUpDownEyeColor.Value = 0;
            numericUpDownClothing.Value = 0;
            numericUpDownHuntingStyle.Value = 0;
            numericUpDownHunterArt1.Value = 0;
            numericUpDownHunterArt2.Value = 0;
            numericUpDownHunterArt3.Value = 0;

            listViewEquipment.Items.Clear();
            listViewItemBox.Items.Clear();
            listViewItemPouch.Items.Clear();
            listViewPalicos.Items.Clear();

            saveSlot1ToolStripMenuItem.Checked = false;
            saveSlot2ToolStripMenuItem.Checked = false;
            saveSlot3ToolStripMenuItem.Checked = false;
            saveSlot1ToolStripMenuItem.Enabled = false;
            saveSlot1ToolStripMenuItem.Enabled = false;
            saveSlot1ToolStripMenuItem.Enabled = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "All files (*.*)|*.*";
                ofd.Filter = "MHX/Gen System File|system|All files (*.*)|*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    ofd.Dispose();
                    return;
                }

                //this.Text = ofd.SafeFileName;
                this.Text = string.Format("{0} [{1}]", Constants.EDITOR_VERSION, ofd.SafeFileName);
                filePath = ofd.FileName;
                dataExtractor = new DataExtractor(filePath);

                saveFile = dataExtractor.GetSaveFile();
                loadSave();

                ofd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error");
                saveFile = null;
                clearForms();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            try
            {
                if (filePath == "")
                {
                    MessageBox.Show("No file loaded!", "Error");
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Do you want to save?", "Save?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                savePlayer(currentPlayer);
                dataExtractor.SaveData(saveFile);
                File.WriteAllBytes(this.filePath, dataExtractor.FileData);
                MessageBox.Show("Save Complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsucessful");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.FileName = "system";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        savePlayer(currentPlayer);
                        dataExtractor.SaveData(saveFile);

                        File.WriteAllBytes(sfd.FileName, dataExtractor.FileData);
                        this.filePath = sfd.FileName;
                        this.Text = string.Format("{0} [{1}]", Constants.EDITOR_VERSION, Path.GetFileName(filePath));
                        MessageBox.Show("Save Complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsucessful");
            }
        }

        private void saveSlot1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSlot1ToolStripMenuItem.Checked = true;
            saveSlot2ToolStripMenuItem.Checked = false;
            saveSlot3ToolStripMenuItem.Checked = false;
            savePlayer(currentPlayer);
            currentPlayer = 0;
            loadPlayer(0);
        }

        private void saveSlot2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSlot1ToolStripMenuItem.Checked = false;
            saveSlot2ToolStripMenuItem.Checked = true;
            saveSlot3ToolStripMenuItem.Checked = false;
            savePlayer(currentPlayer);
            currentPlayer = 1;
            loadPlayer(1);
        }

        private void saveSlot3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSlot1ToolStripMenuItem.Checked = false;
            saveSlot2ToolStripMenuItem.Checked = false;
            saveSlot3ToolStripMenuItem.Checked = true;
            savePlayer(currentPlayer);
            currentPlayer = 2;
            loadPlayer(2);
        }

        private void loadSave()
        {
            if (saveFile == null || saveFile.Players == null || (saveFile.Players[0] == null && saveFile.Players[1] == null && saveFile.Players[2] == null))
            {
                MessageBox.Show("Load a file first");
                return;
            }

            switchProfileToolStripMenuItem.Enabled = true;

            if (saveFile.Players[0] != null)
                saveSlot1ToolStripMenuItem.Enabled = true;
            if (saveFile.Players[1] != null)
                saveSlot2ToolStripMenuItem.Enabled = true;
            if (saveFile.Players[2] != null)
                saveSlot3ToolStripMenuItem.Enabled = true;

            saveSlot1ToolStripMenuItem.Checked = false;
            saveSlot2ToolStripMenuItem.Checked = false;
            saveSlot3ToolStripMenuItem.Checked = false;

            if (saveFile.Players[0] != null)
            {
                this.currentPlayer = 0;
                saveSlot1ToolStripMenuItem.Checked = true;
            }
            else if (saveFile.Players[1] != null)
            {
                this.currentPlayer = 1;
                saveSlot2ToolStripMenuItem.Checked = true;
            }
            else
            {
                this.currentPlayer = 2;
                saveSlot3ToolStripMenuItem.Checked = true;
            }

            loadPlayer(currentPlayer);
        }

        //Loads a player. Note that index start at 0.
        private void loadPlayer(int slot)
        {
            Player p = saveFile.Players[slot];

            //General Tab
            textBoxPlayerName.Text = p.Name;
            numericUpDownHrLevel.Value = p.HunterRank;
            numericUpDownHrPoints.Value = p.HRPoints;
            numericUpDownZenny.Value = p.Zenny;
            numericUpDownAcademyPoints.Value = p.AcademyPoints;
            numericUpDownBerunaPoints.Value = p.BerunaPoints;
            numericUpDownKokotoPoints.Value = p.KokotoPoints;
            numericUpDownPokkePoints.Value = p.PokkePoints;
            numericUpDownYukumoPoints.Value = p.YukumoPoints;
            numericUpDownPlayTime.Value = p.PlayTime;

            //Player Tab
            comboBoxGender.SelectedIndex = p.Gender;
            numericUpDownHair.Value = p.HairStyle;
            numericUpDownFace.Value = p.Face;
            numericUpDownFeatures.Value = p.Features;
            numericUpDownVoice.Value = p.Voice;
            numericUpDownEyeColor.Value = p.EyeColor;
            numericUpDownClothing.Value = p.Clothing;
            numericUpDownHuntingStyle.Value = p.HuntingStyle;
            numericUpDownHunterArt1.Value = p.HunterArt1;
            numericUpDownHunterArt2.Value = p.HunterArt2;
            numericUpDownHunterArt3.Value = p.HunterArt3;
            textBoxSkinColorRGBA.Text = BitConverter.ToString(p.SkinColorRGBA).Replace("-", "");
            textBoxHairColorRGBA.Text = BitConverter.ToString(p.HairColorRGBA).Replace("-", "");
            textBoxFeaturesColorRGBA.Text = BitConverter.ToString(p.FeaturesColorRGBA).Replace("-", "");
            textBoxClothingColorRGBA.Text = BitConverter.ToString(p.ClothingColorRGBA).Replace("-", "");

            loadEquipmentBox(currentPlayer);
            loadItemBoxes(currentPlayer);
            loadItemPouch(currentPlayer);
            loadPalicos(currentPlayer);
        }


        private void savePlayer(int slot)
        {
            try
            {
                Player p = saveFile.Players[slot];

                //General
                p.Name = textBoxPlayerName.Text;
                p.PlayTime = (UInt32)numericUpDownPlayTime.Value;
                p.HunterRank = (UInt16)numericUpDownHrLevel.Value;
                p.HRPoints = (int)numericUpDownHrPoints.Value;
                p.Zenny = (int)numericUpDownZenny.Value;
                p.AcademyPoints = (int)numericUpDownAcademyPoints.Value;
                p.BerunaPoints = (int)numericUpDownBerunaPoints.Value;
                p.KokotoPoints = (int)numericUpDownKokotoPoints.Value;
                p.PokkePoints = (int)numericUpDownPokkePoints.Value;
                p.YukumoPoints = (int)numericUpDownYukumoPoints.Value;

                //Player Tab
                p.Gender = (byte)comboBoxGender.SelectedIndex;
                p.HairStyle = (byte)numericUpDownHair.Value;
                p.Face = (byte)numericUpDownFace.Value;
                p.Features = (byte)numericUpDownFeatures.Value;
                p.Voice = (byte)numericUpDownVoice.Value;
                p.EyeColor = (byte)numericUpDownEyeColor.Value;
                p.Clothing = (byte)numericUpDownClothing.Value;
                p.HuntingStyle = (byte)numericUpDownHuntingStyle.Value;
                p.HunterArt1 = (UInt16)numericUpDownHunterArt1.Value;
                p.HunterArt2 = (UInt16)numericUpDownHunterArt2.Value;
                p.HunterArt3 = (UInt16)numericUpDownHunterArt3.Value;

                if (textBoxSkinColorRGBA.Text.Length != 8 || textBoxHairColorRGBA.Text.Length != 8 || textBoxFeaturesColorRGBA.Text.Length != 8 || textBoxClothingColorRGBA.Text.Length != 8)
                {
                    MessageBox.Show("One or more invalid RGBA Colors\nColors not saved", "Error");
                }
                else
                {
                    p.SkinColorRGBA = Converters.StringToByteArray(textBoxSkinColorRGBA.Text);
                    p.HairColorRGBA = Converters.StringToByteArray(textBoxHairColorRGBA.Text);
                    p.FeaturesColorRGBA = Converters.StringToByteArray(textBoxFeaturesColorRGBA.Text);
                    p.ClothingColorRGBA = Converters.StringToByteArray(textBoxClothingColorRGBA.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void loadEquipmentBox(int slot)
        {
            listViewEquipment.Items.Clear();
            int index = comboBoxEquipmentBox.SelectedIndex * Constants.ITEM_PER_BOX;
            for (int i = 0; i < Constants.ITEM_PER_BOX; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(GameConstants.EquipmentTypes[saveFile.Players[slot].EquipmentBox[index + i].EquipmentBytes[0]]);
                lvi.SubItems.Add(string.Format("Equipment ID: {0}", saveFile.Players[slot].EquipmentBox[index + i].EquipmentBytes[1]));
                listViewEquipment.Items.Add(lvi);
            }
        }

        private void loadItemBoxes(int slot)
        {
            listViewItemBox.Items.Clear();
            int index = comboBoxItemBox.SelectedIndex * Constants.ITEM_PER_BOX;
            for (int i = 0; i < Constants.ITEM_PER_BOX; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(saveFile.Players[slot].ItemBox[index + i].ToString());
                lvi.SubItems.Add(saveFile.Players[slot].ItemBox[index + i].ItemAmount.ToString());
                listViewItemBox.Items.Add(lvi);
            }
        }

        private void loadItemPouch(int slot)
        {
            listViewItemPouch.Items.Clear();
            int index = comboBoxPouch.SelectedIndex * Constants.ITEM_PER_POUCH;
            for (int i = 0; i < Constants.ITEM_PER_POUCH; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(saveFile.Players[slot].ItemPouch[index + i].ToString());
                lvi.SubItems.Add(saveFile.Players[slot].ItemPouch[index + i].ItemAmount.ToString());
                listViewItemPouch.Items.Add(lvi);
            }
        }

        private void loadPalicos(int slot)
        {
            listViewPalicos.Items.Clear();
            for (int i = 0; i < Constants.TOTAL_PALICOS; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(saveFile.Players[slot].Palicos[i].ToString());
                listViewPalicos.Items.Add(lvi);
            }
        }

        private void comboBoxEquipmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                return;
            }
            loadEquipmentBox(currentPlayer);
        }

        private void comboBoxItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                return;
            }
            loadItemBoxes(currentPlayer);
        }

        private void comboBoxPouch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                return;
            }
            loadItemPouch(currentPlayer);
        }

        private void buttonEditPalico_Click(object sender, EventArgs e)
        {
            if (listViewPalicos.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select a palico");
                return;
            }

            int itemSelected = listViewPalicos.SelectedItems[0].Index;
            PalicoEditDialog ped = new PalicoEditDialog(saveFile.Players[currentPlayer].Palicos[itemSelected]);

            ped.ShowDialog();
            if (ped.DialogResult == DialogResult.OK)
            {
                loadPalicos(currentPlayer);
                listViewPalicos.Items[itemSelected].Selected = true;
                listViewPalicos.TopItem = listViewPalicos.SelectedItems[0];
            }

            ped.Dispose();
        }

        private void listViewPalicos_DoubleClick(object sender, EventArgs e)
        {
            buttonEditPalico.PerformClick();
        }

        private void buttonEditItemBox_Click(object sender, EventArgs e)
        {
            if (listViewItemBox.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select and item to edit.");
                return;
            }

            int itemSelected = listViewItemBox.SelectedItems[0].Index + (comboBoxItemBox.SelectedIndex * Constants.ITEM_PER_BOX);
           
            ItemEditDialog ied = new ItemEditDialog(saveFile.Players[currentPlayer].ItemBox[itemSelected], (itemSelected + 1));
            ied.ShowDialog();

            if (ied.DialogResult == DialogResult.OK)
            {
                loadItemBoxes(currentPlayer);
                int indexSelected = itemSelected - (comboBoxItemBox.SelectedIndex * Constants.ITEM_PER_BOX);
                listViewItemBox.Items[indexSelected].Selected = true;
                listViewItemBox.TopItem = listViewItemBox.SelectedItems[0];
            }

            ied.Dispose();
        }

        private void listViewItemBox_DoubleClick(object sender, EventArgs e)
        {
            buttonEditItemBox.PerformClick();
        }

        private void buttonEditItemPouch_Click(object sender, EventArgs e)
        {
            if (listViewItemPouch.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewItemPouch.SelectedItems[0].Index + (comboBoxPouch.SelectedIndex * Constants.ITEM_PER_POUCH);

            ItemEditDialog ied = new ItemEditDialog(saveFile.Players[currentPlayer].ItemPouch[itemSelected], (itemSelected + 1));
            ied.ShowDialog();

            if (ied.DialogResult == DialogResult.OK)
            {
                loadItemPouch(currentPlayer);
                int indexSelected = itemSelected - (comboBoxPouch.SelectedIndex * Constants.ITEM_PER_POUCH);
                listViewItemPouch.Items[indexSelected].Selected = true;
                listViewItemPouch.TopItem = listViewItemPouch.SelectedItems[0];
            }

            ied.Dispose();
        }
        private void listViewItemPouch_DoubleClick(object sender, EventArgs e)
        {
            buttonEditItemPouch.PerformClick();
        }

        private void buttonEditEquipment_Click(object sender, EventArgs e)
        {
            if (listViewEquipment.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewEquipment.SelectedItems[0].Index + (comboBoxEquipmentBox.SelectedIndex * Constants.ITEM_PER_BOX);

            EquipmentEditDialog eed = new EquipmentEditDialog(saveFile.Players[currentPlayer].EquipmentBox[itemSelected]);
            eed.ShowDialog();

            if (eed.DialogResult == DialogResult.OK)
            {
                loadEquipmentBox(currentPlayer);
                int indexSelected = itemSelected - (comboBoxEquipmentBox.SelectedIndex * Constants.ITEM_PER_BOX);
                listViewEquipment.Items[indexSelected].Selected = true;
                listViewEquipment.TopItem = listViewEquipment.SelectedItems[0];
            }
            eed.Dispose();
        }

        private void listViewEquipment_DoubleClick(object sender, EventArgs e)
        {
            buttonEditEquipment.PerformClick();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog ad = new AboutDialog();
            ad.ShowDialog();
            ad.Dispose();
        }

        private void maxItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            Util.Tools.MaxItems(saveFile.Players[currentPlayer].ItemBox);
            loadItemBoxes(currentPlayer);
            MessageBox.Show("All item amounts set to 99");
        }

        private void buttonEditGuildCard_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            MessageBox.Show(string.Format("{0:X2}", (saveFile.Players[currentPlayer].SaveOffset + Offsets.PLAYER_GUILD_CARD_OFFSET)), "Offset");
        }


        private void allCraftableArmorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            Tools.CraftArmorUnlock(saveFile.Players[currentPlayer].CraftableArmorShops);
            MessageBox.Show("All armors are now craftable!", "Success!");
        }

        private void allCraftableWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            Tools.CraftWeaponShopUnlock(saveFile.Players[currentPlayer].CraftableWeaponShops);
            MessageBox.Show("All weapons are now craftable!", "Success!");
        }

        private void allCraftablePalicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            Tools.CraftPalicoGearUnlock(saveFile.Players[currentPlayer].CraftablePalicoShops);
            MessageBox.Show("All palcio gear are now craftable!", "Success!");
        }

        private void importListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            ImportItemBoxListDialog iibld = new ImportItemBoxListDialog(saveFile.Players[currentPlayer].ItemBox);
            iibld.ShowDialog();

            if (iibld.DialogResult == DialogResult.OK)
            {
                loadItemBoxes(currentPlayer);
            }

            iibld.Dispose();
        }

        private void exportToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFile == null)
                {
                    MessageBox.Show("Load a file first!");
                    return;
                }
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Item Lists (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        List<UInt32> items = new List<UInt32>();

                        for (int i = 0; i < Constants.TOTAL_ITEM_BOX_SLOTS; i++)
                        {
                            if (saveFile.Players[currentPlayer].ItemBox[i].ItemID != 0)
                            {
                                items.Add(saveFile.Players[currentPlayer].ItemBox[i].ItemID);
                            }
                        }

                        File.WriteAllText(sfd.FileName, string.Join(",",items.ToArray()));
                        MessageBox.Show("Export Complete!", "Success");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void importEqpBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            ImportEquipmentBoxDialog iebd = new ImportEquipmentBoxDialog(saveFile.Players[currentPlayer].EquipmentBox);
            iebd.ShowDialog();
            if (iebd.DialogResult == DialogResult.OK)
            {
                loadEquipmentBox(currentPlayer);
            }
            iebd.Dispose();
        }

        private void exportEqpBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null)
            {
                MessageBox.Show("Load a file first!");
                return;
            }
            ExportEquipmentBoxDialog eebd = new ExportEquipmentBoxDialog(saveFile.Players[currentPlayer].EquipmentBox);
            eebd.ShowDialog();
            eebd.Dispose();
        }

        private void setItemAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetItemBoxItemAmountDialog sibd = new SetItemBoxItemAmountDialog(saveFile.Players[currentPlayer].ItemBox);
            sibd.ShowDialog();
            if (sibd.DialogResult == DialogResult.OK)
            {
                loadItemBoxes(currentPlayer);
            }
            sibd.Dispose();
        }

        private void deleteAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Clear ALL items from item box?", "Delete all items?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.ClearItems(saveFile.Players[currentPlayer].ItemBox);
            }
        }

        private void buttonClearItemBox_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Clear ALL items from current item box?", "Delete all items?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.ClearItems(saveFile.Players[currentPlayer].ItemBox,
                    (comboBoxItemBox.SelectedIndex * Constants.ITEM_PER_BOX),
                    ((comboBoxItemBox.SelectedIndex * Constants.ITEM_PER_BOX) + Constants.ITEM_PER_BOX));
                loadItemBoxes(currentPlayer);
            }
        }

        private void buttonClearItemPouch_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Clear ALL items from current item pouch?", "Delete all items?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.ClearItems(saveFile.Players[currentPlayer].ItemPouch,
                    (comboBoxPouch.SelectedIndex * Constants.ITEM_PER_POUCH),
                    ((comboBoxPouch.SelectedIndex * Constants.ITEM_PER_POUCH) + Constants.ITEM_PER_POUCH));
                loadItemPouch(currentPlayer);
            }
        }

        private void buttonClearEquipmentBox_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Delete ALL equipment from current Equipment Box?", "Delete all equipment?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.ClearEquipment(saveFile.Players[currentPlayer].EquipmentBox,
                    (comboBoxEquipmentBox.SelectedIndex * Constants.ITEM_PER_BOX),
                    ((comboBoxEquipmentBox.SelectedIndex * Constants.ITEM_PER_BOX) + Constants.ITEM_PER_BOX));
                loadEquipmentBox(currentPlayer);
            }
        }

        private void deleteAllEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Delete ALL equipment from current Equipment Box?", "Delete all equipment?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.ClearEquipment(saveFile.Players[currentPlayer].EquipmentBox);
                loadEquipmentBox(currentPlayer);
            }
        }

        private void allBoxSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile == null) { return; }

            DialogResult dialogResult = MessageBox.Show("Unlock all boxes?\nWARNING: EXPERIMENTAL FEATURE", "Unlock all boxes?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Tools.UnlockAllBoxes(saveFile.Players[currentPlayer].UnlockedBoxData);
                MessageBox.Show("All item boxes and palico boxes are now unlocked","Success!");
            }
        }

    }
}
