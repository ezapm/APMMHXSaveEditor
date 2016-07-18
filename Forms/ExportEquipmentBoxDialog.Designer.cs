namespace APMMHXSaveEditor.Forms
{
    partial class ExportEquipmentBoxDialog
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxSelectedBox = new System.Windows.Forms.ComboBox();
            this.labelSelectedBox = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(96, 33);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxSelectedBox
            // 
            this.comboBoxSelectedBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedBox.FormattingEnabled = true;
            this.comboBoxSelectedBox.Items.AddRange(new object[] {
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
            this.comboBoxSelectedBox.Location = new System.Drawing.Point(44, 6);
            this.comboBoxSelectedBox.Name = "comboBoxSelectedBox";
            this.comboBoxSelectedBox.Size = new System.Drawing.Size(208, 21);
            this.comboBoxSelectedBox.TabIndex = 17;
            // 
            // labelSelectedBox
            // 
            this.labelSelectedBox.AutoSize = true;
            this.labelSelectedBox.Location = new System.Drawing.Point(12, 9);
            this.labelSelectedBox.Name = "labelSelectedBox";
            this.labelSelectedBox.Size = new System.Drawing.Size(25, 13);
            this.labelSelectedBox.TabIndex = 16;
            this.labelSelectedBox.Text = "Box";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(177, 33);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ExportEquipmentBoxDialog
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(259, 59);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxSelectedBox);
            this.Controls.Add(this.labelSelectedBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportEquipmentBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Equipment Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxSelectedBox;
        private System.Windows.Forms.Label labelSelectedBox;
        private System.Windows.Forms.Button buttonClose;
    }
}