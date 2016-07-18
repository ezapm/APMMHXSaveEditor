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
    public partial class PalicoActionEditorDialog : Form
    {
        public byte ActionID { get; set; }

        public PalicoActionEditorDialog(byte actionID)
        {
            InitializeComponent();
            this.ActionID = actionID;
            comboBoxPalicoSkills.DataSource = GameConstants.PalicoSupportMoves;
            comboBoxPalicoSkills.SelectedIndex = actionID;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.ActionID = (byte)comboBoxPalicoSkills.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
