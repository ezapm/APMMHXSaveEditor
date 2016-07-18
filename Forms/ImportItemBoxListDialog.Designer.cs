namespace APMMHXSaveEditor.Forms
{
    partial class ImportItemBoxListDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.labelDest = new System.Windows.Forms.Label();
            this.comboBoxDest = new System.Windows.Forms.ComboBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Location = new System.Drawing.Point(44, 6);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(208, 20);
            this.textBoxFileLocation.TabIndex = 1;
            // 
            // labelDest
            // 
            this.labelDest.AutoSize = true;
            this.labelDest.Location = new System.Drawing.Point(12, 29);
            this.labelDest.Name = "labelDest";
            this.labelDest.Size = new System.Drawing.Size(29, 13);
            this.labelDest.TabIndex = 2;
            this.labelDest.Text = "Dest";
            // 
            // comboBoxDest
            // 
            this.comboBoxDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDest.FormattingEnabled = true;
            this.comboBoxDest.Items.AddRange(new object[] {
            "Box 1",
            "Box 2",
            "Box 3",
            "Box 4",
            "Box 5",
            "Box 6",
            "Box 7",
            "Box 8",
            "Box 9",
            "Box 10",
            "Box 11",
            "Box 12",
            "Box 13",
            "Box 14"});
            this.comboBoxDest.Location = new System.Drawing.Point(44, 26);
            this.comboBoxDest.Name = "comboBoxDest";
            this.comboBoxDest.Size = new System.Drawing.Size(208, 21);
            this.comboBoxDest.TabIndex = 3;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(258, 4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(63, 23);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(246, 53);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(165, 53);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // ImportItemBoxListDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(328, 82);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.comboBoxDest);
            this.Controls.Add(this.labelDest);
            this.Controls.Add(this.textBoxFileLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportItemBoxListDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Item List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Label labelDest;
        private System.Windows.Forms.ComboBox comboBoxDest;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}