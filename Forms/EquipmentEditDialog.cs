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
using System.IO;

namespace APMMHXSaveEditor.Forms
{
    public partial class EquipmentEditDialog : Form
    {
        private Equipment equipment;

        public EquipmentEditDialog(Equipment equipment)
        {
            InitializeComponent();
            numericUpDownItemID.Maximum = 255;
            numericUpDownLevel.Maximum = 255;
            textBoxDecoration1.MaxLength = 4;
            textBoxDecoration2.MaxLength = 4;
            textBoxDecoration3.MaxLength = 4;
            comboBoxEquipmentType.DataSource = GameConstants.EquipmentTypes;
            this.equipment = equipment;
            loadData();
        }

        private void loadData()
        {
            comboBoxEquipmentType.SelectedIndex = equipment.EquipmentBytes[0];
            numericUpDownItemID.Value = equipment.EquipmentBytes[1];
            numericUpDownLevel.Value = equipment.EquipmentBytes[2] + 1;

            textBoxDecoration1.Text = string.Format("{0:X2}{1:X2}", equipment.EquipmentBytes[6], equipment.EquipmentBytes[7]);
            textBoxDecoration2.Text = string.Format("{0:X2}{1:X2}", equipment.EquipmentBytes[8], equipment.EquipmentBytes[9]);
            textBoxDecoration3.Text = string.Format("{0:X2}{1:X2}", equipment.EquipmentBytes[10], equipment.EquipmentBytes[11]);
        }

        private void saveData()
        {
            if (textBoxDecoration1.Text.Length != 4 || textBoxDecoration2.Text.Length != 4 || textBoxDecoration3.Text.Length != 4)
            {
                throw new Exception("One of the decorations is invalid");
            }

            //Anyone got a better way at this?
            equipment.EquipmentBytes[0] = (byte)comboBoxEquipmentType.SelectedIndex;
            equipment.EquipmentBytes[1] = (byte)numericUpDownItemID.Value;
            equipment.EquipmentBytes[2] = (byte)(numericUpDownLevel.Value - 1);
            equipment.EquipmentBytes[6] = Convert.ToByte(textBoxDecoration1.Text.Substring(0, 2), 16);
            equipment.EquipmentBytes[7] = Convert.ToByte(textBoxDecoration1.Text.Substring(2, 2), 16);
            equipment.EquipmentBytes[8] = Convert.ToByte(textBoxDecoration2.Text.Substring(0, 2), 16);
            equipment.EquipmentBytes[9] = Convert.ToByte(textBoxDecoration2.Text.Substring(2, 2), 16);
            equipment.EquipmentBytes[10] = Convert.ToByte(textBoxDecoration3.Text.Substring(0, 2), 16);
            equipment.EquipmentBytes[11] = Convert.ToByte(textBoxDecoration3.Text.Substring(2, 2), 16);
        }

        private void EquipmentEditDialog_Load(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            saveData();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Equipment temp = new Equipment(equipment);
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "EquipmentFile (*.eqp)|*.eqp|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        saveData();
                        File.WriteAllBytes(sfd.FileName, equipment.EquipmentBytes);
                        this.equipment = temp;
                        MessageBox.Show(string.Format("Exported equipment to {0}", sfd.FileName), "Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Unsucessful");
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Equipment temp = new Equipment(equipment);
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "EquipmentFile (*.eqp)|*.eqp|All files (*.*)|*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    ofd.Dispose();
                    return;
                }

                byte[] fileData = File.ReadAllBytes(ofd.FileName);
                if (fileData.Length != Constants.SIZEOF_EQUIPMENT)
                {
                    MessageBox.Show("Invalid Equipment", "Error");
                    return;
                }

                this.equipment.EquipmentBytes = fileData;
                loadData();

                ofd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error");
                this.equipment = temp;
            }
        }
    }
}
