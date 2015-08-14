namespace PfxBruteForce.UI.Views
{
    partial class MainForm
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
            this.certificatePath = new System.Windows.Forms.TextBox();
            this.go = new System.Windows.Forms.Button();
            this.footer = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.checksPerSecondsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.elapsedDurationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.current = new System.Windows.Forms.Label();
            this.minChar = new System.Windows.Forms.NumericUpDown();
            this.maxChar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dictionaryUrl = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.selectFile = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // certificatePath
            // 
            this.certificatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.certificatePath.Location = new System.Drawing.Point(3, 3);
            this.certificatePath.Name = "certificatePath";
            this.certificatePath.ReadOnly = true;
            this.certificatePath.Size = new System.Drawing.Size(766, 20);
            this.certificatePath.TabIndex = 0;
            this.certificatePath.Text = "TestKeys/key-01.p12";
            // 
            // go
            // 
            this.go.Dock = System.Windows.Forms.DockStyle.Top;
            this.go.Location = new System.Drawing.Point(0, 88);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(853, 63);
            this.go.TabIndex = 1;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // footer
            // 
            this.footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.checksPerSecondsLabel,
            this.toolStripStatusLabel3,
            this.elapsedDurationLabel,
            this.toolStripStatusLabel5});
            this.footer.Location = new System.Drawing.Point(0, 413);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(853, 22);
            this.footer.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(140, 17);
            this.statusLabel.Text = "Waiting";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checksPerSecondsLabel
            // 
            this.checksPerSecondsLabel.AutoSize = false;
            this.checksPerSecondsLabel.Name = "checksPerSecondsLabel";
            this.checksPerSecondsLabel.Size = new System.Drawing.Size(70, 17);
            this.checksPerSecondsLabel.Text = "0";
            this.checksPerSecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel3.Text = "checks per seconds";
            // 
            // elapsedDurationLabel
            // 
            this.elapsedDurationLabel.AutoSize = false;
            this.elapsedDurationLabel.Name = "elapsedDurationLabel";
            this.elapsedDurationLabel.Size = new System.Drawing.Size(90, 17);
            this.elapsedDurationLabel.Text = "0";
            this.elapsedDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel5.Text = "seconds";
            // 
            // current
            // 
            this.current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.current.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current.Location = new System.Drawing.Point(0, 151);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(853, 262);
            this.current.TabIndex = 3;
            this.current.Text = "xyz";
            this.current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minChar
            // 
            this.minChar.Location = new System.Drawing.Point(93, 16);
            this.minChar.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minChar.Name = "minChar";
            this.minChar.Size = new System.Drawing.Size(72, 20);
            this.minChar.TabIndex = 4;
            this.minChar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // maxChar
            // 
            this.maxChar.Location = new System.Drawing.Point(171, 16);
            this.maxChar.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxChar.Name = "maxChar";
            this.maxChar.Size = new System.Drawing.Size(72, 20);
            this.maxChar.TabIndex = 4;
            this.maxChar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password length";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maxChar);
            this.groupBox1.Controls.Add(this.minChar);
            this.groupBox1.Location = new System.Drawing.Point(3, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enumerator";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dictionaryUrl);
            this.groupBox2.Location = new System.Drawing.Point(262, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dictionary Based";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dictionary";
            // 
            // dictionaryUrl
            // 
            this.dictionaryUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryUrl.Location = new System.Drawing.Point(96, 15);
            this.dictionaryUrl.Name = "dictionaryUrl";
            this.dictionaryUrl.Size = new System.Drawing.Size(486, 20);
            this.dictionaryUrl.TabIndex = 0;
            this.dictionaryUrl.Text = "http://manitra.net/wp-content/uploads/2015/07/pwd.txt.gz";
            // 
            // selectFile
            // 
            this.selectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFile.Location = new System.Drawing.Point(775, 3);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(75, 23);
            this.selectFile.TabIndex = 1;
            this.selectFile.Text = "Select File";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.certificatePath);
            this.panel1.Controls.Add(this.selectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 88);
            this.panel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AcceptButton = this.go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 435);
            this.Controls.Add(this.current);
            this.Controls.Add(this.go);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.footer);
            this.Name = "MainForm";
            this.Text = "Password Cracker";
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox certificatePath;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.StatusStrip footer;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label current;
        private System.Windows.Forms.ToolStripStatusLabel checksPerSecondsLabel;
        private System.Windows.Forms.NumericUpDown minChar;
        private System.Windows.Forms.NumericUpDown maxChar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dictionaryUrl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel elapsedDurationLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button selectFile;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Panel panel1;
    }
}

