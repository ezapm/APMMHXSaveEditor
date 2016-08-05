using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APMMHXSaveEditor.Data;
using APMMHXSaveEditor.Forms;
using APMMHXSaveEditor.Util;
using System.IO;

namespace APMMHXSaveEditor.Forms
{
    public partial class PalicoEditDialog : Form
    {

        public Palico Palico;

        public PalicoEditDialog(Palico palico)
        {
            InitializeComponent();
            this.Palico = palico;

            comboBoxForte.DataSource = GameConstants.PalicoForte;
            numericUpDownXP.Maximum = UInt32.MaxValue;
            numericUpDownLevel.Minimum = 1;
            numericUpDownLevel.Maximum = 255;
            numericUpDownTarget.Maximum = 255;
            numericUpDownEnthusiasm.Maximum = 255;
            textBoxLearnedActionRNG.MaxLength = 4;
            textBoxLearnedSkillRNG.MaxLength = 4;
            textBoxName.MaxLength = 16;
            textBoxNameGiver.MaxLength = 16;
            textBoxPreviousOwner.MaxLength = 16;
            textBoxCoatRGBA.MaxLength = 8;
            textBoxLeftEyeRGBA.MaxLength = 8;
            textBoxRightEyeRGBA.MaxLength = 8;
            textBoxVestRGBA.MaxLength = 8;
            textBoxGreetings.MaxLength = 30;

            loadPalico();
        }

        private void loadPalico()
        {
            textBoxName.Text = Palico.Name;
            numericUpDownLevel.Value = Palico.Level + 1;
            numericUpDownXP.Value = Palico.XP;
            numericUpDownEnthusiasm.Value = Palico.Enthusiasm;
            numericUpDownTarget.Value = Palico.Target;
            textBoxLearnedActionRNG.Text = BitConverter.ToString(BitConverter.GetBytes(Palico.LearnedActionRNG)).Replace("-", "");
            textBoxLearnedSkillRNG.Text = BitConverter.ToString(BitConverter.GetBytes(Palico.LearnedSkillRNG)).Replace("-", "");
            textBoxNameGiver.Text = Palico.NameGiver;
            textBoxPreviousOwner.Text = Palico.PreviousMaster;
            textBoxGreetings.Text = Palico.Greeting;
            comboBoxForte.SelectedIndex = Palico.Forte;
            textBoxCoatRGBA.Text = BitConverter.ToString(Palico.CoatRGBAValue).Replace("-", "");
            textBoxLeftEyeRGBA.Text = BitConverter.ToString(Palico.LeftEyeRGBAValue).Replace("-", "");
            textBoxRightEyeRGBA.Text = BitConverter.ToString(Palico.RightEyeRGBAValue).Replace("-", "");
            textBoxVestRGBA.Text = BitConverter.ToString(Palico.VestRGBAValue).Replace("-", "");

            loadEquippedActions();
            loadEquippedSkills();
            loadLearnedActions();
            loadLearnedSkills();
        }

        private void savePalico()
        {
            //General
            Palico.Name = textBoxName.Text;
            Palico.Level = (byte)(numericUpDownLevel.Value - 1);
            Palico.XP = (UInt32)numericUpDownXP.Value;
            Palico.Forte = (byte)comboBoxForte.SelectedIndex;
            Palico.Enthusiasm = (byte)numericUpDownEnthusiasm.Value;
            Palico.Target = (byte)numericUpDownTarget.Value;
            Palico.LearnedActionRNG = BitConverter.ToUInt16(Converters.StringToByteArray(textBoxLearnedActionRNG.Text), 0);
            Palico.LearnedSkillRNG = BitConverter.ToUInt16(Converters.StringToByteArray(textBoxLearnedSkillRNG.Text), 0);
            Palico.NameGiver = textBoxNameGiver.Text;
            Palico.PreviousMaster = textBoxPreviousOwner.Text;
            Palico.Greeting = textBoxGreetings.Text;
            Palico.CoatRGBAValue = Converters.StringToByteArray(textBoxCoatRGBA.Text);
            Palico.LeftEyeRGBAValue = Converters.StringToByteArray(textBoxLeftEyeRGBA.Text);
            Palico.RightEyeRGBAValue = Converters.StringToByteArray(textBoxRightEyeRGBA.Text);
            Palico.VestRGBAValue = Converters.StringToByteArray(textBoxVestRGBA.Text);
        }

        private void loadEquippedActions()
        {
            listViewEquippedAction.Items.Clear();
            for (int i = 0; i < Palico.EquippedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(GameConstants.PalicoSupportMoves[Palico.EquippedActions[i]]);
                listViewEquippedAction.Items.Add(lviAction);
            }
        }

