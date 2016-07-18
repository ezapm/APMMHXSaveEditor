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
    public partial class ItemEditDialog : Form
    {
        private Item item;

        public ItemEditDialog(Item item, int slot)
        {
            InitializeComponent();
            this.item = item;
            numericUpDownAmount.Maximum = 99;

            comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBoxItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxItem.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxItem.Sorted = true;

            this.Text = string.Format("Editing Slot: [{0}]", slot);
            this.item = item;
            numericUpDownAmount.Value = item.ItemAmount;

            for (int i = 0; i < GameConstants.ItemList.Length; i++)
            {
                comboBoxItem.Items.Add(GameConstants.ItemList[i]);
            }

            for (int i = 0; i < comboBoxItem.Items.Count; i++)
            {
                if (comboBoxItem.Items[i] == GameConstants.ItemList[item.ItemID])
                {
                    comboBoxItem.SelectedIndex = i;
                    break;
                }
            }

            comboBoxItem.Refresh();

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxItem.SelectedItem == null || !GameConstants.ItemList.Contains(comboBoxItem.SelectedItem.ToString()))
            {
                return;
            }

            this.item.ItemID = GameConstants.GetItemIDFromName(comboBoxItem.SelectedItem.ToString());
            this.item.ItemAmount = (UInt32)numericUpDownAmount.Value;

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
