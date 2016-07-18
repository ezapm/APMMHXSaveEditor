using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using APMMHXSaveEditor.Data;
using System.IO;

namespace APMMHXSaveEditor.Forms
{
    public partial class ExportEquipmentBoxDialog : Form
    {
        Equipment[] equips;
        public ExportEquipmentBoxDialog(Equipment[] equips)
        {
            InitializeComponent();
            comboBoxSelectedBox.SelectedIndex = 0;
            this.equips = equips;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Equipment Box (*.eqpbox)|*.eqpbox|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.FileName = string.Format("Equipment Box {0}", (comboBoxSelectedBox.SelectedIndex + 1));

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        int equipIndex = comboBoxSelectedBox.SelectedIndex * 100;
                        byte[] fileData = new byte[Constants.SIZEOF_EQUIPMENT * 100];
                        for (int i = 0; i < 100; i++)
                        {
                            Buffer.BlockCopy(equips[equipIndex + i].EquipmentBytes, 0, fileData, (i * Constants.SIZEOF_EQUIPMENT), Constants.SIZEOF_EQUIPMENT);
                        }
                        File.WriteAllBytes(sfd.FileName, fileData);

                        MessageBox.Show("Save Complete", "Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
