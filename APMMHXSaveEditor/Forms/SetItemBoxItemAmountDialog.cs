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
    public partial class SetItemBoxItemAmountDialog : Form
    {
        private Item[] items;
        public SetItemBoxItemAmountDialog(Item[] items)
        {
            InitializeComponent();
            numericUpDownAmount.Maximum = 255;
            numericUpDownAmount.Value = 99;
            this.items = items;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            foreach (Item item in items)
            {
                if (item.ItemID != 0)
                {
                    item.ItemAmount = (UInt32)numericUpDownAmount.Value;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
