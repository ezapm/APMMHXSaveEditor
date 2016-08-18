using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APMMHXSaveEditor.Forms
{
    public partial class ShoutoutsEditDialog : Form
    {
        public string[] Shoutouts { get; set; }
        public string[] AutomaticShoutouts { get; set; }

        public ShoutoutsEditDialog(string[] shoutOuts, string[] automaticShoutouts)
        {
            InitializeComponent();
            this.Shoutouts = shoutOuts;
            this.AutomaticShoutouts = automaticShoutouts;

            loadShoutouts();
            loadAutomaticShoutouts();
        }

        private void loadShoutouts()
        {
            listViewShououts.Items.Clear();
            for (int i = 0; i < Shoutouts.Length; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(Shoutouts[i]);
                listViewShououts.Items.Add(lvi);
            }
        }

        private void loadAutomaticShoutouts()
        {
            listViewAutomaticShoutouts.Items.Clear();
            for (int i = 0; i < AutomaticShoutouts.Length; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(AutomaticShoutouts[i]);
                listViewAutomaticShoutouts.Items.Add(lvi);
            }
        }

        private void ShoutoutsEditDialog_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void listViewShououts_DoubleClick(object sender, EventArgs e)
        {
            int itemSelected = listViewShououts.SelectedItems[0].Index;
            ShoutoutTextEditDialog sted = new ShoutoutTextEditDialog(Shoutouts[itemSelected]);
            if (sted.ShowDialog() == DialogResult.OK)
            {
                Shoutouts[itemSelected] = sted.Shoutout;
                loadShoutouts();
                listViewShououts.Items[itemSelected].Selected = true;
                listViewShououts.TopItem = listViewShououts.SelectedItems[0];
            }
            sted.Dispose();
        }

        private void listViewAutomaticShoutouts_DoubleClick(object sender, EventArgs e)
        {
            int itemSelected = listViewAutomaticShoutouts.SelectedItems[0].Index;
            ShoutoutTextEditDialog sted = new ShoutoutTextEditDialog(AutomaticShoutouts[itemSelected]);
            if (sted.ShowDialog() == DialogResult.OK)
            {
                AutomaticShoutouts[itemSelected] = sted.Shoutout;
                loadAutomaticShoutouts();
                listViewAutomaticShoutouts.Items[itemSelected].Selected = true;
                listViewAutomaticShoutouts.TopItem = listViewAutomaticShoutouts.SelectedItems[0];
            }
            sted.Dispose();
        }
    }
}
