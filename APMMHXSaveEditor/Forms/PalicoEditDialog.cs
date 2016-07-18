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

namespace APMMHXSaveEditor.Forms
{
    public partial class PalicoEditDialog : Form
    {

        private Palico palico;

        public PalicoEditDialog(Palico palico)
        {
            InitializeComponent();
            this.palico = palico;

            comboBoxForte.DataSource = GameConstants.Palico_Forte;
            numericUpDownXP.Maximum = UInt32.MaxValue;
            numericUpDownLevel.Maximum = 255;
            numericUpDownTarget.Maximum = 255;
            numericUpDownEnthusiasm.Maximum = 255;
            numericUpDownLearnedActionRNG.Maximum = UInt16.MaxValue;
            numericUpDownLearnedSkillRNG.Maximum = UInt16.MaxValue;
            textBoxName.MaxLength = 16;
            textBoxNameGiver.MaxLength = 16;
            textBoxPreviousOwner.MaxLength = 16;
            textBoxRGBA.MaxLength = 8;
            textBoxGreetings.MaxLength = 30;

            //Loading General
            textBoxName.Text = palico.Name;
            numericUpDownLevel.Value = palico.Level;
            numericUpDownXP.Value = palico.XP;
            numericUpDownEnthusiasm.Value = palico.Enthusiasm;
            numericUpDownTarget.Value = palico.Target;
            numericUpDownLearnedActionRNG.Value = palico.LearnedActionRNG;
            numericUpDownLearnedSkillRNG.Value = palico.LearnedSkillRNG;
            textBoxNameGiver.Text = palico.NameGiver;
            textBoxPreviousOwner.Text = palico.PreviousMaster;
            textBoxGreetings.Text = palico.Greeting;
            comboBoxForte.SelectedIndex = palico.Forte;
            textBoxRGBA.Text = BitConverter.ToString(palico.RGBAValue).Replace("-", "");

            loadEquippedActions();
            loadEquippedSkills();
            loadLearnedActions();
            loadLearnedSkills();

        }

        private void loadEquippedActions()
        {
            listViewEquippedAction.Items.Clear();
            for (int i = 0; i < palico.EquippedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(string.Format("Action ID {0}", palico.EquippedActions[i].ToString()));
                listViewEquippedAction.Items.Add(lviAction);
            }
        }

        private void loadEquippedSkills()
        {
            listViewEquippedSkills.Items.Clear();
            for (int i = 0; i < palico.EquippedActions.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(string.Format("Skill ID {0}", palico.EquippedSkills[i].ToString()));
                listViewEquippedSkills.Items.Add(lviSkill);
            }
        }

        private void loadLearnedActions()
        {
            listViewLearnedActions.Items.Clear();
            for (int i = 0; i < palico.LearnedActions.Length; i++)
            {
                ListViewItem lviAction = new ListViewItem((i + 1).ToString());
                lviAction.SubItems.Add(string.Format("Action ID {0}", palico.LearnedActions[i].ToString()));
                listViewLearnedActions.Items.Add(lviAction);
            }
        }

        private void loadLearnedSkills()
        {
            listViewLearnedSkills.Items.Clear();
            for (int i = 0; i < palico.LearnedActions.Length; i++)
            {
                ListViewItem lviSkill = new ListViewItem((i + 1).ToString());
                lviSkill.SubItems.Add(string.Format("Skill ID {0}", palico.LearnedSkills[i].ToString()));
                listViewLearnedSkills.Items.Add(lviSkill);
            }
        }

        private void PalicoEditDialog_Load(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxRGBA.Text.Length != 8)
            {
                MessageBox.Show("Make sure RGBA color is 4 bytes (AABBCCFF).", "Invalid RGBA");
            }
            try
            {
                //General
                palico.Name = textBoxName.Text;
                palico.Level = (byte)numericUpDownLevel.Value;
                palico.XP = (UInt32)numericUpDownXP.Value;
                palico.Forte = (byte)comboBoxForte.SelectedIndex;
                palico.Enthusiasm = (byte)numericUpDownEnthusiasm.Value;
                palico.Target = (byte)numericUpDownTarget.Value;
                palico.LearnedActionRNG = (UInt16)numericUpDownLearnedActionRNG.Value;
                palico.LearnedSkillRNG = (UInt16)numericUpDownLearnedSkillRNG.Value;
                palico.NameGiver = textBoxNameGiver.Text;
                palico.PreviousMaster = textBoxPreviousOwner.Text;
                palico.Greeting = textBoxGreetings.Text;
                palico.RGBAValue = Converters.StringToByteArray(textBoxRGBA.Text);

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
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this.palico.EquippedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this.palico.EquippedSkills[itemSelected] = psed.SkillID;
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
            PalicoSkillEditorDialog psed = new PalicoSkillEditorDialog(this.palico.LearnedSkills[itemSelected]);

            psed.ShowDialog();

            if (psed.DialogResult == DialogResult.OK)
            {
                this.palico.LearnedSkills[itemSelected] = psed.SkillID;
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
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(palico.EquippedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this.palico.EquippedActions[itemSelected] = paed.ActionID;
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
            PalicoActionEditorDialog paed = new PalicoActionEditorDialog(palico.LearnedActions[itemSelected]);

            paed.ShowDialog();

            if (paed.DialogResult == DialogResult.OK)
            {
                this.palico.LearnedActions[itemSelected] = paed.ActionID;
                loadLearnedActions();
                int indexSelected = itemSelected;
                listViewLearnedActions.Items[indexSelected].Selected = true;
                listViewLearnedActions.TopItem = listViewLearnedActions.SelectedItems[0];
            }

            paed.Dispose();
        }


    }
}
