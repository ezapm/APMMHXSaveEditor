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
    public partial class ImportEquipmentBoxDialog : Form
    {
        private Equipment[] equips;
        public ImportEquipmentBoxDialog(Equipment[] equips)
        {
            InitializeComponent();
            this.equips = equips;
            comboBoxDest.SelectedIndex = 0;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Equipment Box (*.eqpbox)|*.eqpbox|All files (*.*)|*.*";
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
            if (textBoxFileLocation.Text == "")
            {
                MessageBox.Show("Select a list first!", "Error");
                return;
            }

            try
            {
                byte[] fileData = File.ReadAllBytes(textBoxFileLocation.Text);
                if(fileData.Length != (100 * Constants.SIZEOF_EQUIPMENT))
                {
                    MessageBox.Show("Invalid file!", "Error");
                    return;
                }

                int eqpIndex = (comboBoxDest.SelectedIndex * 100);
                for (int i = 0; i < 100; i++)
                {
                    Buffer.BlockCopy(fileData, (i * Constants.SIZEOF_EQUIPMENT), equips[eqpIndex + i].EquipmentBytes, 0, Constants.SIZEOF_EQUIPMENT);
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
            this.DialogResult = DialogResult.OK;
        }
    }
}
