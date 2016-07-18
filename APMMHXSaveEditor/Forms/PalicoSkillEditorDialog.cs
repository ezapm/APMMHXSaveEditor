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

namespace APMMHXSaveEditor.Forms
{
    public partial class PalicoSkillEditorDialog : Form
    {
        public byte SkillID { get; set; }

        public PalicoSkillEditorDialog(byte skillID)
        {
            InitializeComponent();
            comboBoxPalicoSkills.DataSource = GameConstants.PalicoSkills;
            this.SkillID = skillID;
            comboBoxPalicoSkills.SelectedIndex = skillID;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.SkillID = (byte)comboBoxPalicoSkills.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PalicoSkillEditorDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
