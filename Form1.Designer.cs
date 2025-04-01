namespace HexColourSlider
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trackBar0 = new TrackBar();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox0 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            numericUpDown0 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label6 = new Label();
            textBox0 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)trackBar0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            SuspendLayout();
            // 
            // trackBar0
            // 
            trackBar0.LargeChange = 1;
            trackBar0.Location = new Point(61, 70);
            trackBar0.Maximum = 2147483647;
            trackBar0.Name = "trackBar0";
            trackBar0.Size = new Size(401, 45);
            trackBar0.TabIndex = 3;
            trackBar0.Scroll += calculate;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(61, 155);
            trackBar1.Maximum = 2147483647;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(401, 45);
            trackBar1.TabIndex = 4;
            trackBar1.Scroll += calculate;
            // 
            // trackBar2
            // 
            trackBar2.LargeChange = 1;
            trackBar2.Location = new Point(61, 242);
            trackBar2.Maximum = 2147483647;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(401, 45);
            trackBar2.TabIndex = 5;
            trackBar2.Scroll += calculate;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Black;
            pictureBox3.Location = new Point(61, 293);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(401, 50);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 70);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 7;
            label1.Text = "Red";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 155);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 8;
            label2.Text = "Green";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 242);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 9;
            label3.Text = "Blue";
            // 
            // pictureBox0
            // 
            pictureBox0.BackColor = Color.Black;
            pictureBox0.Location = new Point(468, 41);
            pictureBox0.Name = "pictureBox0";
            pictureBox0.Size = new Size(50, 50);
            pictureBox0.TabIndex = 10;
            pictureBox0.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(468, 126);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Black;
            pictureBox2.Location = new Point(468, 213);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 9);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 13;
            label4.Text = "Range";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(148, 41);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(125, 23);
            textBox3.TabIndex = 14;
            textBox3.Text = "00 00 00 00";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(148, 126);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(125, 23);
            textBox4.TabIndex = 15;
            textBox4.Text = "00 00 00 00";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(148, 213);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(125, 23);
            textBox5.TabIndex = 16;
            textBox5.Text = "00 00 00 00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(164, 9);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 17;
            label5.Text = "HEX (float32)";
            // 
            // numericUpDown0
            // 
            numericUpDown0.Location = new Point(61, 41);
            numericUpDown0.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            numericUpDown0.Name = "numericUpDown0";
            numericUpDown0.Size = new Size(81, 23);
            numericUpDown0.TabIndex = 18;
            numericUpDown0.ValueChanged += calculate;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(61, 126);
            numericUpDown1.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(81, 23);
            numericUpDown1.TabIndex = 19;
            numericUpDown1.ValueChanged += calculate;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(61, 213);
            numericUpDown2.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(81, 23);
            numericUpDown2.TabIndex = 20;
            numericUpDown2.ValueChanged += calculate;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 293);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 21;
            label6.Text = "Colour";
            // 
            // textBox0
            // 
            textBox0.Location = new Point(279, 41);
            textBox0.Name = "textBox0";
            textBox0.ReadOnly = true;
            textBox0.Size = new Size(80, 23);
            textBox0.TabIndex = 22;
            textBox0.Text = "0";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 126);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(80, 23);
            textBox1.TabIndex = 23;
            textBox1.Text = "0";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(279, 213);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(80, 23);
            textBox2.TabIndex = 24;
            textBox2.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(284, 9);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 25;
            label7.Text = "Float";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(364, 9);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 26;
            label8.Text = "RGB";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(365, 41);
            numericUpDown3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(62, 23);
            numericUpDown3.TabIndex = 27;
            numericUpDown3.ValueChanged += calculate;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(365, 126);
            numericUpDown4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(62, 23);
            numericUpDown4.TabIndex = 28;
            numericUpDown4.ValueChanged += calculate;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(365, 214);
            numericUpDown5.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(62, 23);
            numericUpDown5.TabIndex = 29;
            numericUpDown5.ValueChanged += calculate;
            // 
            // button1
            // 
            button1.Location = new Point(443, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 30;
            button1.Text = "R3D Finder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += R3D_Click;
            // 
            // button2
            // 
            button2.Location = new Point(443, 377);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 30;
            button2.Text = "Patch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += patch_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(10, 355);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(75, 19);
            radioButton1.TabIndex = 31;
            radioButton1.Text = "Dialog Text";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Checked = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(95, 355);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(75, 19);
            radioButton2.TabIndex = 31;
            radioButton2.Text = "Button Border";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(195, 355);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(75, 19);
            radioButton3.TabIndex = 31;
            radioButton3.Text = "Status Effects";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(290, 355);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(75, 19);
            radioButton4.TabIndex = 31;
            radioButton4.Text = "Text Highlight";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(390, 355);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(75, 19);
            radioButton5.TabIndex = 31;
            radioButton5.Text = "Patch All";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 410);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton3);
            Controls.Add(radioButton4);
            Controls.Add(radioButton5);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(textBox0);
            Controls.Add(label6);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(numericUpDown0);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox0);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(trackBar0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Colour Code Previewer";
            ((System.ComponentModel.ISupportInitialize)trackBar0).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox0).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown0).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar trackBar0;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox0;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label5;
        private NumericUpDown numericUpDown0;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label6;
        private TextBox textBox0;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label7;
        private Label label8;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Button button1;
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
    }
}
