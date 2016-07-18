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
    public partial class ImportItemBoxListDialog : Form
    {
        private Item[] items;

        public ImportItemBoxListDialog(Item[] items)
        {
            InitializeComponent();
            this.items = items;
            comboBoxDest.SelectedIndex = 0;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Item List (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    ofd.Dispose();
                    return;
                }

                textBoxFileLocation.Text = ofd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxFileLocation.Text == "")
            {
                MessageBox.Show("Select a list first!", "Error");
                return;
            }

            try
            {
                Item[] newItems = getItemsFromList(File.ReadAllText(textBoxFileLocation.Text));
                int itemIndex = (comboBoxDest.SelectedIndex * 100);
                for (int i = 0; i < newItems.Length && (itemIndex + i) < Constants.TOTAL_ITEM_BOX_SLOTS; i++)
                {
                    items[itemIndex + i] = newItems[i];
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private Item[] getItemsFromList(string fileData)
        {
            string[] seperateData = fileData.Split(',');
            Item[] items = new Item[seperateData.Length];

            for (int i = 0; i < seperateData.Length; i++)
            {
                items[i] = new Item(UInt32.Parse(seperateData[i]), 99); 
            }

            return items;
        }

    }
}
