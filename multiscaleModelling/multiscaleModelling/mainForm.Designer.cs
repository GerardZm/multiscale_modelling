namespace multiscaleModelling
{
    partial class mainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microstructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xSizeTextbox = new System.Windows.Forms.NumericUpDown();
            this.ySizeTextbox = new System.Windows.Forms.NumericUpDown();
            this.nucleonAmmountTextbox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simulateButton = new System.Windows.Forms.Button();
            this.stepShowPanel = new System.Windows.Forms.Panel();
            this.firstStepButton = new System.Windows.Forms.Button();
            this.lastStepButton = new System.Windows.Forms.Button();
            this.previousStepButton = new System.Windows.Forms.Button();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.stepCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentStepLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.breakButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonAmmountTextbox)).BeginInit();
            this.stepShowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microstructureToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xSizeTextbox);
            this.panel1.Controls.Add(this.ySizeTextbox);
            this.panel1.Controls.Add(this.nucleonAmmountTextbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(214, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 92);
            this.panel1.TabIndex = 2;
            // 
            // xSizeTextbox
            // 
            this.xSizeTextbox.Location = new System.Drawing.Point(7, 21);
            this.xSizeTextbox.Name = "xSizeTextbox";
            this.xSizeTextbox.Size = new System.Drawing.Size(42, 20);
            this.xSizeTextbox.TabIndex = 1;
            // 
            // ySizeTextbox
            // 
            this.ySizeTextbox.Location = new System.Drawing.Point(73, 21);
            this.ySizeTextbox.Name = "ySizeTextbox";
            this.ySizeTextbox.Size = new System.Drawing.Size(42, 20);
            this.ySizeTextbox.TabIndex = 2;
            // 
            // nucleonAmmountTextbox
            // 
            this.nucleonAmmountTextbox.Location = new System.Drawing.Point(7, 63);
            this.nucleonAmmountTextbox.Name = "nucleonAmmountTextbox";
            this.nucleonAmmountTextbox.Size = new System.Drawing.Size(108, 20);
            this.nucleonAmmountTextbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nucleon ammount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columns (x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rows (y)";
            // 
            // simulateButton
            // 
            this.simulateButton.Location = new System.Drawing.Point(343, 28);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(95, 48);
            this.simulateButton.TabIndex = 4;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.UseVisualStyleBackColor = true;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // stepShowPanel
            // 
            this.stepShowPanel.Controls.Add(this.firstStepButton);
            this.stepShowPanel.Controls.Add(this.lastStepButton);
            this.stepShowPanel.Controls.Add(this.previousStepButton);
            this.stepShowPanel.Controls.Add(this.nextStepButton);
            this.stepShowPanel.Controls.Add(this.stepCountLabel);
            this.stepShowPanel.Controls.Add(this.label6);
            this.stepShowPanel.Controls.Add(this.currentStepLabel);
            this.stepShowPanel.Controls.Add(this.label4);
            this.stepShowPanel.Location = new System.Drawing.Point(13, 201);
            this.stepShowPanel.Name = "stepShowPanel";
            this.stepShowPanel.Size = new System.Drawing.Size(240, 26);
            this.stepShowPanel.TabIndex = 4;
            this.stepShowPanel.Visible = false;
            // 
            // firstStepButton
            // 
            this.firstStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstStepButton.Location = new System.Drawing.Point(131, 1);
            this.firstStepButton.Name = "firstStepButton";
            this.firstStepButton.Size = new System.Drawing.Size(23, 23);
            this.firstStepButton.TabIndex = 6;
            this.firstStepButton.Text = "<<";
            this.firstStepButton.UseVisualStyleBackColor = true;
            this.firstStepButton.Click += new System.EventHandler(this.firstStepButton_Click);
            // 
            // lastStepButton
            // 
            this.lastStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lastStepButton.Location = new System.Drawing.Point(214, 1);
            this.lastStepButton.Name = "lastStepButton";
            this.lastStepButton.Size = new System.Drawing.Size(23, 23);
            this.lastStepButton.TabIndex = 9;
            this.lastStepButton.Text = ">>";
            this.lastStepButton.UseVisualStyleBackColor = true;
            this.lastStepButton.Click += new System.EventHandler(this.lastStepButton_Click);
            // 
            // previousStepButton
            // 
            this.previousStepButton.Location = new System.Drawing.Point(159, 1);
            this.previousStepButton.Name = "previousStepButton";
            this.previousStepButton.Size = new System.Drawing.Size(23, 23);
            this.previousStepButton.TabIndex = 7;
            this.previousStepButton.Text = "<";
            this.previousStepButton.UseVisualStyleBackColor = true;
            this.previousStepButton.Click += new System.EventHandler(this.previousStepButton_Click);
            // 
            // nextStepButton
            // 
            this.nextStepButton.Location = new System.Drawing.Point(188, 1);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(23, 23);
            this.nextStepButton.TabIndex = 8;
            this.nextStepButton.Text = ">";
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // stepCountLabel
            // 
            this.stepCountLabel.AutoSize = true;
            this.stepCountLabel.Location = new System.Drawing.Point(87, 4);
            this.stepCountLabel.Name = "stepCountLabel";
            this.stepCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stepCountLabel.Size = new System.Drawing.Size(13, 13);
            this.stepCountLabel.TabIndex = 3;
            this.stepCountLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "/";
            // 
            // currentStepLabel
            // 
            this.currentStepLabel.Location = new System.Drawing.Point(39, 4);
            this.currentStepLabel.Name = "currentStepLabel";
            this.currentStepLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentStepLabel.Size = new System.Drawing.Size(31, 13);
            this.currentStepLabel.TabIndex = 1;
            this.currentStepLabel.Text = "0";
            this.currentStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Step";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(337, 2);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // breakButton
            // 
            this.breakButton.Enabled = false;
            this.breakButton.Location = new System.Drawing.Point(343, 82);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(95, 38);
            this.breakButton.TabIndex = 5;
            this.breakButton.Text = "Break";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 237);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.stepShowPanel);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Multiscale modelling";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonAmmountTextbox)).EndInit();
            this.stepShowPanel.ResumeLayout(false);
            this.stepShowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microstructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nucleonAmmountTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.NumericUpDown xSizeTextbox;
        private System.Windows.Forms.NumericUpDown ySizeTextbox;
        private System.Windows.Forms.Panel stepShowPanel;
        private System.Windows.Forms.Button previousStepButton;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.Label stepCountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentStepLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button firstStepButton;
        private System.Windows.Forms.Button lastStepButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button breakButton;
    }
}

