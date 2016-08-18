namespace APMMHXSaveEditor.Forms
{
    partial class ShoutoutTextEditDialog
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
            this.labelShoutout = new System.Windows.Forms.Label();
            this.textBoxShoutout = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxLimit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelShoutout
            // 
            this.labelShoutout.AutoSize = true;
            this.labelShoutout.Location = new System.Drawing.Point(12, 9);
            this.labelShoutout.Name = "labelShoutout";
            this.labelShoutout.Size = new System.Drawing.Size(50, 13);
            this.labelShoutout.TabIndex = 0;
            this.labelShoutout.Text = "Shoutout";
            // 
            // textBoxShoutout
            // 
            this.textBoxShoutout.Location = new System.Drawing.Point(15, 25);
            this.textBoxShoutout.Name = "textBoxShoutout";
            this.textBoxShoutout.Size = new System.Drawing.Size(297, 20);
            this.textBoxShoutout.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(156, 51);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(237, 51);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxLimit
            // 
            this.checkBoxLimit.AutoSize = true;
            this.checkBoxLimit.Location = new System.Drawing.Point(15, 51);
            this.checkBoxLimit.Name = "checkBoxLimit";
            this.checkBoxLimit.Size = new System.Drawing.Size(47, 17);
            this.checkBoxLimit.TabIndex = 4;
            this.checkBoxLimit.Text = "Limit";
            this.checkBoxLimit.UseVisualStyleBackColor = true;
            this.checkBoxLimit.CheckedChanged += new System.EventHandler(this.checkBoxLimit_CheckedChanged);
            // 
            // ShoutoutTextEditDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(324, 80);
            this.Controls.Add(this.checkBoxLimit);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxShoutout);
            this.Controls.Add(this.labelShoutout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShoutoutTextEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Shoutout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShoutout;
        private System.Windows.Forms.TextBox textBoxShoutout;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxLimit;
    }
}