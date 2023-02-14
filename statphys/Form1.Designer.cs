namespace statphys
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label_mean = new System.Windows.Forms.Label();
            this.label_var = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.numericUpDownMean = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVar = new System.Windows.Forms.NumericUpDown();
            this.label_count = new System.Windows.Forms.Label();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.formsPlot4 = new ScottPlot.FormsPlot();
            this.ParametrLabel1 = new System.Windows.Forms.Label();
            this.ParametrLabel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.freqUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.formsPlot5 = new ScottPlot.FormsPlot();
            this.label_period = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(600, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Получить новое значение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(10, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1565, 230);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(600, 96);
            this.label1.MinimumSize = new System.Drawing.Size(400, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "x = 0 delta = 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(296, 470);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 45);
            this.button4.TabIndex = 5;
            this.button4.Text = "Запустить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_start_timer_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(296, 588);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 45);
            this.button5.TabIndex = 6;
            this.button5.Text = "Сбросить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_mean
            // 
            this.label_mean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_mean.AutoSize = true;
            this.label_mean.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_mean.Location = new System.Drawing.Point(18, 560);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(102, 25);
            this.label_mean.TabIndex = 7;
            this.label_mean.Text = "Mean = 0";
            this.label_mean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_var
            // 
            this.label_var.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_var.AutoSize = true;
            this.label_var.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_var.Location = new System.Drawing.Point(18, 590);
            this.label_var.Name = "label_var";
            this.label_var.Size = new System.Drawing.Size(133, 25);
            this.label_var.TabIndex = 8;
            this.label_var.Text = "Variance = 0";
            this.label_var.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(296, 530);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 45);
            this.button6.TabIndex = 9;
            this.button6.Text = "Остановить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_stop_timer_Click);
            // 
            // numericUpDownMean
            // 
            this.numericUpDownMean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownMean.DecimalPlaces = 1;
            this.numericUpDownMean.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownMean.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMean.Location = new System.Drawing.Point(296, 300);
            this.numericUpDownMean.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownMean.Name = "numericUpDownMean";
            this.numericUpDownMean.Size = new System.Drawing.Size(140, 32);
            this.numericUpDownMean.TabIndex = 10;
            this.numericUpDownMean.ThousandsSeparator = true;
            this.numericUpDownMean.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownMean.ValueChanged += new System.EventHandler(this.numericUpDownMean_ValueChanged);
            // 
            // numericUpDownVar
            // 
            this.numericUpDownVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownVar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownVar.Location = new System.Drawing.Point(296, 380);
            this.numericUpDownVar.Name = "numericUpDownVar";
            this.numericUpDownVar.Size = new System.Drawing.Size(140, 32);
            this.numericUpDownVar.TabIndex = 11;
            this.numericUpDownVar.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownVar.ValueChanged += new System.EventHandler(this.numericUpDownVar_ValueChanged);
            // 
            // label_count
            // 
            this.label_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_count.Location = new System.Drawing.Point(18, 650);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(105, 25);
            this.label_count.TabIndex = 12;
            this.label_count.Text = "Count = 0";
            this.label_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(1015, 260);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(560, 240);
            this.formsPlot1.TabIndex = 13;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formsPlot2.Location = new System.Drawing.Point(1015, 500);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(10);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(560, 240);
            this.formsPlot2.TabIndex = 14;
            // 
            // formsPlot4
            // 
            this.formsPlot4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.formsPlot4.Location = new System.Drawing.Point(450, 500);
            this.formsPlot4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot4.Name = "formsPlot4";
            this.formsPlot4.Size = new System.Drawing.Size(560, 240);
            this.formsPlot4.TabIndex = 16;
            // 
            // ParametrLabel1
            // 
            this.ParametrLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametrLabel1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ParametrLabel1.Location = new System.Drawing.Point(296, 260);
            this.ParametrLabel1.Name = "ParametrLabel1";
            this.ParametrLabel1.Size = new System.Drawing.Size(137, 32);
            this.ParametrLabel1.TabIndex = 17;
            this.ParametrLabel1.Text = "Параметр 1";
            // 
            // ParametrLabel2
            // 
            this.ParametrLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametrLabel2.AutoSize = true;
            this.ParametrLabel2.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ParametrLabel2.Location = new System.Drawing.Point(296, 340);
            this.ParametrLabel2.Name = "ParametrLabel2";
            this.ParametrLabel2.Size = new System.Drawing.Size(137, 31);
            this.ParametrLabel2.TabIndex = 18;
            this.ParametrLabel2.Text = "Параметр 2";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 530);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Статистика";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // freqUpDown
            // 
            this.freqUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.freqUpDown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.freqUpDown.Location = new System.Drawing.Point(18, 470);
            this.freqUpDown.Name = "freqUpDown";
            this.freqUpDown.Size = new System.Drawing.Size(120, 32);
            this.freqUpDown.TabIndex = 20;
            this.freqUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.freqUpDown.ValueChanged += new System.EventHandler(this.freqUpDownValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(18, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 30);
            this.label5.TabIndex = 21;
            this.label5.Text = "Замедление процесса";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 260);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 38);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(18, 702);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 38);
            this.button2.TabIndex = 23;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // formsPlot5
            // 
            this.formsPlot5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.formsPlot5.Location = new System.Drawing.Point(450, 260);
            this.formsPlot5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot5.Name = "formsPlot5";
            this.formsPlot5.Size = new System.Drawing.Size(560, 240);
            this.formsPlot5.TabIndex = 24;
            // 
            // label_period
            // 
            this.label_period.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_period.AutoSize = true;
            this.label_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_period.Location = new System.Drawing.Point(18, 620);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(70, 25);
            this.label_period.TabIndex = 26;
            this.label_period.Text = "label2";
            this.label_period.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.freqUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label_var);
            this.Controls.Add(this.label_mean);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ParametrLabel2);
            this.Controls.Add(this.ParametrLabel1);
            this.Controls.Add(this.numericUpDownVar);
            this.Controls.Add(this.numericUpDownMean);
            this.Controls.Add(this.label_period);
            this.Controls.Add(this.formsPlot5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.formsPlot4);
            this.Controls.Add(this.formsPlot2);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "statphys";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Button button4;
        private Button button5;
        private Label label_mean;
        private Label label_var;
        private Button button6;
        private NumericUpDown numericUpDownMean;
        private NumericUpDown numericUpDownVar;
        private Label label_count;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private ScottPlot.FormsPlot formsPlot4;
        private Label ParametrLabel1;
        private Label ParametrLabel2;
        private Label label4;
        private NumericUpDown freqUpDown;
        private Label label5;
        private ComboBox comboBox1;
        private Button button2;
        private ScottPlot.FormsPlot formsPlot5;
        private Label label_period;
    }
}