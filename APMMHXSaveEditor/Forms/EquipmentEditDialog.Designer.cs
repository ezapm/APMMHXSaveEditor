namespace APMMHXSaveEditor.Forms
{
    partial class EquipmentEditDialog
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
            this.labelEquipmentType = new System.Windows.Forms.Label();
            this.comboBoxEquipmentType = new System.Windows.Forms.ComboBox();
            this.labelItemID = new System.Windows.Forms.Label();
            this.numericUpDownItemID = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelDec1 = new System.Windows.Forms.Label();
            this.textBoxDecoration1 = new System.Windows.Forms.TextBox();
            this.textBoxDecoration2 = new System.Windows.Forms.TextBox();
            this.labelDec2 = new System.Windows.Forms.Label();
            this.textBoxDecoration3 = new System.Windows.Forms.TextBox();
            this.labelDec3 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEquipmentType
            // 
            this.labelEquipmentType.AutoSize = true;
            this.labelEquipmentType.Location = new System.Drawing.Point(12, 9);
            this.labelEquipmentType.Name = "labelEquipmentType";
            this.labelEquipmentType.Size = new System.Drawing.Size(84, 13);
            this.labelEquipmentType.TabIndex = 0;
            this.labelEquipmentType.Text = "Equipment Type";
            // 
            // comboBoxEquipmentType
            // 
            this.comboBoxEquipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEquipmentType.FormattingEnabled = true;
            this.comboBoxEquipmentType.Location = new System.Drawing.Point(15, 25);
            this.comboBoxEquipmentType.Name = "comboBoxEquipmentType";
            this.comboBoxEquipmentType.Size = new System.Drawing.Size(112, 21);
            this.comboBoxEquipmentType.TabIndex = 1;
            // 
            // labelItemID
            // 
            this.labelItemID.AutoSize = true;
            this.labelItemID.Location = new System.Drawing.Point(128, 9);
            this.labelItemID.Name = "labelItemID";
            this.labelItemID.Size = new System.Drawing.Size(41, 13);
            this.labelItemID.TabIndex = 2;
            this.labelItemID.Text = "Item ID";
            // 
            // numericUpDownItemID
            // 
            this.numericUpDownItemID.Location = new System.Drawing.Point(131, 25);
            this.numericUpDownItemID.Name = "numericUpDownItemID";
            this.numericUpDownItemID.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownItemID.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(266, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(185, 113);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelDec1
            // 
            this.labelDec1.AutoSize = true;
            this.labelDec1.Location = new System.Drawing.Point(12, 49);
            this.labelDec1.Name = "labelDec1";
            this.labelDec1.Size = new System.Drawing.Size(68, 13);
            this.labelDec1.TabIndex = 6;
            this.labelDec1.Text = "Decoration 1";
            // 
            // textBoxDecoration1
            // 
            this.textBoxDecoration1.Location = new System.Drawing.Point(15, 65);
            this.textBoxDecoration1.Name = "textBoxDecoration1";
            this.textBoxDecoration1.Size = new System.Drawing.Size(100, 20);
            this.textBoxDecoration1.TabIndex = 7;
            // 
            // textBoxDecoration2
            // 
            this.textBoxDecoration2.Location = new System.Drawing.Point(123, 65);
            this.textBoxDecoration2.Name = "textBoxDecoration2";
            this.textBoxDecoration2.Size = new System.Drawing.Size(100, 20);
            this.textBoxDecoration2.TabIndex = 9;
            // 
            // labelDec2
            // 
            this.labelDec2.AutoSize = true;
            this.labelDec2.Location = new System.Drawing.Point(120, 49);
            this.labelDec2.Name = "labelDec2";
            this.labelDec2.Size = new System.Drawing.Size(68, 13);
            this.labelDec2.TabIndex = 8;
            this.labelDec2.Text = "Decoration 2";
            // 
            // textBoxDecoration3
            // 
            this.textBoxDecoration3.Location = new System.Drawing.Point(230, 65);
            this.textBoxDecoration3.Name = "textBoxDecoration3";
            this.textBoxDecoration3.Size = new System.Drawing.Size(100, 20);
            this.textBoxDecoration3.TabIndex = 11;
            // 
            // labelDec3
            // 
            this.labelDec3.AutoSize = true;
            this.labelDec3.Location = new System.Drawing.Point(227, 49);
            this.labelDec3.Name = "labelDec3";
            this.labelDec3.Size = new System.Drawing.Size(71, 13);
            this.labelDec3.TabIndex = 10;
            this.labelDec3.Text = "Decoration 3 ";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(5, 113);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 12;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(86, 113);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 13;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(227, 9);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 4;
            this.labelLevel.Text = "Level";
            // 
            // numericUpDownLevel
            // 
            this.numericUpDownLevel.Location = new System.Drawing.Point(230, 26);
            this.numericUpDownLevel.Name = "numericUpDownLevel";
            this.numericUpDownLevel.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownLevel.TabIndex = 5;
            // 
            // EquipmentEditDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(346, 142);
            this.Controls.Add(this.numericUpDownLevel);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.textBoxDecoration3);
            this.Controls.Add(this.labelDec3);
            this.Controls.Add(this.textBoxDecoration2);
            this.Controls.Add(this.labelDec2);
            this.Controls.Add(this.textBoxDecoration1);
            this.Controls.Add(this.labelDec1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericUpDownItemID);
            this.Controls.Add(this.labelItemID);
            this.Controls.Add(this.comboBoxEquipmentType);
            this.Controls.Add(this.labelEquipmentType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Equipment Editor";
            this.Load += new System.EventHandler(this.EquipmentEditDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEquipmentType;
        private System.Windows.Forms.ComboBox comboBoxEquipmentType;
        private System.Windows.Forms.Label labelItemID;
        private System.Windows.Forms.NumericUpDown numericUpDownItemID;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelDec1;
        private System.Windows.Forms.TextBox textBoxDecoration1;
        private System.Windows.Forms.TextBox textBoxDecoration2;
        private System.Windows.Forms.Label labelDec2;
        private System.Windows.Forms.TextBox textBoxDecoration3;
        private System.Windows.Forms.Label labelDec3;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownLevel;
    }
}