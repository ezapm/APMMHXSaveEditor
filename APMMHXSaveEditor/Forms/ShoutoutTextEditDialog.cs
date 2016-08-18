using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using APMMHXSaveEditor.Data;

namespace APMMHXSaveEditor.Forms
{
    public partial class ShoutoutTextEditDialog : Form
    {
        public string Shoutout { get; set; }
        public ShoutoutTextEditDialog(string shoutout)
        {
            InitializeComponent();
            this.Shoutout = shoutout;
            textBoxShoutout.Text = Shoutout;
            checkBoxLimit.Checked = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Shoutout = textBoxShoutout.Text.PadRight(Constants.SIZEOF_SHOUTOUT, '\0'); ;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBoxLimit_CheckedChanged(object sender, EventArgs e)
        {
            textBoxShoutout.MaxLength = checkBoxLimit.Checked ? Constants.SIZEOF_GAME_SHOUTOUT : Constants.SIZEOF_SHOUTOUT;
        }
    }
}
