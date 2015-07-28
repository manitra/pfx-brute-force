namespace WindowsFormsApplication1
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minChar = new System.Windows.Forms.NumericUpDown();
            this.maxChar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dictionaryUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // certificatePath
            // 
            this.certificatePath.Location = new System.Drawing.Point(12, 12);
            this.certificatePath.Name = "certificatePath";
            this.certificatePath.Size = new System.Drawing.Size(361, 20);
            this.certificatePath.TabIndex = 0;
            this.certificatePath.Text = "TestKeys/key-01.p12";
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(392, 9);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 1;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // footer
            // 
            this.footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.footer.Location = new System.Drawing.Point(0, 251);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(605, 22);
            this.footer.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Waiting";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Result:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "...";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enumerator";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dictionaryUrl);
            this.groupBox2.Location = new System.Drawing.Point(272, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 104);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dictionary Based";
            // 
            // dictionaryUrl
            // 
            this.dictionaryUrl.Location = new System.Drawing.Point(96, 15);
            this.dictionaryUrl.Name = "dictionaryUrl";
            this.dictionaryUrl.Size = new System.Drawing.Size(224, 20);
            this.dictionaryUrl.TabIndex = 0;
            this.dictionaryUrl.Text = "http://manitra.net/wp-content/uploads/2015/07/pwd.txt.gz";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.go);
            this.Controls.Add(this.certificatePath);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox certificatePath;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.StatusStrip footer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.NumericUpDown minChar;
        private System.Windows.Forms.NumericUpDown maxChar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dictionaryUrl;
    }
}