        private void loadEquippedSkills()
        {
            listViewEquippedSkills.Items.Clear();
            for (int i = 0; i < Palico.EquippedActions.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(GameConstants.PalicoSkills[Palico.EquippedSkills[i]]);
                listViewEquippedSkills.Items.Add(lviSkill);
            }
        }

        private void loadLearnedActions()
        {
            listViewLearnedActions.Items.Clear();
            for (int i = 0; i < Palico.LearnedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(GameConstants.PalicoSupportMoves[Palico.LearnedActions[i]]);
                listViewLearnedActions.Items.Add(lviAction);
            }
        }

        private void loadLearnedSkills()
        {
            listViewLearnedSkills.Items.Clear();
            for (int i = 0; i < Palico.LearnedSkills.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(GameConstants.PalicoSkills[Palico.LearnedSkills[i]]);
                listViewLearnedSkills.Items.Add(lviSkill);
            }
        }

        private void PalicoEditDialog_Load(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxCoatRGBA.Text.Length != 8 || textBoxLeftEyeRGBA.Text.Length != 8 || textBoxRightEyeRGBA.Text.Length != 8 || textBoxVestRGBA.Text.Length != 8)
            {
                MessageBox.Show("Make sure RGBA color(s) is 4 bytes (AABBCCFF).", "Invalid RGBA");
                return;
            }
            else if (textBoxLearnedActionRNG.Text.Length != 4 || textBoxLearnedSkillRNG.Text.Length != 4)
            {
                MessageBox.Show("Invalid Learned Action or Skill RNG Value", "Invalid RNG Value(s)");
            }
            try
            {
                savePalico();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void listViewEquippedSkills_DoubleClick(object sender, EventArgs e)
        {
            if (listViewEquippedSkills.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewEquippedSkills.SelectedItems[0].Index;
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this.Palico.EquippedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this.Palico.EquippedSkills[itemSelected] = psed.SkillID;
                loadEquippedSkills();
                int indexSelected = itemSelected;
                listViewEquippedSkills.Items[indexSelected].Selected = true;
                listViewEquippedSkills.TopItem = listViewEquippedSkills.SelectedItems[0];
            }

            psed.Dispose();
        }

        private void listViewLearnedSkills_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLearnedSkills.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewLearnedSkills.SelectedItems[0].Index;
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this.Palico.LearnedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this.Palico.LearnedSkills[itemSelected] = psed.SkillID;
                loadLearnedSkills();
                int indexSelected = itemSelected;
                listViewLearnedSkills.Items[indexSelected].Selected = true;
                listViewLearnedSkills.TopItem = listViewLearnedSkills.SelectedItems[0];
            }

            psed.Dispose();
        }

        private void listViewEquippedAction_DoubleClick(object sender, EventArgs e)
        {
            if (listViewEquippedAction.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewEquippedAction.SelectedItems[0].Index;
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(Palico.EquippedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this.Palico.EquippedActions[itemSelected] = paed.ActionID;
                loadEquippedActions();
                int indexSelected = itemSelected;
                listViewEquippedAction.Items[indexSelected].Selected = true;
                listViewEquippedAction.TopItem = listViewEquippedAction.SelectedItems[0];
            }

            paed.Dispose();
        }

        private void listViewLearnedActions_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLearnedActions.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an item to edit");
                return;
            }

            int itemSelected = listViewLearnedActions.SelectedItems[0].Index;
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(Palico.LearnedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this.Palico.LearnedActions[itemSelected] = paed.ActionID;
                loadLearnedActions();
                int indexSelected = itemSelected;
                listViewLearnedActions.Items[indexSelected].Selected = true;
                listViewLearnedActions.TopItem = listViewLearnedActions.SelectedItems[0];
            }

            paed.Dispose();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            byte[] temp = DataExtractor.PackPalico(this.Palico);
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Palico File (*.catz)|*.catz|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.FileName = textBoxName.Text;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        savePalico();
                        File.WriteAllBytes(sfd.FileName, DataExtractor.PackPalico(this.Palico));
                        this.Palico = DataExtractor.GetPalcio(temp);
                        MessageBox.Show(string.Format("Exported palico to {0}", sfd.FileName), "Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsucessful");
                this.Palico = DataExtractor.GetPalcio(temp);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            byte[] temp = DataExtractor.PackPalico(this.Palico);
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Palico File (*.catz)|*.catz|All files (*.*)|*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    ofd.Dispose();
                    return;
                }

                byte[] fileData = File.ReadAllBytes(ofd.FileName);
                if (fileData.Length != Constants.SIZEOF_PALICO)
                {
                    MessageBox.Show("Invalid Palico", "Error");
                    return;
                }

                this.Palico = DataExtractor.GetPalcio(fileData);
                loadPalico();

                ofd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error");
                this.Palico = DataExtractor.GetPalcio(temp);
            }
        }


    }
}
