using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using APMMHXSaveEditor.Data;

namespace APMMHXSaveEditor.Forms
{
    public partial class GuildCardEditorDialog : Form
    {
        public GuildCard GuildCard { get; set; }

        private UInt16[] villageWeaponUsage;
        private UInt16[] hunterHubWeaponUsage;
        private UInt16[] arenaWeaponUsage;
        private int currentWeaponUsageIndex = -1;

        public GuildCardEditorDialog(GuildCard guildCard)
        {
            InitializeComponent();
            this.GuildCard = guildCard;

            textBoxName.Enabled = false;

            numericUpDownPlayTime.Maximum = UInt32.MaxValue;
            numericUpDownStreetPasses.Maximum = UInt16.MaxValue;
            numericUpDownVillageQuests.Maximum = UInt16.MaxValue;
            numericUpDownLowHubQuests.Maximum = UInt16.MaxValue;
            numericUpDownHighHubQuests.Maximum = UInt16.MaxValue;
            numericUpDownSpecialPermitQuests.Maximum = UInt16.MaxValue;
            numericUpDownArenaQuests.Maximum = UInt16.MaxValue;
            numericUpDownVillageWeapons.Maximum = UInt16.MaxValue;
            numericUpDownHunterHubWeapons.Maximum = UInt16.MaxValue;
            numericUpDownArenaWeapons.Maximum = UInt16.MaxValue;

           
            loadGuildCard();
            comboBoxWeapons.DataSource = GameConstants.WeaponTypes;
        }

        private void loadGuildCard()
        {
            BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(GuildCard.GuildCardData));
            char nextchar = binaryReader.ReadChar();
            while (nextchar != '\0')
            {
                textBoxName.Text += nextchar;
                binaryReader.ReadChar();
                nextchar = binaryReader.ReadChar();
            }

            binaryReader.BaseStream.Seek(GuildCardOffsets.PLAYTIME_OFFSET, SeekOrigin.Begin);
            numericUpDownPlayTime.Value = binaryReader.ReadUInt32();

            binaryReader.BaseStream.Seek(GuildCardOffsets.STREET_PASS_OFFSETS, SeekOrigin.Begin);
            numericUpDownStreetPasses.Value = binaryReader.ReadUInt16();

            binaryReader.BaseStream.Seek(GuildCardOffsets.VILLAGE_QUEST_OFFSETS, SeekOrigin.Begin);
            numericUpDownVillageQuests.Value = binaryReader.ReadUInt16();
            numericUpDownLowHubQuests.Value = binaryReader.ReadUInt16();
            numericUpDownHighHubQuests.Value = binaryReader.ReadUInt16();
            numericUpDownSpecialPermitQuests.Value = binaryReader.ReadUInt16();
            numericUpDownArenaQuests.Value = binaryReader.ReadUInt16();

            binaryReader.BaseStream.Seek(GuildCardOffsets.VILLAGE_WEAPON_USAGE_OFFSET, SeekOrigin.Begin);
            villageWeaponUsage = new UInt16[Constants.TOTAL_WEAPONS];
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                villageWeaponUsage[i] = binaryReader.ReadUInt16();
            }

            hunterHubWeaponUsage = new UInt16[Constants.TOTAL_WEAPONS];
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                hunterHubWeaponUsage[i] = binaryReader.ReadUInt16();
            }

            arenaWeaponUsage = new UInt16[Constants.TOTAL_WEAPONS];
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                arenaWeaponUsage[i] = binaryReader.ReadUInt16();
            }
        }

        private void saveGuildCard()
        {
            saveWeaponUsage();
            BinaryWriter binaryWriter = new BinaryWriter((Stream)new MemoryStream(GuildCard.GuildCardData));

            binaryWriter.BaseStream.Seek(GuildCardOffsets.PLAYTIME_OFFSET, SeekOrigin.Begin);
            binaryWriter.Write((UInt32)numericUpDownPlayTime.Value);

            binaryWriter.BaseStream.Seek(GuildCardOffsets.STREET_PASS_OFFSETS, SeekOrigin.Begin);
            binaryWriter.Write((UInt16)numericUpDownStreetPasses.Value);

            binaryWriter.BaseStream.Seek(GuildCardOffsets.VILLAGE_QUEST_OFFSETS, SeekOrigin.Begin);
            binaryWriter.Write((UInt16)numericUpDownVillageQuests.Value);
            binaryWriter.Write((UInt16)numericUpDownLowHubQuests.Value);
            binaryWriter.Write((UInt16)numericUpDownHighHubQuests.Value);
            binaryWriter.Write((UInt16)numericUpDownSpecialPermitQuests.Value);
            binaryWriter.Write((UInt16)numericUpDownArenaQuests.Value);

            binaryWriter.BaseStream.Seek(GuildCardOffsets.VILLAGE_WEAPON_USAGE_OFFSET, SeekOrigin.Begin);
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                binaryWriter.Write(villageWeaponUsage[i]);
            }
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                binaryWriter.Write(hunterHubWeaponUsage[i]);
            }
            for (int i = 0; i < Constants.TOTAL_WEAPONS; i++)
            {
                binaryWriter.Write(arenaWeaponUsage[i]);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                saveGuildCard();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsuccessful");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void GuildCardEditorDialog_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentWeaponUsageIndex != -1)
            {
                saveWeaponUsage();
            }
            currentWeaponUsageIndex = comboBoxWeapons.SelectedIndex;
            numericUpDownVillageWeapons.Value = villageWeaponUsage[currentWeaponUsageIndex];
            numericUpDownHunterHubWeapons.Value = hunterHubWeaponUsage[currentWeaponUsageIndex];
            numericUpDownArenaWeapons.Value = arenaWeaponUsage[currentWeaponUsageIndex];
        }

        private void saveWeaponUsage()
        {
            villageWeaponUsage[currentWeaponUsageIndex] = (UInt16)numericUpDownVillageWeapons.Value;
            hunterHubWeaponUsage[currentWeaponUsageIndex] = (UInt16)numericUpDownHunterHubWeapons.Value;
            arenaWeaponUsage[currentWeaponUsageIndex] = (UInt16)numericUpDownArenaWeapons.Value;
        }
    }
}
