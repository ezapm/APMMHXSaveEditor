namespace APMMHXSaveEditor.Forms
{
    partial class ShoutoutsEditDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlShoutOutEditor = new System.Windows.Forms.TabControl();
            this.tabPageShoutOuts = new System.Windows.Forms.TabPage();
            this.listViewShououts = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAutomaticShoutOuts = new System.Windows.Forms.TabPage();
            this.listViewAutomaticShoutouts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlShoutOutEditor.SuspendLayout();
            this.tabPageShoutOuts.SuspendLayout();
            this.tabPageAutomaticShoutOuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlShoutOutEditor
            // 
            this.tabControlShoutOutEditor.Controls.Add(this.tabPageShoutOuts);
            this.tabControlShoutOutEditor.Controls.Add(this.tabPageAutomaticShoutOuts);
            this.tabControlShoutOutEditor.Location = new System.Drawing.Point(1, 12);
            this.tabControlShoutOutEditor.Name = "tabControlShoutOutEditor";
            this.tabControlShoutOutEditor.SelectedIndex = 0;
            this.tabControlShoutOutEditor.Size = new System.Drawing.Size(514, 238);
            this.tabControlShoutOutEditor.TabIndex = 0;
            // 
            // tabPageShoutOuts
            // 
            this.tabPageShoutOuts.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageShoutOuts.Controls.Add(this.listViewShououts);
            this.tabPageShoutOuts.Location = new System.Drawing.Point(4, 22);
            this.tabPageShoutOuts.Name = "tabPageShoutOuts";
            this.tabPageShoutOuts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShoutOuts.Size = new System.Drawing.Size(506, 212);
            this.tabPageShoutOuts.TabIndex = 0;
            this.tabPageShoutOuts.Text = "Shoutouts";
            // 
            // listViewShououts
            // 
            this.listViewShououts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShououts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewShououts.FullRowSelect = true;
            this.listViewShououts.GridLines = true;
            this.listViewShououts.Location = new System.Drawing.Point(-2, -2);
            this.listViewShououts.Name = "listViewShououts";
            this.listViewShououts.Size = new System.Drawing.Size(510, 218);
            this.listViewShououts.TabIndex = 9;
            this.listViewShououts.UseCompatibleStateImageBehavior = false;
            this.listViewShououts.View = System.Windows.Forms.View.Details;
            this.listViewShououts.DoubleClick += new System.EventHandler(this.listViewShououts_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Slot";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Shoutout";
            this.columnHeader4.Width = 425;
            // 
            // tabPageAutomaticShoutOuts
            // 
            this.tabPageAutomaticShoutOuts.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAutomaticShoutOuts.Controls.Add(this.listViewAutomaticShoutouts);
            this.tabPageAutomaticShoutOuts.Location = new System.Drawing.Point(4, 22);
            this.tabPageAutomaticShoutOuts.Name = "tabPageAutomaticShoutOuts";
            this.tabPageAutomaticShoutOuts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAutomaticShoutOuts.Size = new System.Drawing.Size(506, 212);
            this.tabPageAutomaticShoutOuts.TabIndex = 1;
            this.tabPageAutomaticShoutOuts.Text = "Automatic Shoutouts";
            // 
            // listViewAutomaticShoutouts
            // 
            this.listViewAutomaticShoutouts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAutomaticShoutouts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAutomaticShoutouts.FullRowSelect = true;
            this.listViewAutomaticShoutouts.GridLines = true;
            this.listViewAutomaticShoutouts.Location = new System.Drawing.Point(-2, -2);
            this.listViewAutomaticShoutouts.Name = "listViewAutomaticShoutouts";
            this.listViewAutomaticShoutouts.Size = new System.Drawing.Size(510, 218);
            this.listViewAutomaticShoutouts.TabIndex = 8;
            this.listViewAutomaticShoutouts.UseCompatibleStateImageBehavior = false;
            this.listViewAutomaticShoutouts.View = System.Windows.Forms.View.Details;
            this.listViewAutomaticShoutouts.DoubleClick += new System.EventHandler(this.listViewAutomaticShoutouts_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Slot";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Shoutout";
            this.columnHeader2.Width = 425;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(438, 252);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ShoutoutsEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(516, 281);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabControlShoutOutEditor);
            this.Name = "ShoutoutsEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Shoutouts";
            this.Load += new System.EventHandler(this.ShoutoutsEditDialog_Load);
            this.tabControlShoutOutEditor.ResumeLayout(false);
            this.tabPageShoutOuts.ResumeLayout(false);
            this.tabPageAutomaticShoutOuts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlShoutOutEditor;
        private System.Windows.Forms.TabPage tabPageShoutOuts;
        private System.Windows.Forms.TabPage tabPageAutomaticShoutOuts;
        private System.Windows.Forms.ListView listViewAutomaticShoutouts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewShououts;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonClose;
    }
}