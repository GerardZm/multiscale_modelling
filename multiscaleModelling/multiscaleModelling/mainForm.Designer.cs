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
            this.label12 = new System.Windows.Forms.Label();
            this.structureSelect = new System.Windows.Forms.ComboBox();
            this.grainBoundaryShapeControlPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grainBoundaryShapeControlTextbox = new System.Windows.Forms.NumericUpDown();
            this.grainBoundaryShapeControlCheckbox = new System.Windows.Forms.CheckBox();
            this.precipitatesPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.squareShapeRadio = new System.Windows.Forms.RadioButton();
            this.circleShapeRadio = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.precipitatesRadiusToTextbox = new System.Windows.Forms.NumericUpDown();
            this.precipitatesRadiusToLabel = new System.Windows.Forms.Label();
            this.precipitatesRadiusFromLabel = new System.Windows.Forms.Label();
            this.precipitatesRadiusFromTextbox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPositionRadio = new System.Windows.Forms.RadioButton();
            this.randomPositionRadio = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.precipitatesTextbox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.xSizeTextbox = new System.Windows.Forms.NumericUpDown();
            this.ySizeTextbox = new System.Windows.Forms.NumericUpDown();
            this.nucleonAmmountTextbox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simulateButton = new System.Windows.Forms.Button();
            this.stepShowPanel = new System.Windows.Forms.Panel();
            this.stepSlider = new System.Windows.Forms.TrackBar();
            this.stepCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentStepLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.breakButton = new System.Windows.Forms.Button();
            this.markBoundriesCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.grainBoundaryShapeControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grainBoundaryShapeControlTextbox)).BeginInit();
            this.precipitatesPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesRadiusToTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesRadiusFromTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonAmmountTextbox)).BeginInit();
            this.stepShowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
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
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.microstructureToolStripMenuItem.Text = "Microstructure";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
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
            this.panel1.Controls.Add(this.markBoundriesCheckbox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.structureSelect);
            this.panel1.Controls.Add(this.grainBoundaryShapeControlPanel);
            this.panel1.Controls.Add(this.grainBoundaryShapeControlCheckbox);
            this.panel1.Controls.Add(this.precipitatesPanel);
            this.panel1.Controls.Add(this.precipitatesTextbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.xSizeTextbox);
            this.panel1.Controls.Add(this.ySizeTextbox);
            this.panel1.Controls.Add(this.nucleonAmmountTextbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(280, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 327);
            this.panel1.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Structure:";
            // 
            // structureSelect
            // 
            this.structureSelect.FormattingEnabled = true;
            this.structureSelect.Items.AddRange(new object[] {
            "",
            "Substructure",
            "Dual phrase"});
            this.structureSelect.Location = new System.Drawing.Point(124, 87);
            this.structureSelect.Name = "structureSelect";
            this.structureSelect.Size = new System.Drawing.Size(180, 21);
            this.structureSelect.TabIndex = 10;
            // 
            // grainBoundaryShapeControlPanel
            // 
            this.grainBoundaryShapeControlPanel.Controls.Add(this.label11);
            this.grainBoundaryShapeControlPanel.Controls.Add(this.label10);
            this.grainBoundaryShapeControlPanel.Controls.Add(this.grainBoundaryShapeControlTextbox);
            this.grainBoundaryShapeControlPanel.Location = new System.Drawing.Point(124, 27);
            this.grainBoundaryShapeControlPanel.Name = "grainBoundaryShapeControlPanel";
            this.grainBoundaryShapeControlPanel.Size = new System.Drawing.Size(180, 33);
            this.grainBoundaryShapeControlPanel.TabIndex = 9;
            this.grainBoundaryShapeControlPanel.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Probability for rule 4:";
            // 
            // grainBoundaryShapeControlTextbox
            // 
            this.grainBoundaryShapeControlTextbox.Location = new System.Drawing.Point(108, 6);
            this.grainBoundaryShapeControlTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.grainBoundaryShapeControlTextbox.Name = "grainBoundaryShapeControlTextbox";
            this.grainBoundaryShapeControlTextbox.Size = new System.Drawing.Size(42, 20);
            this.grainBoundaryShapeControlTextbox.TabIndex = 10;
            this.grainBoundaryShapeControlTextbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grainBoundaryShapeControlCheckbox
            // 
            this.grainBoundaryShapeControlCheckbox.AutoSize = true;
            this.grainBoundaryShapeControlCheckbox.Location = new System.Drawing.Point(124, 4);
            this.grainBoundaryShapeControlCheckbox.Name = "grainBoundaryShapeControlCheckbox";
            this.grainBoundaryShapeControlCheckbox.Size = new System.Drawing.Size(185, 17);
            this.grainBoundaryShapeControlCheckbox.TabIndex = 8;
            this.grainBoundaryShapeControlCheckbox.Text = "Use grain boundary shape control";
            this.grainBoundaryShapeControlCheckbox.UseVisualStyleBackColor = true;
            this.grainBoundaryShapeControlCheckbox.CheckedChanged += new System.EventHandler(this.grainBoundaryShapeControlCheckbox_CheckedChanged);
            // 
            // precipitatesPanel
            // 
            this.precipitatesPanel.Controls.Add(this.panel2);
            this.precipitatesPanel.Controls.Add(this.precipitatesRadiusToTextbox);
            this.precipitatesPanel.Controls.Add(this.precipitatesRadiusToLabel);
            this.precipitatesPanel.Controls.Add(this.precipitatesRadiusFromLabel);
            this.precipitatesPanel.Controls.Add(this.precipitatesRadiusFromTextbox);
            this.precipitatesPanel.Controls.Add(this.label8);
            this.precipitatesPanel.Controls.Add(this.gbPositionRadio);
            this.precipitatesPanel.Controls.Add(this.randomPositionRadio);
            this.precipitatesPanel.Controls.Add(this.label7);
            this.precipitatesPanel.Location = new System.Drawing.Point(7, 115);
            this.precipitatesPanel.Name = "precipitatesPanel";
            this.precipitatesPanel.Size = new System.Drawing.Size(107, 204);
            this.precipitatesPanel.TabIndex = 7;
            this.precipitatesPanel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.squareShapeRadio);
            this.panel2.Controls.Add(this.circleShapeRadio);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(3, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 65);
            this.panel2.TabIndex = 18;
            // 
            // squareShapeRadio
            // 
            this.squareShapeRadio.AutoSize = true;
            this.squareShapeRadio.Location = new System.Drawing.Point(5, 43);
            this.squareShapeRadio.Name = "squareShapeRadio";
            this.squareShapeRadio.Size = new System.Drawing.Size(59, 17);
            this.squareShapeRadio.TabIndex = 20;
            this.squareShapeRadio.TabStop = true;
            this.squareShapeRadio.Text = "Square";
            this.squareShapeRadio.UseVisualStyleBackColor = true;
            // 
            // circleShapeRadio
            // 
            this.circleShapeRadio.AutoSize = true;
            this.circleShapeRadio.Checked = true;
            this.circleShapeRadio.Location = new System.Drawing.Point(5, 19);
            this.circleShapeRadio.Name = "circleShapeRadio";
            this.circleShapeRadio.Size = new System.Drawing.Size(51, 17);
            this.circleShapeRadio.TabIndex = 19;
            this.circleShapeRadio.TabStop = true;
            this.circleShapeRadio.Text = "Circle";
            this.circleShapeRadio.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Precipitates shape:";
            // 
            // precipitatesRadiusToTextbox
            // 
            this.precipitatesRadiusToTextbox.Location = new System.Drawing.Point(56, 178);
            this.precipitatesRadiusToTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precipitatesRadiusToTextbox.Name = "precipitatesRadiusToTextbox";
            this.precipitatesRadiusToTextbox.Size = new System.Drawing.Size(42, 20);
            this.precipitatesRadiusToTextbox.TabIndex = 14;
            this.precipitatesRadiusToTextbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precipitatesRadiusToTextbox.ValueChanged += new System.EventHandler(this.precipitatesRadiusToTextbox_ValueChanged);
            // 
            // precipitatesRadiusToLabel
            // 
            this.precipitatesRadiusToLabel.AutoSize = true;
            this.precipitatesRadiusToLabel.Location = new System.Drawing.Point(59, 162);
            this.precipitatesRadiusToLabel.Name = "precipitatesRadiusToLabel";
            this.precipitatesRadiusToLabel.Size = new System.Drawing.Size(23, 13);
            this.precipitatesRadiusToLabel.TabIndex = 13;
            this.precipitatesRadiusToLabel.Text = "To:";
            // 
            // precipitatesRadiusFromLabel
            // 
            this.precipitatesRadiusFromLabel.AutoSize = true;
            this.precipitatesRadiusFromLabel.Location = new System.Drawing.Point(9, 162);
            this.precipitatesRadiusFromLabel.Name = "precipitatesRadiusFromLabel";
            this.precipitatesRadiusFromLabel.Size = new System.Drawing.Size(33, 13);
            this.precipitatesRadiusFromLabel.TabIndex = 12;
            this.precipitatesRadiusFromLabel.Text = "From:";
            // 
            // precipitatesRadiusFromTextbox
            // 
            this.precipitatesRadiusFromTextbox.Location = new System.Drawing.Point(7, 178);
            this.precipitatesRadiusFromTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precipitatesRadiusFromTextbox.Name = "precipitatesRadiusFromTextbox";
            this.precipitatesRadiusFromTextbox.Size = new System.Drawing.Size(42, 20);
            this.precipitatesRadiusFromTextbox.TabIndex = 8;
            this.precipitatesRadiusFromTextbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precipitatesRadiusFromTextbox.ValueChanged += new System.EventHandler(this.precipiratesRadiusFromTextbox_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Precipitates radius:";
            // 
            // gbPositionRadio
            // 
            this.gbPositionRadio.AutoSize = true;
            this.gbPositionRadio.Location = new System.Drawing.Point(4, 44);
            this.gbPositionRadio.Name = "gbPositionRadio";
            this.gbPositionRadio.Size = new System.Drawing.Size(97, 17);
            this.gbPositionRadio.TabIndex = 10;
            this.gbPositionRadio.TabStop = true;
            this.gbPositionRadio.Text = "Grain boundary";
            this.gbPositionRadio.UseVisualStyleBackColor = true;
            // 
            // randomPositionRadio
            // 
            this.randomPositionRadio.AutoSize = true;
            this.randomPositionRadio.Checked = true;
            this.randomPositionRadio.Location = new System.Drawing.Point(4, 20);
            this.randomPositionRadio.Name = "randomPositionRadio";
            this.randomPositionRadio.Size = new System.Drawing.Size(65, 17);
            this.randomPositionRadio.TabIndex = 9;
            this.randomPositionRadio.TabStop = true;
            this.randomPositionRadio.Text = "Random";
            this.randomPositionRadio.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Precipitates position:";
            // 
            // precipitatesTextbox
            // 
            this.precipitatesTextbox.Location = new System.Drawing.Point(67, 88);
            this.precipitatesTextbox.Name = "precipitatesTextbox";
            this.precipitatesTextbox.Size = new System.Drawing.Size(48, 20);
            this.precipitatesTextbox.TabIndex = 6;
            this.precipitatesTextbox.ValueChanged += new System.EventHandler(this.precipitatesTextbox_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precipitates";
            // 
            // xSizeTextbox
            // 
            this.xSizeTextbox.Location = new System.Drawing.Point(7, 21);
            this.xSizeTextbox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.xSizeTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xSizeTextbox.Name = "xSizeTextbox";
            this.xSizeTextbox.Size = new System.Drawing.Size(42, 20);
            this.xSizeTextbox.TabIndex = 1;
            this.xSizeTextbox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ySizeTextbox
            // 
            this.ySizeTextbox.Location = new System.Drawing.Point(73, 21);
            this.ySizeTextbox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ySizeTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ySizeTextbox.Name = "ySizeTextbox";
            this.ySizeTextbox.Size = new System.Drawing.Size(42, 20);
            this.ySizeTextbox.TabIndex = 2;
            this.ySizeTextbox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nucleonAmmountTextbox
            // 
            this.nucleonAmmountTextbox.Location = new System.Drawing.Point(7, 63);
            this.nucleonAmmountTextbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nucleonAmmountTextbox.Name = "nucleonAmmountTextbox";
            this.nucleonAmmountTextbox.Size = new System.Drawing.Size(108, 20);
            this.nucleonAmmountTextbox.TabIndex = 3;
            this.nucleonAmmountTextbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.simulateButton.Location = new System.Drawing.Point(213, 28);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(61, 48);
            this.simulateButton.TabIndex = 4;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.UseVisualStyleBackColor = true;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // stepShowPanel
            // 
            this.stepShowPanel.Controls.Add(this.stepSlider);
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
            // stepSlider
            // 
            this.stepSlider.Location = new System.Drawing.Point(124, 3);
            this.stepSlider.Minimum = 1;
            this.stepSlider.Name = "stepSlider";
            this.stepSlider.Size = new System.Drawing.Size(113, 45);
            this.stepSlider.TabIndex = 10;
            this.stepSlider.Value = 1;
            this.stepSlider.Scroll += new System.EventHandler(this.stepSlider_Scroll);
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
            this.progressBar.Location = new System.Drawing.Point(302, 1);
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
            this.breakButton.Location = new System.Drawing.Point(213, 82);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(61, 38);
            this.breakButton.TabIndex = 5;
            this.breakButton.Text = "Break";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            // 
            // markBoundriesCheckbox
            // 
            this.markBoundriesCheckbox.AutoSize = true;
            this.markBoundriesCheckbox.Location = new System.Drawing.Point(124, 118);
            this.markBoundriesCheckbox.Name = "markBoundriesCheckbox";
            this.markBoundriesCheckbox.Size = new System.Drawing.Size(99, 17);
            this.markBoundriesCheckbox.TabIndex = 14;
            this.markBoundriesCheckbox.Text = "Mark boundries";
            this.markBoundriesCheckbox.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 358);
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
            this.grainBoundaryShapeControlPanel.ResumeLayout(false);
            this.grainBoundaryShapeControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grainBoundaryShapeControlTextbox)).EndInit();
            this.precipitatesPanel.ResumeLayout(false);
            this.precipitatesPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesRadiusToTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesRadiusFromTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precipitatesTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonAmmountTextbox)).EndInit();
            this.stepShowPanel.ResumeLayout(false);
            this.stepShowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSlider)).EndInit();
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
        private System.Windows.Forms.Label stepCountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentStepLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.Panel precipitatesPanel;
        private System.Windows.Forms.NumericUpDown precipitatesTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton gbPositionRadio;
        private System.Windows.Forms.RadioButton randomPositionRadio;
        private System.Windows.Forms.NumericUpDown precipitatesRadiusToTextbox;
        private System.Windows.Forms.Label precipitatesRadiusToLabel;
        private System.Windows.Forms.Label precipitatesRadiusFromLabel;
        private System.Windows.Forms.NumericUpDown precipitatesRadiusFromTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar stepSlider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton squareShapeRadio;
        private System.Windows.Forms.RadioButton circleShapeRadio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel grainBoundaryShapeControlPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown grainBoundaryShapeControlTextbox;
        private System.Windows.Forms.CheckBox grainBoundaryShapeControlCheckbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox structureSelect;
        private System.Windows.Forms.CheckBox markBoundriesCheckbox;
    }
}

