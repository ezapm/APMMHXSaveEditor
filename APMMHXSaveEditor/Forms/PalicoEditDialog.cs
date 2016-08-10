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

        public Palico _Palico;

        public PalicoEditDialog(Palico palico)
        {
            InitializeComponent();
            this._Palico = palico;

            comboBoxForte.DataSource = GameConstants.PalicoForte;
            comboBoxClothing.DataSource = GameConstants.PalicoClothing;
            comboBoxCoat.DataSource = GameConstants.PalicoCoat;
            comboBoxEars.DataSource = GameConstants.PalicoEars;
            comboBoxEyes.DataSource = GameConstants.PalicoEyes;
            comboBoxTail.DataSource = GameConstants.PalicoTail;
            comboBoxVoice.DataSource = GameConstants.PalicoVoices;
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
            textBoxName.Text = _Palico.Name;
            numericUpDownLevel.Value = _Palico.Level + 1;
            numericUpDownXP.Value = _Palico.XP;
            numericUpDownEnthusiasm.Value = _Palico.Enthusiasm;
            numericUpDownTarget.Value = _Palico.Target;
            textBoxLearnedActionRNG.Text = BitConverter.ToString(BitConverter.GetBytes(_Palico.LearnedActionRNG)).Replace("-", "");
            textBoxLearnedSkillRNG.Text = BitConverter.ToString(BitConverter.GetBytes(_Palico.LearnedSkillRNG)).Replace("-", "");
            textBoxNameGiver.Text = _Palico.NameGiver;
            textBoxPreviousOwner.Text = _Palico.PreviousMaster;
            textBoxGreetings.Text = _Palico.Greeting;
            comboBoxForte.SelectedIndex = _Palico.Forte;
            textBoxCoatRGBA.Text = BitConverter.ToString(_Palico.CoatRGBAValue).Replace("-", "");
            textBoxLeftEyeRGBA.Text = BitConverter.ToString(_Palico.LeftEyeRGBAValue).Replace("-", "");
            textBoxRightEyeRGBA.Text = BitConverter.ToString(_Palico.RightEyeRGBAValue).Replace("-", "");
            textBoxVestRGBA.Text = BitConverter.ToString(_Palico.VestRGBAValue).Replace("-", "");

            comboBoxClothing.SelectedIndex = _Palico.Clothing;
            comboBoxCoat.SelectedIndex = _Palico.Coat;
            comboBoxEars.SelectedIndex = _Palico.Ears;
            comboBoxEyes.SelectedIndex = _Palico.Eyes;
            comboBoxTail.SelectedIndex = _Palico.Tail;
            comboBoxVoice.SelectedIndex = _Palico.Voice;

            loadEquippedActions();
            loadEquippedSkills();
            loadLearnedActions();
            loadLearnedSkills();

            checkBoxDLC.Checked = ((_Palico.Unknown2[4] >> 4) & 8) == 8;
        }

        private void savePalico()
        {
            //General
            _Palico.Name = textBoxName.Text;
            _Palico.Level = (byte)(numericUpDownLevel.Value - 1);
            _Palico.XP = (UInt32)numericUpDownXP.Value;
            _Palico.Forte = (byte)comboBoxForte.SelectedIndex;
            _Palico.Enthusiasm = (byte)numericUpDownEnthusiasm.Value;
            _Palico.Target = (byte)numericUpDownTarget.Value;

            _Palico.LearnedActionRNG = BitConverter.ToUInt16(Converters.StringToByteArray(textBoxLearnedActionRNG.Text), 0);
            _Palico.LearnedSkillRNG = BitConverter.ToUInt16(Converters.StringToByteArray(textBoxLearnedSkillRNG.Text), 0);
           
            //Text
            _Palico.NameGiver = textBoxNameGiver.Text;
            _Palico.PreviousMaster = textBoxPreviousOwner.Text;
            _Palico.Greeting = textBoxGreetings.Text;
            
            //Design
            _Palico.CoatRGBAValue = Converters.StringToByteArray(textBoxCoatRGBA.Text);
            _Palico.LeftEyeRGBAValue = Converters.StringToByteArray(textBoxLeftEyeRGBA.Text);
            _Palico.RightEyeRGBAValue = Converters.StringToByteArray(textBoxRightEyeRGBA.Text);
            _Palico.VestRGBAValue = Converters.StringToByteArray(textBoxVestRGBA.Text);
            _Palico.Clothing = (byte)comboBoxClothing.SelectedIndex;
            _Palico.Coat = (byte)comboBoxCoat.SelectedIndex;
            _Palico.Ears = (byte)comboBoxEars.SelectedIndex;
            _Palico.Eyes = (byte)comboBoxEyes.SelectedIndex;
            _Palico.Tail = (byte)comboBoxTail.SelectedIndex;
            _Palico.Voice = (byte)comboBoxVoice.SelectedIndex;

            _Palico.Unknown2[4] = checkBoxDLC.Checked ? (byte)(_Palico.Unknown2[4] | 0x80) : (byte)(_Palico.Unknown2[4] & ~(0x80));
        }

        private void loadEquippedActions()
        {
            listViewEquippedAction.Items.Clear();
            for (int i = 0; i < _Palico.EquippedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(GameConstants.PalicoSupportMoves[_Palico.EquippedActions[i]]);
                listViewEquippedAction.Items.Add(lviAction);
            }
        }

        private void loadEquippedSkills()
        {
            listViewEquippedSkills.Items.Clear();
            for (int i = 0; i < _Palico.EquippedActions.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(GameConstants.PalicoSkills[_Palico.EquippedSkills[i]]);
                listViewEquippedSkills.Items.Add(lviSkill);
            }
        }

        private void loadLearnedActions()
        {
            listViewLearnedActions.Items.Clear();
            for (int i = 0; i < _Palico.LearnedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(GameConstants.PalicoSupportMoves[_Palico.LearnedActions[i]]);
                listViewLearnedActions.Items.Add(lviAction);
            }
        }

        private void loadLearnedSkills()
        {
            listViewLearnedSkills.Items.Clear();
            for (int i = 0; i < _Palico.LearnedSkills.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(GameConstants.PalicoSkills[_Palico.LearnedSkills[i]]);
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
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this._Palico.EquippedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this._Palico.EquippedSkills[itemSelected] = psed.SkillID;
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
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this._Palico.LearnedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this._Palico.LearnedSkills[itemSelected] = psed.SkillID;
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
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(_Palico.EquippedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this._Palico.EquippedActions[itemSelected] = paed.ActionID;
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
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(_Palico.LearnedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this._Palico.LearnedActions[itemSelected] = paed.ActionID;
                loadLearnedActions();
                int indexSelected = itemSelected;
                listViewLearnedActions.Items[indexSelected].Selected = true;
                listViewLearnedActions.TopItem = listViewLearnedActions.SelectedItems[0];
            }

            paed.Dispose();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            byte[] temp = DataExtractor.PackPalico(this._Palico);
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
                        File.WriteAllBytes(sfd.FileName, DataExtractor.PackPalico(this._Palico));
                        this._Palico = DataExtractor.GetPalcio(temp);
                        MessageBox.Show(string.Format("Exported palico to {0}", sfd.FileName), "Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsucessful");
                this._Palico = DataExtractor.GetPalcio(temp);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            byte[] temp = DataExtractor.PackPalico(this._Palico);
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

                this._Palico = DataExtractor.GetPalcio(fileData);
                loadPalico();

                ofd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error");
                this._Palico = DataExtractor.GetPalcio(temp);
            }
        }


    }
}
