namespace APMMHXSaveEditor.Forms
{
    partial class PalicoEditDialog
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
            this.tabControlPalico = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.textBoxLearnedSkillRNG = new System.Windows.Forms.TextBox();
            this.textBoxLearnedActionRNG = new System.Windows.Forms.TextBox();
            this.textBoxGreetings = new System.Windows.Forms.TextBox();
            this.labelGretings = new System.Windows.Forms.Label();
            this.textBoxPreviousOwner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNameGiver = new System.Windows.Forms.TextBox();
            this.labelNameGiver = new System.Windows.Forms.Label();
            this.labelLearnedSkillRNG = new System.Windows.Forms.Label();
            this.labelLearnedActionRNG = new System.Windows.Forms.Label();
            this.numericUpDownTarget = new System.Windows.Forms.NumericUpDown();
            this.labelTarget = new System.Windows.Forms.Label();
            this.comboBoxForte = new System.Windows.Forms.ComboBox();
            this.numericUpDownEnthusiasm = new System.Windows.Forms.NumericUpDown();
            this.labelEnthusiasm = new System.Windows.Forms.Label();
            this.labelForte = new System.Windows.Forms.Label();
            this.numericUpDownXP = new System.Windows.Forms.NumericUpDown();
            this.labelXP = new System.Windows.Forms.Label();
            this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.labelLevel = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tabPageStyle = new System.Windows.Forms.TabPage();
            this.textBoxVestRGBA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRightEyeRGBA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLeftEyeRGBA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCoatRGBA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageEquippedActions = new System.Windows.Forms.TabPage();
            this.listViewEquippedAction = new System.Windows.Forms.ListView();
            this.columnHeaderEqActionSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEqAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageEquippedSkills = new System.Windows.Forms.TabPage();
            this.listViewEquippedSkills = new System.Windows.Forms.ListView();
            this.columnHeaderEqSkillSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEqSkill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageLearnedActions = new System.Windows.Forms.TabPage();
            this.listViewLearnedActions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageLearnedSkills = new System.Windows.Forms.TabPage();
            this.listViewLearnedSkills = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.tabControlPalico.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnthusiasm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
            this.tabPageStyle.SuspendLayout();
            this.tabPageEquippedActions.SuspendLayout();
            this.tabPageEquippedSkills.SuspendLayout();
            this.tabPageLearnedActions.SuspendLayout();
            this.tabPageLearnedSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPalico
            // 
            this.tabControlPalico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPalico.Controls.Add(this.tabPageGeneral);
            this.tabControlPalico.Controls.Add(this.tabPageStyle);
            this.tabControlPalico.Controls.Add(this.tabPageEquippedActions);
            this.tabControlPalico.Controls.Add(this.tabPageEquippedSkills);
            this.tabControlPalico.Controls.Add(this.tabPageLearnedActions);
            this.tabControlPalico.Controls.Add(this.tabPageLearnedSkills);
            this.tabControlPalico.Location = new System.Drawing.Point(1, 1);
            this.tabControlPalico.Name = "tabControlPalico";
            this.tabControlPalico.SelectedIndex = 0;
            this.tabControlPalico.Size = new System.Drawing.Size(445, 229);
            this.tabControlPalico.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGeneral.Controls.Add(this.textBoxLearnedSkillRNG);
            this.tabPageGeneral.Controls.Add(this.textBoxLearnedActionRNG);
            this.tabPageGeneral.Controls.Add(this.textBoxGreetings);
            this.tabPageGeneral.Controls.Add(this.labelGretings);
            this.tabPageGeneral.Controls.Add(this.textBoxPreviousOwner);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.textBoxNameGiver);
            this.tabPageGeneral.Controls.Add(this.labelNameGiver);
            this.tabPageGeneral.Controls.Add(this.labelLearnedSkillRNG);
            this.tabPageGeneral.Controls.Add(this.labelLearnedActionRNG);
            this.tabPageGeneral.Controls.Add(this.numericUpDownTarget);
            this.tabPageGeneral.Controls.Add(this.labelTarget);
            this.tabPageGeneral.Controls.Add(this.comboBoxForte);
            this.tabPageGeneral.Controls.Add(this.numericUpDownEnthusiasm);
            this.tabPageGeneral.Controls.Add(this.labelEnthusiasm);
            this.tabPageGeneral.Controls.Add(this.labelForte);
            this.tabPageGeneral.Controls.Add(this.numericUpDownXP);
            this.tabPageGeneral.Controls.Add(this.labelXP);
            this.tabPageGeneral.Controls.Add(this.numericUpDownLevel);
            this.tabPageGeneral.Controls.Add(this.labelLevel);
            this.tabPageGeneral.Controls.Add(this.textBoxName);
            this.tabPageGeneral.Controls.Add(this.labelName);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(437, 203);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            // 
            // textBoxLearnedSkillRNG
            // 
            this.textBoxLearnedSkillRNG.Location = new System.Drawing.Point(143, 98);
            this.textBoxLearnedSkillRNG.Name = "textBoxLearnedSkillRNG";
            this.textBoxLearnedSkillRNG.Size = new System.Drawing.Size(120, 20);
            this.textBoxLearnedSkillRNG.TabIndex = 17;
            // 
            // textBoxLearnedActionRNG
            // 
            this.textBoxLearnedActionRNG.Location = new System.Drawing.Point(10, 98);
            this.textBoxLearnedActionRNG.Name = "textBoxLearnedActionRNG";
            this.textBoxLearnedActionRNG.Size = new System.Drawing.Size(120, 20);
            this.textBoxLearnedActionRNG.TabIndex = 15;
            // 
            // textBoxGreetings
            // 
            this.textBoxGreetings.Location = new System.Drawing.Point(10, 176);
            this.textBoxGreetings.Name = "textBoxGreetings";
            this.textBoxGreetings.Size = new System.Drawing.Size(413, 20);
            this.textBoxGreetings.TabIndex = 23;
            // 
            // labelGretings
            // 
            this.labelGretings.AutoSize = true;
            this.labelGretings.Location = new System.Drawing.Point(7, 160);
            this.labelGretings.Name = "labelGretings";
            this.labelGretings.Size = new System.Drawing.Size(52, 13);
            this.labelGretings.TabIndex = 22;
            this.labelGretings.Text = "Greetings";
            // 
            // textBoxPreviousOwner
            // 
            this.textBoxPreviousOwner.Location = new System.Drawing.Point(226, 137);
            this.textBoxPreviousOwner.Name = "textBoxPreviousOwner";
            this.textBoxPreviousOwner.Size = new System.Drawing.Size(197, 20);
            this.textBoxPreviousOwner.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Previous Owner";
            // 
            // textBoxNameGiver
            // 
            this.textBoxNameGiver.Location = new System.Drawing.Point(10, 137);
            this.textBoxNameGiver.Name = "textBoxNameGiver";
            this.textBoxNameGiver.Size = new System.Drawing.Size(197, 20);
            this.textBoxNameGiver.TabIndex = 19;
            // 
            // labelNameGiver
            // 
            this.labelNameGiver.AutoSize = true;
            this.labelNameGiver.Location = new System.Drawing.Point(7, 121);
            this.labelNameGiver.Name = "labelNameGiver";
            this.labelNameGiver.Size = new System.Drawing.Size(63, 13);
            this.labelNameGiver.TabIndex = 18;
            this.labelNameGiver.Text = "Name Giver";
            // 
            // labelLearnedSkillRNG
            // 
            this.labelLearnedSkillRNG.AutoSize = true;
            this.labelLearnedSkillRNG.Location = new System.Drawing.Point(140, 82);
            this.labelLearnedSkillRNG.Name = "labelLearnedSkillRNG";
            this.labelLearnedSkillRNG.Size = new System.Drawing.Size(98, 13);
            this.labelLearnedSkillRNG.TabIndex = 16;
            this.labelLearnedSkillRNG.Text = "Learned Skill RNG ";
            // 
            // labelLearnedActionRNG
            // 
            this.labelLearnedActionRNG.AutoSize = true;
            this.labelLearnedActionRNG.Location = new System.Drawing.Point(7, 82);
            this.labelLearnedActionRNG.Name = "labelLearnedActionRNG";
            this.labelLearnedActionRNG.Size = new System.Drawing.Size(106, 13);
            this.labelLearnedActionRNG.TabIndex = 14;
            this.labelLearnedActionRNG.Text = "Learned Action RNG";
            // 
            // numericUpDownTarget
            // 
            this.numericUpDownTarget.Location = new System.Drawing.Point(303, 59);
            this.numericUpDownTarget.Name = "numericUpDownTarget";
            this.numericUpDownTarget.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTarget.TabIndex = 11;
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(300, 42);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(38, 13);
            this.labelTarget.TabIndex = 10;
            this.labelTarget.Text = "Target";
            // 
            // comboBoxForte
            // 
            this.comboBoxForte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForte.FormattingEnabled = true;
            this.comboBoxForte.Location = new System.Drawing.Point(10, 58);
            this.comboBoxForte.Name = "comboBoxForte";
            this.comboBoxForte.Size = new System.Drawing.Size(151, 21);
            this.comboBoxForte.TabIndex = 7;
            // 
            // numericUpDownEnthusiasm
            // 
            this.numericUpDownEnthusiasm.Location = new System.Drawing.Point(170, 59);
            this.numericUpDownEnthusiasm.Name = "numericUpDownEnthusiasm";
            this.numericUpDownEnthusiasm.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEnthusiasm.TabIndex = 9;
            // 
            // labelEnthusiasm
            // 
            this.labelEnthusiasm.AutoSize = true;
            this.labelEnthusiasm.Location = new System.Drawing.Point(167, 42);
            this.labelEnthusiasm.Name = "labelEnthusiasm";
            this.labelEnthusiasm.Size = new System.Drawing.Size(61, 13);
            this.labelEnthusiasm.TabIndex = 8;
            this.labelEnthusiasm.Text = "Enthusiasm";
            // 
            // labelForte
            // 
            this.labelForte.AutoSize = true;
            this.labelForte.Location = new System.Drawing.Point(7, 42);
            this.labelForte.Name = "labelForte";
            this.labelForte.Size = new System.Drawing.Size(31, 13);
            this.labelForte.TabIndex = 6;
            this.labelForte.Text = "Forte";
            // 
            // numericUpDownXP
            // 
            this.numericUpDownXP.Location = new System.Drawing.Point(303, 20);
            this.numericUpDownXP.Name = "numericUpDownXP";
            this.numericUpDownXP.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownXP.TabIndex = 5;
            // 
            // labelXP
            // 
            this.labelXP.AutoSize = true;
            this.labelXP.Location = new System.Drawing.Point(300, 3);
            this.labelXP.Name = "labelXP";
            this.labelXP.Size = new System.Drawing.Size(28, 13);
            this.labelXP.TabIndex = 4;
            this.labelXP.Text = "EXP";
            // 
            // numericUpDownLevel
            // 
            this.numericUpDownLevel.Location = new System.Drawing.Point(170, 19);
            this.numericUpDownLevel.Name = "numericUpDownLevel";
            this.numericUpDownLevel.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLevel.TabIndex = 3;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(167, 3);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Level";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(10, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(151, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(7, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // tabPageStyle
            // 
            this.tabPageStyle.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStyle.Controls.Add(this.textBoxVestRGBA);
            this.tabPageStyle.Controls.Add(this.label5);
            this.tabPageStyle.Controls.Add(this.textBoxRightEyeRGBA);
            this.tabPageStyle.Controls.Add(this.label4);
            this.tabPageStyle.Controls.Add(this.textBoxLeftEyeRGBA);
            this.tabPageStyle.Controls.Add(this.label2);
            this.tabPageStyle.Controls.Add(this.textBoxCoatRGBA);
            this.tabPageStyle.Controls.Add(this.label1);
            this.tabPageStyle.Location = new System.Drawing.Point(4, 22);
            this.tabPageStyle.Name = "tabPageStyle";
            this.tabPageStyle.Size = new System.Drawing.Size(437, 203);
            this.tabPageStyle.TabIndex = 5;
            this.tabPageStyle.Text = "Style";
            // 
            // textBoxVestRGBA
            // 
            this.textBoxVestRGBA.Location = new System.Drawing.Point(10, 66);
            this.textBoxVestRGBA.Name = "textBoxVestRGBA";
            this.textBoxVestRGBA.Size = new System.Drawing.Size(122, 20);
            this.textBoxVestRGBA.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Vest RGBA Value";
            // 
            // textBoxRightEyeRGBA
            // 
            this.textBoxRightEyeRGBA.Location = new System.Drawing.Point(281, 27);
            this.textBoxRightEyeRGBA.Name = "textBoxRightEyeRGBA";
            this.textBoxRightEyeRGBA.Size = new System.Drawing.Size(122, 20);
            this.textBoxRightEyeRGBA.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Right Eye RGBA Value";
            // 
            // textBoxLeftEyeRGBA
            // 
            this.textBoxLeftEyeRGBA.Location = new System.Drawing.Point(147, 27);
            this.textBoxLeftEyeRGBA.Name = "textBoxLeftEyeRGBA";
            this.textBoxLeftEyeRGBA.Size = new System.Drawing.Size(122, 20);
            this.textBoxLeftEyeRGBA.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Left Eye RGBA Value";
            // 
            // textBoxCoatRGBA
            // 
            this.textBoxCoatRGBA.Location = new System.Drawing.Point(10, 27);
            this.textBoxCoatRGBA.Name = "textBoxCoatRGBA";
            this.textBoxCoatRGBA.Size = new System.Drawing.Size(122, 20);
            this.textBoxCoatRGBA.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Coat RGBA Value";
            // 
            // tabPageEquippedActions
            // 
            this.tabPageEquippedActions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageEquippedActions.Controls.Add(this.listViewEquippedAction);
            this.tabPageEquippedActions.Location = new System.Drawing.Point(4, 22);
            this.tabPageEquippedActions.Name = "tabPageEquippedActions";
            this.tabPageEquippedActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEquippedActions.Size = new System.Drawing.Size(437, 203);
            this.tabPageEquippedActions.TabIndex = 1;
            this.tabPageEquippedActions.Text = "Equipped Actions";
            // 
            // listViewEquippedAction
            // 
            this.listViewEquippedAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEquippedAction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEqActionSlot,
            this.columnHeaderEqAction});
            this.listViewEquippedAction.FullRowSelect = true;
            this.listViewEquippedAction.GridLines = true;
            this.listViewEquippedAction.Location = new System.Drawing.Point(-1, 0);
            this.listViewEquippedAction.Name = "listViewEquippedAction";
            this.listViewEquippedAction.Size = new System.Drawing.Size(438, 203);
            this.listViewEquippedAction.TabIndex = 0;
            this.listViewEquippedAction.UseCompatibleStateImageBehavior = false;
            this.listViewEquippedAction.View = System.Windows.Forms.View.Details;
            this.listViewEquippedAction.DoubleClick += new System.EventHandler(this.listViewEquippedAction_DoubleClick);
            // 
            // columnHeaderEqActionSlot
            // 
            this.columnHeaderEqActionSlot.Text = "Slot";
            // 
            // columnHeaderEqAction
            // 
            this.columnHeaderEqAction.Text = "Action";
            this.columnHeaderEqAction.Width = 350;
            // 
            // tabPageEquippedSkills
            // 
            this.tabPageEquippedSkills.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageEquippedSkills.Controls.Add(this.listViewEquippedSkills);
            this.tabPageEquippedSkills.Location = new System.Drawing.Point(4, 22);
            this.tabPageEquippedSkills.Name = "tabPageEquippedSkills";
            this.tabPageEquippedSkills.Size = new System.Drawing.Size(437, 203);
            this.tabPageEquippedSkills.TabIndex = 2;
            this.tabPageEquippedSkills.Text = "Equipped Skills";
            // 
            // listViewEquippedSkills
            // 
            this.listViewEquippedSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEquippedSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEqSkillSlot,
            this.columnHeaderEqSkill});
            this.listViewEquippedSkills.FullRowSelect = true;
            this.listViewEquippedSkills.GridLines = true;
            this.listViewEquippedSkills.Location = new System.Drawing.Point(-1, 0);
            this.listViewEquippedSkills.Name = "listViewEquippedSkills";
            this.listViewEquippedSkills.Size = new System.Drawing.Size(438, 203);
            this.listViewEquippedSkills.TabIndex = 1;
            this.listViewEquippedSkills.UseCompatibleStateImageBehavior = false;
            this.listViewEquippedSkills.View = System.Windows.Forms.View.Details;
            this.listViewEquippedSkills.DoubleClick += new System.EventHandler(this.listViewEquippedSkills_DoubleClick);
            // 
            // columnHeaderEqSkillSlot
            // 
            this.columnHeaderEqSkillSlot.Text = "Slot";
            // 
            // columnHeaderEqSkill
            // 
            this.columnHeaderEqSkill.Text = "Skill";
            this.columnHeaderEqSkill.Width = 350;
            // 
            // tabPageLearnedActions
            // 
            this.tabPageLearnedActions.Controls.Add(this.listViewLearnedActions);
            this.tabPageLearnedActions.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearnedActions.Name = "tabPageLearnedActions";
            this.tabPageLearnedActions.Size = new System.Drawing.Size(437, 203);
            this.tabPageLearnedActions.TabIndex = 3;
            this.tabPageLearnedActions.Text = "Learned Actions";
            this.tabPageLearnedActions.UseVisualStyleBackColor = true;
            // 
            // listViewLearnedActions
            // 
            this.listViewLearnedActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLearnedActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLearnedActions.FullRowSelect = true;
            this.listViewLearnedActions.GridLines = true;
            this.listViewLearnedActions.Location = new System.Drawing.Point(-1, 0);
            this.listViewLearnedActions.Name = "listViewLearnedActions";
            this.listViewLearnedActions.Size = new System.Drawing.Size(438, 203);
            this.listViewLearnedActions.TabIndex = 1;
            this.listViewLearnedActions.UseCompatibleStateImageBehavior = false;
            this.listViewLearnedActions.View = System.Windows.Forms.View.Details;
            this.listViewLearnedActions.DoubleClick += new System.EventHandler(this.listViewLearnedActions_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Slot";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.Width = 350;
            // 
            // tabPageLearnedSkills
            // 
            this.tabPageLearnedSkills.Controls.Add(this.listViewLearnedSkills);
            this.tabPageLearnedSkills.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearnedSkills.Name = "tabPageLearnedSkills";
            this.tabPageLearnedSkills.Size = new System.Drawing.Size(437, 203);
            this.tabPageLearnedSkills.TabIndex = 4;
            this.tabPageLearnedSkills.Text = "Learned Skills";
            this.tabPageLearnedSkills.UseVisualStyleBackColor = true;
            // 
            // listViewLearnedSkills
            // 
            this.listViewLearnedSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLearnedSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewLearnedSkills.FullRowSelect = true;
            this.listViewLearnedSkills.GridLines = true;
            this.listViewLearnedSkills.Location = new System.Drawing.Point(-1, 0);
            this.listViewLearnedSkills.Name = "listViewLearnedSkills";
            this.listViewLearnedSkills.Size = new System.Drawing.Size(438, 203);
            this.listViewLearnedSkills.TabIndex = 2;
            this.listViewLearnedSkills.UseCompatibleStateImageBehavior = false;
            this.listViewLearnedSkills.View = System.Windows.Forms.View.Details;
            this.listViewLearnedSkills.DoubleClick += new System.EventHandler(this.listViewLearnedSkills_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Slot";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Skill";
            this.columnHeader4.Width = 350;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(367, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(286, 232);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExport.Location = new System.Drawing.Point(5, 232);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonImport.Location = new System.Drawing.Point(86, 232);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // PalicoEditDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(451, 268);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlPalico);
            this.Name = "PalicoEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Palico Editor";
            this.Load += new System.EventHandler(this.PalicoEditDialog_Load);
            this.tabControlPalico.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnthusiasm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
            this.tabPageStyle.ResumeLayout(false);
            this.tabPageStyle.PerformLayout();
            this.tabPageEquippedActions.ResumeLayout(false);
            this.tabPageEquippedSkills.ResumeLayout(false);
            this.tabPageLearnedActions.ResumeLayout(false);
            this.tabPageLearnedSkills.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPalico;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageEquippedActions;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownXP;
        private System.Windows.Forms.Label labelXP;
        private System.Windows.Forms.NumericUpDown numericUpDownLevel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownEnthusiasm;
        private System.Windows.Forms.Label labelEnthusiasm;
        private System.Windows.Forms.Label labelForte;
        private System.Windows.Forms.ComboBox comboBoxForte;
        private System.Windows.Forms.NumericUpDown numericUpDownTarget;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.Label labelLearnedSkillRNG;
        private System.Windows.Forms.Label labelLearnedActionRNG;
        private System.Windows.Forms.ListView listViewEquippedAction;
        private System.Windows.Forms.ColumnHeader columnHeaderEqActionSlot;
        private System.Windows.Forms.ColumnHeader columnHeaderEqAction;
        private System.Windows.Forms.TabPage tabPageEquippedSkills;
        private System.Windows.Forms.ListView listViewEquippedSkills;
        private System.Windows.Forms.ColumnHeader columnHeaderEqSkillSlot;
        private System.Windows.Forms.ColumnHeader columnHeaderEqSkill;
        private System.Windows.Forms.TabPage tabPageLearnedActions;
        private System.Windows.Forms.TabPage tabPageLearnedSkills;
        private System.Windows.Forms.ListView listViewLearnedActions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewLearnedSkills;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBoxGreetings;
        private System.Windows.Forms.Label labelGretings;
        private System.Windows.Forms.TextBox textBoxPreviousOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameGiver;
        private System.Windows.Forms.Label labelNameGiver;
        private System.Windows.Forms.TextBox textBoxLearnedSkillRNG;
        private System.Windows.Forms.TextBox textBoxLearnedActionRNG;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TabPage tabPageStyle;
        private System.Windows.Forms.TextBox textBoxCoatRGBA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVestRGBA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRightEyeRGBA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLeftEyeRGBA;
        private System.Windows.Forms.Label label2;
    }
}