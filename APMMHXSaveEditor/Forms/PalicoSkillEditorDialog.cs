using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMMHXSaveEditor.Forms
{
    public partial class PalicoSkillEditorDialog : Form
    {
        public byte SkillID { get; set; }

        public PalicoSkillEditorDialog(byte skillID)
        {
            InitializeComponent();
            numericUpDownSkillID.Maximum = 255;
            this.SkillID = skillID;
            numericUpDownSkillID.Value = skillID;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.SkillID = (byte)numericUpDownSkillID.Value;
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
