namespace ln_win
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBoxRelativeMode = new CheckBox();
            richTextBoxLogger = new RichTextBox();
            checkBoxSymbolic = new CheckBox();
            textBoxFile = new TextBox();
            buttonSelectFile = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonSelectWorkdir = new Button();
            label3 = new Label();
            textBoxWorkdir = new TextBox();
            checkBoxForce = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxRelativeMode
            // 
            checkBoxRelativeMode.AutoSize = true;
            checkBoxRelativeMode.Location = new Point(3, 47);
            checkBoxRelativeMode.Name = "checkBoxRelativeMode";
            checkBoxRelativeMode.Size = new Size(72, 21);
            checkBoxRelativeMode.TabIndex = 0;
            checkBoxRelativeMode.Text = "Relative";
            checkBoxRelativeMode.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLogger
            // 
            richTextBoxLogger.Dock = DockStyle.Bottom;
            richTextBoxLogger.Location = new Point(0, 224);
            richTextBoxLogger.Name = "richTextBoxLogger";
            richTextBoxLogger.Size = new Size(334, 97);
            richTextBoxLogger.TabIndex = 1;
            richTextBoxLogger.Text = "";
            // 
            // checkBoxSymbolic
            // 
            checkBoxSymbolic.AutoSize = true;
            checkBoxSymbolic.Checked = true;
            checkBoxSymbolic.CheckState = CheckState.Checked;
            checkBoxSymbolic.Location = new Point(3, 20);
            checkBoxSymbolic.Name = "checkBoxSymbolic";
            checkBoxSymbolic.Size = new Size(81, 21);
            checkBoxSymbolic.TabIndex = 0;
            checkBoxSymbolic.Text = "SYMLINK";
            checkBoxSymbolic.UseVisualStyleBackColor = true;
            // 
            // textBoxFile
            // 
            textBoxFile.Dock = DockStyle.Fill;
            textBoxFile.Location = new Point(3, 20);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(289, 23);
            textBoxFile.TabIndex = 2;
            // 
            // buttonSelectFile
            // 
            buttonSelectFile.Location = new Point(298, 20);
            buttonSelectFile.Name = "buttonSelectFile";
            buttonSelectFile.Size = new Size(33, 23);
            buttonSelectFile.TabIndex = 3;
            buttonSelectFile.Text = "...";
            buttonSelectFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(textBoxFile, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonSelectFile, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(334, 62);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(263, 17);
            label1.TabIndex = 4;
            label1.Text = "Input path, select path or drag path to here";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(checkBoxRelativeMode, 0, 3);
            tableLayoutPanel2.Controls.Add(checkBoxSymbolic, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(checkBoxForce, 0, 4);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 62);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(334, 100);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 17);
            label2.TabIndex = 3;
            label2.Text = "Arguments";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(buttonSelectWorkdir, 1, 1);
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(textBoxWorkdir, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 162);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(334, 62);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // buttonSelectWorkdir
            // 
            buttonSelectWorkdir.Location = new Point(298, 20);
            buttonSelectWorkdir.Name = "buttonSelectWorkdir";
            buttonSelectWorkdir.Size = new Size(33, 23);
            buttonSelectWorkdir.TabIndex = 3;
            buttonSelectWorkdir.Text = "...";
            buttonSelectWorkdir.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 4;
            label3.Text = "Workdir";
            // 
            // textBoxWorkdir
            // 
            textBoxWorkdir.Dock = DockStyle.Fill;
            textBoxWorkdir.Location = new Point(3, 20);
            textBoxWorkdir.Name = "textBoxWorkdir";
            textBoxWorkdir.Size = new Size(289, 23);
            textBoxWorkdir.TabIndex = 2;
            textBoxWorkdir.Text = "./";
            // 
            // checkBoxForce
            // 
            checkBoxForce.AutoSize = true;
            checkBoxForce.Location = new Point(3, 74);
            checkBoxForce.Name = "checkBoxForce";
            checkBoxForce.Size = new Size(268, 21);
            checkBoxForce.TabIndex = 4;
            checkBoxForce.Text = "Force recreate (excpet regular file/folder)";
            checkBoxForce.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 321);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(richTextBoxLogger);
            Name = "Main";
            Text = "ln_win";
            DragDrop += TextBoxFile_DragDrop;
            DragEnter += TextBoxFile_DragEnter;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox checkBoxRelativeMode;
        private RichTextBox richTextBoxLogger;
        private CheckBox checkBoxSymbolic;
        private TextBox textBoxFile;
        private Button buttonSelectFile;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxWorkdir;
        private Button buttonSelectWorkdir;
        private Label label3;
        private CheckBox checkBoxForce;
    }
}
