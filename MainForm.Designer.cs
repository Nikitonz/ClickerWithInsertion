namespace WinFormsApp1
{
    partial class MainForm
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
            statusStrip1 = new StatusStrip();
            status = new ToolStripStatusLabel();
            btnStartRecording = new Button();
            btnReplay = new Button();
            loadCSV = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label2 = new Label();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { status });
            statusStrip1.Location = new Point(0, 49);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(354, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            status.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top;
            status.BorderStyle = Border3DStyle.Sunken;
            status.MergeAction = MergeAction.Replace;
            status.Name = "status";
            status.Size = new Size(4, 17);
            // 
            // btnStartRecording
            // 
            btnStartRecording.Location = new Point(0, -1);
            btnStartRecording.Name = "btnStartRecording";
            btnStartRecording.Size = new Size(75, 23);
            btnStartRecording.TabIndex = 5;
            btnStartRecording.Text = "rec/stop sequ";
            btnStartRecording.TextAlign = ContentAlignment.TopLeft;
            btnStartRecording.TextImageRelation = TextImageRelation.TextAboveImage;
            btnStartRecording.UseVisualStyleBackColor = true;
            btnStartRecording.Click += btnStartRecording_Click;
            // 
            // btnReplay
            // 
            btnReplay.Location = new Point(0, 21);
            btnReplay.Name = "btnReplay";
            btnReplay.Size = new Size(75, 23);
            btnReplay.TabIndex = 6;
            btnReplay.Text = "replay";
            btnReplay.UseVisualStyleBackColor = true;
            btnReplay.Click += btnReplay_Click;
            // 
            // loadCSV
            // 
            loadCSV.Location = new Point(12, 13);
            loadCSV.Name = "loadCSV";
            loadCSV.Size = new Size(75, 23);
            loadCSV.TabIndex = 7;
            loadCSV.Text = "loadCSV";
            loadCSV.UseVisualStyleBackColor = true;
            loadCSV.Click += loadCSV_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(15, 23);
            textBox1.TabIndex = 8;
            textBox1.Text = ",";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 10);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 9;
            label1.Text = "delimeter";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(loadCSV);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(81, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 45);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "dataFile";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(0, 17);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 12;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(228, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(19, 23);
            textBox2.TabIndex = 11;
            textBox2.Text = "3";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Cursor = Cursors.Help;
            label2.ImageAlign = ContentAlignment.TopLeft;
            label2.Location = new Point(87, 26);
            label2.Name = "label2";
            label2.Size = new Size(180, 15);
            label2.TabIndex = 10;
            label2.Text = "Wait for server's responce       sec";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 71);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(btnReplay);
            Controls.Add(btnStartRecording);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MainForm";
            Text = "Form1";
            TopMost = true;
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel status;
        private Button btnStartRecording;
        private Button btnReplay;
        private Button loadCSV;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox2;
        private CheckBox checkBox1;
    }
}
